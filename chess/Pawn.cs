using board;
using board.Enums;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color){
        }

        public override string ToString(){
            return "P";
        }

        private bool existEnemy(Position position){
            Piece p = board.onePiece(position);
            return p != null && p.color != color;
        }

        private bool free(Position position){
            return board.onePiece(position) == null;
        }

        public override bool[,] possibleMovements(){
            bool[,] matrix = new bool[board.Lines, board.Columns];

            Position position = new Position(0,0);

            if(color == Color.White){
                position.defineValues(position.line - 1, position.column);
                if(board.validPosition(position) && free(position)){
                    matrix[position.line, position.column] = true;
                }

                position.defineValues(position.line - 2, position.column);
                if(board.validPosition(position) && free(position) && qtMovements == 0){
                    matrix[position.line, position.column] = true;
                }

                position.defineValues(position.line - 1, position.column - 1);
                if(board.validPosition(position) && existEnemy(position)){
                    matrix[position.line, position.column] = true;
                }

                position.defineValues(position.line - 1, position.column + 1);
                if(board.validPosition(position) && existEnemy(position)){
                    matrix[position.line, position.column] = true;
                }
            }
            else{
                position.defineValues(position.line + 1, position.column);
                if(board.validPosition(position) && free(position)){
                    matrix[position.line, position.column] = true;
                }

                position.defineValues(position.line + 2, position.column);
                if(board.validPosition(position) && free(position) && qtMovements == 0){
                    matrix[position.line, position.column] = true;
                }

                position.defineValues(position.line + 1, position.column - 1);
                if(board.validPosition(position) && existEnemy(position)){
                    matrix[position.line, position.column] = true;
                }

                position.defineValues(position.line + 1, position.column + 1);
                if(board.validPosition(position) && existEnemy(position)){
                    matrix[position.line, position.column] = true;
                }
            }
            return matrix;
        }

    }
}