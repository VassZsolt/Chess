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
        int count_of_hit = 0;
        public bool is_possible_hit(Coordinate from, Coordinate to)
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
            if (possible & count_of_hit < 2)
            {
                possible = true;
            }
            return possible;
        }
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
            if (possible & count_of_hit < 2)
            {
                int can_hit = 0;
                bool hitable = false;
                board[to.Row, to.Column] = new ChessPiece();
                board[to.Row, to.Column].Type = PieceType.King;
                board[to.Row, to.Column].Color = board[from.Row, from.Column].Color;
                board[from.Row, from.Column] = null;

                for (int row = 0; row < 8; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        Coordinate temp_from = new Coordinate();
                        temp_from.Row = row;
                        temp_from.Column = column;
                        if (board[temp_from.Row, temp_from.Column] != null)
                        {
                            if (board[temp_from.Row, temp_from.Column].Color != board[to.Row, to.Column].Color)
                            {
                                switch (board[temp_from.Row, temp_from.Column].Type)
                                {
                                    case PieceType.Pawn:
                                        {
                                            GameLogic.Pawn pawn = new GameLogic.Pawn();
                                            hitable = pawn.is_possible_hit(temp_from, to);
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
                                            hitable = king.is_possible_hit(temp_from, to);
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
                if (can_hit != 0)
                {
                    possible = false;

                }
                else
                {
                    possible = true;
                }
            }
            else
            {
                possible = false;
            }
            board[from.Row, from.Column] = new ChessPiece();
            board[from.Row, from.Column].Type = PieceType.King;
            board[from.Row, from.Column].Color = board[to.Row, to.Column].Color;
            board[to.Row, to.Column] = null;
            return possible;
        }
    }
}