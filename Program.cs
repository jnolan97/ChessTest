using System;

namespace ChessEngineTest
{
    class Program
    {
        public static Bitboard bitboard;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             bitboard = new Bitboard();
            bitboard.initStandardChess();
            
        }
    }
}
