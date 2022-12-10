﻿using System;
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
        public (int, int) shape = (7, 7);

        public Board((int, int) shape)
        {
            this.shape = shape;
        }

        public void Draw(Graphics g, int square_size, int width_limit, int height_limit)
        {
            // this is really dumb, find a better way!
            int[] exclude = { 1, 2, 6, 7, 8, 9, 13, 14, 36, 37, 41, 42, 43, 44, 48, 49 };
            int i = 1;
            for (int row = 0; row < shape.Item1; row++)
            {
                for (int col = 0; col < shape.Item2; col++)
                {
                    if (!(exclude.Contains(i))){
                        Rectangle rect = new Rectangle(col * square_size, row * square_size, square_size, square_size);
                        Pen pen = new Pen(Color.Black, 1);
                        g.DrawRectangle(pen, rect);
                    }

                    i += 1;
                }
            }
        }
    }
}
