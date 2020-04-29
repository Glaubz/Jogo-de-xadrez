namespace board
{
    class Screen
    {
        public static void PrintScreen(Board board){
            for(int i=0; i<board.lines; i++){
                for(int j=0; j<board.columns; j++){
                    if(board.OnePawn(i, j) == null){
                        System.Console.Write("- ");
                    }
                    else{
                        System.Console.WriteLine(board.OnePawn(i, j));
                    }
                }
                System.Console.WriteLine(); //Quebrar linha
            }
            

        }
    }
}