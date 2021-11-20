using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    internal class Bishop
    {
        internal bool is_possible_move(Coordinate from, Coordinate to)
        {
            bool possible = true;
            int i = 0; //used as row in loops
            int j = 0; //used as column in loops
            int count_of_hit = 0;
            ChessPiece[,] board = GameLogicManager.board;

            if (from.Row != to.Row && from.Column == to.Column  //Ignore vertical move
             || from.Row == to.Row && from.Column != to.Column) //Ignore horizontal move
            {
                possible = false;
                return possible;
            }
            i = from.Row;
            j = from.Column;
            if (Math.Abs(to.Row - i) == Math.Abs(to.Column - j))
            {
                if (i < to.Row && j < to.Column) //Moving Up-Right
                {
                    do
                    {
                        if (board[i + 1, j + 1] is not null && possible)
                        {
                            if (board[from.Row, from.Column].Color == PieceColor.Black && board[i + 1, j + 1].Color == PieceColor.White && i + 1 == to.Row     //Move after hit is ignored by felt 3
                             || board[from.Row, from.Column].Color == PieceColor.White && board[i + 1, j + 1].Color == PieceColor.Black && i + 1 == to.Row)    //Move after hit is ignored by felt 3
                            {
                                possible = true;
                                count_of_hit++;  //Hit ignored after 'hit'
                            }
                            else
                            {
                                possible = false;
                                return possible;
                            }
                        }
                        if (board[i + 1, j + 1] is null && possible)
                        {
                            possible = true;
                        }
                        i++;
                        j++;
                    } while (i < to.Row && from.Column < to.Column);
                }

                if (i < to.Row && j > to.Column) //Moving Up-Left
                {
                    do
                    {
                        if (board[i + 1, j - 1] is not null && possible)
                        {
                            if (board[from.Row, from.Column].Color == PieceColor.Black && board[i + 1, j - 1].Color == PieceColor.White && i + 1 == to.Row
                             || board[from.Row, from.Column].Color == PieceColor.White && board[i + 1, j - 1].Color == PieceColor.Black && i + 1 == to.Row)
                            {
                                possible = true;
                                count_of_hit++;
                            }
                            else
                            {
                                possible = false;
                                return possible;
                            }
                        }
                        if (board[i + 1, j - 1] is null && possible)
                        {
                            possible = true;
                        }
                        i++;
                        j--;
                    } while (i < to.Row && j > to.Column);
                }

                if (i > to.Row && j < to.Column) //Moving Down-Right
                {
                    do
                    {
                        if (board[i - 1, j + 1] is not null && possible)
                        {
                            if (board[from.Row, from.Column].Color == PieceColor.Black && board[i - 1, j + 1].Color == PieceColor.White && i - 1 == to.Row
                             || board[from.Row, from.Column].Color == PieceColor.White && board[i - 1, j + 1].Color == PieceColor.Black && i - 1 == to.Row)
                            {
                                possible = true;
                                count_of_hit++;
                            }
                            else
                            {
                                possible = false;
                                return possible;
                            }
                        }
                        if (board[i - 1, j + 1] is null && possible)
                        {
                            possible = true;
                        }
                        i--;
                        j++;
                    } while (i > to.Row && j < to.Column);
                }

                if (i > to.Row && j > to.Column) //Moving Down-Left
                {
                    do
                    {
                        if (board[i - 1, j - 1] is not null && possible)
                        {
                            if (board[from.Row, from.Column].Color == PieceColor.Black && board[i - 1, j - 1].Color == PieceColor.White && i - 1 == to.Row
                             || board[from.Row, from.Column].Color == PieceColor.White && board[i - 1, j - 1].Color == PieceColor.Black && i - 1 == to.Row)
                            {
                                possible = true;
                                count_of_hit++;
                            }
                            else
                            {
                                possible = false;
                                return possible;
                            }
                        }
                        if (board[i - 1, j - 1] is null && possible)
                        {
                            possible = true;
                        }
                        i--;
                        j--;
                    } while (i > to.Row && j > to.Column);
                }
            }
            else
            {
                possible = false;
                return possible;
            }
            if (possible && count_of_hit < 2)
            {
                possible = true;
            }
            else
            {
                possible = false;
            }
            return possible;
        }
    }
}
