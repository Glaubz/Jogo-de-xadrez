namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Pawn[,] Pawns;

        public Board(int lines, int columns){
            this.lines = lines;
            this.columns = columns;
            Pawns = new Pawn[lines,columns];
        }

        public Pawn OnePawn(int lines, int columns){
            return Pawns[lines, columns];
        }

    }
}