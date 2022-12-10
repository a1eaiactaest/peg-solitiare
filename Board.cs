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
            for (int row = 0; row < shape.Item1; row++)
            {
                for (int col = 0; col < shape.Item2; col++)
                {
                    Rectangle rect = new Rectangle(col*square_size, row*square_size, square_size, square_size);
                    Pen pen = new Pen(Color.Black, 1);
                    g.DrawRectangle(pen, rect);
                }
            }
        }
    }
}
