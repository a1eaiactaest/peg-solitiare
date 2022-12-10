using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegSolitiare
{

    internal class Peg
    {
        public int x;
        public int y;
        public int size;

        public Peg(int x, int y, int size)
        {
            this.x = x;
            this.y = y;
            this.size = size;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Black, x, y, size, size);
        }
    }
}
