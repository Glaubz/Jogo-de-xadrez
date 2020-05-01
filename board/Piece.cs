using board.Enums;

namespace board
{
    class Piece
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
    }
}