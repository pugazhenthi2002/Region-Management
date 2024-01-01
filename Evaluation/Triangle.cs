using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    public class Triangle:IRegion
    {
        private double area = 0.0;
        public int Height = 0;
        public int Width = 0;

        public int Region_ID { get; set; }
        public string Name { get; set; }
        public int EdgesCount { get; }
        public double Area { get; set; }
        public CentricPoint Location { get; set; }
        public int UpBoundary => 0;
        public int DownBoundary => 500;
        public int LeftBoundary => 0;
        public int RightBoundary => 500;


        public Triangle(int w=1, int h=1)
        {
            Width = w;
            Height = h;
            Area = Height * Width / 2.0;
        }

        public double GetArea()
        {
            Area = Height * Width / 2.0;

            return area;
        }

        public CentricPoint MoveRegion(int x, int y)
        {
            CentricPoint C = new CentricPoint();
            if(Location.X + x < LeftBoundary || Location.X + x > RightBoundary || Location.Y + y < UpBoundary || Location.Y + y > DownBoundary)
            {
                return new CentricPoint(-1, -1);
            }
            else
            {
                Location.X += x;
                Location.Y += y;

                return new CentricPoint(Location.X, Location.Y);
            }
        }

        public bool Resize(int newWidth, int newHeight)
        {
            if(newWidth<LeftBoundary || newHeight<UpBoundary || Location.X+(newWidth/2)>RightBoundary || Location.Y+newHeight>DownBoundary)
            {
                return false;
            }
            else
            {
                Width = newWidth;
                Height = newHeight;

                Area = Width * Height / 2;

                return true;
            }
            
        }

        public bool Intersect(IRegion R1)
        {
            int X2 = Location.X, Y2 = Location.Y, length = Width, height = Height, W = 0, H = 0;

            int X1 = R1.Location.X;
            int Y1 = R1.Location.Y;

            if (R1.GetType() == typeof(Triangle))
            {
                Triangle T = (Triangle)R1;
                W = T.Width;
                H = T.Height;
                if ((X1 <= X2 && X1 + W >= X2) || (Y1 <= Y2 && Y1 + H >= Y2) || (X2 + length >= X1 && X2 <= X1) || (Y2 + height >= Y1 && Y2 <= Y1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
