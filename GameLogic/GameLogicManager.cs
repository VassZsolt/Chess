using System;

namespace GameLogic
{
    public class GameLogicManager
    {
        public static ChessPiece[,] board = new ChessPiece[8, 8];  //row,column A=0 (0,0 means A0)

        public ChessPiece[,] Initialize()
        {
            // Create black team
            for (int i = 0; i < 8; i++)
            {
                board[0, i] = new ChessPiece();
                board[0, i].Color = PieceColor.Black;
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
                board[1, i].Color = PieceColor.Black;
            }

            // Create white team
            for (int i = 0; i < 8; i++)
            {
                board[7, i] = new ChessPiece();
                board[7, i].Color = PieceColor.White;
            }

            board[7, 0].Type = PieceType.Rook;
            board[7, 1].Type = PieceType.Knight;
            board[7, 2].Type = PieceType.Bishop;
            board[7, 3].Type = PieceType.King;
            board[7, 4].Type = PieceType.Queen;
            board[7, 5].Type = PieceType.Bishop;
            board[7, 6].Type = PieceType.Knight;
            board[7, 7].Type = PieceType.Rook;

            for (int i = 0; i < 8; i++)
            {
                board[6, i] = new ChessPiece();
                board[6, i].Type = PieceType.Pawn;
                board[6, i].Color = PieceColor.White;
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

            if (board[from.Row, from.Column] != null)
            {

                switch (board[from.Row, from.Column].Type)
                {
                    case PieceType.Pawn:
                        {
                            GameLogic.Pawn pawn = new GameLogic.Pawn();
                            possible = pawn.is_possibe_move(from, to);
                            break;

                        }
                    case PieceType.Knight:
                        {
                            GameLogic.Knight knight = new GameLogic.Knight();
                            possible = knight.is_possibe_move(from, to);
                            break;
                        }
                    case PieceType.Rook:
                        {
                            GameLogic.Rook rook = new GameLogic.Rook();
                            possible = rook.is_possibe_move(from, to);
                            break;
                        }
                    case PieceType.Bishop:
                        {
                            GameLogic.Bishop bishop = new GameLogic.Bishop();
                            possible = bishop.is_possibe_move(from, to);
                            break;
                        }
                    case PieceType.Queen:
                        {
                            GameLogic.Queen queen = new GameLogic.Queen();
                            possible = queen.is_possibe_move(from, to);
                            break;
                        }
                    case PieceType.King:
                        {
                            GameLogic.King king = new GameLogic.King();
                            possible = king.is_possibe_move(from, to);
                            break;
                        }

                }
                if (possible)
                {
                    Move(from, to);
                }
                return board;
            }
            return board;
        }
    }
}