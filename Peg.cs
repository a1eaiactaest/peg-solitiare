using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public bool state;

        public Peg(int x, int y, int size, bool state)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.state = state;
        }

        public override string ToString()
        {
            return $"x: {x}, y: {y}, size: {size}, state: {state}";
        }

        public void Draw(Graphics g)
        {
            int row = x;
            int col = y;

            if (state)
            {
                Rectangle rect = new Rectangle((col * size) + 5, (row * size) + 5, size - 10, size - 10);
                Pen pen = new Pen(Color.Red);
                g.FillEllipse(Brushes.Red, rect);
            }
            
        }
    }
}
