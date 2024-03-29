/* bzflag
 * Copyright (c) 1993 - 2008 Tim Riker
 *
 * This package is free software;  you can redistribute it and/or
 * modify it under the terms of the license found in the file
 * named COPYING that should have accompanied this file.
 *
 * THIS PACKAGE IS PROVIDED ``AS IS'' AND WITHOUT ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, WITHOUT LIMITATION, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
 */

// a base class for plugins that want to do HTTP
#ifndef _HTTP_H_
#define _HTTP_H_

#include <string>
#include <vector>
#include <map>


class TemplateCallbackClass
{
public:
  virtual ~TemplateCallbackClass() {};
  virtual void keyCallback(std::string & /* data */, const std::string & /* key */) {};
  virtual bool loopCallback(const std::string &/* key */) { return false; }
  virtual bool ifCallback(const std::string &/* key */) { return false; }
};

class Templateiser : public TemplateCallbackClass
{
public:
  Templateiser();
  virtual ~Templateiser();

  void addKey(const char *key, TemplateKeyCallback callback);
  void addKey(const char *key, TemplateCallbackClass *callback);
  void clearKey(const char *key);
  void flushKeys(void);

  void addLoop(const char *loop, TemplateTestCallback callback);
  void addLoop(const char *loop, TemplateCallbackClass *callback);
  void clearLoop(const char *loop);
  void flushLoops(void);

  void addIF(const char *name, TemplateTestCallback callback);
  void addIF(const char *name, TemplateCallbackClass *callback);
  void clearIF(const char *name);
  void flushIFs(void);

  void processTemplate(std::string &code, const std::string &templateText);
  bool processTemplateFile(std::string &code, const char *file);

  // for the default template tokens
  virtual void keyCallback(std::string &data, const std::string &key);
  virtual bool loopCallback(const std::string &key);
  virtual bool ifCallback(const std::string &key);

  void startTimer(void);
  void setPluginName(const char* name, const char* URL);

  void addSearchPath(const char* path);
  void flushSearchPaths(void);

protected:
  typedef std::map<std::string,TemplateKeyCallback> KeyMap;
  typedef std::map<std::string,TemplateTestCallback> TestMap;
  typedef std::map<std::string,TemplateCallbackClass*> ClassMap;

  KeyMap keyFuncCallbacks;
  TestMap loopFuncCallbacks;
  TestMap ifFuncCallbacks;
  ClassMap keyClassCallbacks;
  ClassMap loopClassCallbacks;
  ClassMap ifClassCallbacks;

  bool callKey(std::string &data, const std::string &key);
  bool callLoop(const std::string &key);
  bool callIF(const std::string &key);

  void setDefaultTokens(void);

private:
  std::string::const_iterator readKey(std::string &key,
				      std::string::const_iterator inItr,
				      const std::string &str);
  std::string::const_iterator findNextTag(const std::vector<std::string> &keys,
					  std::string &endKey, std::string &code,
					  std::string::const_iterator inItr,
					  const std::string &str);

  void processInclude(std::string &code, std::string::const_iterator &inItr, const std::string &str);
  void processComment(std::string &code, std::string::const_iterator &inItr, const std::string &str);
  void replaceVar(std::string &code, std::string::const_iterator &itr, const std::string &str);
  void processIF(std::string &code, std::string::const_iterator &inItr, const std::string &str);
  void processLoop(std::string &code, std::string::const_iterator &inItr, const std::string &str);

  double startTime;
  std::string pluginName,baseURL;

  std::vector<std::string> filePaths;
};

typedef enum {
  eUnknown = 0,
  eHead,
  eGet,
  ePost,
  ePut,
  eDelete,
  eTrace,
  eOptions,
  eConnect,
  eOther
}HTTPRequestType;

class HTTPRequest
{
public:
  HTTPRequest() : requestID(-1), request(eUnknown) {};

  int		  sessionID;
  int		  requestID;
  HTTPRequestType request;

  std::string vdir;
  std::string resource;
  std::map<std::string, std::vector<std::string> > parameters;

  std::map<std::string, std::string> headers;
  std::map<std::string, std::string> cookies;

  std::string body;
  std::string baseURL;

  //connetion info
  std::string ip;
  std::string hostmask;

  // HTTP auth
  std::string authType;
  std::string authCredentials;

  std::string username;
  std::string password;

  bool getParam(const char* param, std::string &val) const;
  bool getParam(const std::string &param, std::string &val) const;

  bool getParam(const char* param, std::vector<std::string> &val) const;
  bool getParam(const std::string &param, std::vector<std::string> &val) const;

};

class HTTPReply
{
public:
  HTTPReply(): docType(eText), returnCode(e404NotFound), forceNoCache(true) {};

  typedef enum {
    eText,
    eOctetStream,
    eBinary,
    eHTML,
    eOther
  } DocumentType;

  typedef enum {
    e200OK,
    e301Redirect,
    e401Unauthorized,
    e403Forbiden,
    e404NotFound,
    e500ServerError
  } ReturnCode;

  DocumentType docType;
  ReturnCode  returnCode;
  std::string otherMimeType;
  std::map<std::string, std::string> headers;
  std::map<std::string, std::string> cookies;

  std::string body;

  // authentication method
  std::string authType;
  std::string authRealm;

  bool forceNoCache;

  // content info
  std::string lastUpdateTime;
  std::string md5;

  std::string redirectLoc;
};

class BZFSHTTP
{
public:
  BZFSHTTP();
  virtual ~BZFSHTTP();

  typedef enum {
    e404 = 0, // not found
    e200,     // ok
    eDeffer
  } PageStatus;

  void registerVDir(void);

  virtual const char * getVDir(void) = 0;
  virtual const char * getDescription(void) { return ""; }
  virtual bool supportPut(void) { return false; }

  virtual bool handleRequest(const HTTPRequest &request, HTTPReply &reply) = 0;

  virtual bool resumeTask(int /*requestID*/) {return true; }

protected:
  std::string getBaseURL(void);
};

bool RegisterVDir(BZFSHTTP* handler);
bool RemoveVDir(BZFSHTTP *handler);

#endif //_HTTP_H_


// Local Variables: ***
// mode: C++ ***
// tab-width: 8 ***
// c-basic-offset: 2 ***
// indent-tabs-mode: t ***
// End: ***
// ex: shiftwidth=2 tabstop=8
