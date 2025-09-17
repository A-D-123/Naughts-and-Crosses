using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naughts_and_Crosses__good_AI_
{
    class AI
    {
        public AI()
        {
            
        }
        public void Input(char[,] Boardpos, out int Besti, out int Bestj)
        {
            int[,] Score = new int[3, 3];
            Besti = 0;
            Bestj = 0;


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Boardpos[i, j] != ' ')
                    {
                        Score[i, j] = -1000;
                    }
                    else
                    {
                        if ((i % 2 == 1 && j % 2 == 0) || (i % 2 == 0 && j % 2 == 1))
                        {
                            Score[i, j] += 1;
                        }
                        else if (i % 2 == 0 && j % 2 == 0)
                        {
                            Score[i, j] += 2;
                        }
                        else if (i == 1 && j == 1)
                        {
                            Score[i, j] += 3;
                        }

                        if (i == 0)
                        {
                            if (Boardpos[1, j] == 'X' && Boardpos[2, j] == 'X')
                            {
                                Score[i, j] += 50;
                            }
                            else if (Boardpos[1, j] == 'O' && Boardpos[2, j] == 'O')
                            {
                                Score[i, j] += 100;
                            }
                        }
                        else if (i == 1)
                        {
                            if (Boardpos[0, j] == 'X' && Boardpos[2, j] == 'X')
                            {
                                Score[i, j] += 50;
                            }
                            else if (Boardpos[0, j] == 'O' && Boardpos[2, j] == 'O')
                            {
                                Score[i, j] += 100;
                            }
                        }
                        else if (i == 2)
                        {
                            if (Boardpos[0, j] == 'X' && Boardpos[1, j] == 'X')
                            {
                                Score[i, j] += 50;
                            }
                            else if (Boardpos[0, j] == 'O' && Boardpos[1, j] == 'O')
                            {
                                Score[i, j] += 100;
                            }
                        }

                        if (j == 0)
                        {
                            if (Boardpos[i, 1] == 'X' && Boardpos[i, 2] == 'X')
                            {
                                Score[i, j] += 50;
                            }
                            else if (Boardpos[i, 1] == 'O' && Boardpos[i, 2] == 'O')
                            {
                                Score[i, j] += 100;
                            }
                        }
                        else if (j == 1)
                        {
                            if (Boardpos[i, 0] == 'X' && Boardpos[i, 2] == 'X')
                            {
                                Score[i, j] += 50;
                            }
                            else if (Boardpos[i, 0] == 'O' && Boardpos[i, 2] == 'O')
                            {
                                Score[i, j] += 100;
                            }
                        }
                        else if (j == 2)
                        {
                            if (Boardpos[i, 0] == 'X' && Boardpos[i, 1] == 'X')
                            {
                                Score[i, j] += 50;
                            }
                            else if (Boardpos[i, 0] == 'O' && Boardpos[i, 1] == 'O')
                            {
                                Score[i, j] += 100;
                            }
                        }

                        if (i == 0 && j == 0)
                        {
                            if (Boardpos[1, 1] == 'X' && Boardpos[2, 2] == 'X')
                            {
                                Score[i, j] += 50;
                            }
                            else if (Boardpos[1, 1] == 'O' && Boardpos[2, 2] == 'O')
                            {
                                Score[i, j] += 100;
                            }
                        }
                        else if (i == 2 && j == 0)
                        {
                            if (Boardpos[1, 1] == 'X' && Boardpos[0, 2] == 'X')
                            {
                                Score[i, j] += 50;
                            }
                            else if (Boardpos[1, 1] == 'O' && Boardpos[0, 2] == 'O')
                            {
                                Score[i, j] += 100;
                            }
                        }
                    }
                }
            }

            int BestScore = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Score[i, j] > BestScore)
                    {
                        BestScore = Score[i, j];
                        Besti = i;
                        Bestj = j;
                    }
                }
            }
        }
    }
}

