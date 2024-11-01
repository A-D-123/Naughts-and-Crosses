using System;
namespace Naughts___Crosses
{
    internal class Board
    {
        public char[,] board;

        public Board()
        {
            board = new char[3, 3];
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }
        public void Print()
        {
            Console.Clear();
            Console.WriteLine("    1   2   3");
            for(int i = 0;i <= 2; i++) 
            {
             Console.WriteLine($" {i+1}  {board[0, i]} | {board[1, i]} | {board[2, i]}");
             Console.WriteLine((i == 2) ? "" : "   ---+---+---");
            }
        }
    }
}
