char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
char currentPlayer = 'X';
int moves = 0;

while (true)
{
    Console.Clear();
    DrawBoard();

    Console.Write($"Player {currentPlayer}, enter position (1-9): ");
    if (!int.TryParse(Console.ReadLine(), out int pos) || pos < 1 || pos > 9 || board[pos - 1] == 'X' || board[pos - 1] == 'O')
    {
        Console.WriteLine("Invalid move. Press any key...");
        Console.ReadKey();
        continue;
    }

    board[pos - 1] = currentPlayer;
    moves++;

    if (CheckWin())
    {
        Console.Clear();
        DrawBoard();
        Console.WriteLine($"Player {currentPlayer} wins!");
        break;
    }

    if (moves == 9)
    {
        Console.Clear();
        DrawBoard();
        Console.WriteLine("It's a draw!");
        break;
    }

    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
}

void DrawBoard()
{
    Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    Console.WriteLine();
}

bool CheckWin()
{
    int[][] wins = [
        [0, 1, 2], [3, 4, 5], [6, 7, 8],
        [0, 3, 6], [1, 4, 7], [2, 5, 8],
        [0, 4, 8], [2, 4, 6]
    ];

    foreach (var w in wins)
        if (board[w[0]] == currentPlayer && board[w[1]] == currentPlayer && board[w[2]] == currentPlayer)
            return true;

    return false;
}
