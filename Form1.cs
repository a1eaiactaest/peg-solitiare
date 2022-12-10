using System.Security.Cryptography.X509Certificates;

namespace PegSolitiare
{
    public partial class Form1 : Form
    {
        static bool[,] board_state = new bool[7,7];
        Board board = new Board(board_state);

        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw Board
            int square_size = pictureBox1.Height / board.shape.Item2;
            board.Draw(g, square_size);

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int square_size = pictureBox1.Height / board.shape.Item2;

            int x_map = e.X/square_size;
            int y_map = e.Y/square_size;

            
            //board[x_map, y_map] = true;
            MessageBox.Show($"{board_state[x_map,y_map]}");

            pictureBox1.Invalidate();
        }
    }
}