using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    static class RegionManager
    {
        private static readonly List<IRegion> RegionCollection = new List<IRegion>();

        public static bool AddRegion(int radius, string regionName, int X, int Y)
        {
            if (IntersectRegions(radius, radius, X-radius, Y-radius))
            {
                return false;
            }

            Circle C = new Circle(radius);
            C.Name = regionName;
            C.Location = new CentricPoint(X, Y);
            C.Region_ID = SetID();
            RegionCollection.Add(C);

            SortRegion();

            return true;
        }

        public static bool AddRegion(int width, int height, string regionName, int X, int Y)
        {
            if (IntersectRegions(width, height, X, Y))
            {
                return false;
            }

            Rectangle R = new Rectangle(width, height);
            R.Name = regionName;
            R.Location = new CentricPoint(X, Y);
            R.Region_ID = SetID();
            RegionCollection.Add(R);

            SortRegion();

            return true;
        }

        public static bool AddRegion(string regionName, int width, int height, int X, int Y)
        {
            if (IntersectRegions(width, height, X, Y))
            {
                return false;
            }

            Triangle T = new Triangle(width, height);
            T.Name = regionName;
            T.Location = new CentricPoint(X, Y);
            T.Region_ID = SetID();
            RegionCollection.Add(T);

            SortRegion();

            return true;
        }

        public static bool RemoveRegion(int removeID)
        {
            for (int ctr = 0; ctr < RegionCollection.Count; ctr++)
            {
                if (RegionCollection[ctr].Region_ID == removeID)
                {
                    RegionCollection.RemoveAt(ctr);
                    return true;
                }
            }

            return false;
        }

        public static bool RemoveRegion(string S)
        {
            for (int ctr = 0; ctr < RegionCollection.Count; ctr++)
            {
                if (RegionCollection[ctr].Name == S)
                {
                    RegionCollection.RemoveAt(ctr);
                    return true;
                }
            }

            return false;
        }

        public static bool RemoveRegion(IRegion R)
        {
            bool Flag = false;

            for (int ctr = 0; ctr < RegionCollection.Count; ctr++)
            {
                if (RegionCollection[ctr].GetType() == R.GetType())
                {
                    RegionCollection.RemoveAt(ctr);
                    ctr--;
                    Flag = true;
                }
            }

            if (Flag)
                return true;

            return false;
        }

        public static IRegion GetRegion(int ID)
        {
            for (int ctr = 0; ctr < RegionCollection.Count; ctr++)
            {
                if (RegionCollection[ctr].Region_ID == ID)
                {
                    return RegionCollection[ctr];
                }
            }

            return null;
        }



        public static IReadOnlyList<IRegion> GetAllRegions()
        {
            return RegionCollection;
        }

        private static bool IntersectRegions(int length, int height, int X2, int Y2)
        {
            int X1 = 0, Y1 = 0, W = 0, H = 0;
            for(int ctr=0;ctr<RegionCollection.Count;ctr++)
            {
                X1 = RegionCollection[ctr].Location.X;
                Y1 = RegionCollection[ctr].Location.Y;
                if(RegionCollection[ctr].GetType() == typeof(Circle))
                {
                    Circle C = (Circle)RegionCollection[ctr];
                    W = H = C.Radius;
                    X1 = X1 - W;
                    Y1 = Y1 - H;
                    
                }
                else if(RegionCollection[ctr].GetType() == typeof(Rectangle))
                {
                    Rectangle R = (Rectangle)RegionCollection[ctr];
                    W = R.Width;
                    H = R.Height;
                }
                else
                {
                    Triangle T = (Triangle)RegionCollection[ctr];
                    W = T.Width;
                    H = T.Height;
                    X1 = X1 - (W/2);
                }
                if((X2 <= X1 && X2 + length >= X1) || (X2 <= X1+W && X2 + length >= X1 + W) || (Y2 <= Y1 && Y2 + height >= Y1) || (Y2 <= Y1+H && Y2 + height >= Y1+H))
                {
                    return true;
                }
            }
            return false;
        }

        private static int SetID()
        {
            int Counter = 1;
            for (int ctr = 0; ctr < RegionCollection.Count; ctr++, Counter++)
            {
                if(RegionCollection[ctr].Region_ID != Counter)
                {
                    return Counter;
                }
            }
            return RegionCollection.Count+1;
        }


        private static void SortRegion()
        {
            int Maxi = int.MinValue, Idx = 0;
            IRegion TempRegion;
            for (int ctr=RegionCollection.Count-1;ctr>=0;ctr--)
            {
                Maxi = int.MinValue; Idx = 0;
                for (int ptr=0;ptr<=ctr;ptr++)
                {
                    if(RegionCollection[ptr].Region_ID>Maxi)
                    {
                        Maxi = RegionCollection[ptr].Region_ID;
                        Idx = ptr;
                    }
                    
                }
                TempRegion = RegionCollection[Idx];
                RegionCollection[Idx] = RegionCollection[ctr];
                RegionCollection[ctr] = TempRegion;
            }
        }
    }
}
