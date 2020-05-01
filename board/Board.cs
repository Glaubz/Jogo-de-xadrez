namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns){
            this.lines = lines;
            this.columns = columns;
            Pieces = new Piece[lines,columns];
        }

        public Piece OnePiece(int lines, int columns){
            return Pieces[lines, columns];
        }

        public void PutPawn(Piece piece, Position position){ //Método para colocar a peça no tabuleiro
            Pieces[position.line, position.column] = piece; //Coloca a peça na posição definida
            piece.Position = position; //Guarda a posição em que a peça esta
        }

    }
}