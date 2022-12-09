namespace PegSolitiare
{
    public partial class Form1 : Form
    {
        bool[,] board = new bool[7,7];

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; 

            int n = board.GetLength(0);
            int m = board.GetLength(1);

            int box_size = pictureBox1.Height / n;

            for (int i = 0; i <= n; i++)
            {
                g.DrawLine(Pens.Black, 0, box_size * i, pictureBox1.Width, box_size * i);
            }

            for (int i =0; i <= m; i++)
            {
                g.DrawLine(Pens.Black, box_size * i, 0, box_size * i, pictureBox1.Height);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {       
            int x_map = e.X;
            int y_map = e.Y;

            
            //board[x_map, y_map] = true;
            MessageBox.Show(String.Format("{0} {1}", x_map, y_map));

            pictureBox1.Invalidate();
        }
    }
}