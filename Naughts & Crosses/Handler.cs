using System;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
namespace Naughts___Crosses
{
    internal class Handler
    {
        private Random random;
        String turnxy;
        int turnx;
        int turny;
        public Handler()
        {
            random = new Random();
            turnxy = "";
        }
        public char firstTurn()
        {
            char currentTurn = (random.Next(1, 2) == 1) ? 'X' : 'O';
            return currentTurn;
        }
        public char nextTurn(char currentTurn)
        {
            currentTurn = (currentTurn == 'X') ? currentTurn = 'O' : 'X';
            return currentTurn;
        }
        public void Input(char currentTurn, string turnxy, int turnx, int turny)
        {
            Console.WriteLine($"Enter co-ordinates to place {currentTurn}.");
            turnxy = Console.ReadLine();
            turnx = turnxy.
        
        
        }
    }   

    
}
