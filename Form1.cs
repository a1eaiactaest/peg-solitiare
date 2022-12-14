using System.ComponentModel;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

// Modules
using static PegSolitiare.Utils;

namespace PegSolitiare
{
    public partial class Form1 : Form
    {
        int[,]? board_state;
        Board board;

        public Form1()
        {
            InitializeComponent();

            board = InitializeBoard();
        }

        private Board InitializeBoard()
        {
            int n = Settings.Default.BoardSize;
            int square_size = pictureBox1.Height / 7;

            board_state = new int[n, n];
            return new Board(board_state, square_size, pictureBox1, label1);
        }

        private void Reset()
        {
            if (board.pegs_on_board + 1 <= 32)
            {
                for (int i = pictureBox1.Controls.Count; i > 0; i--)
                {
                    System.Diagnostics.Debug.WriteLine(i);
                    pictureBox1.Controls.RemoveAt(i - 1);
                }
                board = InitializeBoard();
            }
            label1.Text = "Moves: 0";
        }

        private void Solve() 
        {
            Reset();


            Backtrack backtrack = new Backtrack(board);
            Stack<Move> solution = backtrack.Solve();
            if (solution != null)
            {
                foreach (Move move in solution)
                {
                    System.Diagnostics.Debug.Write(move.ToString());

                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw Board
            //int square_size = pictureBox1.Height / board.shape.Item2;
            //board.Draw(g, square_size);

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
            Reset();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Solve();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            board.ReverseMove();
        }
    }
}