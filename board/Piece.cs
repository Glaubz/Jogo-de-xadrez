using board.Enums;

namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color color { get; protected set; }
        public int qtMovements { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Color color){
            Position = null;
            this.board = board;
            this.color = color;
            qtMovements = 0;
        }

        public void incrementQteMovements(){
            qtMovements++;
        }

        public void disproveQteMovements(){
            qtMovements--;
        }

        public bool existPossibleMovements(){
            bool[,] matrix = possibleMovements();
            for(int i=0; i<board.Lines; i++){
                for(int j=0; j<board.Columns; j++){
                    if(matrix[i,j]) return true;
                }
            }
            return false;
        }

        public bool canMoveFor(Position position){
            return possibleMovements()[position.line, position.column];
        }

        public abstract bool[,] possibleMovements();

    }
}