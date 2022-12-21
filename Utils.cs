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
    }
}
