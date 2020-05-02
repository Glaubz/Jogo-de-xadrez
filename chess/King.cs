using board;
using board.Enums;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) {

        }

        public override string ToString(){
            return "R";
        }

        private bool canMove(Position position){
            Piece p = board.onePiece(position);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements(){
            bool[,] matrix = new bool[board.Lines, board.Columns];

            Position position = new Position(0,0);

            //above
            position.defineValues(position.line - 1, position.column);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            //northeast
            position.defineValues(position.line - 1, position.column + 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            //right
            position.defineValues(position.line, position.column + 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            //southeast
            position.defineValues(position.line + 1, position.column + 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            //below
            position.defineValues(position.line + 1, position.column);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            //southwest
            position.defineValues(position.line + 1, position.column - 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            //left
            position.defineValues(position.line, position.column - 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            //northwest
            position.defineValues(position.line - 1, position.column - 1);
            if(board.validPosition(position) && canMove(position)){
                matrix[position.line, position.column] = true;
            }

            return matrix;

        }


    }
}