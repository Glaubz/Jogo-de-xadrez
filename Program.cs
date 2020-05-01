using board;
using board.Enums;
using chess;

namespace PROJETO_XADREZ
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition position = new ChessPosition(7, 'c');

            System.Console.WriteLine(position);

            System.Console.WriteLine(position.toPosition());

            System.Console.WriteLine();

        }

    }
}
