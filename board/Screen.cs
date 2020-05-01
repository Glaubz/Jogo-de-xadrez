namespace board
{
    class Screen
    {
        public static void PrintScreen(Board board){
            for(int i=0; i<board.Lines; i++){
                for(int j=0; j<board.Columns; j++){
                    if(board.onePiece(i, j) == null){
                        System.Console.Write("- ");
                    }
                    else{
                        System.Console.Write(board.onePiece(i, j) + " ");
                    }
                }
                System.Console.WriteLine(); //Quebrar linha
            }
            

        }
    }
}