﻿using board;
using board.Enums;
using chess;

namespace PROJETO_XADREZ
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Board board = new Board(8, 8);

                board.putPiece(new Tower(board, Color.Black), new Position(0,0));
                board.putPiece(new Tower(board, Color.Black), new Position(1,3));
                board.putPiece(new King(board, Color.Black), new Position(0,2));

                board.putPiece(new Tower(board, Color.White), new Position(3,5));

                Screen.printBoard(board);
            }
            catch(BoardException e){
                System.Console.WriteLine(e.Message);
            }

        }

    }
}
