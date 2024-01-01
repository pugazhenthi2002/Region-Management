using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    public class CentricPoint
    {
        public CentricPoint(int a=0, int b=0)
        {
            X = a;  Y = b;
        }
        public int X;
        public int Y;
    }
    public interface IRegion
    {
        int Region_ID { get; set; }
        string Name { get; set; }
        int EdgesCount { get; }
        double Area { get; set; }
        int UpBoundary { get; }
        int DownBoundary { get; }
        int LeftBoundary { get; }
        int RightBoundary { get; }
        CentricPoint Location { get; set; }

        double GetArea();
        CentricPoint MoveRegion(int X, int Y);
        bool Resize(int Width, int Height=-1);
        bool Intersect(IRegion R1);
    }
}
