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

                    try{
                        Console.Clear();
                        Screen.printMatch(match);

                        System.Console.Write("\nOrigin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validateOriginPosition(origin);

                        bool[,] possibleMovements = match.board.onePiece(origin).possibleMovements();
                        
                        Console.Clear();
                        Screen.printBoard(match.board, possibleMovements);

                        System.Console.Write("\nDestiny: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        match.validateDestinyPosition(origin, destiny);

                        match.realizeMove(origin, destiny);
                        
                        //Screen.printBoard(match.board);
                    }

                    catch(BoardException e){
                        System.Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }

            catch(BoardException e){
                System.Console.WriteLine(e.Message);
            }

        }

    }
}
