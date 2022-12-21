using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitiare
{
    internal class Backtrack
    {
        public Board board;
        public BitArray state;

        public Backtrack(Board board, BitArray state)
        {
            this.board = board;
            this.state = state;
        }

        public void Solve()
        {

        }
    }
}
