using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Knight
    {
        public bool is_possibe_move(int f_row, int f_column, int t_row, int t_column)
        {
            bool possible = true;
            ChessPiece[,] board = GameLogicManager.board;

            if ((f_row == t_row + 2 && f_column == t_column + 1)  // 2 Down 1 Left
             || (f_row == t_row + 2 && f_column == t_column - 1)  // 2 Down 1 Right 
             || (f_row == t_row - 2 && f_column == t_column + 1)  // 2 Up   1 Left 
             || (f_row == t_row - 2 && f_column == t_column - 1)  // 2 Up   1 Right
             || (f_row == t_row + 1 && f_column == t_column + 2)  // 1 Down 2 Left 
             || (f_row == t_row + 1 && f_column == t_column - 2)  // 1 Down 2 Right 
             || (f_row == t_row - 1 && f_column == t_column + 2)  // 1 Up   2 Left
             || (f_row == t_row - 1 && f_column == t_column - 2)) // 1 Up   2 Right
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
