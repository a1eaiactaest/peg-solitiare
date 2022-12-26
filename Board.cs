using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PegSolitiare
{
    internal class Board
    {
        public int[] exclude = { 1, 2, 6, 7, 8, 9, 13, 14, 36, 37, 41, 42, 43, 44, 48, 49 };

        public int[,] state;
        public (int, int) shape;

        bool src_pick = true;

        int src_row = 0;
        int src_col = 0;

        int dest_row = 0;
        int dest_col = 0;

        public Button[,] pegs = new Button[7, 7];

        public int pegs_on_board = (7 * 7) - (4 * 4) - 1;

        public int moves_made = 0;

        public Label moves_label;

        public Stack<Move> history;


        public Board(int[,] state, int square_size, PictureBox pictureBox, Label moves_label)
        {
            this.state = state;
            this.shape = (state.GetLength(0), state.GetLength(1));
            this.moves_label = moves_label;
            this.history = new Stack<Move>();

            int i = 1;
            for (int row = 0; row < shape.Item1; row++)
            {
                for (int col = 0; col < shape.Item2; col++)
                {

                    if (!(exclude.Contains(i)))
                    {
                        //Button current_peg = pegs[row, col];
                        pegs[row, col] = new Button
                        {
                            Width = square_size,
                            Height = square_size,
                            Left = square_size * row,
                            Top = square_size * col,
                        };


                        if (!(row == 3 && col == 3))
                        {
                            pegs[row, col].BackColor = Color.Black;
                            state[row, col] = 1;
                        } else
                        {
                            state[row, col] = 0;
                        }

                        pegs[row, col].UseVisualStyleBackColor = false;

                        pegs[row, col].Name = $"({row},{col}) {state[row,col]}";


                        pegs[row, col].Click += new EventHandler(PegClick);
                    
                        pictureBox.Controls.Add(pegs[row, col]);
                    } else 
                    {
                        // this are corners of out board, they need to be included in the state too.
                        state[row, col] = 0;
                    }
                    i++;
                }
            }
        }

        public bool IsFinished()
        {
            int acc = 0;
            for (int i = 0; i < shape.Item1; i++)
            {
                for (int j = 0; j < shape.Item2; j++)
                {
                    if (state[i, j] == 1)
                    {
                        acc++;
                    }
                }
            }
            return acc == 1;
        }


        // this really slows down the game play is there a better way?
        public bool HasMoves()
        {
            int x = 1;
            for (int i = 0; i < shape.Item1; i++)
            {
                for (int j = 0; j < shape.Item2; j++)
                {
                    
                    if (state[i,j] == 1)
                    {
                        for (int k = -2; k <= 2; k++)
                        {
                            for (int l = -2; l <= 2; l++)
                            {
                                if (k == 0 || l == 0 || Math.Abs(k) == Math.Abs(l))
                                {
                                    continue;
                                }
                                if (!(exclude.Contains(i+k)) && !(exclude.Contains(j + l)))
                                {
                                    Move move = new Move((i, j), (i+k, j+l), state);
                                    if (move.isLegit())
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    x++;
                }
            }
            return false;
        }

        public void PegClick(object sender, EventArgs e)
        {

            // System.Diagnostics.Debug.WriteLine($"has moves: {HasMoves()}");

            Button PegClicked = (Button) sender;

            string repr = PegClicked.Name;
            //System.Diagnostics.Debug.WriteLine($"{repr}");

            int clicked_row = int.Parse(repr.Substring(1, 1));
            int clicked_col = int.Parse(repr.Substring(3, 1));

            System.Diagnostics.Debug.WriteLine($"{src_pick}");

            if (src_pick)
            {
                src_row = clicked_row;
                src_col = clicked_col;
                src_pick = false;

            } else
            {
                dest_row = clicked_row;
                dest_col = clicked_col;
                src_pick = true;
            }

            if (src_pick)
            {
                (int, int) move_src = (src_row, src_col);
                (int, int) move_dest = (dest_row, dest_col);

                Move move = new Move(move_src, move_dest, state);

                if (move.isLegit())
                {
                    MakeMove(move);
                    if (IsFinished())
                    {
                        moves_label.Text = $"Game Won with {moves_made} moves made.";
                    }
                }
            }
        }

        public void MakeMove(Move move)
        {
            state[move.src.Item1, move.src.Item2] = 0;
            pegs[move.src.Item1, move.src.Item2].ResetBackColor();

            if (move.horizontal)
            {
                state[move.jumpedPegCol, move.src.Item2] = 0;
                pegs[move.jumpedPegCol, move.src.Item2].ResetBackColor();
            } else
            {
                state[move.src.Item1, move.jumpedPegRow] = 0;
                pegs[move.src.Item1, move.jumpedPegRow].ResetBackColor();
            }

            state[move.dest.Item1, move.dest.Item2] = 1; 
            pegs[move.dest.Item1, move.dest.Item2].BackColor = Color.Black;

            this.pegs_on_board -= 1;
            this.moves_made += 1;

            this.moves_label.Text = $"Moves: {moves_made}";
            this.history.Push(move);
        }

        public void ReverseMove()
        {

            if (this.history.Count <= 0)
            {
                return;
            }

            Move move = this.history.Pop();

            state[move.src.Item1, move.src.Item2] = 1;
            pegs[move.src.Item1, move.src.Item2].BackColor = Color.Black;

            if (move.horizontal)
            {
                state[move.jumpedPegCol, move.src.Item2] = 1;
                pegs[move.jumpedPegCol, move.src.Item2].BackColor = Color.Black;
            }
            else
            {
                state[move.src.Item1, move.jumpedPegRow] = 1;
                pegs[move.src.Item1, move.jumpedPegRow].BackColor = Color.Black;
            }

            state[move.dest.Item1, move.dest.Item2] = 0;
            pegs[move.dest.Item1, move.dest.Item2].ResetBackColor();

            this.pegs_on_board += 1;
            this.moves_made -= 1;

            this.moves_label.Text = $"Moves: {moves_made}";

        }


        public void Draw(Graphics g, int square_size)
        {
            throw new NotImplementedException();
        }
    }
}
