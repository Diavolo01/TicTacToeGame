using System.Diagnostics;

namespace TicTacToeGame
{
   public partial class Form1 : Form
{
    bool playerTurn = true;
    int turnCount = 0;
    Button[,] board;

    public Form1()
    {
        InitializeComponent();

        board = new Button[3, 3] {
            { button1, button2, button3 },
            { button4, button5, button6 },
            { button7, button8, button9 }
        };

        foreach (var btn in board)
        {
            btn.Click += Button_Click;
        }
        
    }

    private void Button_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
            Debug.WriteLine($"You clicked {b.Name}");

            if (b.Text != "") return;

        b.Text = playerTurn ? "X" : "O";
        playerTurn = !playerTurn;
        turnCount++;

        if (CheckWinner())
        {
            MessageBox.Show($"{(playerTurn ? "O" : "X")} Wins!", "Game Over");
            ResetGame();
        }
        else if (turnCount == 9)
        {
            MessageBox.Show("Draw !", "Game Over");
            ResetGame();
        }
    }

    private bool CheckWinner()
    {
        // Check rows, columns, diagonals with loops
        for (int i = 0; i < 3; i++)
        {
            if (IsSame(board[i, 0], board[i, 1], board[i, 2])) return true; // Row
            if (IsSame(board[0, i], board[1, i], board[2, i])) return true; // Column
        }

        if (IsSame(board[0, 0], board[1, 1], board[2, 2])) return true; // Diagonal \
        if (IsSame(board[0, 2], board[1, 1], board[2, 0])) return true; // Diagonal /

        return false;
    }

    private bool IsSame(Button a, Button b, Button c)
    {
        return a.Text != "" && a.Text == b.Text && b.Text == c.Text;
    }


    private void ResetGame()
    {
        playerTurn = true;
        turnCount = 0;
        foreach (var btn in board)
        {
            btn.Text = "";
        }
    }
}

}
