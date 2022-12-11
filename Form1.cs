using System.Security.Cryptography.X509Certificates;

namespace PegSolitiare
{
    public partial class Form1 : Form
    {
        bool[,]? board_state;
        Board board;

        public Form1()
        {
            InitializeComponent();
            board_state = new bool[7, 7];
            board = new Board(board_state);
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
            _ = MessageBox.Show($"{board_state[x_map, y_map]}");

            pictureBox1.Invalidate();
        }
    }
}