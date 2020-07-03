using board;
using board.Enums;

namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color){
        }

        public override string ToString(){
            return "B";
        }

        private bool canMove(Position position){
            Piece p = board.onePiece(position);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements(){
            bool[,] matrix = new bool[board.Lines, board.Columns];

            Position position = new Position(0,0);

            position.defineValues(position.line - 1, position.column - 1);
            while(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
                if(board.onePiece(position) != null && board.onePiece(position).color != color){
                    break;
                }
                position.defineValues(position.line - 1, position.column - 1);
            }

            position.defineValues(position.line - 1, position.column + 1);
            while(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
                if(board.onePiece(position) != null && board.onePiece(position).color != color){
                    break;
                }
                position.defineValues(position.line - 1, position.column + 1);
            }

            position.defineValues(position.line + 1, position.column + 1);
            while(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
                if(board.onePiece(position) != null && board.onePiece(position).color != color){
                    break;
                }
                position.defineValues(position.line + 1, position.column + 1);
            }

            position.defineValues(position.line + 1, position.column - 1);
            while(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
                if(board.onePiece(position) != null && board.onePiece(position).color != color){
                    break;
                }
                position.defineValues(position.line + 1, position.column - 1);
            }

            return matrix;
        }
        
    }
}