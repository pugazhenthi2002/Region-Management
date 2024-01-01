using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
                Console.WriteLine("1. Add Region\n2. Remove Region\n3. GetAllRegion\n4. Manage Region\n0. Exit\n\nEnter Token: ");
                int Token = Convert.ToInt32(Console.ReadLine());
                
                IRegion R = new Rectangle();
                if (Token==0)
                {
                    Console.WriteLine("END");
                    break;
                }
                switch(Token)
                {
                    case 1: AddRegion(); break;
                    case 2: RemoveRegion(); break;
                    case 3: DisplayRegions(); break;
                    case 4: ManageRegions(); break;
                    default: Console.WriteLine("Invalid Token");    break;
                }

                Console.ReadLine();
            }
            Console.ReadLine();
        }

        static void AddRegion()
        {
            Console.Clear();
            Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
            Console.WriteLine("1. Add Circle\n2. Add Rectangle\n3. Add Triangle\n\nEnter Token: ");
            int Token = Convert.ToInt32(Console.ReadLine());
            
            switch (Token)
            {
                case 1: AddCircle();  break;
                case 2: AddRectangle(); break;
                case 3: AddTriangle(); break;
                default: Console.WriteLine("Invalid Token"); break;
            }
        }

        static void AddCircle()
        {
            bool Flag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nCircle Entry\n\n");

                Console.WriteLine("Name: ");
                string Name = Console.ReadLine();
                Console.WriteLine("Location: ");
                int X = Convert.ToInt32(Console.ReadLine());
                int Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Radius: ");
                int Radius = Convert.ToInt32(Console.ReadLine());

                Flag = RegionManager.AddRegion(Radius, Name, X, Y);

                if(!Flag)
                {
                    Console.Clear();
                    Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nRegions Intersecting - Cannot Add\n\n");
                    Console.WriteLine("[Press any key to Re-Entry]");
                    Console.ReadLine();
                }

            } while (!Flag);
            
            Console.Clear();
            Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nCircle Added\n\n");
        }

        static void AddRectangle()
        {
            bool Flag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nRectangle Entry\n\n");

                Console.WriteLine("Name: ");
                string Name = Console.ReadLine();
                Console.WriteLine("Location: ");
                int X = Convert.ToInt32(Console.ReadLine());
                int Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Width: ");
                int Width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Height: ");
                int Height = Convert.ToInt32(Console.ReadLine());

                Flag = RegionManager.AddRegion(Width, Height, Name, X, Y);

                if (!Flag)
                {
                    Console.Clear();
                    Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nRegions Intersecting - Cannot Add\n\n");
                    Console.WriteLine("[Press any key to Re-Entry]");
                    Console.ReadLine();
                }

            } while (!Flag);
            
            Console.Clear();
            Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nRectangle Added\n\n");
        }

        static void AddTriangle()
        {
            bool Flag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nTriangle Entry\n\n");

                Console.WriteLine("Name: ");
                string Name = Console.ReadLine();
                Console.WriteLine("Location: ");
                int X = Convert.ToInt32(Console.ReadLine());
                int Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Width: ");
                int Width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Height: ");
                int Height = Convert.ToInt32(Console.ReadLine());

                Flag = RegionManager.AddRegion(Name, Width, Height, X, Y);

                Flag = RegionManager.AddRegion(Width, Height, Name, X, Y);

                if (!Flag)
                {
                    Console.Clear();
                    Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nRegions Intersecting - Cannot Add\n\n");
                    Console.WriteLine("[Press any key to Re-Entry]");
                    Console.ReadLine();
                }

            } while (!Flag);

            Console.Clear();
            Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\nTriangle Added\n\n");
        }

        static void RemoveRegion()
        {
            
            bool Flag = false;
            do
            {
                Console.Clear();
                DisplayRegions();
                string Token = Console.ReadLine();

                if (IsNum(Token))
                {
                    Flag = RegionManager.RemoveRegion(Convert.ToInt32(Token));
                }
                else
                {
                    if (Token.ToLower() == "circle")
                    {
                        Flag = RegionManager.RemoveRegion(new Circle());
                    }
                    else if (Token.ToLower() == "rectangle")
                    {
                        Flag = RegionManager.RemoveRegion(new Rectangle());
                    }
                    else if (Token.ToLower() == "triangle")
                    {
                        Flag = RegionManager.RemoveRegion(new Triangle());
                    }
                    else
                    {
                        Flag = RegionManager.RemoveRegion(Token);
                    }
                }

                if(!Flag)
                {
                    Console.WriteLine("Invalid Entry");
                }
            } while (!Flag);
            
        }

        static void ManageRegions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Get Area\n2. Move Region\n3. Resize\n4. Intersect\n0. Exit\n\n");
                int Token = Convert.ToInt32(Console.ReadLine());
                if (Token == 0)
                {
                    Console.WriteLine("Exiting Managing Region");
                    break;
                }
                
                switch (Token)
                {
                    case 1: GetArea();
                            break;

                    case 2: MoveRegion();
                            break;

                    case 3: ResizeRegion();
                            break;

                    case 4: IntersectRegions();
                            break;
                }
            }
        }

        static void GetArea()
        {
            int RegionID = 0;
            bool Flag = true;

            do
            {
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");

                RegionManager.GetAllRegions();
                RegionID = Convert.ToInt32(Console.ReadLine());
                IRegion R1 = RegionManager.GetRegion(RegionID);

                if(R1==null)
                {
                    Console.Clear();
                    Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
                    Console.WriteLine("\nINVALID ID\n[Press any key to Re-Entry]");
                    Console.ReadLine();
                    continue;
                }

                double Area = R1.GetArea();

                Console.WriteLine("Region 1\n\n" + R1.Region_ID + " " + R1.Name + " " + R1.GetType().ToString().Remove(0, 11));
                Console.WriteLine("Area\nX: {0}", Area);

                Flag = false;

            } while (Flag);

            Console.WriteLine("\n[Press any key to Re-Entry]");
            Console.ReadLine();

            
        }
        static void MoveRegion()
        {
            int RegionID = 0;
            bool Flag = true;

            do
            {
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");

                RegionManager.GetAllRegions();
                RegionID = Convert.ToInt32(Console.ReadLine());
                IRegion R1 = RegionManager.GetRegion(RegionID);

                if (R1 == null)
                {
                    Console.Clear();
                    Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
                    Console.WriteLine("\nINVALID ID\n[Press any key to Re-Entry]");
                    Console.ReadLine();
                    continue;
                }

                int X = Convert.ToInt32(Console.ReadLine());
                int Y = Convert.ToInt32(Console.ReadLine());
                CentricPoint C = R1.MoveRegion(X, Y);

                

                if (C.X == -1 && C.Y == -1)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Region 1\n\n" + R1.Region_ID + " " + R1.Name + " " + R1.GetType().ToString().Remove(0, 11));
                    Console.WriteLine("New Location\nX: {0}\nY: {1}", C.X, C.Y);
                    Flag = false;
                }

            } while (Flag);

            Console.WriteLine("\n[Press any key to Re-Entry]");
            Console.ReadLine();

        }

        static void ResizeRegion()
        {
            int RegionID = 0;
            bool Flag = false;

            do
            {
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");

                RegionManager.GetAllRegions();

                RegionID = Convert.ToInt32(Console.ReadLine());
                IRegion R1 = RegionManager.GetRegion(RegionID);

                if (R1 == null)
                {
                    Console.Clear();
                    Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
                    Console.WriteLine("\nINVALID ID\n[Press any key to Re-Entry]");
                    Console.ReadLine();
                    continue;
                }

                int Width = Convert.ToInt32(Console.ReadLine());
                int Height = Convert.ToInt32(Console.ReadLine());

                Flag = R1.Resize(Width, Height);

                

                Console.WriteLine("Region 1\n\n" + R1.Region_ID + " " + R1.Name + " " + R1.GetType().ToString().Remove(0, 11));
                if (Flag)
                {
                    Console.WriteLine("\n\n\t*** RESIZED REGION ***\t");
                }
                else
                {
                    Console.WriteLine("\n\n\t*** REACHED OUT OF BOUNDARY ***\t");
                }

                Console.WriteLine("\n[Press any key to Re-Entry]");
                Console.ReadLine();

            } while (!Flag);
            

            
        }

        static void IntersectRegions()
        {
            int RegionID = 0;
            bool Flag = true, Intersect = false; ;

            do
            {
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
                RegionManager.GetAllRegions();

                RegionID = Convert.ToInt32(Console.ReadLine());
                IRegion R1 = RegionManager.GetRegion(RegionID);

                if (R1 == null)
                {
                    Console.Clear();
                    Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
                    Console.WriteLine("\nINVALID ID\n[Press any key to Re-Entry]");
                    Console.ReadLine();
                    continue;
                }

                RegionID = Convert.ToInt32(Console.ReadLine());
                IRegion R2 = RegionManager.GetRegion(RegionID);

                if (R2 == null)
                {
                    Console.Clear();
                    Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
                    Console.WriteLine("\nINVALID ID\n[Press any key to Re-Entry]");
                    Console.ReadLine();
                    continue;
                }

                if (R1.GetType() == typeof(Circle))
                {
                    Intersect = R1.Intersect(R2);
                }
                else if ((R1.GetType() == typeof(Rectangle) && R2.GetType() == typeof(Rectangle)) || (R1.GetType() == typeof(Rectangle) && R2.GetType() == typeof(Triangle)))
                {
                    Intersect = R1.Intersect(R2);
                }
                else if ((R1.GetType() == typeof(Triangle) && R2.GetType() == typeof(Triangle)))
                {
                    Intersect = R1.Intersect(R2);
                }
                else
                {
                    Intersect = R2.Intersect(R1);
                }
                Console.Clear();
                Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");

                Console.WriteLine("Region 1\n\n" + R1.Region_ID + " " + R1.Name + " " + R1.GetType().ToString().Remove(0, 11));
                Console.WriteLine("Region 2\n\n" + R2.Region_ID + " " + R2.Name + " " + R2.GetType().ToString().Remove(0, 11));
                if (Intersect)
                {
                    Console.WriteLine("\n\n\t*** INTERSECT EACHOTHER ***\t");
                    Flag = false;
                }
                else
                {
                    Console.WriteLine("\n\n\t*** NOT INTERSECT EACHOTHER ***\t");
                }

                Console.WriteLine("\n[Press any key to Re-Entry]");
                Console.ReadLine();

            } while (Flag);
            

        }

        static void DisplayRegions()
        {
            IReadOnlyList<IRegion> FetchedRegions = RegionManager.GetAllRegions();

            Console.Clear();
            Console.WriteLine("***\tSHAPE MANAGEMENT\t***\n\n");
            Console.WriteLine("Id\tName\tShape\tArea\n");

            for (int ctr = 0; ctr < FetchedRegions.Count; ctr++)
            {
                IRegion R = FetchedRegions[ctr];
                Console.WriteLine(R.Region_ID + "\t" + R.Name + "\t" + R.GetType().ToString().Remove(0, 11) + "\t" + R.Area);
            }

            Console.WriteLine("\n\n[Press any key to Continue]");
            Console.ReadLine();
        }

        static bool IsNum(string S)
        {
            for(int ctr=0;ctr<S.Length;ctr++)
            {
                if (S[ctr] <= '0' || S[ctr] >= '9')
                    return false;
            }

            return true;
        }
        
    }
}
