using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_DD_ArrayTreasure_Traps
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] treasure =new int[,] {{2, 3, 2, 1, 2 },
                                         {2, 3, 4, 5, 6 },
                                         { 1, 3, 4, 7, 1 },
                                         {3, 4, 1, 2, 4 }
                                        };
            List<Tuple<int, int>> placedToOpen = new List<Tuple<int, int>>();

            placedToOpen.Add(new Tuple<int, int>(0, 0));
            placedToOpen.Add(new Tuple<int, int>(2, 1));
            placedToOpen.Add(new Tuple<int, int>(2, 3));
            int v = GetValue(treasure, placedToOpen);
            Console.WriteLine($"Value = {v}");
            placedToOpen.Clear();

            placedToOpen.Add(new Tuple<int, int>(1, 1));
            placedToOpen.Add(new Tuple<int, int>(1, 2));
            placedToOpen.Add(new Tuple<int, int>(2, 3));
            v = GetValue(treasure, placedToOpen);

            Console.WriteLine($"Value = {v}");
            Console.Read();
        }

        public static int GetValue(int [,] treasure,List<Tuple<int, int>> input)
        {
            List<Tuple<int, int>> forbiddenPlaces = new List<Tuple<int, int>>();

            int value = 0;
            int rows = treasure.GetLength(0);
            int cols = treasure.GetLength(1);

            for (int i=0;i<input.Count;i++)
            {
                var placeToPick = input[i];
                if(forbiddenPlaces.Any(f=>f.Item1 == placeToPick.Item1 && f.Item2 == placeToPick.Item2) ||
                    placeToPick.Item1 <0 || placeToPick.Item1 > rows || placeToPick.Item2 < 0 || placeToPick.Item2 > cols)
                {
                    throw new Exception("Forbidden.");
                }

                forbiddenPlaces.Add(new Tuple<int, int>(placeToPick.Item1, placeToPick.Item2));
                value += treasure[placeToPick.Item1,placeToPick.Item2];

                //Also add all forbidden places around this item.
                forbiddenPlaces.Add(new Tuple<int, int>(placeToPick.Item1, placeToPick.Item2 - 1)); //Left place of current place
                forbiddenPlaces.Add(new Tuple<int,int> (placeToPick.Item1, placeToPick.Item2 + 1));// Right place of current place

                int aboveCurrentRow = placeToPick.Item1 - 1;
                int belowCurrentRow = placeToPick.Item1 + 1;

                if(aboveCurrentRow > 0)
                {
                    for(int col = 0; col < cols;col++)
                    {
                        forbiddenPlaces.Add(new Tuple<int, int>(aboveCurrentRow, col));
                    }
                }
                if (belowCurrentRow < rows)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        forbiddenPlaces.Add(new Tuple<int, int>(belowCurrentRow, col));
                    }
                }
            }

            return value;
        }


        
    }
}
