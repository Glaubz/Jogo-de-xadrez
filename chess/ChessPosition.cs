using board;

namespace chess
{
    class ChessPosition
    {
        public int line { get; set; }
        public char column { get; set; }

        public ChessPosition(int line, char column){
            this.line = line;
            this.column = column;
        }

        public Position toPosition(){
            return new Position(8 - line, column - 'a');
        }

        public override string ToString(){
            return "" + line + column;
        }


    }
}