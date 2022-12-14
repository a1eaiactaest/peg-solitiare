using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitiare
{
    public static class Utils
    {
        public static int[] flatten(int[,] array)
        {
            List<int> retList = new List<int>();

            for (int row = 0; row <= array.GetLength(0); row++)
            {
                for (int col = 0; col <= array.GetLength(1); col++)
                {
                    retList.Add(array[row, col]);
                }
            }

            return retList.ToArray();
        }

        public static Dictionary<string, (int,int)> generate_dirs()
        {
            Dictionary<string, (int, int)> hash_dirs = new Dictionary<string, (int, int)>
            {
                // (row, col)
                { "N", (-1, 0) },
                { "S", (1, 0) },
                { "W", (0, -1) },
                { "E", (0, 1) }
            };

            return hash_dirs;
        }
    }
}
