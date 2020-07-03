using board;
using board.Enums;

namespace chess
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color){
        }

        public override string ToString(){
            return "H";
        }

        private bool canMove(Position position){
            Piece p = board.onePiece(position);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements(){
            bool[,] matrix = new bool[board.Lines, board.Columns];

            Position position = new Position(0,0);

            position.defineValues(position.line - 1, position.column - 2);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            position.defineValues(position.line - 2, position.column - 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            position.defineValues(position.line - 2, position.column + 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            position.defineValues(position.line - 1, position.column + 2);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            position.defineValues(position.line + 1, position.column + 2);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            position.defineValues(position.line + 2, position.column + 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            position.defineValues(position.line + 2, position.column - 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            position.defineValues(position.line + 1, position.column - 2);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            return matrix;
        }

    }
}