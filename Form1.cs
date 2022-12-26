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
            List<((int, int), (int, int))> solution = backtrack.Solve();
            System.Diagnostics.Debug.Write(solution.ToArray());


        }

        private List<Move> SolveGame(Board board)
        {
            // Check if the game is already finished
            if (board.IsFinished())
            {
                return board.history.ToList();
            }

            // Try making a move and solving the game from the resulting board state
            for (int row = 0; row < board.shape.Item1; row++)
            {
                for (int col = 0; col < board.shape.Item1; col++)
                {
                    if (board.state[row, col] == 1)
                    {
                        for (int k = -2; k <= 2; k++)
                        {
                            for (int l = -2; l <= 2; l++)
                            {
                                if (k == 0 || l == 0 || Math.Abs(k) == Math.Abs(l))
                                {
                                    continue;
                                }
                                if (!(board.exclude.Contains(row + k)) && !(board.exclude.Contains(col + l)))
                                {
                                    if (!(row + k < 0 || col + l < 0 || row + k > board.shape.Item1 || col + l > board.shape.Item1))
                                    {
                                        System.Diagnostics.Debug.WriteLine($"{row+k}: {col+l}");
                                        if (board.state[row + k, col + l] == 0)
                                        {
                                            // Make a copy of the current board state
                                            int[,] newState = (int[,])board.state.Clone();

                                            // Make the move on the copied board state
                                            newState[row, col] = 0;
                                            newState[row + k, col + l] = 1;
                                            newState[(row + k + row) / 2, (col + l + col) / 2] = 0;

                                            // Create a new board with the modified state
                                            Board newBoard = new Board(newState, board.square_size, pictureBox1, board.moves_label);

                                            // Save the move to the history stack
                                            Move move = new Move((row, col), (row + k, col + l), board.state);
                                            newBoard.history.Push(move);
                                            newBoard.moves_made++;

                                            // Recursively solve the game with the modified board
                                            List<Move> solution = SolveGame(newBoard);

                                            // If a solution was found, return it
                                            if (solution.Count > 0)
                                            {
                                                return solution;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return new List<Move>();
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
            List<Move> moves = SolveGame(board);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            board.ReverseMove();
        }
    }
}