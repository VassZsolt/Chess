using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class King
    {
        public bool is_possibe_move(Coordinate from, Coordinate to)
        {
            bool possible = true;
            int count_of_hit = 0;
            ChessPiece[,] board = GameLogicManager.board;


            if (to.Row == from.Row + 1 && to.Column == from.Column
             || to.Row == from.Row - 1 && to.Column == from.Column
             || to.Row == from.Row && to.Column == from.Column + 1
             || to.Row == from.Row && to.Column == from.Column - 1
             || to.Row == from.Row + 1 && to.Column == from.Column + 1
             || to.Row == from.Row + 1 && to.Column == from.Column - 1
             || to.Row == from.Row - 1 && to.Column == from.Column + 1
             || to.Row == from.Row - 1 && to.Column == from.Column - 1)
            {
                
                if (board[to.Row, to.Column] is not null)
                {
                    if (board[from.Row, from.Column].Color != board[to.Row, to.Column].Color)
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

            }
            else
            {
                possible = false;
                return possible;
            }
            if(!(possible & count_of_hit<2))
            {
                possible=false;
            }
            return possible;

        }
    }
}
