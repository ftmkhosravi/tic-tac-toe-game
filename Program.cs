using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 3;
            int columns = 3;
            string[,] board = new string[rows, columns];
            string player1 = "_";
            string player2 = "_";

            var t = false;
            do
            {
                t = false;
                setupBoard(board, rows, columns, ref player1, ref player2);
                printBoard(board, rows, columns);

                playGame(board, rows, columns, ref player1, ref player2);
                Console.WriteLine("thanks fo playing : do you want play again?y/n:");
                if (Console.ReadLine() == "y")
                {
                    t = true;
                }

            } while (t);
            Console.WriteLine("Thanks for playing our version of TicTocToe Game... :))");
        }


        public static void printBoard(string[,] board, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }


        public static void setupBoard(string[,] board, int rows, int columns, ref string player1, ref string player2)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = "_";
                }
            }
            do
            {
                Console.WriteLine("player1 Enter your char X/O : ");
                player1 = Console.ReadLine();
                if (player1 == "x" || player1 == "o")
                {
                    if (player1 == "x")
                    {
                        player2 = "o";
                        break;
                    }
                    else
                    {
                        player2 = "x";
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("hey there... please choose X or O nothing else :(");
                }


            } while(true);

        }

        public static void setPosition(ref string player, string[,] board)
        {
            do
            {
                Console.WriteLine($"{player} enter row 0-2:");
                var row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"{player} enter column 0-2:");
                var col = Convert.ToInt32(Console.ReadLine());
                if (row > 3 || col > 3)
                {
                    Console.WriteLine("hey there... babe i(justtt) have 3 rows and 3 column.");
                }
                else
                {
                    if (board[row, col] == "_")
                    {
                        board[row, col] = player;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("this position is fill please choose another cell...!");
                    }
                }
            } while (true);

        }

        public static void playGame(string[,] board, int rows, int columns, ref string player1, ref string player2)
        {
            do
            {
                if (gameOver(board, ref player2))
                {
                    Console.WriteLine($"HEY YOU {player2} WIN");
                    break;
                }
                else
                {
                    setPosition(ref player1, board);
                    printBoard(board, rows, columns);
                    if (isFinished(board))
                    {
                        Console.WriteLine($"HEY YOU !!! none of you WIN");
                        break;
                    }
                    else
                    {
                        if (gameOver(board, ref player1))
                        {
                            Console.WriteLine($"HEY YOU {player1} WIN");
                            break;
                        }
                        else
                        {
                            setPosition(ref player2, board);
                            printBoard(board, rows, columns);
                            if (isFinished(board))
                            {
                                Console.WriteLine($"HEY YOU !!! none of you WIN");
                                break;
                            }
                        }
                    }


                }
            } while (true);

        }

        public static bool isFinished(string[,] board)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "_")
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public static bool gameOver(string[,] board, ref string player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i,0]==player && board[i,1]==player && board[i,2]==player && player !="_")
                {
                    return true;
                }
            }
             for (int i = 0; i < 3; i++)
            {
                if (board[0,i]==player && board[1,i]==player && board[2,i]==player && player !="_")
                {
                    return true;
                }
            }
            if (board[0,0]==player && board[1,1]==player && board[2,2]==player && player !="_")
            {
                return true;
            }
            if (board[0,2]==player && board[1,1]==player && board[2,0]==player && player !="_")
            {
                return true;
            }
            return false;

        }
    }
}
