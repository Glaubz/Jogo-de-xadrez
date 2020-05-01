using System;
using board;
using board.Enums;
using chess;

namespace PROJETO_XADREZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            try{
                board.putPiece(new Tower(board, Color.Black), new Position(0,0));
                board.putPiece(new Tower(board, Color.Black), new Position(0,0));
                board.putPiece(new King(board, Color.Black), new Position(2,4));

                Screen.PrintScreen(board);
            }
            catch(BoardException e){
                System.Console.WriteLine(e.Message);
            }

        }
    }
}
