using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    internal class Pawn
    {
        bool possible = true;
        ChessPiece[,] board = GameLogicManager.board;
        internal bool is_possible_move(Coordinate from, Coordinate to)
        {
            if (board[to.Row, to.Column] is null)
            {
                if (board[from.Row, from.Column].Color == PieceColor.Black && from.Row == to.Row + 1 && from.Column == to.Column                       //Black Pawn move 1 up
                 || board[from.Row, from.Column].Color == PieceColor.Black && from.Row == to.Row + 2 && from.Column == to.Column && from.Row == 6      //Black Pawn move 2 up
                 || board[from.Row, from.Column].Color == PieceColor.White && from.Row == to.Row - 1 && from.Column == to.Column                       //White Pawn move 1 down
                 || board[from.Row, from.Column].Color == PieceColor.White && from.Row == to.Row - 2 && from.Column == to.Column && from.Row == 1)     //White Pawn move 2 down
                {
                    possible = true;
                }
                else
                {
                    possible = false;
                    return possible;
                }
            }
            else
            {
                possible = false;
            }

            return possible;
        }
        internal bool is_possible_hit(Coordinate from, Coordinate to)
        {
            if (board[to.Row, to.Column] is not null)
            {
                if (board[from.Row, from.Column].Color == PieceColor.Black && from.Row == to.Row + 1 && from.Column == to.Column + 1                   //Black Pawn hit left         
                 || board[from.Row, from.Column].Color == PieceColor.Black && from.Row == to.Row + 1 && from.Column == to.Column - 1                   //Black Pawn hit right
                 || board[from.Row, from.Column].Color == PieceColor.White && from.Row == to.Row - 1 && from.Column == to.Column + 1                   //White Pawn hit left
                 || board[from.Row, from.Column].Color == PieceColor.White && from.Row == to.Row - 1 && from.Column == to.Column - 1)                  //White Pawn hit right
                {
                    possible = true;
                }
                else
                {
                    possible = false;
                }
            }
            else
            {
                possible = false;
            }

            return possible;
        }
        internal bool can_give_chess(Coordinate from, Coordinate to)
        {
            if (board[from.Row, from.Column].Color == PieceColor.Black && from.Row == to.Row + 1 && from.Column == to.Column + 1                   //Black Pawn hit left         
             || board[from.Row, from.Column].Color == PieceColor.Black && from.Row == to.Row + 1 && from.Column == to.Column - 1                   //Black Pawn hit right
             || board[from.Row, from.Column].Color == PieceColor.White && from.Row == to.Row - 1 && from.Column == to.Column + 1                   //White Pawn hit left
             || board[from.Row, from.Column].Color == PieceColor.White && from.Row == to.Row - 1 && from.Column == to.Column - 1)                  //White Pawn hit right
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
