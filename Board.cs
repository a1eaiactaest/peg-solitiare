using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PegSolitiare
{
    internal class Board
    {
        public bool[,] state;
        public (int, int) shape;

        public Board(bool[,] state)
        {
            this.state = state;
            shape = (state.GetLength(0), state.GetLength(1));
        }
        public void Draw(Graphics g, int square_size)
        {
            // this is really dumb, find a better way!
            int[] exclude = { 1, 2, 6, 7, 8, 9, 13, 14, 36, 37, 41, 42, 43, 44, 48, 49 };
            int i = 1;
            for (int row = 0; row < shape.Item1; row++)
            {
                for (int col = 0; col < shape.Item2; col++)
                {
                    if (!(exclude.Contains(i))){
                        // set default value of state
                        state[row,col] = true;

                        // draw board square
                        Rectangle rect = new Rectangle(col * square_size, row * square_size, square_size, square_size);
                        Pen pen = new Pen(Color.Black, 1);
                        g.DrawRectangle(pen, rect);
                    }

                    // draw peg for certain position
                    if (state[row,col] == true)
                    {
                        if (!(row == 3 && col == 3))
                        {
                            Rectangle rect = new Rectangle((col * square_size)+5, (row * square_size)+5, square_size-10, square_size-10);
                            Pen pen = new Pen(Color.Red);
                            g.FillEllipse(Brushes.Red, rect);
                        }
                    }

                    i += 1;
                }
            }
            // empty middle item of state
            state[shape.Item1 / 2, shape.Item2 / 2] = false;
        }

        public void Update(Graphics g)
        {

        }
    }
}
