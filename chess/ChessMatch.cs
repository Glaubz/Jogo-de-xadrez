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
        public bool Check { get; private set; }

        public ChessMatch(){
            board = new Board(8,8);
            _round = 1;
            _currentPlayer = Color.White;
            Finish = false;
            Check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            putPieceS();
        }

        public Piece executeMovement(Position origin, Position destiny){
            Piece p = board.removePiece(origin);
            p.incrementQteMovements();
            Piece capturedPiece = board.removePiece(destiny);
            board.putPiece(p, destiny);
            if(capturedPiece != null){
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMovement(Position origin, Position destiny, Piece capturedPiece){
            Piece p = board.removePiece(destiny);
            p.disproveQteMovements();
            if(capturedPiece != null){
                board.putPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.putPiece(p, origin);
        }

        public void realizeMove(Position origin, Position destiny){
            Piece capturedPiece = executeMovement(origin, destiny);
            if(inCheck(_currentPlayer)){
                undoMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if(inCheck(adversary(_currentPlayer))){
                Check = true;
            }
            else{
                Check = false;
            }

            if(checkmateTest(adversary(_currentPlayer))){
                Finish = true;
            }
            else{
                _round++;
                changePlayer();
            }
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
            if(!board.onePiece(origin).possibleMovemenT(destiny)){
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

        private Color adversary(Color color){
            if(color == Color.White){
                return Color.Black;
            }
            else{
                return Color.White;
            }
        }

        private Piece king(Color color){
            foreach(Piece p in piecesInGame(color)){
                if(p is King){
                    return p;
                }
            }
            return null;
        }

        public bool inCheck(Color color){
            Piece K = king(color);
            if(K == null){
                throw new BoardException("Don't have " + color + "king on the board!");
            }
            foreach(Piece p in piecesInGame(adversary(color))){
                bool[,] matrix = p.possibleMovements();
                if(matrix[K.Position.line, K.Position.column]){
                    return true;
                }
            }
            return false;
        }

        public bool checkmateTest(Color color){
            if(!inCheck(color)){
                return false;
            }
            foreach(Piece p in piecesInGame(color)){
                bool[,] matrix = p.possibleMovements();
                for(int i=0; i<board.Lines; i++){
                    for(int j=0; j<board.Columns; j++){
                        if(matrix[i, j]){
                            Position origin =p.Position;
                            Position destiny = new Position(i,j);
                            Piece capturedPiece = executeMovement(origin, destiny);
                            bool checkTest = inCheck(color);
                            undoMovement(origin, destiny, capturedPiece);
                            if(!checkTest){
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void putPieceS(){
            putNewPiece('a', 1, new Tower(board, Color.White));
            putNewPiece('b', 1, new Horse(board, Color.White));
            putNewPiece('c', 1, new Bishop(board, Color.White));
            putNewPiece('d', 1, new Queen(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White));
            putNewPiece('f', 1, new Bishop(board, Color.White));
            putNewPiece('g', 1, new Horse(board, Color.White));
            putNewPiece('h', 1, new Tower(board, Color.White));
            putNewPiece('a', 2, new Pawn(board, Color.White));
            putNewPiece('b', 2, new Pawn(board, Color.White));
            putNewPiece('c', 2, new Pawn(board, Color.White));
            putNewPiece('d', 2, new Pawn(board, Color.White));
            putNewPiece('e', 2, new Pawn(board, Color.White));
            putNewPiece('f', 2, new Pawn(board, Color.White));
            putNewPiece('g', 2, new Pawn(board, Color.White));
            putNewPiece('h', 2, new Pawn(board, Color.White));

            putNewPiece('a', 8, new Tower(board, Color.Black));
            putNewPiece('b', 8, new Horse(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Horse(board, Color.Black));
            putNewPiece('h', 8, new Tower(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black));
            putNewPiece('b', 7, new Pawn(board, Color.Black));
            putNewPiece('c', 7, new Pawn(board, Color.Black));
            putNewPiece('d', 7, new Pawn(board, Color.Black));
            putNewPiece('e', 7, new Pawn(board, Color.Black));
            putNewPiece('f', 7, new Pawn(board, Color.Black));
            putNewPiece('g', 7, new Pawn(board, Color.Black));
            putNewPiece('h', 7, new Pawn(board, Color.Black));

            /* PARA TESTES
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
            */
        }

    }
}