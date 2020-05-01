using board.Enums;
using System;

namespace board
{
    class Screen
    {
        public static void printBoard(Board board){
            for(int i=0; i<board.Lines; i++){
                System.Console.Write(8 - i + " "); //Numerando as linhas
                for(int j=0; j<board.Columns; j++){
                    if(board.onePiece(i, j) == null){
                        System.Console.Write("- ");
                    }
                    else{
                        printPiece(board.onePiece(i, j));
                        System.Console.Write(" ");
                    }
                }
                System.Console.WriteLine(); //Quebrar linha
            }
            System.Console.WriteLine("  a b c d e f g h");
        }

        public static void printPiece(Piece piece){
            if(piece.color == Color.White){
                Console.Write(piece);
            }
            else{
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(piece);
                Console.ForegroundColor = aux; //Volta para a cor original
            }
        }

    }
}