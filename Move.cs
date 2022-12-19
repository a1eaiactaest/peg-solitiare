using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitiare
{
    internal class Move
    {
        public (int, int) src;
        public (int, int) dest;
        private int[,] state;
        public int jumpedPegRow;

        public Move((int, int) src, (int,int) dest, int[,] state)
        {
            this.src = src;
            this.dest = dest;
            this.state = state;
        }

        public bool isLegit()
        {
            /* Transalte:
             * src.Item1 -> src.row
             * src.Item2 -> src.col
            */ 


            System.Diagnostics.Debug.WriteLine($"Validating a Move from {src.Item1} {src.Item2} to {dest.Item1} {dest.Item2}:");

            if (src.Item2 == dest.Item2)
            {
                if (Math.Abs(src.Item1 - dest.Item1) == 2)
                {
                    this.jumpedPegRow = (src.Item1 + dest.Item1) / 2;


                    // src is a peg
                    if (state[src.Item1, src.Item2] == 1)
                    {
                        // middle is a peg
                        if (state[jumpedPegRow, src.Item2] == 1)
                        {
                            // dest is not a peg
                            if (state[dest.Item1, dest.Item2] == 0)
                            {
                                System.Diagnostics.Debug.WriteLine("Move is valid.");
                                return true;
                            }
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Move is not valid.");
            return false;
        }
    }
}
