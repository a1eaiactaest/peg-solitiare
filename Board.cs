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

        public bool[,] state;
        public Button[,] pegs = new Button[7, 7];
        public (int, int) shape;

        public Board(bool[,] state, int square_size, PictureBox pictureBox)
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
                        Button current_peg = pegs[row, col];
                        current_peg = new Button();
                        current_peg.Width = square_size;
                        current_peg.Height = square_size;
                        current_peg.Left = square_size * row;
                        current_peg.Top = square_size * col;

                        pictureBox.Controls.Add(current_peg);
                    }
                    i++;
                }
            }
        }

        public void Draw(Graphics g, int square_size)
        {
            
        }
    }
}
