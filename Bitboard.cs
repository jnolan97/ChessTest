using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessEngineTest
{
    class Bitboard
    {

        public UInt64 Board = 000000000000000000000000000000000000000000000000000000000000000UL;
        public ulong BlackPieces { get; set; }
        public static ulong FileABB = 0101010101010101;
        public static ulong FileCBB = FileABB << 2;
        public static ulong FileDBB = FileABB << 3;
        public static ulong FileBBB = FileABB << 1;
        public static ulong FileEBB = FileABB << 4;
        public static ulong FileFBB = FileABB << 5;
        public static ulong FileGBB = FileABB << 6;
        public static ulong FileHBB = FileABB << 7;

        public static ulong Rank1BB = 255;
        public static ulong Rank2BB = Rank1BB << (8 * 1);
        public static ulong Rank3BB = Rank1BB << (8 * 2);
        public static ulong Rank4BB = Rank1BB << (8 * 3);
        public static ulong Rank5BB = Rank1BB << (8 * 4);
        public static ulong Rank6BB = Rank1BB << (8 * 5);
        public static ulong Rank7BB = Rank1BB << (8 * 6);
        public static ulong Rank8BB = Rank1BB << (8 * 7);
        public UInt64 WP = 0UL, WN = 0UL, WR = 0UL, WB = 0UL, WQ = 0UL, WK = 0UL, BP = 0UL, BN = 0UL, BB = 0UL,
    BR = 0UL, BQ = 0UL, BK = 0UL;

       // public ulong BlackPieces;
        public ulong WhitePieces;

        private static uint[] debruijn64Array = new uint[64]{
            63,  0, 58,  1, 59, 47, 53,  2,
            60, 39, 48, 27, 54, 33, 42,  3,
            61, 51, 37, 40, 49, 18, 28, 20,
            55, 30, 34, 11, 43, 14, 22,  4,
            62, 57, 46, 52, 38, 26, 32, 41,
            50, 36, 17, 19, 29, 10, 13, 21,
            56, 45, 25, 31, 35, 16,  9, 12,
            44, 24, 15,  8, 23,  7,  6,  5
        };
        public static UInt64 ToBinary(string data)
        {
            Console.WriteLine(data.Length);
            return UInt64.Parse(data);
        }
        public void initStandardChess()
        {

            Console.WriteLine(FileHBB);



            var chessBoard = new string[,] {
                {
                    "r","n","b","q","k","b","n","r"
                },
                {
                    "p","p","p","p","p","p","p","p"
                },
                {
                    " "," "," "," "," "," "," "," "
                },
                {
                    " "," "," "," "," "," "," "," "
                },
                {
                    " "," "," "," "," "," "," "," "
                },
                {
                    " "," "," "," "," "," "," "," "
                },
                                {
                    "P","P","P","P","P","P","P","P"
                },
                {
                    "R","N","B","Q","K","B","N","R"
                }
            };
            Console.WriteLine("test " + chessBoard);

            arrayToBitBoard(chessBoard, WP, WN, WR, WB, WQ, WK, BP, BN, BB,
                BR, BQ, BK);
        }

        private void arrayToBitBoard(string[,] chessBoard, ulong wP, ulong wN, ulong wR, ulong wB, ulong wQ, ulong wK, ulong bP, ulong bN, ulong bB, ulong bR, ulong bQ, ulong bK)
        {
            long testbN = 0L;
            string Binary;
            string TotalBin;
            
            TotalBin = "0000000000000000000000000000000000000000000000000000000000000000";


            for (int j = 0; j < 64; j++)
            {
                Binary = "0000000000000000000000000000000000000000000000000000000000000000";
                Binary = Binary.Substring(j + 1) + "1" + Binary.Substring(0, j);
                //Binary = 
                //Console.WriteLine(Binary + " " + chessBoard[j/8,j%8]);
                Console.WriteLine(chessBoard[j / 8, j % 8]);
                //for (int j = 0; j < 8; j++)
                //{

                switch (chessBoard[j / 8, j % 8]) 
                {

                    case "p":

                        Board += convertStringToBitBoard(Binary);
                        bP += convertStringToBitBoard(Binary);
                        break;

                    case "n":
                        Board += convertStringToBitBoard(Binary);
                        bN += convertStringToBitBoard(Binary);
                        break;

                    case "b":

                        Board += convertStringToBitBoard(Binary);
                        bB += convertStringToBitBoard(Binary);
                        break;

                    case "r":
                        Board += convertStringToBitBoard(Binary);
                        bR += convertStringToBitBoard(Binary);
                        break;

                    case "q":

                        Board += convertStringToBitBoard(Binary);
                        bQ += convertStringToBitBoard(Binary);
                        break;

                    case "k":
                        Board += convertStringToBitBoard(Binary);
                        bK += convertStringToBitBoard(Binary);
                        break;
                };
 
                    
                
                Console.WriteLine("Boards: " + Board + " " +bP + "/n" + bN + " " + bR + " " + bB + " " + bQ + " " + bK );

                


     
   
            }
            drawArray(wP, wN, wR, wB, wQ, wK, bP, bN, bB, bR, bQ, bK);
        }

        public ulong test(ulong Rank8BB,ulong Rank7BB)
        {
            //ulong test;
            while (Rank8BB != 0)
                {
                ulong c = Rank8BB & Rank7BB;
                            Rank8BB = Rank8BB ^ Rank7BB;
                            c = c << 1;
                Rank7BB = c;
                        }
            return Rank8BB;
        }

        public void drawArray(ulong wP, ulong wN, ulong wR, ulong wB, ulong wQ, ulong wK, ulong bP, ulong bN, ulong bB, ulong bR, ulong bQ, ulong bK)
        {
            var chessBoard = new string[8, 8];
            for (int i = 0; i < 64; i++)
            {
                chessBoard[i / 8, i % 8] = " ";
            }

            for (int i = 0; i < 64; i++)
            {
                if (((wP) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "P";
                }
                if (((wN) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "N";
                }
                if (((wR) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "R";
                }
                if (((wB) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "B";
                }
                if (((wQ) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "Q";
                }
                if (((wK) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "K";
                }
                if (((bP) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "p";
                }
                if (((bN) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "n";
                }
                if (((bR) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "r";
                }
                if (((bB) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "b";
                }
                if (((bQ) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "q";
                }
                if (((bK) >> i & 1) == 1)
                {
                    chessBoard[i / 8, i % 8] = "k";
                }
            }
            Console.WriteLine("chessboard" + chessBoard.ToString());
        }

        static public ulong getBitCountFromBitboard(ulong bitboard)
        {
            //ulong i = 0UL;
            const long debruijn64 = (long)(0x07EDD5E59A4E28C2);
            return debruijn64Array[(ulong)(getBitboardLSB(bitboard) * debruijn64) >> 58];
            //ulong k = 1;
            //if (bitboard != 0)
            //{
            //    do
            //    {
            //        Math.Pow(k,2);
            //    } while ((bitboard &= bitboard - 1) != 0); // reset LS1B 
            //}
            //return k;
        }
        static public ulong getBitboardLSB(ulong bitboard)
        {
            return ((ulong)((long)bitboard & -(long)bitboard));
        }

        private ulong convertStringToBitBoard(string binary)
        {
            Console.WriteLine(binary);
            
            if (binary[0] == '0')
            {
                UInt64 returnval = UInt64.Parse(binary);
                return returnval;
            } else { 
                return UInt64.Parse("1" + binary.Substring(2), System.Globalization.NumberStyles.Integer) * 2;
            }
        }

    }
}
