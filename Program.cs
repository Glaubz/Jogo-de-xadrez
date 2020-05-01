﻿using System;
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

            board.PutPawn(new Tower(board, Color.Black), new Position(0,0));
            board.PutPawn(new Tower(board, Color.Black), new Position(1,3));
            board.PutPawn(new King(board, Color.Black), new Position(2,4));

            Screen.PrintScreen(board);
        }
    }
}
