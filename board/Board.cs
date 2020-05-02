namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int Lines, int Columns){
            this.Lines = Lines;
            this.Columns = Columns;
            Pieces = new Piece[Lines,Columns];
        }

        public Piece onePiece(int lines, int columns){ //Retorna a peça da posição que foi dada como entrada
            return Pieces[lines, columns];
        }

        public Piece onePiece(Position position){ //Retorna a Posição da peça que foi dado entrada
            return Pieces[position.line, position.column];
        }

        public bool pieceExistance(Position position){
            positionValidation(position);
            return onePiece(position) != null;
        }

        public void putPiece(Piece piece, Position position){ //Método para colocar a peça no tabuleiro
            if(pieceExistance(position)){
                throw new BoardException("Already exist a piece in this position!");
            }
            Pieces[position.line, position.column] = piece; //Coloca a peça na posição definida
            piece.Position = position; //Guarda a posição em que a peça esta
        }

        public Piece removePiece(Position position){
            if(Pieces[position.line, position.column] == null){
                return null;
            }
            Piece aux = onePiece(position);
            aux.Position = null;
            Pieces[position.line, position.column] = null;
            return aux;
        }

        public bool validPosition(Position position){ //Método para verificar se o numero da linha e/ou da coluna existe no tabuleiro
            if(position.line < 0 || position.line >= Lines || position.column < 0 || position.column >= Columns){
                return false;
            }
            return true;
        }

        public void positionValidation(Position position){ //Método para lançar uma exceção de que a posição não existe no tabuleiro
            if(!validPosition(position)){ //A exclamação faz com que o 'se' seja acionado caso o retorno do método ValidPosition seja falso
                throw new BoardException("Invalid position!");
            }
        }

    }
}