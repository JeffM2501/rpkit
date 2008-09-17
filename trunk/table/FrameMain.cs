using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

using GLRenderer;
using GridMap;

namespace table
{
    public partial class FrameMain : Form
    {
        private bool initialized = false;
        private Utilities.MessagePeeker msgPeeker;

        private Map map;
        private Renderer renderer;

        public FrameMain()
        {
            InitializeComponent();

            this.CreateParams.ClassStyle = this.CreateParams.ClassStyle | User.CS_HREDRAW | User.CS_VREDRAW | User.CS_OWNDC;      // Redraw On Size, And Own DC For Window.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);            // No Need To Erase Form Background
            this.SetStyle(ControlStyles.DoubleBuffer, true);                    // Buffer Control
            this.SetStyle(ControlStyles.Opaque, true);                          // No Need To Draw Form Background
            this.SetStyle(ControlStyles.ResizeRedraw, true);                    // Redraw On Resize
            this.SetStyle(ControlStyles.UserPaint, true);                       // We'll Handle Painting Ourselves


            this.ClientSize = new Size(800, 600);
          //  this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void initialize()
        {
            msgPeeker = new Utilities.MessagePeeker();
            renderer = new Renderer(this);
            map = new Map(renderer);

            renderer.setClearColor(0, 0, 0);

            this.MouseMove += new MouseEventHandler(mouseMove);
            this.MouseWheel += new MouseEventHandler(mouseWheel);
            initialized = true;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            map.zoom(-e.Delta / 120.0f);
        }

        private void mouseWheel(object sender, MouseEventArgs e)
        {
            map.zoom(-e.Delta / 12000.0f);
        }

        public void mainLoop()
        {
            // Check if Initialized() method has been called
            if (!initialized)
            {
                throw new Exception("Not initialized!");
            }

            // We'll hook the application's idle event
            Application.Idle += new EventHandler(OnApplicationIdle);

            // Go!
            Application.Run(this);
        }

        private void OnApplicationIdle(object sender, EventArgs e)
        {
            // If the application windows is not focused, let's pause the game
            if (!this.Focused)
                return;

            while (!msgPeeker.MessageAvailable)
            {
                renderer.beginDraw();
                draw();
                renderer.endDraw();
            }
        }

        private void draw ()
        {
//             Gl.glPushMatrix();
//             Gl.glTranslatef(0, 0, -15);
// 
//             Gl.glDisable(Gl.GL_LIGHTING);
//             Gl.glDisable(Gl.GL_TEXTURE_2D);
//             Gl.glBegin(Gl.GL_LINES);
// 
//             Gl.glColor3f(1, 0, 0);
//             Gl.glVertex3f(10, 10, 10);
//             Gl.glVertex3f(-10, -10, -10);
// 
//             Gl.glEnd();
// 
//             Glu.gluSphere(Glu.gluNewQuadric(),2,10,10);
//             Gl.glPopMatrix();

            map.draw();
        }

    }
}