using System;
using board;

namespace PROJETO_XADREZ
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            Screen.PrintScreen(board);
        }
    }
}
