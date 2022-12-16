using System.Linq.Expressions;
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

            InitializeBoard();
        }

        private void InitializeBoard()
        {
            int n = Settings.Default.BoardSize;
            board_state = new bool[n, n];
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
            if (board.pegs[x_map, y_map] != null )
            {
                _ = MessageBox.Show($"{board.pegs[x_map, y_map].ToString()}");
            }

            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Reset board to default state.
            InitializeBoard();
            pictureBox1.Invalidate();
        }
    }
}