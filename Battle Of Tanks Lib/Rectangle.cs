using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Of_Tanks_Lib
{
    public class Rectangle
    {
        public Point Point { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(Point position, int width, int heidth)
        {
            Point = position;
            Width = width;
            Height = heidth;
        }
        public bool Intersects(Rectangle other)
        {
            // Проверка на пересечение по осям X и Y
            bool xLeft = Point.X + Width > other.Point.X;
            bool xRight = Point.X < other.Point.X + other.Width;
            bool yUp = Point.Y + Width > other.Point.Y;
            bool yDown = Point.Y < other.Point.Y + other.Height;

            // Если есть пересечение по обеим осям, то прямоугольники пересекаются
            return xLeft && xRight && yUp && yDown;
        }
        public object Clone()
        {
            return new Rectangle((Point)Point.Clone(), Width, Height);
        }
    }
}
