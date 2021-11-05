using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Rook
    {
        public bool is_possible_move(Coordinate from, Coordinate to)
        {
            bool possible = true;
            int i = 0; //used as row or column in loops
            int count_of_hit = 0;
            ChessPiece[,] board = GameLogicManager.board;

            if (from.Row != to.Row && from.Column != to.Column) //Ignore transverse move
            {
                possible = false;
                return possible;
            }
            i = from.Row;
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

            i = from.Column;
            if (from.Row == to.Row && i < to.Column) //Moving Right
            {
                do
                {
                    if (board[to.Row, i + 1] is not null && possible)
                    {
                        if (board[to.Row, from.Column].Color == PieceColor.Black && board[to.Row, i + 1].Color == PieceColor.White && i + 1 == to.Column
                         || board[to.Row, from.Column].Color == PieceColor.White && board[to.Row, i + 1].Color == PieceColor.Black && i + 1 == to.Column)
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
                    if (board[to.Row, i + 1] is null && possible)
                    {
                        possible = true;
                    }
                    i++;
                } while (i < to.Column);
            }

            if (from.Row == to.Row && i > to.Column) //Moving Left
            {
                do
                {
                    if (board[to.Row, i - 1] is not null && possible)
                    {
                        if (board[to.Row, from.Column].Color == PieceColor.Black && board[to.Row, i - 1].Color == PieceColor.White && i - 1 == to.Column
                         || board[to.Row, from.Column].Color == PieceColor.White && board[to.Row, i - 1].Color == PieceColor.Black && i - 1 == to.Column)
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
                    if (board[to.Row, i - 1] is null && possible)
                    {
                        possible = true;
                    }
                    i--;
                } while (i > to.Column);
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
