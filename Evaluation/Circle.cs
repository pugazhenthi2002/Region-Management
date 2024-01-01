using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{

    public class Circle: IRegion
    {
        private double area = 0.0;

        public int Radius = 0;

        public int Region_ID { get; set; }
        public string Name { get; set; }
        public int EdgesCount { get; }
        public double Area { get; set; }
        public CentricPoint Location { get; set; }
        public int UpBoundary => 0;
        public int DownBoundary => 500;
        public int LeftBoundary => 0;
        public int RightBoundary => 500;


        public Circle(int r=1)
        {
            Radius = r;
            Area = 22 / 7.0 * Radius * Radius;
        }

        public double GetArea()
        {
            Area = 22 / 7.0 * Radius * Radius;

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

        public bool Resize(int newRadius, int temp=-1)
        {
            if (newRadius - Location.X < LeftBoundary || newRadius + Location.Y < UpBoundary || newRadius + Location.X > RightBoundary || newRadius - Location.Y > DownBoundary)
            {
                return false;
            }
            else
            {
                Radius = newRadius;

                Area = 22 / 7.0 * Radius * Radius;

                return true;
            }

        }

        public bool Intersect(IRegion R1)
        {
            int X1 = Location.X, Y1 = Location.Y, X2 = 0, Y2 = 0, r1 = Radius, r2 = 0;
            double d = 0.0;
            if (R1.GetType() == typeof(Circle))
            {
                Circle C = (Circle)R1;
                X2 = C.Location.X;
                Y2 = C.Location.Y;

                d = Math.Sqrt((X1 - X2) * (X1 - X2)+ (Y1 - Y2) * (Y1 - Y2));

                if ((d <= r1 - r2) || (d <= r2 - r1) || (d < r1 + r2) || (d == r1 + r2))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (R1.GetType() == typeof(Triangle))
            {
                Triangle R = (Triangle)R1;

                X2 = R.Location.X;  //TOP
                Y2 = R.Location.Y;

                d = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));

                if (d <= r1)
                {
                    return true;
                }

                X2 = R.Location.X + (R.Width/2);        //RIGHT
                Y2 = R.Location.Y + R.Height;

                d = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));

                if (d <= r1)
                {
                    return true;
                }

                X2 = R.Location.X - (R.Width / 2);      //LEFT
                Y2 = R.Location.Y + R.Height;

                d = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));

                if (d <= r1)
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
                Rectangle T = (Rectangle)R1;
                X2 = T.Location.X;
                Y2 = T.Location.Y;

                d = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));

                if (d <= r1)    //TOPLEFT
                {
                    return true;
                }

                X2 = T.Location.X+T.Width;
                Y2 = T.Location.Y;

                d = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));

                if (d <= r1)    //TOPRIGHT
                {
                    return true;
                }

                X2 = T.Location.X;
                Y2 = T.Location.Y + T.Height;

                d = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));

                if (d <= r1)     //BOTTOMLEFT
                {
                    return true;
                }

                X2 = T.Location.X + T.Width;
                Y2 = T.Location.Y + T.Height;

                d = Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2));

                if (d <= r1)        //BOTTOMRIGHT
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
