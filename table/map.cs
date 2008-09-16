using System;
using System.Collections.Generic;
using System.Text;

using Tao.OpenGl;
using Tao.Platform.Windows;

using GLRenderer;

namespace GridMap
{
    class Map
    {
        private Renderer renderer;

        float x = 0;
        float y = 0;
        float z = 10;

        public Map(Renderer r)
        {
            renderer = r;
        }

        public void zoom(float delta)
        {
            z += delta;
        }

        public void pan(float deltaX, float deltaY)
        {
            x += deltaX;
            y += deltaY;
        }

        public void draw ( )
        {
            Gl.glTranslatef(x, y, z);
            Gl.glPushMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(0, 0, -0.001f);
            Gl.glPopMatrix();

            drawGrid();

            Gl.glPopMatrix();
        }

        private void drawGrid ( )
        {
            float bounds = 50;

            Gl.glColor3f(0.5f, 0.5f, 0.5f);
            Gl.glBegin(Gl.GL_LINES);
            // grid is a 5 unit square so find the closest size
            for ( float f = -bounds; f < bounds; f+= 5)
            {
                Gl.glVertex2d(bounds, f);
                Gl.glVertex2d(bounds,-f);

                Gl.glVertex2d(f,bounds);
                Gl.glVertex2d(-f, bounds);
            }
            Gl.glEnd();
        }
    }
}
