namespace PegSolitiare
{
    public partial class Form1 : Form
    {
        Board board = new Board((7,7));

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw Board
            int square_size = pictureBox1.Height / board.shape.Item2;
            board.Draw(g, square_size, pictureBox1.Width, pictureBox1.Height);

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int square_size = pictureBox1.Height / board.shape.Item2;

            int x_map = e.X/square_size;
            int y_map = e.Y/square_size;

            
            //board[x_map, y_map] = true;
            MessageBox.Show(String.Format("{0} {1}", x_map, y_map));

            pictureBox1.Invalidate();
        }
    }
}