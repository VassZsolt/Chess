using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Queen
    {
        public bool is_possibe_move(Coordinate from, Coordinate to)
        {
            bool possible = true;
            int i = 0;    //used as row in loops
            int j = 0;    //used as column in loops
            int count_of_hit = 0;
            ChessPiece[,] board = GameLogicManager.board;

            i = from.Row;
            j = from.Column;

            #region _like_a_rook
            if (from.Row == to.Row && from.Column != to.Column              //is a horizontal moving?
             || from.Row != to.Row && from.Column == to.Column)             //is a vertical moving?
            {
                if (i < to.Row && from.Column == to.Column) //Moving Up
                {
                    do
                    {
                        if (board[i + 1, to.Column] is not null && possible)
                        {
                            if (board[from.Row, to.Column].Color == PieceColor.Black && board[i + 1, to.Column].Color == PieceColor.White && i + 1 == to.Row     //Move after hit is ignored by felt 3
                             || board[from.Row, to.Column].Color == PieceColor.White && board[i + 1, to.Column].Color == PieceColor.Black && i + 1 == to.Row)    //Move after hit is ignored by felt 3
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
                        if (board[i + 1, to.Column] is null && possible)
                        {
                            possible = true;
                        }
                        i++;
                    } while (i < to.Row);
                }

                if (i > to.Row && from.Column == to.Column) //Moving Down
                {
                    do
                    {
                        if (board[i - 1, to.Column] is not null && possible)
                        {
                            if (board[from.Row, to.Column].Color == PieceColor.Black && board[i - 1, to.Column].Color == PieceColor.White && i - 1 == to.Row
                             || board[from.Row, to.Column].Color == PieceColor.White && board[i - 1, to.Column].Color == PieceColor.Black && i - 1 == to.Row)
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
                        if (board[i - 1, to.Column] is null && possible)
                        {
                            possible = true;
                        }
                        i--;
                    } while (i > to.Row);
                }

                if (from.Row == to.Row && j < to.Column) //Moving Right
                {
                    do
                    {
                        if (board[to.Row, j + 1] is not null && possible)
                        {
                            if (board[to.Row, from.Column].Color == PieceColor.Black && board[to.Row, j + 1].Color == PieceColor.White && j + 1 == to.Column
                             || board[to.Row, from.Column].Color == PieceColor.White && board[to.Row, j + 1].Color == PieceColor.Black && j + 1 == to.Column)
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
                        if (board[to.Row, j + 1] is null && possible)
                        {
                            possible = true;
                        }
                        j++;
                    } while (j < to.Column);
                }

                if (from.Row == to.Row && j > to.Column) //Moving Left
                {
                    do
                    {
                        if (board[to.Row, j - 1] is not null && possible)
                        {
                            if (board[to.Row, from.Column].Color == PieceColor.Black && board[to.Row, j - 1].Color == PieceColor.White && j - 1 == to.Column
                             || board[to.Row, from.Column].Color == PieceColor.White && board[to.Row, j - 1].Color == PieceColor.Black && j - 1 == to.Column)
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
                        if (board[to.Row, j - 1] is null && possible)
                        {
                            possible = true;
                        }
                        j--;
                    } while (j > to.Column);
                }
            }
            #endregion
            else
            {
                #region like_a_bishop
                if (to.Row - i == to.Column - j) //is a transverse moving?
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
                            if (board[i - 1, j + 1] is null && possible)
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
                }
                #endregion
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