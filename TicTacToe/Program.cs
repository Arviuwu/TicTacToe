﻿using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            bool playLoop = true;
            string coordinateInput = "";
            int coordinate1 = 0;
            int coordinate2 = 0;
            bool pXTurn = true;
            bool pOTurn = false;
            string pXSign = "X";
            string pOSign = "O";
            string error = "Unexpected error";
            bool win = false;
            int roundCount = 0;
            string[,] board =
                {
                { " ", " ", " " },
                { " ", " ", " " },
                { " ", " ", " " }
            }
            ;

            while (true)
            {
                Reset(ref board, ref roundCount, ref pXTurn, ref pOTurn, ref win, ref playLoop);

                while (playLoop)
                {
                    UpdateUI(board);

                    // win check
                    if (win)
                    {
                        if (pOTurn)
                        {
                            Console.Write(" Player X wins");
                            break;
                        }
                        else if (pXTurn)
                        {
                            Console.Write(" Player O wins");
                            break;
                        }
                    }
                    if (roundCount == 9)
                    {
                        Console.WriteLine("Draw!");
                        break;
                    }


                    Console.WriteLine();

                    // marker placement loop
                    while (true)
                    {
                        if (pOTurn)
                        {
                            Console.WriteLine("It's player O's turn.\nEnter your coordinates!");
                        }
                        else if (pXTurn)
                        {
                            Console.WriteLine("It's player X's turn.\nEnter your coordinates!");

                        }
                        else
                        {
                            Console.WriteLine(error);
                        }

                        coordinateInput = Console.ReadLine().ToUpper();// check for input 2 char long, save number in coord 1, letter in coord 2 depending on order in input

                        // input validadation 
                        while (true)
                        {
                            if (coordinateInput.Length == 2)
                            {
                                char firstChar = coordinateInput[0];
                                char secondChar = coordinateInput[1];

                                // Check if the input is valid (A-C and 1-3)(gpt solution)
                                bool firstIsValidDigit = firstChar >= '1' && firstChar <= '3';
                                bool firstIsValidLetter = firstChar >= 'A' && firstChar <= 'C';
                                bool secondIsValidDigit = secondChar >= '1' && secondChar <= '3';
                                bool secondIsValidLetter = secondChar >= 'A' && secondChar <= 'C';

                                if (firstIsValidDigit && secondIsValidLetter)
                                {
                                    coordinate1 = firstChar - '1';
                                    coordinate2 = secondChar - 'A';
                                    break;
                                }
                                else if (firstIsValidLetter && secondIsValidDigit)
                                {
                                    coordinate1 = secondChar - '1';
                                    coordinate2 = firstChar - 'A';
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("enter a valid coordinate");
                                    coordinateInput = Console.ReadLine().ToUpper();
                                }
                            }
                            else
                            {
                                Console.WriteLine("coordinate cant be longer than 2");
                                coordinateInput = Console.ReadLine().ToUpper();
                            }
                        }

                        //placing play markers
                        if (board[coordinate1, coordinate2] == " ")// checking for empty spot
                        {
                            if (pXTurn) //placing marker on coordinate depending on turn
                            {

                                board[coordinate1, coordinate2] = pXSign;
                                pXTurn = false;
                                pOTurn = true;
                                break;
                            }
                            else if (pOTurn) //placing marker on coordinate depending on turn
                            {
                                board[coordinate1, coordinate2] = pOSign;
                                pXTurn = true;
                                pOTurn = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine(error);
                            }
                        }
                        else
                        {
                            Console.WriteLine("already guessed");
                        }
                    }

                    // win check left vertical
                    win = false;

                    if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && !board[0, 0].Contains(" ") && !board[1, 0].Contains(" ") && !board[2, 0].Contains(" "))
                    {
                        win = true;
                    }
                    // middle vertical
                    else if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && !board[0, 1].Contains(" ") && !board[1, 1].Contains(" ") && !board[2, 1].Contains(" "))
                    {
                        win = true;
                    }
                    // right vertical
                    else if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && !board[0, 2].Contains(" ") && !board[1, 2].Contains(" ") && !board[2, 2].Contains(" "))
                    {
                        win = true;
                    }
                    // up horizontal
                    else if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && !board[0, 0].Contains(" ") && !board[0, 1].Contains(" ") && !board[0, 2].Contains(" "))
                    {
                        win = true;
                    }
                    // middle horizontal
                    else if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && !board[1, 0].Contains(" ") && !board[1, 1].Contains(" ") && !board[1, 2].Contains(" "))
                    {
                        win = true;
                    }
                    // down horizontal
                    else if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && !board[2, 0].Contains(" ") && !board[2, 1].Contains(" ") && !board[2, 2].Contains(" "))
                    {
                        win = true;
                    }
                    // diag left -> right
                    else if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && !board[1, 1].Contains(" ") && !board[1, 1].Contains(" ") && !board[2, 2].Contains(" "))
                    {
                        win = true;
                    }
                    //diag right -> left
                    else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && !board[0, 2].Contains(" ") && !board[1, 1].Contains(" ") && !board[2, 0].Contains(" "))
                    {
                        win = true;
                    }
                    else
                    {
                        win = false;
                    }

                    roundCount++;
                }
                Console.WriteLine("\nDo you want to play another round? (Y/N)");
                var anotherRound = Console.ReadKey().Key;
                if (anotherRound == ConsoleKey.Y)
                {

                }

                else
                {
                    break;
                }
            }

            

            
            }

        static void Reset(ref string[,] board,ref int roundCount, ref bool pXTurn, ref bool pOTurn, ref bool win, ref bool playLoop)
            {
                //resetting values
                for(int i = 0; i < board.GetLength(0); i++)
                {
                    for(int j = 0;j < board.GetLength(1); j++)
                    {
                        board[i, j] = " ";
                    }
                }
                roundCount = 0;
                pXTurn = true;
                pOTurn = false;
                win = false;
                playLoop = true;
        }
        static void UpdateUI(string[,] board)
        {
            Console.Clear();

            //updates and draws board
            Console.WriteLine($"   -----------");
            Console.WriteLine($"1 | {board[0, 0]} | {board[0, 1]} | {board[0, 2]} |");
            Console.WriteLine($"   -----------");
            Console.WriteLine($"2 | {board[1, 0]} | {board[1, 1]} | {board[1, 2]} |");
            Console.WriteLine($"   -----------");
            Console.WriteLine($"3 | {board[2, 0]} | {board[2, 1]} | {board[2, 2]} |");
            Console.WriteLine($"   -----------");
            Console.WriteLine($"    A   B   C");
        }
    }
}
