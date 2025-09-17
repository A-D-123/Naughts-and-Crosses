using System;

namespace Naughts_and_Crosses__good_AI_
{
    class Program
    {
        static void Main(string[] args)
        {
            AI ai = new AI();
            char Turn = RandomTurn();
            char[,] Boardpos = new char[3, 3];
            bool GameComplete = false;
            bool AIPlaying = false;
            int Besti, Bestj;

            AIPlaying = PlayAgainstAI();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Boardpos[i, j] = ' ';
                }
            }

            while (GameComplete == false)
            {
                if (GameComplete == false)
                {
                    if (AIPlaying == false || Turn == 'X')
                    {
                        PlayerInput(Turn, Boardpos);
                    }
                    else
                    {
                        ai.Input(Boardpos, out Besti, out Bestj);
                        Boardpos[Besti, Bestj] = 'O';
                    }

                    GameComplete = GameEndCheck(Turn, Boardpos, GameComplete);
                    Turn = NextTurn(Turn);
                }
            }
        }
        static char RandomTurn()
        {
            Random rnd = new Random();
            return (rnd.Next(0, 2) == 0) ? 'X' : 'O';
        }
        static bool PlayAgainstAI()
        {
            while (true)
            {
                Console.WriteLine("Would you like to play against an AI? y/n");
                String Temp = Console.ReadLine();
            
                if (Temp.ToLower() == "y")
                {
                    return true;
                }
                else if (Temp.ToLower() == "n")
                {
                    return false;
                }
                else if (Temp.ToLower() == "y/n")
                {
                    Console.WriteLine("ts nga pmo");
                    Console.ReadKey();
                    Console.Clear();
            }
                else
                {
                    Console.WriteLine("Please input y/n");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static void SpawnBoard(char[,] Boardpos)
        {
            Console.Clear();
            Console.WriteLine("   1   2   3");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}  {Boardpos[0, i]} | {Boardpos[1, i]} | {Boardpos[2, i]}");
                Console.WriteLine((i == 2) ? "" : "  ---+---+---");
            }
        }
        static void PlayerInput(char Turn, char[,] Boardpos)
        {
                bool TurnComplete = false;

            while (TurnComplete == false)
            {
                try
                {
                    SpawnBoard(Boardpos);
                    Console.WriteLine("Enter X and Y coordinate");

                    int Xcoord = Convert.ToInt32(Console.ReadLine());
                    int Ycoord = Convert.ToInt32(Console.ReadLine());

                    if (Boardpos[Xcoord - 1, Ycoord - 1] == ' ')
                    {
                        Boardpos[Xcoord - 1, Ycoord - 1] = Turn;
                        TurnComplete = true;
                    }
                    else
                    {
                        Console.WriteLine("Space Taken\n ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter an integer between 1 and 3 inclusive");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            
        }
        static char NextTurn(char Turn)
        {
            return (Turn == 'X') ? 'O' : 'X';
        }
        static bool GameEndCheck(char Turn, char[,] Boardpos, bool GameComplete)
        {
            int SpacesTaken = 0;
            char Winner = ' ';

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Boardpos[i, j] != ' ')
                    {
                        SpacesTaken++;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (Boardpos[i, 0] == Turn && Boardpos[i, 1] == Turn && Boardpos[i, 2] == Turn)
                {
                    Winner = Turn;
                    GameComplete = true;
                }
            }

            for (int j = 0; j < 3; j++)
            {
                if (Boardpos[0, j] == Turn && Boardpos[1, j] == Turn && Boardpos[2, j] == Turn)
                {
                    Winner = Turn;
                    GameComplete = true;
                }
            }

            if (Boardpos[0, 0] == Turn && Boardpos[1, 1] == Turn && Boardpos[2, 2] == Turn)
            {
                Winner = Turn;
                GameComplete = true;
            }

            if (Boardpos[2, 0] == Turn && Boardpos[1, 1] == Turn && Boardpos[0, 2] == Turn)
            {
                Winner = Turn;
                GameComplete = true;
            }

            
            if (SpacesTaken == 9 && Winner == ' ')
            {
                GameComplete = true;
                SpawnBoard(Boardpos);
                Console.WriteLine("Draw!");
                Console.ReadKey();
            }
            else if(GameComplete == true)
            {
                SpawnBoard(Boardpos);
                Console.WriteLine($"The winner is {Turn}!");
                Console.ReadKey();
            }

            return GameComplete;
        }
    }   
}
