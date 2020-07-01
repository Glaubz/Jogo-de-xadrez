using System.Collections.Generic;
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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch(){
            board = new Board(8,8);
            _round = 1;
            _currentPlayer = Color.White;
            Finish = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieceS();
        }

        public void executeMovement(Position origin, Position destiny){
            Piece p = board.removePiece(origin);
            p.incrementQteMovements();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if(capturedPiece != null){
                captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> capturedPieces(Color color){
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece p in captured){
                if(p.color == color){
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color){
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece p in pieces){
                if(p.color == color){
                    aux.Add(p);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        public void putNewPiece(char column, int line, Piece piece){
            board.putPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void putPieceS(){
            putNewPiece('c', 1, new Tower(board, Color.White));
            putNewPiece('d', 1, new Tower(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White));
            putNewPiece('f', 1, new Tower(board, Color.White));
            putNewPiece('c', 2, new Tower(board, Color.White));
            putNewPiece('d', 2, new Tower(board, Color.White));
            putNewPiece('e', 2, new Tower(board, Color.White));
            putNewPiece('f', 2, new Tower(board, Color.White));

            putNewPiece('c', 8, new Tower(board, Color.Black));
            putNewPiece('d', 8, new King(board, Color.Black));
            putNewPiece('e', 8, new Tower(board, Color.Black));
            putNewPiece('f', 8, new Tower(board, Color.Black));
            putNewPiece('c', 7, new Tower(board, Color.Black));
            putNewPiece('d', 7, new Tower(board, Color.Black));
            putNewPiece('e', 7, new Tower(board, Color.Black));
            putNewPiece('f', 7, new Tower(board, Color.Black));
        }

    }
}