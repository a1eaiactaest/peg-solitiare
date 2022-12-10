using System;
using System.Collections.Generic;
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
            for (int i = 0; i <= shape.Item1; i++)
            {
                g.DrawLine(Pens.Black, 0, square_size * i, width_limit, square_size * i);
            }

            for (int i = 0; i <= shape.Item2; i++)
            {
                g.DrawLine(Pens.Black, square_size * i, 0, square_size * i, height_limit);
            }
        }
    }
}
