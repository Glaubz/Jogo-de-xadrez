using board;
using chess;
using System;

namespace PROJETO_XADREZ
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                ChessMatch match = new ChessMatch();

                while(!match.Finish){
                    Console.Clear();
                    Screen.printBoard(match.board);
                    System.Console.WriteLine("\nRound: " + match._round);
                    System.Console.WriteLine("Waiting " + match._currentPlayer + " move");

                    System.Console.Write("\nOrigin: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] possibleMovements = match.board.onePiece(origin).possibleMovements();
                    
                    Console.Clear();
                    Screen.printBoard(match.board, possibleMovements);

                    System.Console.Write("\nDestiny: ");

                    Position destiny = Screen.readChessPosition().toPosition();

                    match.realizeMove(origin, destiny);
                }

                Screen.printBoard(match.board);
            }
            catch(Exception e){
                System.Console.WriteLine(e.Message);
            }

        }

    }
}
