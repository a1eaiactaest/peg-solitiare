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
        private Board board;
        private Stack<Move> _solution;

        public Backtrack(Board board)
        {
            this.board = board;
            this._solution = new Stack<Move>();
        }

        public Stack<Move> Solve()
        {
            return _Solve(0, 0);
        }

        private Stack<Move> _Solve(int src_row, int src_col)
        {
            bool hasLegalMoves = false;

            for (int row = 0; row < board.shape.Item1; row++)
            {
                for (int col = 0; col < board.shape.Item2; col++)
                {
                    if (board.state[row, col] == 1)
                    {
                        // neighbors
                        for (int n_row = -2; n_row <= 2; n_row++)
                        {
                            for (int n_col = -2; n_col <= 2; n_col++)
                            {
                                // if square is the current square or move is diagonal
                                if ((n_row == 0 && n_col == 0) || Math.Abs(n_row) == Math.Abs(n_col))
                                {
                                    continue;
                                }

                                // if dest is not on corners
                                if (!(board.exclude.Contains(row + n_row)) &&
                                    !(board.exclude.Contains(col + n_col)))
                                {
                                    int dest_row = row + n_row;
                                    int dest_col = col + n_col;
                                    // if dest in bounds 
                                    if ((0 <= dest_row && dest_row <= board.shape.Item1) && (0 <= dest_col && dest_col <= board.shape.Item1))
                                    {
                                        // if dest is empty
                                        if (board.state[dest_row, dest_col] == 0)
                                        {
                                            Move tmp_move = new Move((row, col), (dest_row, dest_col), board.state);
                                            if (tmp_move.isLegit())
                                            {

                                                hasLegalMoves = true;

                                                board.MakeMove(tmp_move);
                                                _solution.Push(tmp_move);

                                                Stack<Move> solution = _Solve(row, col);

                                                if (solution != null)
                                                {
                                                    return solution;
                                                }

                                                board.ReverseMove();
                                                _solution.Pop();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }                    
                }
            }
            if (!hasLegalMoves)
            {
                return _solution;
            }
            return null;

        }
    }
}
