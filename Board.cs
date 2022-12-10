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
                        state[row,col] = true;
                        Rectangle rect = new Rectangle(col * square_size, row * square_size, square_size, square_size);
                        Pen pen = new Pen(Color.Black, 1);
                        g.DrawRectangle(pen, rect);
                    }

                    i += 1;
                }
            }
            // empty middle item
            state[shape.Item1 / 2, shape.Item2 / 2] = false;
        }
    }
}
