using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Pawn
    {
        public bool is_possibe_move(int f_row, int f_column, int t_row, int t_column)
        {
            bool possible = true;
            ChessPiece[,] board = GameLogicManager.board;

            if (board[t_row, t_column] is null)
            {
                if (board[f_row, f_column].Color == PieceColor.Black && f_row == t_row - 1 && f_column == t_column                   //Black Pawn move 1 up
                || board[f_row, f_column].Color == PieceColor.Black && f_row == t_row - 2 && f_column == t_column && f_row == 1      //Black Pawn move 2 up
                || board[f_row, f_column].Color == PieceColor.White && f_row == t_row + 1 && f_column == t_column                    //White Pawn move 1 down
                || board[f_row, f_column].Color == PieceColor.White && f_row == t_row + 2 && f_column == t_column && f_row == 6)     //White Pawn move 2 down
                {
                    possible = true;
                }
                else
                {
                    possible = false;
                }
            }
            else if (board[t_row, t_column] is not null)
            {

                if (board[f_row, f_column].Color == PieceColor.Black && f_row == t_row - 1 && f_column == t_column + 1                 //Black Pawn hit left         
                 || board[f_row, f_column].Color == PieceColor.Black && f_row == t_row - 1 && f_column == t_column - 1                 //Black Pawn hit right
                 || board[f_row, f_column].Color == PieceColor.White && f_row == t_row + 1 && f_column == t_column + 1                 //White Pawn hit left
                 || board[f_row, f_column].Color == PieceColor.White && f_row == t_row + 1 && f_column == t_column - 1)                //White Pawn hit right
                {
                    possible = true;
                }
                else
                {
                    possible = false;
                }
            }
            return possible;
        }
    }
}
