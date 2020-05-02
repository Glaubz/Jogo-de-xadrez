using board;
using board.Enums;
using System;
using chess;

namespace board
{
    class Screen
    {
        public static void printBoard(Board board){
                for(int i=0; i<board.Lines; i++){
                System.Console.Write(8 - i + " "); //Numerando as linhas
                for(int j=0; j<board.Columns; j++){
                    printPiece(board.onePiece(i, j));
                }
                System.Console.WriteLine(); //Quebrar linha
            }
            System.Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possibleMovements){
            ConsoleColor backOriginal = Console.BackgroundColor;
            ConsoleColor backModified = ConsoleColor.DarkGray;

            for(int i=0; i<board.Lines; i++){
                System.Console.Write(8 - i + " "); //Numerando as linhas
                for(int j=0; j<board.Columns; j++){
                    if(possibleMovements[i, j]){
                        Console.BackgroundColor = backModified;
                    }
                    else{
                        Console.BackgroundColor = backOriginal;
                    }
                    printPiece(board.onePiece(i, j));
                    Console.BackgroundColor = backOriginal;
                }
                System.Console.WriteLine(); //Quebrar linha
            }
            System.Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = backOriginal;
        }

        public static ChessPosition readChessPosition(){
            string s = Console.ReadLine();
            int line = int.Parse(s[0] + "");
            char column = s[1];
            return new ChessPosition(line, column);
        }

        public static void printPiece(Piece piece){

            if(piece == null){ //board.onePiece(i, j) tirei e coloquei somente piece no local
                System.Console.Write("- ");
            }
            else{
                if(piece.color == Color.White){
                    Console.Write(piece);
                }
                else{
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = aux; //Volta para a cor original
                }
                System.Console.Write(" ");
            }

        }

    }
}