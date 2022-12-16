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
        public Peg[,] pegs = new Peg[7,7];
        public (int, int) shape;

        public Board(bool[,] state)
        {
            this.state = state;
            this.shape = (state.GetLength(0), state.GetLength(1));
        }

        public void Draw(Graphics g, int square_size)
        {            
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

                    // draw peg for a certain position
                    if (state[row,col] == true)
                    {
                        if (!(row == 3 && col == 3))
                        {
                            Peg peg = new Peg(row, col, square_size, state[row,col]);
                            pegs[row,col] = peg;
                            peg.Draw(g);

                        }
                    }

                    i += 1;
                }
            }
            // empty middle item of state
            state[shape.Item1 / 2, shape.Item2 / 2] = false;
        }

        public void Move((int, int) src, (int,int) dest)
        {
            // TODO
        }

        public void Update(Graphics g)
        {
            // pass
        }
    }
}
