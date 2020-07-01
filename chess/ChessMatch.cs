using board;
using board.Enums;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int _round { get; private set; }
        public Color _currentPlayer { get; private set; }
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

        public void realizeMove(Position origin, Position destiny){
            executeMovement(origin, destiny);
            _round++;
            changePlayer();
        }

        public void validateOriginPosition(Position position){
            if(board.onePiece(position) == null){
                throw new BoardException("Doesn't exist piece in the choosed position!");
            }
            if(_currentPlayer != board.onePiece(position).color){
                throw new BoardException("The current position not belong you!");
            }
            if(!board.onePiece(position).existPossibleMovements()){
                throw new BoardException("Don't have possible movements to the choosed piece!");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny){
            if(!board.onePiece(origin).canMoveFor(destiny)){
                throw new BoardException("Destiny position not is valid!");
            }
        }

        private void changePlayer(){
            if(_currentPlayer == Color.White){
                _currentPlayer = Color.Black;
            }
            else{
                _currentPlayer = Color.White;
            }
        }

        private void putPieceS(){
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d', 8).toPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).toPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('f', 8).toPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.putPiece(new Tower(board, Color.Black), new ChessPosition('f', 7).toPosition());

            board.putPiece(new Tower(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('d', 1).toPosition());
            board.putPiece(new King(board, Color.White), new ChessPosition('e', 1).toPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('f', 1).toPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.putPiece(new Tower(board, Color.White), new ChessPosition('f', 2).toPosition());
        }

    }
}