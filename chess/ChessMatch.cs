using board;
using board.Enums;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int _round;
        private Color _currentPlayer;
        public bool Finish { get; private set; }

        public ChessMatch(){
            board = new Board(8,8);
            _round = 1;
            _currentPlayer = Color.White;
            putPieceS();
            Finish = false;
        }

        public void executeMovement(Position origin, Position destiny){
            Piece p = board.removePiece(origin);
            p.incrementQteMovements();
            Piece CapturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
        }

        private void putPieceS(){
            board.putPiece(new Tower(board, Color.Black), new ChessPosition(8, 'c').toPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition(8, 'd').toPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition(8, 'e').toPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition(8, 'f').toPosition());

            board.putPiece(new Tower(board, Color.White), new ChessPosition(1, 'c').toPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition(1, 'd').toPosition());
            board.putPiece(new King(board, Color.White), new ChessPosition(1, 'e').toPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition(1, 'f').toPosition());
        }

    }
}