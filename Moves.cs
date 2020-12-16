using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTest
{
    class Moves : Bitboard
    {
        
        private ulong fileA = Bitboard.FileABB;
        private ulong rank8 = Bitboard.Rank8BB;
        void Main()
        {
            // bitboard.initStandardChess();
            Program.bitboard.initStandardChess();
            
        }

        //shift 8, shift 16, shift 7, shift 9
        public string whitePawnMoves(string previous, ulong WP)
        {
            string prev = "";
            ulong PawnCapRight = (WP >> 7) & ~fileA & ~rank8;

            //if(((WP) >> 7 & 1) == 1)
            //{

            //}
            return prev; 
        }

        public string whiteKnightMoves(string previous, ulong WN)
        {
            //TODO: Implement

            return previous;
        }
    }
}
