using board.Enums;

namespace board
{
    class Pawn
    {
        public Positions Position { get; set; }
        public Color color { get; set; }
        public int qteMovements { get; protected set; }
        public Board board { get; set; }

        public Pawn(Positions position, Board board, Color color){
            Position = position;
            this.board = board;
            this.color = color;
            qteMovements = 0;
        }
    }
}