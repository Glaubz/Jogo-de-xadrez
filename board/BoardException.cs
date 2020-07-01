using System;

namespace board
{
    class BoardException : Exception
    {
        public BoardException(string e) : base(e){
            
        }
    }
}