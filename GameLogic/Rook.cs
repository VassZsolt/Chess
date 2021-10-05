using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Rook
    {
        public bool is_possibe_move(int f_row, int f_column, int t_row, int t_column)
        {
            bool possible = true;
            int i = 0;
            int db = 0;
            ChessPiece[,] board = GameLogicManager.board;

            if (f_row != t_row && f_column != t_column) //Ignore transverse move
            {
                possible = false;
            }
            i = f_row;
            if (i < t_row && f_column == t_column) //Moving Up
            {
                do
                {
                    if (board[i + 1, t_column] is not null && possible)
                    {
                        if (board[f_row, t_column].Color == PieceColor.Black && board[i + 1, t_column].Color == PieceColor.White && i + 1 == t_row
                         || board[f_row, t_column].Color == PieceColor.White && board[i + 1, t_column].Color == PieceColor.Black && i + 1 == t_row)
                        {
                            possible = true;
                            db++;
                        }
                        else
                        {
                            possible = false;
                        }
                    }
                    if (board[i + 1, t_column] is null && possible)
                    {
                        possible = true;
                    }
                    i++;
                } while (i < t_row);
            }

            if (i > t_row && f_column == t_column) //Moving Down
            {
                do
                {
                    if (board[i - 1, t_column] is not null && possible)
                    {
                        if (board[f_row, t_column].Color == PieceColor.Black && board[i - 1, t_column].Color == PieceColor.White && i - 1 == t_row
                         || board[f_row, t_column].Color == PieceColor.White && board[i - 1, t_column].Color == PieceColor.Black && i - 1 == t_row)
                        {
                            possible = true;
                            db++;
                        }
                        else
                        {
                            possible = false;
                        }
                    }
                    if (board[i - 1, t_column] is null && possible)
                    {
                        possible = true;
                    }
                    i--;
                } while (i > t_row);
            }

            i = f_column;
            if (f_row == t_row && f_column < t_column) //Moving Right
            {
                do
                {
                    if (board[t_row, i + 1] is not null && possible)
                    {
                        if (board[t_row, f_column].Color == PieceColor.Black && board[t_row, i + 1].Color == PieceColor.White && i + 1 == t_column
                         || board[t_row, f_column].Color == PieceColor.White && board[t_row, i + 1].Color == PieceColor.Black && i + 1 == t_column)
                        {
                            possible = true;
                            db++;
                        }
                        else
                        {
                            possible = false;
                        }
                    }
                    if (board[t_row, i + 1] is null && possible)
                    {
                        possible = true;
                    }
                    i++;
                } while (i < t_row);
            }

            if (f_row == t_row && f_column > t_column) //Moving Left
            {
                do
                {
                    if (board[t_row, i - 1] is not null && possible)
                    {
                        if (board[t_row, f_column].Color == PieceColor.Black && board[t_row, i - 1].Color == PieceColor.White && i - 1 == t_column
                         || board[t_row, f_column].Color == PieceColor.White && board[t_row, i - 1].Color == PieceColor.Black && i - 1 == t_column)
                        {
                            possible = true;
                            db++;
                        }
                        else
                        {
                            possible = false;
                        }
                    }
                    if (board[t_row, i - 1] is null && possible)
                    {
                        possible = true;
                    }
                    i--;
                } while (i > t_row);
            }
            if (possible && db < 2)
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
