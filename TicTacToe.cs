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

			public int turnCount = 1;

			public bool isPlaying = true;

			public TicTacToe(){

			}

			public void displayBoard(){
				System.Console.WriteLine("         ");
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

			private string getPlayerTurn(){
				if(turnCount % 2 == 0){
					return "Player 2";
				} else {
					return "Player 1";
				}
			}

			// public void takeTurn(){
			// 	if(getPlayerTurn() == 1){
			// 		System.Console.WriteLine("Player 1 please pick a space:");
			// 		string input = Console.ReadLine();
			// 		int move = isValidMove(input);
			// 		//System.Console.WriteLine(board.Length);
			// 		bool x = positionTaken(move);
			// 		System.Console.WriteLine(x);

			// 		takeTurn();
			// 	} else {
			// 		System.Console.WriteLine("Player 2 please pick a space:");
			// 		Console.ReadLine();
			// 	}
			// }

			public void takeTurn(){
				//check for winner 
				
				System.Console.WriteLine("{0} please make a move:", getPlayerTurn());
				string input = Console.ReadLine();
				int move = isValidMove(input);
				bool taken = positionTaken(move);
				if (taken){
					System.Console.WriteLine("Invalid Move!");
					takeTurn();
				} else {
					// update board
					gameStatus();
					Console.Clear();
					displayBoard();
					turnCount++;
					
					// check if board is full/ winner 
					if(isPlaying){
						takeTurn();

					} else {
						
						System.Console.WriteLine("GAME END");
					}
					// check for a winner after a successful move
				}
			}

			private int isValidMove(string input){
				int squareNumber;
				bool valid = int.TryParse(input, out squareNumber);
				if(valid && squareNumber > 0 && squareNumber < 10){
					return squareNumber;
				} else {
					return -1;
				}
			}

			private bool positionTaken(int position){
				bool taken = true;
				for(int row = 0; row < board.GetLength(1); row++){
					for(int col = 0; col < board.GetLength(1); col++){
						//System.Console.WriteLine(board[row, col]);
						if(board[row, col].Equals(position.ToString())){
							updateBoard(row, col);
							return taken = false;
						} 
					}	
				}
				return taken;
			}

			private void updateBoard(int row, int col){
				string token = getPlayerTurn() == "Player 1" ? "X" : "O";
				board[row, col] = token;
			}

			private bool gameStatus(){
				for(int row = 0; row < board.GetLength(1); row++){
					for(int col = 0; col < board.GetLength(1); col++){
						if(board[row, col].Equals("X") || board[row, col].Equals("O")){
							isPlaying = false;
						} else {
							isPlaying = true;
						} 
					}
				}
				// check for winner 
				return isPlaying;
			}

		
	
	} //</classEnd>
}