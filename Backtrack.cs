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
        private readonly Board board;
        private readonly List<((int, int), (int, int))> _solution;

        public Backtrack(Board board)
        {
            this.board = board;
            this._solution = new List<((int, int), (int, int))>();
        }

        public List<((int,int), (int,int))> Solve()
        {
            return Solve(3, 5);
        }

        private List<((int, int), (int, int))> Solve(int src_row, int src_col)
        {
            if (board.IsFinished())
            {
                return _solution;
            }

            for (int row = 0; row < board.shape.Item1; row++)
            {
                for (int col = 0; col < board.shape.Item2; col++)
                {
                    Move tmp_move = new Move((src_row, src_col), (row, col), board.state);
                    if (tmp_move.isLegit())
                    {
                        board.MakeMove(tmp_move);
                        _solution.Add((tmp_move.src, tmp_move.dest));

                        List<((int, int), (int, int))> solution = Solve(row, col);
                        
                        if (solution != null)
                        {
                            return solution;
                        }

                        board.ReverseMove();
                        _solution.RemoveAt(_solution.Count - 1);
                    }
                }
            }
            return null;
        }
    }
}
