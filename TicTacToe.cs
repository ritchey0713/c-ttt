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

			public void takeTurn(){
				//check for winner 
				System.Console.WriteLine("{0} please make a move:", getPlayerTurn());
				string input = Console.ReadLine();
				int move = isValidMove(input);
				bool taken = positionTaken(move);
				string winnerToken = getWinner();

				if (taken){
					System.Console.WriteLine("Invalid Move!");
					takeTurn();

				} else {
					System.Console.Clear();
					displayBoard();
					turnCount++;

					if(!isFull() && winnerToken == null){
						takeTurn();
						
					} else if(isFull()) {
						
						System.Console.WriteLine("GAME END - (TIED)");
						System.Console.WriteLine("Please press any key to restart");
						Console.ReadLine();
						resetGame();
					} else if(winnerToken != null){
						System.Console.WriteLine("WINNER WINNER {0}", winnerToken);
						System.Console.WriteLine("Please press any key to restart");
						Console.ReadLine();
						resetGame();
					}

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
						if(board[row, col].Equals(position.ToString())){
							updateBoard(row, col);
							return taken = false;
						} 
					}	
				}
				return taken;
			}

			private string playerToken(){
				return getPlayerTurn() == "Player 1" ? "X" : "O";
			}

			private void updateBoard(int row, int col){
				board[row, col] = playerToken();
			}

			private bool isFull(){
				// bool boardStatus = false;
				// for(int row = 0; row < board.GetLength(1); row++){
				// 	for(int col = 0; col < board.GetLength(1); col++){
				// 		if(board[row, col].Equals("X") || board[row, col].Equals("O")){
				// 			boardStatus = true;
				// 		} else {
				// 			boardStatus = false;
				// 		}
				// 	}
				// }
				// return boardStatus;
				// simplified => can only increment turn if valid move, no need to check squares
				if(turnCount >= 10){
					return true;
				} else {
					return false;
				}
			}
			public string getWinner(){
				//horizontal
				if(board[0,0].Equals(board[0,1]) && board[0,0].Equals(board[0,2])){
					return board[0,0];
				} else if(board[1,0].Equals(board[1,1]) && board[1,0].Equals(board[1,2])){
					return board[1,0];
				} else if(board[2,0].Equals(board[2,1]) && board[2,0].Equals(board[2,2])){
					return board[2,0];
				}
				// diagonal 
				else if(board[0,0].Equals(board[1,1]) && board[0,0].Equals(board[2,2])){
					return board[0,0];
				}
				else if(board[0,2].Equals(board[1,1]) && board[0,2].Equals(board[2,0])){
					return board[0,2];
				}
				// vertical
				else if(board[0,0].Equals(board[1,0]) && board[0,0].Equals(board[2,0])){
					return board[0,0];
				}
				else if(board[0,1].Equals(board[1,1]) && board[0,1].Equals(board[2,1])){
					return board[0,1];
				}
				else if(board[0,2].Equals(board[1,2]) && board[0,2].Equals(board[2,2])){
					return board[0,2];
				} else {
					return null;
				}
			}

			public void resetGame(){
				 string[,] initBoard = {
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
				board = initBoard;
				turnCount = 1;
				displayBoard();
				takeTurn();
			}
	
	} //</classEnd>
}