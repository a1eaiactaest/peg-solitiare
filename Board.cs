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


        public Board(int[,] state, int square_size, PictureBox pictureBox)
        {
            this.state = state;
            this.shape = (state.GetLength(0), state.GetLength(1));

            int i = 1;
            for (int row = 0; row < shape.Item1; row++)
            {
                for (int col = 0; col < shape.Item2; col++)
                {

                    if (!(exclude.Contains(i)))
                    {
                        //Button current_peg = pegs[row, col];
                        pegs[row,col] = new Button();
                        pegs[row,col].Width = square_size;
                        pegs[row, col].Height = square_size;
                        pegs[row, col].Left = square_size * row;
                        pegs[row, col].Top = square_size * col;


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

        public void PegClick(object sender, EventArgs e)
        {
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

                // currently only horizontal move is implemented.
                if (move.isLegit())
                {
                    MakeMove(move);
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
        }


        public void Draw(Graphics g, int square_size)
        {
            throw new NotImplementedException();
        }
    }
}
