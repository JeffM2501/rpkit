// HTTPServer.cpp : Defines the entry point for the DLL application.
//

#include "utils.h"
#include "HTTPServer.h"
#include <algorithm>
#include <sstream>
#include <time.h>

#define FORCE_CLOSE false

typedef std::map<std::string,BZFSHTTP*> VirtualDirs;

VirtualDirs virtualDirs;

bool registered = false;
int lastRequestID = 1;


bool RegisterVDir(BZFSHTTP* handler)
{
  if (!handler)
    return false;

  std::string name = handler->getVDir();
  if (!name.size())
    return false;

  if (virtualDirs.find(name) != virtualDirs.end())
    return false;

  virtualDirs[name] = handler;
  return true;
}

bool RemoveVDir(BZFSHTTP *handler)
{
  if (!handler)
    return false;

  std::string name = handler->getVDir();
  if (!name.size())
    return false;

  if (virtualDirs.find(name) == virtualDirs.end())
    return false;

  virtualDirs.erase(virtualDirs.find(name));
  return true;
}

int generateSessionID(void)
{
  short s[2];
  s[0] = rand();
  s[1] = rand();

  return *((int*)s);
}

class HTTPConnection
{
public:
  HTTPConnection() : connectionID(-1),
		     requestComplete(false),
		     headerComplete(false),
		     contentSize(0),
		     bodyEnd(0),
		     request(eUnknown),
		     sessionID(0) {};

  void flush(void)
  {
    body = "";
    contentSize = 0;
    bodyEnd = 0;
    headerComplete = false;
    requestComplete = false;
    request = eUnknown;
    vdir = "";
    resource = "";
    host = "";
    header.clear();
  }

  void update(void);

  int connectionID;

  // the current request as we process it
  std::string currentData;
  std::string body;
  size_t      contentSize;
  size_t      bodyEnd;
  bool	      headerComplete;
  bool	      requestComplete;

  int sessionID;

  HTTPRequestType   request;
  std::string	    vdir;
  std::string	    resource;
  std::string	    host;
  std::map<std::string, std::string> header;

  void fillRequest(HTTPRequest &req);

  class HTTPTask
  {
  public:
    HTTPTask(HTTPReply& r, bool noBody);
    HTTPTask(const HTTPTask& t);

    virtual ~HTTPTask (void){};

    void generateBody (HTTPReply& r, bool noBody);

    bool update(int connectionID);

    std::string page;
    size_t pos;
  };

  class PendingHTTPTask : public HTTPTask
  {
  public:
    PendingHTTPTask(HTTPReply& r, HTTPRequest &rq, bool noBody): HTTPTask(r,noBody), request(rq), reply(r){};
    HTTPRequest request;
    HTTPReply reply;
  };

  std::vector<HTTPTask> processingTasks;  // tasks working
  std::vector<PendingHTTPTask> pendingTasks;	  // tasks waiting
};

typedef std::map<int,HTTPConnection> HTTPConnectionMap;

class HTTPServer
{
public:
  HTTPServer();
  virtual ~HTTPServer();

  // network connections
  void connect(int connectionID, void *d, unsigned int s);
  void pending(int connectionID, void *d, unsigned int s);
  void disconnect(int connectionID);

  // tick update
  void update(void);

protected:

  void processRequest(HTTPRequest &request, int connectionID);

  HTTPConnectionMap liveConnections;

  std::string baseURL;

private:
  void send100Continue(int connectionID);
  void send403Error(int connectionID);
  void send404Error(int connectionID);
  void send501Error(int connectionID);
  void sendOptions(int connectionID, bool p);

  void generateIndex(int connectionID, const HTTPRequest &request);
  void generatePage(BZFSHTTP* vdir, int connectionID, HTTPRequest &request);
};

HTTPServer *server = NULL;

// some statics for speed
std::string serverVersion;
std::string serverHostname;


HTTPServer::HTTPServer( const char * host, int port )
{
  baseURL = "http://";
  serverHostname = "localhost";
  if (host)
    serverHostname = host;

  // make sure it has the port
  if (strrchr(serverHostname.c_str(),':') == NULL)
    serverHostname += format(":%d",port);

  baseURL += serverHostname +"/";
}

HTTPServer::~HTTPServer()
{

}

void HTTPServer::connect(int connectionID, void *d, unsigned int s);
{

    // we go an accept everyone so that we can see if they are going to give us an HTTP command
      // record the connection
      HTTPConnection connection;
      connection.connectionID = connectionID;
      connection.request = eUnknown;
      connection.sessionID = generateSessionID();  // new ID in case they don't have one

      HTTPConnectionMap::iterator itr = liveConnections.find(connection.connectionID);

      if (itr != liveConnections.end())
	liveConnections.erase(itr);	// something weird is happening here

      liveConnections[connection.connectionID] = connection;

      // go and process any data they have and see what the deal is
      pendingsconnectionID, d, d);
    }
}

void HTTPServer::pending(int connectionID, void *d, unsigned int s)
{
  HTTPConnectionMap::iterator itr = liveConnections.find(connectionID);

  if (itr == liveConnections.end())
    return;

  HTTPConnection &connection = itr->second;

  // grab the current data
  if(d && s) {
    char *t = (char*)malloc(s+1);
    memcpy(t,d,s);
    t[s] = 0;
    connection.currentData += t;
    free(t);
  }

  // see what our status is
  if (!connection.request) {
    std::stringstream stream(connection.currentData);

    std::string request, resource, httpVersion;
    stream >> request >> resource >> httpVersion;

    if (request.size() && resource.size() && httpVersion.size()) {
      if (compare_nocase(request,"get") == 0)
	connection.request = eGet;
      else if (compare_nocase(request,"head") == 0)
	connection.request = eHead;
      else if (compare_nocase(request,"post") == 0)
	connection.request = ePost;
      else if (compare_nocase(request,"put") == 0)
	connection.request = ePut;
      else if (compare_nocase(request,"delete") == 0)
	connection.request = eDelete;
      else if (compare_nocase(request,"trace") == 0)
	connection.request = eTrace;
      else if (compare_nocase(request,"options") == 0)
	connection.request = eOptions;
      else if (compare_nocase(request,"connect") == 0)
	connection.request = eConnect;
      else
	connection.request = eOther;

      if (httpVersion != "HTTP/1.1" && httpVersion != "HTTP/1.0")
	bz_debugMessagef(1,"HTTPServer HTTP version of %s requested",httpVersion.c_str());

      if (resource.size() > 1) {
	size_t p = resource.find_first_of('/');
	if (p != std::string::npos) {
	  if (p == 0)
	    p = resource.find_first_of('/',p+1);

	  if (p == std::string::npos) {
	    // there is only one / so the stuff after the slash in the vdir and the resource is NULL
	    connection.vdir.resize(resource.size()-1);
	    std::copy(resource.begin()+1,resource.end(),connection.vdir.begin());
	  } else {
	    connection.vdir.resize(p-1);
	    std::copy(resource.begin()+1,resource.begin()+p,connection.vdir.begin());

	    connection.resource.resize(resource.size()-p-1);
	    std::copy(resource.begin()+p+1,resource.end(),connection.resource.begin());
	  }
	}
      }
    }
  }

  if (connection.request) {
    // we know the type, so we can get the rest of the data or bail out
    if (!connection.requestComplete &&
	(connection.request == ePost || connection.request == ePut)) // if the request is a post, tell the client to send us the rest of the body
      send100Continue(connectionID);

    size_t headerEnd = find_first_substr(connection.currentData,"\r\n\r\n");

    std::string temp = connection.currentData.c_str()+headerEnd;

    if (!connection.headerComplete && headerEnd != std::string::npos) {
      bool done = false;  // ok we have the header and we don't haven't processed it yet

      // read past the command
      size_t p = find_first_substr(connection.currentData,"\r\n");
      p+= 2;

      while (p < headerEnd) {
	size_t p2 = find_first_substr(connection.currentData,"\r\n",p);

	std::string line;
	line.resize(p2-p);
	std::copy(connection.currentData.begin()+p,connection.currentData.begin()+p2,line.begin());
	p = p2+2;

	trimLeadingWhitespace(line);
	std::vector<std::string> headerLine = tokenize(line,":",2,false);
	if (headerLine.size() > 1) {
	  std::string &key = headerLine[0];
	  trimLeadingWhitespace(headerLine[1]);
	  if (compare_nocase(key,"Host") == 0)
	    connection.host = line.c_str()+key.size()+2;
	  else if (compare_nocase(key,"Content-Length") == 0)
	    connection.contentSize = (size_t)atoi(headerLine[1].c_str());
	  else
	    connection.header[key] = headerLine[1];
	}
      }
      connection.headerComplete = true;
    }

    if (connection.headerComplete && !connection.requestComplete) {
      connection.bodyEnd = headerEnd+4;

      if (connection.request != ePost && connection.request != ePut) {
	connection.requestComplete = true; // there is nothing after the header we care about
      } else {
	if (connection.contentSize) {
	  headerEnd += 4;
	  if (connection.currentData.size()-headerEnd >= connection.contentSize) {
	    // read in that body!
	    connection.body.resize(connection.currentData.size()-headerEnd);
	    std::copy(connection.currentData.begin()+headerEnd,connection.currentData.end(),connection.body.end());
	    connection.requestComplete = true;

	    connection.bodyEnd += connection.contentSize;
	  }
	}
	else
	  connection.requestComplete = true;
      }
    }
  }

  if (connection.requestComplete) {
    // special, if it's a trace, just fire it back to them
    if (connection.request == eTrace) {
      bz_sendNonPlayerData(connectionID, connection.currentData.c_str(),(unsigned int)connection.bodyEnd);

      std::string nubby = connection.currentData.c_str()+connection.bodyEnd;
      connection.currentData = nubby;
      connection.flush();
    } else {
      // parse it all UP and build up a complete request
      std::string nubby = connection.currentData.c_str()+connection.bodyEnd;
      connection.currentData = nubby;

      HTTPRequest request;
      connection.fillRequest(request);
      // rip off what we need for the request, and then flush
      processRequest(request,connectionID);
      connection.flush();
    }

    // if there are lines to read
    if (connection.currentData.size() && find_first_substr(connection.currentData,"\r\n") != std::string::npos)
      pending(connectionID,NULL,0);
  }
}

void HTTPServer::disconnect(int connectionID)
{
  HTTPConnectionMap::iterator itr = liveConnections.find(connectionID);

  if (itr != liveConnections.end())
    liveConnections.erase(itr);
}

void HTTPServer::update(void)
{
  HTTPConnectionMap::iterator itr = liveConnections.begin();

  while (itr != liveConnections.end()) {
    itr->second.update();
    itr++;
  }

  if (liveConnections.size())
    bz_setMaxWaitTime(0.01f,"HTTPServer");
  else
    bz_clearMaxWaitTime("HTTPServer");
}

void HTTPServer::generateIndex(int connectionID, const HTTPRequest &request)
{
  HTTPConnectionMap::iterator itr = liveConnections.find(connectionID);

  if (itr == liveConnections.end())
    return;

  HTTPConnection &connection = itr->second;

  HTTPReply reply;

  reply.docType = HTTPReply::eHTML;
  reply.returnCode = HTTPReply::e200OK;
  reply.body = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\"><html><head><title>Index page for " + baseURL + "</title></head>";
  reply.body += "<body>";

  VirtualDirs::iterator dirItr = virtualDirs.begin();

  while (dirItr != virtualDirs.end()) {
    std::string vdirName = dirItr->second->getVDir();
    std::string vDirDescription = dirItr->second->getDescription();
    reply.body += "<a href=\"/" + vdirName + "/\">" + vdirName +"</a>&nbsp;" +vDirDescription +"<br>";
    dirItr++;
  }

  reply.body += "</body></html>";

  connection.processingTasks.push_back(HTTPConnection::HTTPTask(reply,request.request == eHead));
  connection.update();
}

void HTTPServer::generatePage(BZFSHTTP* vdir, int connectionID, HTTPRequest &request)
{
  HTTPConnectionMap::iterator itr = liveConnections.find(connectionID);

  if (itr == liveConnections.end())
    return;

  HTTPConnection &connection = itr->second;

  HTTPReply reply;

  request.baseURL = baseURL;
  request.baseURL += vdir->getVDir();
  request.baseURL += "/";
  request.requestID = lastRequestID++;
  request.sessionID = connection.sessionID;

  if (vdir->handleRequest(request,reply)) {
    reply.cookies["SessionID"] = format("%d",request.sessionID);
    connection.processingTasks.push_back(HTTPConnection::HTTPTask(reply,request.request == eHead));
  } else {
    connection.pendingTasks.push_back(HTTPConnection::PendingHTTPTask(reply,request,request.request == eHead));
  }

  connection.update();
}

void HTTPServer::processRequest(HTTPRequest &request, int connectionID)
{
  // check the request to see if it'll have any thing we care to process

  // find the vdir handler

  BZFSHTTP *vdir = NULL;

  VirtualDirs::iterator itr = virtualDirs.find(request.vdir);

  if (itr != virtualDirs.end())
    vdir = itr->second;

  switch(request.request) {
  case ePut:
    if (!vdir || !vdir->supportPut())	{
      send403Error(connectionID);
      break;
    }
  case eHead:
  case eGet:
  case ePost:
    if(!vdir)
      generateIndex(connectionID,request);
    else
      generatePage(vdir,connectionID,request);
    break;

  case eOptions:
    sendOptions(connectionID, vdir ? vdir->supportPut() : false);
    break;

  case eDelete:
  case eConnect:
    send501Error(connectionID);
    break;
  }
}

void HTTPServer::send100Continue(int connectionID)
{
  std::string httpHeaders;
  httpHeaders += "HTTP/1.1 100 Continue\n\n";

  bz_sendNonPlayerData(connectionID, httpHeaders.c_str(), (unsigned int)httpHeaders.size());
}

void HTTPServer::send403Error(int connectionID)
{
  std::string httpHeaders;
  httpHeaders += "HTTP/1.1 403 Forbidden\n\n";

  bz_sendNonPlayerData(connectionID, httpHeaders.c_str(), (unsigned int)httpHeaders.size());
}

void HTTPServer::send404Error(int connectionID)
{
  std::string httpHeaders;
  httpHeaders += "HTTP/1.1 404 Not Found\n\n";

  bz_sendNonPlayerData(connectionID, httpHeaders.c_str(), (unsigned int)httpHeaders.size());
}

void HTTPServer::send501Error(int connectionID)
{
  std::string httpHeaders;
  httpHeaders += "HTTP/1.1 501 Not Implemented\n\n";

  bz_sendNonPlayerData(connectionID, httpHeaders.c_str(), (unsigned int)httpHeaders.size());
}

void HTTPServer::sendOptions(int connectionID, bool p)
{
  std::string httpHeaders;
  httpHeaders += "HTTP/1.1 200 Ok\n";
  httpHeaders += "Allow: GET, HEAD, POST, OPTIONS";
  if (p)
    httpHeaders += ", PUT";
  httpHeaders += "\n\n";

  bz_sendNonPlayerData(connectionID, httpHeaders.c_str(), (unsigned int)httpHeaders.size());
}

void parseParams(std::map<std::string, std::vector<std::string> > &params, const std::string &text, size_t offset)
{
  std::vector<std::string> items = tokenize(text,"&",0,false,offset);

  for (size_t i = 0; i < items.size(); i++)
    {
      std::string &item = items[i];

      std::string key,val;

      std::vector<std::string> t = tokenize(item,"=",0,false);
      if (t.size() > 1) {
	key = t[0];
	val = t[1];
      } else {
	key = item;
	val = "";
      }

      if (params.find(key) == params.end()) {
	std::vector<std::string> tv;
	params[key] = tv;
      }
      params[key].push_back(val);

    }
}

void HTTPConnection::fillRequest(HTTPRequest &req)
{
  req.request = request;
  req.vdir = url_decode(vdir);
  req.resource = url_decode(resource);
  req.headers = header;
  req.cookies.clear();

  req.ip = bz_getNonPlayerConnectionIP(connectionID);
  req.hostmask = bz_getNonPlayerConnectionHost(connectionID);

  // parse the headers here for cookies
  std::map<std::string,std::string>::iterator itr = req.headers.begin();

  while (itr != req.headers.end()) {
    const std::string &key = itr->first;
    if (compare_nocase(key,"cookie") == 0) {
      std::vector<std::string> cookie = tokenize(itr->second,"=",2,false);

      if (cookie.size() > 1) {
	req.cookies[cookie[0]] = cookie[1];

	// check for the magic sessionID cookie
	if (compare_nocase(cookie[0],"sessionid") == 0)
	  sessionID = atoi(cookie[1].c_str());
      }
    } else if (compare_nocase(key,"authorization") == 0) {
      std::vector<std::string> auth = tokenize(itr->second," ",2,false);

      if (auth.size() > 1) {
	req.authType = auth[0];
	req.authCredentials = auth[1];

	if (compare_nocase(auth[0],"basic") == 0 && auth[1].size()) {
	  std::string b64 = base64_decode(auth[1]);
	  std::vector<std::string> uandp = tokenize(b64,":",2,false);
	  if (uandp.size() == 2) {
	    req.username = uandp[0];
	    req.password = uandp[1];
	  }
	}
      }
    }

    itr++;
  }

  if (req.request != ePost) {
    // parse out the parameters from the resource
    size_t q = req.resource.find_first_of('?');
    if (q != std::string::npos)
    {
      parseParams(req.parameters,req.resource,q+1);
      req.resource.erase(req.resource.begin()+q,req.resource.end());
    }
  }

  if (req.request == ePost && contentSize > 0)
    parseParams(req.parameters,body,0);
  else if (req.request == ePut &&contentSize > 0)
    req.body = body;
}

void HTTPConnection::update(void)
{
  // hit the processings
  std::vector<size_t> killList;

  for (size_t i = 0; i < processingTasks.size(); i++) {
    if (processingTasks[i].update(connectionID))
      killList.push_back(i);
  }

  std::vector<size_t>::reverse_iterator itr = killList.rbegin();
  while (itr != killList.rend()) {
    size_t offset = *itr;
    processingTasks.erase(processingTasks.begin()+offset);
    itr++;
  }

  // check the pending to see if they should be restarted
  std::vector<PendingHTTPTask>::iterator pendingItr = pendingTasks.begin();
  while (pendingTasks.size() && pendingItr != pendingTasks.end()) {
    PendingHTTPTask &pendingTask = *pendingItr;

    BZFSHTTP *vdir = NULL;

    VirtualDirs::iterator itr = virtualDirs.find(pendingTask.request.vdir);

    if (itr != virtualDirs.end())
      vdir = itr->second;

    if (!vdir) {
      std::vector<PendingHTTPTask>::iterator t = pendingItr;
      t++;
      pendingTasks.erase(pendingItr);
      pendingItr = t;
    } else {
      if (vdir->resumeTask(pendingTask.request.requestID)) {
	if (vdir->handleRequest(pendingTask.request,pendingTask.reply)) {
	  // if it is done and fire if off
	  pendingTask.reply.cookies["SessionID"] = format("%d",pendingTask.request.sessionID);
	  pendingTask.generateBody(pendingTask.reply,pendingTask.request.request == eHead);
	  processingTasks.push_back(HTTPTask(pendingTask));

	  std::vector<PendingHTTPTask>::iterator t = pendingItr;
	  t++;
	  pendingTasks.erase(pendingItr);
	  pendingItr = t;
	} else {
	  pendingItr++;
	}
      } else {
	pendingItr++;
      }
    }
  }
}

const char* getMimeType(HTTPReply::DocumentType docType)
{
  switch(docType) {
  case HTTPReply::eOctetStream:
    return "application/octet-stream";

  case HTTPReply::eBinary:
    return "application/binary";

  case HTTPReply::eHTML:
    return "text/html";

  default:
    break;
  }
  return "text/plain";
}

HTTPConnection::HTTPTask::HTTPTask(HTTPReply& r, bool noBody):pos(0)
{
  generateBody(r,noBody);
}

void HTTPConnection::HTTPTask::generateBody (HTTPReply& r, bool noBody)
{
  // start a new one
  page = "HTTP/1.1";

  switch(r.returnCode) {
  case HTTPReply::e200OK:
    page += " 200 OK\n";
    break;

  case HTTPReply::e301Redirect:
    if (r.redirectLoc.size()) {
      page += " 301 Moved Permanently\n";
      page += "Location: " + r.redirectLoc + "\n";
    } else {
      page += " 500 Server Error\n";
    }
    break;

  case HTTPReply::e500ServerError:
    page += " 500 Server Error\n";
    break;

  case HTTPReply::e401Unauthorized:
    page += " 401 Unauthorized\n";
    page += "WWW-Authenticate: ";

    if (r.authType.size())
      page += r.authType;
    else
      page += "Basic";

    page += " realm=\"";
    if (r.authRealm.size())
      page += r.authRealm;
    else
      page += serverHostname;
    page += "\"\n";
    break;

  case HTTPReply::e404NotFound:
    page += " 404 Not Found\n";
    break;

  case HTTPReply::e403Forbiden:
    page += " 403 Forbidden\n";
    break;
  }

  if (r.returnCode != HTTPReply::e200OK)
    page += "Connection: close\n";
  else if (FORCE_CLOSE)
    page += "Connection: close\n";

  if (r.body.size()) {
    page += format("Content-Length: %d\n", r.body.size());

    page += "Content-Type: ";
    if (r.docType == HTTPReply::eOther && r.otherMimeType.size())
      page += r.otherMimeType;
    else
      page += getMimeType(r.docType);
    page += "\n";
  }

  // write the cache info
  if(r.forceNoCache)
    page += "Cache-Control: no-cache\n";

  if (r.md5.size())
    page += "Content-MD5: " + r.md5 + "\n";

  // dump the basic stat block
  page += "Server: " + serverVersion + "\n";

  bz_Time ts;
  bz_getUTCtime (&ts);
  page += "Date: ";
  appendTime(page,&ts,"UTC");
  page += "\n";

  // dump the headers
  std::map<std::string,std::string>::iterator itr = r.headers.begin();

  while (itr != r.headers.end()) {
    page += itr->first + ": " + itr->second = "\n";
    itr++;
  }

  if (r.returnCode == HTTPReply::e200OK) {
    itr = r.cookies.begin();
    while (itr != r.cookies.end()) {
      page += "Set-Cookie: " +itr->first + "=" + itr->second + "\n";
      itr++;
    }
  }

  page += "\n";

  if (!noBody && r.body.size())
    page += r.body;
}

HTTPConnection::HTTPTask::HTTPTask(const HTTPTask& t)
{
  page = t.page;
  pos = t.pos;
}

bool HTTPConnection::HTTPTask::update(int connectionID)
{
  // find out how much to write
  if (pos >= page.size())
    return true;

  // only send out another message if the buffer is nearing being empty, so we don't flood it out and
  // waste a lot of extra memory.
  int pendingMessages =  bz_getNonPlayerConnectionOutboundPacketCount(connectionID);
  if (pendingMessages > 1)
    return false;

  size_t write = page.size();
  size_t left = write-pos;

  if (left > 1000)
    write = pos + 1000;

  if (!bz_sendNonPlayerData (connectionID, page.c_str()+pos, (unsigned int)write))
    return true;

  pos += write;

  return pos >= page.size();
}


std::string BZFSHTTP::getBaseURL ( void )
{
  std::string URL = "http://";
  std::string host = "localhost";
  if (bz_getPublicAddr().size())
    host = bz_getPublicAddr().c_str();

  // make sure it has the port
  if ( strrchr(host.c_str(),':') == NULL )
    host += format(":%d",bz_getPublicPort());

  URL += host +"/";
  URL += getVDir();
  URL += "/";

  return URL;
}

bool HTTPRequest::getParam ( const char* param, std::string &val ) const
{
  val = "";
  if (!param)
    return false;

  std::string p;
  tolower(param,p);

  std::map<std::string, std::vector<std::string> >::const_iterator itr = parameters.find(p);
  if ( itr != parameters.end() )
  {
    if (itr->second.size())
      val = itr->second[itr->second.size()-1];
    return true;
  } 
  return false;
}

bool HTTPRequest::getParam ( const std::string &param, std::string &val ) const
{
  val = "";

  std::string p;
  tolower(param,p);

  std::map<std::string, std::vector<std::string> >::const_iterator itr = parameters.find(p);
  if ( itr != parameters.end() )
  {
    if (itr->second.size())
      val = itr->second[itr->second.size()-1];
    return true;
  } 
  return false;
}

bool HTTPRequest::getParam ( const char* param, std::vector<std::string> &val ) const
{
  val.clear();
  if (!param)
    return false;

  std::string p;
  tolower(param,p);

  std::map<std::string, std::vector<std::string> >::const_iterator itr = parameters.find(p);
  if ( itr != parameters.end() )
  {
    val = itr->second;
    return true;
  } 
  return false;
}

bool HTTPRequest::getParam ( const std::string &param, std::vector<std::string> &val ) const
{
  val.clear();

  std::string p;
  tolower(param,p);

  std::map<std::string, std::vector<std::string> >::const_iterator itr = parameters.find(p);
  if ( itr != parameters.end() )
  {
    val = itr->second;
    return true;
  } 
  return false;
}

Templateiser::Templateiser()
{
  startTimer();
  setDefaultTokens();
}

Templateiser::~Templateiser()
{

}

void Templateiser::startTimer ( void )
{
  startTime = bz_getCurrentTime();
}

void Templateiser::addKey ( const char *key, TemplateKeyCallback callback )
{
  if (!key || !callback)
    return;

  std::string k;
  tolower(key,k);

  keyFuncCallbacks[k] = callback;
  ClassMap::iterator itr = keyClassCallbacks.find(k);
  if (itr != keyClassCallbacks.end())
    keyClassCallbacks.erase(itr);
}

void Templateiser::addKey ( const char *key, TemplateCallbackClass *callback )
{
  if (!key || !callback)
    return;

  std::string k;
  tolower(key,k);

  keyClassCallbacks[k] = callback;
  KeyMap::iterator itr = keyFuncCallbacks.find(k);
  if (itr != keyFuncCallbacks.end())
    keyFuncCallbacks.erase(itr);
}

void Templateiser::clearKey ( const char *key )
{
  std::string k;
  tolower(key,k);

  ClassMap::iterator itr = keyClassCallbacks.find(k);
  if (itr != keyClassCallbacks.end())
    keyClassCallbacks.erase(itr);

  KeyMap::iterator itr2 = keyFuncCallbacks.find(k);
  if (itr2 != keyFuncCallbacks.end())
    keyFuncCallbacks.erase(itr2);
}

void Templateiser::flushKeys ( void )
{
  keyClassCallbacks.clear();
  keyFuncCallbacks.clear();
}

void Templateiser::addLoop ( const char *loop, TemplateTestCallback callback )
{
  if (!loop || !callback)
    return;

  std::string l;
  tolower(loop,l);

  loopFuncCallbacks[l] = callback;
  ClassMap::iterator itr = loopClassCallbacks.find(l);
  if (itr != loopClassCallbacks.end())
    loopClassCallbacks.erase(itr);
}

void Templateiser::addLoop ( const char *loop, TemplateCallbackClass *callback )
{
  if (!loop || !callback)
    return;

  std::string l;
  tolower(loop,l);

  loopClassCallbacks[l] = callback;
  TestMap::iterator itr = loopFuncCallbacks.find(l);
  if (itr != loopFuncCallbacks.end())
    loopFuncCallbacks.erase(itr);
}

void Templateiser::clearLoop ( const char *loop )
{
  if (!loop)
    return;

  std::string l;
  tolower(loop,l);

  TestMap::iterator itr = loopFuncCallbacks.find(l);
  if (itr != loopFuncCallbacks.end())
    loopFuncCallbacks.erase(itr);

  ClassMap::iterator itr2 = loopClassCallbacks.find(l);
  if (itr2 != loopClassCallbacks.end())
    loopClassCallbacks.erase(itr2);
}

void Templateiser::flushLoops ( void )
{
  loopClassCallbacks.clear();
  loopFuncCallbacks.clear();
}

void Templateiser::addIF ( const char *name, TemplateTestCallback callback )
{
  if (!name || !callback)
    return;

  std::string n;
  tolower(name,n);

  ifFuncCallbacks[n] = callback;
  ClassMap::iterator itr = ifClassCallbacks.find(n);
  if (itr != ifClassCallbacks.end())
    ifClassCallbacks.erase(itr);
}

void Templateiser::addIF ( const char *name, TemplateCallbackClass *callback )
{
  if (!name || !callback)
    return;

  std::string n;
  tolower(name,n);

  ifClassCallbacks[n] = callback;
  TestMap::iterator itr = ifFuncCallbacks.find(n);
  if (itr != ifFuncCallbacks.end())
    ifFuncCallbacks.erase(itr);
}

void Templateiser::clearIF ( const char *name )
{
  if(!name)
    return;

  std::string n;
  tolower(name,n);

  ClassMap::iterator itr = ifClassCallbacks.find(n);
  if (itr != ifClassCallbacks.end())
    ifClassCallbacks.erase(itr);

  TestMap::iterator itr2 = ifFuncCallbacks.find(n);
  if (itr2 != ifFuncCallbacks.end())
    ifFuncCallbacks.erase(itr2);
}

void Templateiser::flushIFs ( void )
{
  ifClassCallbacks.clear();
  ifFuncCallbacks.clear();
}

bool Templateiser::callKey ( std::string &data, const std::string &key )
{
  std::string lowerKey;
  tolower(key,lowerKey);

  data.clear();

  ClassMap::iterator itr = keyClassCallbacks.find(lowerKey);
  if (itr != keyClassCallbacks.end()) {
    itr->second->keyCallback(data,key);
    return true;
  }

  KeyMap::iterator itr2 = keyFuncCallbacks.find(lowerKey);
  if (itr2 != keyFuncCallbacks.end()) {
    (itr2->second)(data,key);
    return true;
  }

  return false;
}

bool Templateiser::callLoop ( const std::string &key )
{
  std::string lowerKey;
  tolower(key,lowerKey);

  ClassMap::iterator itr = loopClassCallbacks.find(lowerKey);
  if (itr != loopClassCallbacks.end())
    return itr->second->loopCallback(key);

  TestMap::iterator itr2 = loopFuncCallbacks.find(lowerKey);
  if (itr2 != loopFuncCallbacks.end())
    return (itr2->second)(key);

  return false;
}

bool Templateiser::callIF ( const std::string &key )
{
  std::string lowerKey;
  tolower(key,lowerKey);

  ClassMap::iterator itr = ifClassCallbacks.find(lowerKey);
  if (itr != ifClassCallbacks.end())
    return itr->second->ifCallback(key);

  TestMap::iterator itr2 = ifFuncCallbacks.find(lowerKey);
  if (itr2 != ifFuncCallbacks.end())
    return (itr2->second)(key);

  return false;
}

bool Templateiser::processTemplateFile ( std::string &code, const char *file )
{
  if (!file)
    return false;

  // find the file
  for (size_t i = 0; i < filePaths.size(); i++ ) {
    std::string path = filePaths[i] + file;
    FILE *fp = fopen(getPathForOS(path).c_str(),"rb");
    if (fp) {
      fseek(fp,0,SEEK_END);
      size_t pos = ftell(fp);
      fseek(fp,0,SEEK_SET);
      char *temp = (char*)malloc(pos+1);
      fread(temp,pos,1,fp);
      temp[pos] = 0;

      std::string val(temp);
      free(temp);
      fclose(fp);

      processTemplate(code,val);
      return true;
    }
  }
  return false;
}


void Templateiser::processTemplate ( std::string &code, const std::string &templateText )
{
  std::string::const_iterator templateItr = templateText.begin();

  while ( templateItr != templateText.end() ) {
    if ( *templateItr != '[' ) {
      code += *templateItr;
      templateItr++;
    } else {
      templateItr++;

      if (templateItr == templateText.end()) {
	code += '[';
      } else {
	switch(*templateItr) {
	default: // it's not a code, so just let the next loop hit it and output it
	  break;

	case '$':
	  replaceVar(code,++templateItr,templateText);
	  break;

	case '*':
	  processLoop(code,++templateItr,templateText);
	  break;

	case '?':
	  processIF(code,++templateItr,templateText);
	  break;
	case '-':
	  processComment(code,++templateItr,templateText);
	  break;
	case '!':
	  processInclude(code,++templateItr,templateText);
	  break;
	}
      }
    }
  }
}

void Templateiser::setPluginName ( const char* name, const char* URL )
{
  if (name)
    pluginName = name;

  if (URL)
    baseURL = URL;
}

void Templateiser::addSearchPath ( const char* path )
{
  if (path)
    filePaths.push_back(std::string(path));
}

void Templateiser::flushSearchPaths ( void )
{
  filePaths.clear();
}

void Templateiser::setDefaultTokens ( void )
{
}

void Templateiser::keyCallback ( std::string &data, const std::string &key )
{
}

bool Templateiser::loopCallback ( const std::string & /* key */ )
{
  return false;
}

bool Templateiser::ifCallback ( const std::string &key )
{
  return false;
}

// processing helpers

std::string::const_iterator Templateiser::readKey ( std::string &key, std::string::const_iterator inItr, const std::string &str )
{
  std::string::const_iterator itr = inItr;

  while ( itr != str.end() ) {
    if (*itr != ']') {
      key += *itr;
      itr++;
    } else {
      // go past the code
      itr++;
      makelower(key);
      return itr;
    }
  }
  return itr;
}

std::string::const_iterator Templateiser::findNextTag ( const std::vector<std::string> &keys, std::string &endKey, std::string &code, std::string::const_iterator inItr, const std::string &str )
{
  if (!keys.size())
    return inItr;

  std::string::const_iterator itr = inItr;

  while (1) {
    itr = std::find(itr,str.end(),'[');
    if (itr == str.end())
      return itr;

    // save off the itr in case this is the one, so we can copy to this point
    std::string::const_iterator keyStartItr = itr;

    itr++;
    if (itr == str.end())
      return itr;

    std::string key;
    itr = readKey(key,itr,str);

    for ( size_t i = 0; i < keys.size(); i++ ) {
      if ( key == keys[i]) {
	endKey = key;
	code.resize(keyStartItr - inItr);
	std::copy(inItr,keyStartItr,code.begin());
	return itr;
      }
    }
  }
  return itr;
}

void Templateiser::processComment ( std::string & /* code */, std::string::const_iterator &inItr, const std::string &str )
{
  std::string key;
  inItr = readKey(key,inItr,str);
}

void Templateiser::processInclude ( std::string &code, std::string::const_iterator &inItr, const std::string &str )
{
  std::string key;
  inItr = readKey(key,inItr,str);

  // check the search paths for the include file
  if (!processTemplateFile(code,key.c_str()))
    code += "[!" + key + "]";
}

void Templateiser::replaceVar ( std::string &code, std::string::const_iterator &itr, const std::string &str )
{
  // find the end of the ]]
  std::string key;

  itr = readKey(key,itr,str);

  if (itr != str.end()) {
    std::string lowerKey;
    std::string val;

    tolower(key,lowerKey);

    if (callKey(val,lowerKey))
      code += val;
    else
      code += "[$"+key+"]";
  }
}

void Templateiser::processLoop ( std::string &code, std::string::const_iterator &inItr, const std::string &str )
{
  std::string key;

  // read the rest of the key
  std::string::const_iterator itr = readKey(key,inItr,str);

  std::vector<std::string> commandParts = tokenize(key,std::string(" "),0,0);
  if (commandParts.size() < 2) {
    inItr = itr;
    return;
  }

  // check the params
  makelower(commandParts[0]);
  makelower(commandParts[1]);

  if ( commandParts[0] != "start" ) {
    inItr = itr;
    return;
  }

  // now get the code for the loop section section
  std::string loopSection,emptySection;

  std::vector<std::string> checkKeys;
  checkKeys.push_back(format("*end %s",commandParts[1].c_str()));

  std::string keyFound;
  itr = findNextTag(checkKeys,keyFound,loopSection,itr,str);

  if (itr == str.end()) {
    inItr = itr;
    return;
  }

  // do the empty section
  // loops have to have both
  checkKeys.clear();
  checkKeys.push_back(format("*empty %s",commandParts[1].c_str()));
  itr = findNextTag(checkKeys,keyFound,emptySection,itr,str);

  if (callLoop(commandParts[1])) {
    std::string newCode;
    processTemplate(newCode,loopSection);
    code += newCode;

    while(callLoop(commandParts[1])) {
      newCode = "";
      processTemplate(newCode,loopSection);
      code += newCode;
    }
  } else {
    std::string newCode;
    processTemplate(newCode,emptySection);
    code += newCode;
  }
  inItr = itr;
}

void Templateiser::processIF ( std::string &code, std::string::const_iterator &inItr, const std::string &str )
{
  std::string key;

  // read the rest of the key
  std::string::const_iterator itr = readKey(key,inItr,str);

  std::vector<std::string> commandParts = tokenize(key,std::string(" "),0,0);
  if (commandParts.size() < 2) {
    inItr = itr;
    return;
  }

  // check the params
  makelower(commandParts[0]);
  makelower(commandParts[1]);

  if ( commandParts[0] != "if" ) {
    inItr = itr;
    return;
  }

  // now get the code for the next section
  std::string trueSection,elseSection;

  std::vector<std::string> checkKeys;
  checkKeys.push_back(format("?else %s",commandParts[1].c_str()));
  checkKeys.push_back(format("?end %s",commandParts[1].c_str()));

  std::string keyFound;
  itr = findNextTag(checkKeys,keyFound,trueSection,itr,str);

  if (keyFound == checkKeys[0]) { // we hit an else, so we need to check for it
    // it was the else, so go and find the end too
    if (itr == str.end()) {
      inItr = itr;
      return;
    }

    checkKeys.erase(checkKeys.begin());// kill the else, find the end
    itr = findNextTag(checkKeys,keyFound,elseSection,itr,str);
  }

  // test the if, stuff that dosn't exist is false
  if (callIF(commandParts[1])) {
    std::string newCode;
    processTemplate(newCode,trueSection);
    code += newCode;
  } else {
    std::string newCode;
    processTemplate(newCode,elseSection);
    code += newCode;
  }
  inItr = itr;
}

// Local Variables: ***
// mode: C++ ***
// tab-width: 8 ***
// c-basic-offset: 2 ***
// indent-tabs-mode: t ***
// End: ***
// ex: shiftwidth=2 tabstop=8
