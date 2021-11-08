using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class King
    {
        bool possible = true;
        ChessPiece[,] board = GameLogicManager.board;
        public bool is_possible_move(Coordinate from, Coordinate to)
        {
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
                    if (board[from.Row, from.Column].Color == board[to.Row, to.Column].Color)
                    {
                        possible = false;
                    }
                }
            }
            else
            {
                possible = false;
            }
            return possible;
        }
        public bool entering_into_check(Coordinate from, Coordinate to)
        {
            possible = is_possible_move(from, to);
            if (possible)
            {
                bool hitable = false;
                int can_hit = 0;
                //---------------------------------------

                bool temp_to_Needed = false;
                Coordinate temp_to = new Coordinate();
                PieceType temp_to_Type = new PieceType();
                PieceColor temp_to_Color = new PieceColor();
                if (board[to.Row, to.Column] != null) //If at the coordinate "to" there are any pieces we should make a copy
                {
                    temp_to_Needed = true;
                    temp_to.Row = to.Row;
                    temp_to.Column = to.Column;
                    temp_to_Color = board[to.Row, to.Column].Color;
                    temp_to_Type = board[to.Row, to.Column].Type;
                }
                //------------------------------------------------------

                bool swap = true; //we make a temporary replace from the "from" coordinate to the "to" coordinate
                board[to.Row, to.Column] = new ChessPiece();
                board[to.Row, to.Column].Type = board[from.Row, from.Column].Type;
                board[to.Row, to.Column].Color = board[from.Row, from.Column].Color;
                board[from.Row, from.Column] = null;
                //-------------------------------------------------------


                Coordinate temp_from = new Coordinate();
                for (int row = 0; row < 8; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        temp_from.Row = row;
                        temp_from.Column = column;
                        if (board[temp_from.Row, temp_from.Column] != null) //we can only move with piece
                        {
                            if (!(from.Row == temp_from.Row && from.Column == temp_from.Column) 
                                && !(to.Row == temp_from.Row && to.Column   == temp_from.Column)) //We should'nt examine the moving Piece and the hitted one if it exists
                            {
                                if (board[temp_from.Row, temp_from.Column].Color != board[to.Row,to.Column].Color) //the friendly pieces can't hit us
                                {
                                    switch (board[temp_from.Row, temp_from.Column].Type)
                                    {
                                        case PieceType.Pawn:
                                            {
                                                GameLogic.Pawn pawn = new GameLogic.Pawn();
                                                hitable = pawn.can_give_chess(temp_from, to);
                                                break;

                                            }
                                        case PieceType.Knight:
                                            {
                                                GameLogic.Knight knight = new GameLogic.Knight();
                                                hitable = knight.is_possible_move(temp_from, to);
                                                break;
                                            }
                                        case PieceType.Rook:
                                            {
                                                GameLogic.Rook rook = new GameLogic.Rook();
                                                hitable = rook.is_possible_move(temp_from, to);
                                                break;
                                            }
                                        case PieceType.Bishop:
                                            {
                                                GameLogic.Bishop bishop = new GameLogic.Bishop();
                                                hitable = bishop.is_possible_move(temp_from, to);
                                                break;
                                            }
                                        case PieceType.Queen:
                                            {
                                                GameLogic.Queen queen = new GameLogic.Queen();
                                                hitable = queen.is_possible_move(temp_from, to);
                                                break;
                                            }
                                        case PieceType.King:
                                            {
                                                GameLogic.King king = new GameLogic.King();
                                                hitable = king.is_possible_move(temp_from, to);
                                                break;
                                            }
                                    }
                                    if (hitable)
                                    {
                                        can_hit++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (swap) //we make back the replace
                {
                    board[from.Row, from.Column] = new ChessPiece();
                    board[from.Row, from.Column].Type = board[to.Row, to.Column].Type;
                    board[from.Row, from.Column].Color = board[to.Row, to.Column].Color;
                    board[to.Row, to.Column] = null;

                    if(temp_to_Needed)
                    {
                        board[to.Row, to.Column] = new ChessPiece();
                        to.Row = temp_to.Row;
                        to.Column = temp_to.Column;
                        board[to.Row, to.Column].Color = temp_to_Color;
                        board[to.Row, to.Column].Type = temp_to_Type;
                    }
                }
                if(can_hit==0)
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