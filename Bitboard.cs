using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessEngineTest
{
    class Bitboard
    {

        public static ulong  FileABB = 0101010101010101;
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


        public ulong WP = 0L, WN = 0L, WR = 0L, WB = 0L, WQ = 0L, WK = 0L, BP = 0L, BN = 0L, BB = 0L,
    BR = 0L, BQ = 0L, BK = 0L;

        public string ToBinary(string data)
        {
            string result = string.Empty;
            foreach (char ch in data)
            {
                result += Convert.ToString((int)ch, 2);
            }
            return result;
        }

        public void initStandardChess()
        {


            //var binaryString = ToBinary("000000000000000000000000000000000000000000000000000000000000000");

            //Console.WriteLine(ToBinary("000000000000000000000000000000000000000000000000000000000000000"));

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
            Console.WriteLine("test "+chessBoard);

            arrayToBitBoard(chessBoard, WP, WN, WR, WB, WQ, WK, BP, BN, BB,
                BR, BQ, BK); 
        }

        private void arrayToBitBoard(string[,] chessBoard, ulong wP, ulong wN, ulong wR, ulong wB, ulong wQ, ulong wK, ulong bP, ulong bN, ulong bB, ulong bR, ulong bQ, ulong bK)
        {
            string Binary;
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {


                    Binary = "0000000000000000000000000000000000000000000000000000000000000000";
                    Binary = Binary.Substring(i + 1) + "1" + Binary.Substring(0, i);
                    Console.WriteLine(chessBoard[i, j]);
                    switch (chessBoard[i/8, j % 8])
                    {
                        case "P":
                            wP += convertStringToBitBoard(Binary);
                            break;
                        case "N":
                            wN += convertStringToBitBoard(Binary);
                            break;
                        case "B":
                            wB += convertStringToBitBoard(Binary);
                            break;
                        case "R":
                            wR += convertStringToBitBoard(Binary);
                            break;
                        case "Q":
                            wQ += convertStringToBitBoard(Binary);
                            break;
                        case "K":
                            wK += convertStringToBitBoard(Binary);
                            break;
                        case "p":
                            bP += convertStringToBitBoard(Binary);
                            break;
                        case "n":
                            bN += convertStringToBitBoard(Binary);
                            break;
                        case "r":
                            bR += convertStringToBitBoard(Binary);
                            break;
                        case "b":
                            bB += convertStringToBitBoard(Binary);
                            break;
                        case "q":
                            bQ += convertStringToBitBoard(Binary);
                            break;
                        case "k":
                            bK += convertStringToBitBoard(Binary);
                            break;

                    }
                }
            }
            drawArray(wP, wN, wR, wB, wQ, wK, bP, bN, bB, bR, bQ, bK);
        }

        public void drawArray(ulong wP, ulong wN, ulong wR, ulong wB, ulong wQ, ulong wK, ulong bP, ulong bN, ulong bB, ulong bR, ulong bQ, ulong bK)
        {
            var chessBoard = new string[8, 8];
            for(int i = 0; i < 64; i++)
            {
                chessBoard[i / 8, i % 8] = " ";
            }

            for(int i = 0; i < 64; i++)
            {
                if(((wP)>>i&1)== 1)
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
            Console.WriteLine("chessboard"+chessBoard);
        }

        private ulong convertStringToBitBoard(string binary)
        {
            //char c = '0';
            Console.WriteLine("substring "+binary.Substring(0, 1)+ " end");
           // ulong bin = 0;
            if((binary[0]) == '0')
            {
                return Convert.ToUInt64(binary);
               // Console.WriteLine("bin "+bin);
                //ulong converter = (ulong)bin;
                //Console.Write(converter);
                //return Convert.ToInt64(converter);
                //return bin;
            } else
            {
                return Convert.ToUInt64("1" + binary.Substring(2)) * 2;
            }
        }
    }
}
