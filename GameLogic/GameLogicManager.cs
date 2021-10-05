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

        public ChessPiece[,] Move(int f_row, int f_column, int t_row, int t_column)
        {
            if (board[t_row, t_column] is not null)
            {
                if (board[f_row, f_column].Color == PieceColor.Black && board[t_row, t_column].Color == PieceColor.White
                 || board[f_row, f_column].Color == PieceColor.White && board[t_row, t_column].Color == PieceColor.Black)
                {
                    board[t_row, t_column] = new ChessPiece();
                }
                else
                {
                    return board;
                }
            }
            if (board[t_row, t_column] is null)
            {
                board[t_row, t_column] = new ChessPiece();
            }
            switch (board[f_row, f_column].Type)
            {
                case PieceType.Pawn:
                    {
                        board[t_row, t_column].Type = PieceType.Pawn;
                        break;
                    }
                case PieceType.Knight:
                    {
                        board[t_row, t_column].Type = PieceType.Knight;
                        break;
                    }
                case PieceType.Rook:
                    {
                        board[t_row, t_column].Type = PieceType.Rook;
                        break;
                    }
                case PieceType.Bishop:
                    {
                        board[t_row, t_column].Type = PieceType.Bishop;
                        break;
                    }
                case PieceType.Queen:
                    {
                        board[t_row, t_column].Type = PieceType.Queen;
                        break;
                    }
                case PieceType.King:
                    {
                        board[t_row, t_column].Type = PieceType.King;
                        break;
                    }
            }
            if (board[f_row, f_column].Color == PieceColor.Black)
            {
                board[t_row, t_column].Color = PieceColor.Black;
            }
            else
            {
                board[t_row, t_column].Color = PieceColor.White;
            }
            board[f_row, f_column] = null;
            return board;
        }


        public ChessPiece[,] Is_possible_move(Coordinate from, Coordinate to)
        {
            int f_row = from.X;
            int f_column = from.Y;
            int t_row = to.X;
            int t_column = to.Y;
            bool possible = false;

            if (board[f_row, f_column] != null)
            {
               
                switch (board[f_row, f_column].Type)
                {
                    case PieceType.Pawn:
                        {
                            GameLogic.Pawn pawn = new GameLogic.Pawn();
                            possible=pawn.is_possibe_move(f_row,f_column,t_row,t_column);                            
                            break;

                        }
                    case PieceType.Knight:
                        {
                            GameLogic.Knight knight = new GameLogic.Knight();
                            possible = knight.is_possibe_move(f_row, f_column, t_row, t_column);
                            break;
                        }
                    case PieceType.Rook:
                        {
                            GameLogic.Rook rook = new GameLogic.Rook();
                            possible = rook.is_possibe_move(f_row, f_column, t_row, t_column);
                            break;
                        }

                }
                if (possible)
                {
                    Move(f_row, f_column, t_row, t_column);
                }
                return board;
            }
            return board;
        }
    }
}