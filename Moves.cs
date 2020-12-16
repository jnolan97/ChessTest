using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTest
{
    class Moves
    {
        //private object boardObj = Program.bitboard;
        private ulong fileA = Bitboard.FileABB;
        private ulong rank8 = Bitboard.Rank8BB;
        private ulong WP = Program.bitboard.WP;
        private ulong BPieces = Program.bitboard.BlackPieces;
        //static void Main()
        //{
        //    // bitboard.initStandardChess();
        //    Program.bitboard.initStandardChess();
            
        //}

        //shift 8, shift 16, shift 7, shift 9
        public ulong whitePawnMoves(string previous, ulong WP, ulong BPieces)
        {
            string prev = "";
            ulong PawnCapRight = (WP >> 7) & ~fileA & ~rank8 & BPieces;
            return BPieces;

            //if(((WP) >> 7 & 1) == 1)
            //{

        }

        public string whiteKnightMoves(string previous, ulong WN)
        {
            //TODO: Implement

            return previous;
        }
    }
}
