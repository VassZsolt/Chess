using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    internal class Knight
    {
        internal bool is_possible_move(Coordinate from, Coordinate to)
        {
            bool possible = true;
            ChessPiece[,] board = GameLogicManager.board;

            if ((from.Row == to.Row + 2 && from.Column == to.Column + 1)  // 2 Down 1 Left
             || (from.Row == to.Row + 2 && from.Column == to.Column - 1)  // 2 Down 1 Right 
             || (from.Row == to.Row - 2 && from.Column == to.Column + 1)  // 2 Up   1 Left 
             || (from.Row == to.Row - 2 && from.Column == to.Column - 1)  // 2 Up   1 Right
             || (from.Row == to.Row + 1 && from.Column == to.Column + 2)  // 1 Down 2 Left 
             || (from.Row == to.Row + 1 && from.Column == to.Column - 2)  // 1 Down 2 Right 
             || (from.Row == to.Row - 1 && from.Column == to.Column + 2)  // 1 Up   2 Left
             || (from.Row == to.Row - 1 && from.Column == to.Column - 2)) // 1 Up   2 Right
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