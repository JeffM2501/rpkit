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
        float z = 0.10f;

        public Map(Renderer r)
        {
            renderer = r;
        }

        public void zoom(float delta)
        {
            if (z + delta > 0.05)
                z += delta;
        }

        public void pan(float deltaX, float deltaY)
        {
            x += deltaX;
            y += deltaY;
        }

        public void draw ( )
        {
            Gl.glTranslatef(renderer.Width() / 2.0f, renderer.Height() / 2.0f, 0);
            Gl.glColor4f(1, 1, 1, 1);

            Gl.glScalef(1.0f / z, 1.0f / z, 1.0f/z);
            Gl.glTranslatef(x, y,0);
            Gl.glPushMatrix();

            Gl.glPushMatrix();
            Gl.glTranslatef(0, 0, -0.001f);
            drawMap();
            Gl.glPopMatrix();

            drawGrid();

            Gl.glPopMatrix();
        }

        private void drawMap ( )
        {
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glNormal3f(0, 0, 1);
            Gl.glColor3f(0.85f, 0.5f, 0.5f);

            Gl.glVertex3f(10, 10, 0);
            Gl.glVertex3f(10, -10, 0);
            Gl.glVertex3f(-10, -10, 0);
            Gl.glVertex3f(-10, 10, 0);

            Gl.glEnd();
        }

        private void drawGrid ( )
        {
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            float bounds = 50;

            Gl.glColor3f(0.5f, 0.5f, 0.5f);
            Gl.glBegin(Gl.GL_LINES);
            // grid is a 5 unit square so find the closest size
            for ( float f = -bounds; f <= bounds; f+= 5)
            {
                Gl.glVertex3f(bounds, f, 0);
                Gl.glVertex3f(-bounds, f, 0);
                Gl.glVertex3f(f, -bounds, 0);
                Gl.glVertex3f(f, bounds,0);
            }
            Gl.glEnd();

        }
    }
}
