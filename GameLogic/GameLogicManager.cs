using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class GameLogicManager
    {
        public static ChessPiece[,] board = new ChessPiece[8, 8];  //row,column A=0 (0,0 means A0)
        GameLogic.Check_test chess_test = new GameLogic.Check_test();
        public bool is_check = false;
        public Coordinate check_from = new Coordinate();
        public PieceColor last_team = PieceColor.Black;


        public ChessPiece[,] Initialize()
        {
            // Create black team
            for (int i = 0; i < 8; i++)
            {
                board[0, i] = new ChessPiece();
                board[0, i].Color = PieceColor.White;
            }

            board[0, 0].Type = PieceType.Rook;
            board[0, 1].Type = PieceType.Knight;
            board[0, 2].Type = PieceType.Bishop;
            board[0, 3].Type = PieceType.Queen;
            board[0, 4].Type = PieceType.King;
            board[0, 5].Type = PieceType.Bishop;
            board[0, 6].Type = PieceType.Knight;
            board[0, 7].Type = PieceType.Rook;

            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new ChessPiece();
                board[1, i].Type = PieceType.Pawn;
                board[1, i].Color = PieceColor.White;
            }

            // Create white team
            for (int i = 0; i < 8; i++)
            {
                board[7, i] = new ChessPiece();
                board[7, i].Color = PieceColor.Black;
            }

            board[7, 0].Type = PieceType.Rook;
            board[7, 1].Type = PieceType.Knight;
            board[7, 2].Type = PieceType.Bishop;
            board[7, 3].Type = PieceType.Queen;
            board[7, 4].Type = PieceType.King;
            board[7, 5].Type = PieceType.Bishop;
            board[7, 6].Type = PieceType.Knight;
            board[7, 7].Type = PieceType.Rook;

            for (int i = 0; i < 8; i++)
            {
                board[6, i] = new ChessPiece();
                board[6, i].Type = PieceType.Pawn;
                board[6, i].Color = PieceColor.Black;
            }
            return board;
        }

        public ChessPiece[,] Move(Coordinate from, Coordinate to)
        {
            if (board[to.Row, to.Column] is not null)
            {
                if (board[from.Row, from.Column].Color == PieceColor.Black && board[to.Row, to.Column].Color == PieceColor.White
                 || board[from.Row, from.Column].Color == PieceColor.White && board[to.Row, to.Column].Color == PieceColor.Black)
                {
                    board[to.Row, to.Column] = new ChessPiece();
                }
                else
                {
                    return board;
                }
            }
            if (board[to.Row, to.Column] is null)
            {
                board[to.Row, to.Column] = new ChessPiece();
            }
            switch (board[from.Row, from.Column].Type)
            {
                case PieceType.Pawn:
                    {
                        board[to.Row, to.Column].Type = PieceType.Pawn;
                        break;
                    }
                case PieceType.Knight:
                    {
                        board[to.Row, to.Column].Type = PieceType.Knight;
                        break;
                    }
                case PieceType.Rook:
                    {
                        board[to.Row, to.Column].Type = PieceType.Rook;
                        break;
                    }
                case PieceType.Bishop:
                    {
                        board[to.Row, to.Column].Type = PieceType.Bishop;
                        break;
                    }
                case PieceType.Queen:
                    {
                        board[to.Row, to.Column].Type = PieceType.Queen;
                        break;
                    }
                case PieceType.King:
                    {
                        board[to.Row, to.Column].Type = PieceType.King;
                        break;
                    }
            }
            if (board[from.Row, from.Column].Color == PieceColor.Black)
            {
                board[to.Row, to.Column].Color = PieceColor.Black;
            }
            else
            {
                board[to.Row, to.Column].Color = PieceColor.White;
            }
            board[from.Row, from.Column] = null;
            return board;
        }

        public ChessPiece[,] Is_possible_move(Coordinate from, Coordinate to)
        {
            bool possible = false;

            if (board[from.Row, from.Column].Color != last_team)
            {
                if (is_check == false)
                {
                    possible = chess_test.is_possible_Move(from, to);
                }
                else
                {
                    if (board[from.Row, from.Column].Type == PieceType.King)
                    {
                        GameLogic.King king = new GameLogic.King();
                        possible = king.entering_into_check(from, to);
                    }
                    else
                    {
                        Coordinate hitable_from = chess_test.Hitable_from(from, to);
                        if (hitable_from.Row == from.Row && hitable_from.Column == from.Column
                            && to.Row == check_from.Row && to.Column == check_from.Column)
                        {
                            possible = true;
                        }
                        else
                        {
                            List<Coordinate> protectable_from = chess_test.Protectable(from, to);
                            if (protectable_from.Contains(to))
                            {
                                possible = true;
                            }
                        }
                    }
                }
                if (possible)
                {
                    is_check = chess_test.is_Check(from, to, false);
                    if (is_check)
                    {
                        check_from.Row = to.Row;
                        check_from.Column = to.Column;
                    }
                    last_team = board[from.Row, from.Column].Color;
                    Move(from, to);
                }
                return board;
            }
            return board;
        }
    }
}