using System;

namespace tictactoe
{
    public class TicTacToe {
      public string[,] board = {
				{
					"1", "2", "3"
				},
				{
					"4", "5", "6"
				},
				{
					"7", "8", "9"
				}
			};

			public TicTacToe(){

			}

			public void displayBoard(){
				System.Console.WriteLine("         |         |");
				System.Console.WriteLine("    {0}    |    {1}    |    {2}    ", board[0,0], board[0,1], board[0,2]);
				System.Console.WriteLine("         |         |");
				System.Console.WriteLine("----------------------------");
				System.Console.WriteLine("         |         |");
				System.Console.WriteLine("    {0}    |    {1}    |    {2}    ", board[1,0], board[1,1], board[1,2]);
				System.Console.WriteLine("         |         |");
				System.Console.WriteLine("----------------------------");
				System.Console.WriteLine("         |         |");
				System.Console.WriteLine("    {0}    |    {1}    |    {2}    ", board[2,0], board[2,1], board[2,2]);
				System.Console.WriteLine("         |         |");
			}
    }
}