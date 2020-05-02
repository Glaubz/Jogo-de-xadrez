using board;
using board.Enums;
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

                    System.Console.Write("\nOrigin: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] possibleMovements = match.board.onePiece(origin).possibleMovements();
                    Console.Clear();
                    Screen.printBoard(match.board, possibleMovements);

                    System.Console.Write("\nDestiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    match.executeMovement(origin, destiny);
                }

                Screen.printBoard(match.board);
            }
            catch(BoardException e){
                System.Console.WriteLine(e.Message);
            }

        }

    }
}
