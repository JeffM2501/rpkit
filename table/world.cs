using System;
using System.Collections.Generic;
using System.Text;

namespace FlatMap
{
    class Coordinate
    {
        public Coordinate()
        {
        }
        
        public Coordinate ( float _x, float _y )
        {
            x = _x;
            y = _y;
        }

        public float x = 0;
        public float y = 0;
    }

    class Opening
    {
        public float start = 0;
        public float end = 0;
        public bool open = false;
    }

    class Wall
    {
        public Coordinate start = new Coordinate();
        public Coordinate end = new Coordinate();
        public List<Opening> openings = new List<Opening>();
    }

    class Shape
    {
        public List<Coordinate> corners = new List<Coordinate>();
    }

    class Obsacle
    {
        public Shape shape = new Shape();
    }

    class Region
    {
        public Shape shape = new Shape();
        public float z = 0;
    }

    class Room
    {
        public Coordinate size = new Coordinate();

        public float z = 0;

        public List<Wall> walls = new List<Wall>();

        bool viewed = false;
        bool starting = false;

        string texture = string.Empty;

        public Coordinate textureShift = new Coordinate();
        public Coordinate textureScale = new Coordinate();
    }

    class World
    {
        public List<Room> rooms = new List<Room>();

        public Room addRectRoom ( Coordinate size, Coordinate center )
        {
            Room room = new Room();

            room.size = size;

            Wall wall = new Wall();
            wall.start = Coordinate(center.x + size.x / 2, center.y + size.y / 2);
            wall.start = Coordinate(center.x - size.x / 2, center.y + size.y / 2);
            room.walls.Add(wall);
        }
    }
}
