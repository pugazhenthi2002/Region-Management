using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    public class Rectangle:IRegion
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


        public Rectangle(int w=1, int h=1)
        {
            Width = w;
            Height = h;
            Area = Height * Width;
        }

        public double GetArea()
        {
            Area = Height * Width;

            return area;
        }

        public CentricPoint MoveRegion(int x, int y)
        {
            CentricPoint C = new CentricPoint();
            if (Location.X + x < LeftBoundary || Location.X + x > RightBoundary || Location.Y + y < UpBoundary || Location.Y + y > DownBoundary)
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
            if (newWidth < LeftBoundary || newHeight < UpBoundary || Location.X + (newWidth) > RightBoundary || Location.Y + newHeight > DownBoundary)
            {
                return false;
            }
            else
            {
                Width = newWidth;
                Height = newHeight;

                Area = Width * Height;

                return true;
            }

        }

        public bool Intersect(IRegion R1)
        {
            int X1 = Location.X, Y1 = Location.Y, X2 = 0, Y2 = 0, W, H;
            
            if (R1.GetType() == typeof(Rectangle))
            {
                Rectangle R = (Rectangle)R1;
                X2 = R.Location.X;
                W = R.Width;
                H = R.Height;
                
                if((X1 <= X2 && X1 + Width >= X2) || (X1 <= X2+W && X1 + Width >= X2 + W) || (Y1 <= Y2 && Y1 + Height >= Y2) || (Y1 <= Y2+H && Y1 + Height >= Y2+H))
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
                Triangle T = (Triangle)R1;
                //TOP
                X2 = T.Location.X;      
                Y2 = T.Location.Y;

                if (X2 <= X1 + Width && X2 >= X1 && Y2 <= Y1 + Height && Y2 >= Y1)
                    return true;

                //RIGHT
                X2 = T.Location.X + (T.Width / 2);        
                Y2 = T.Location.Y + T.Height;

                if (X2 <= X1 + Width && X2 >= X1 && Y2 <= Y1 + Height && Y2 >= Y1)
                    return true;

                //LEFT
                X2 = T.Location.X - (T.Width / 2);        
                Y2 = T.Location.Y + T.Height;

                if (X2 <= X1 + Width && X2 >= X1 && Y2 <= Y1 + Height && Y2 >= Y1)
                    return true;
                else
                    return false;
            }

            
        }
    }
}
