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
        public Button[,] pegs = new Button[7, 7];
        public (int, int) shape;

        public Board(int[,] state, int square_size, PictureBox pictureBox)
        {
            this.state = state;
            this.shape = (state.GetLength(0), state.GetLength(1));

            int i = 1;
            for (int col = 0; col < shape.Item1; col++)
            {
                for (int row = 0; row < shape.Item2; row++)
                {

                    if (!(exclude.Contains(i)))
                    {
                        Button current_peg = pegs[row, col];
                        current_peg = new Button();
                        current_peg.Width = square_size;
                        current_peg.Height = square_size;
                        current_peg.Left = square_size * row;
                        current_peg.Top = square_size * col;


                        if (!(row == 3 && col == 3))
                        {
                            current_peg.BackColor = Color.Black;
                            state[row, col] = 1;
                        } else
                        {
                            state[row, col] = 0;
                        }

                        current_peg.Name = $"({row},{col}) {state[row,col]}";


                        current_peg.Click += new EventHandler(PegClick);
                    
                        pictureBox.Controls.Add(current_peg);
                    } else
                    {
                        // this are corners of out board, they need to be included in the state too.
                        state[row, col] = 0;
                    }
                    i++;
                }
            }
        }

        private void PegClick(object sender, EventArgs e)
        {
            Button PegClicked = (Button) sender;

            string repr = PegClicked.Name;
            System.Diagnostics.Debug.WriteLine($"{repr}");

        }


        public void Draw(Graphics g, int square_size)
        {
            throw new NotImplementedException();
        }
    }
}
