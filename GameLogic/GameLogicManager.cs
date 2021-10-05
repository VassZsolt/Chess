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

            for (int i = 0; i < 8; i++)
            {
                board[6, i] = new ChessPiece();
                board[6, i].Type = PieceType.Pawn;
                board[6, i].Color = PieceColor.White;
            }

            board[7, 0].Type = PieceType.Rook;
            board[7, 1].Type = PieceType.Knight;
            board[7, 2].Type = PieceType.Bishop;
            board[7, 3].Type = PieceType.King;
            board[7, 4].Type = PieceType.Queen;
            board[7, 5].Type = PieceType.Bishop;
            board[7, 6].Type = PieceType.Knight;
            board[7, 7].Type = PieceType.Rook;

            return board;
        }

        public ChessPiece[,] Move(int f_row, int f_column, int t_row, int t_column)
        {
            board[t_row, t_column] = new ChessPiece();
            switch ((int)board[f_row, f_column].Type)
            {
                case 0:
                    {
                        board[t_row, t_column].Type = PieceType.Pawn;
                        break;
                    }
                case 1:
                    {
                        board[t_row, t_column].Type = PieceType.Knight;
                        break;
                    }
                case 2:
                    {
                        board[t_row, t_column].Type = PieceType.Rook;
                        break;
                    }
                case 3:
                    {
                        board[t_row, t_column].Type = PieceType.Bishop;
                        break;
                    }
                case 4:
                    {
                        board[t_row, t_column].Type = PieceType.Queen;
                        break;
                    }
                case 5:
                    {
                        board[t_row, t_column].Type = PieceType.King;
                        break;
                    }
            }
            if ((int)board[f_row, f_column].Color == 0) //Black
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

        public ChessPiece[,] Hit(int f_row, int f_column, int t_row, int t_column)
        {
            bool Hit = false;

            if ((int)board[f_row, f_column].Color == 0 && (int)board[t_row, t_column].Color == 1) //Black ChessPiece hit White one
            {
                board[t_row, t_column] = new ChessPiece();
                board[t_row, t_column].Color = PieceColor.Black;
                Hit = true;
            }
            if ((int)board[f_row, f_column].Color == 1 && (int)board[t_row, t_column].Color == 0) //White ChessPiece hit Black one
            {
                board[t_row, t_column] = new ChessPiece();
                board[t_row, t_column].Color = PieceColor.White;
                Hit = true;
            }
            if (Hit == true)
            {

                switch ((int)board[f_row, f_column].Type)
                {
                    case 0:
                        {
                            board[t_row, t_column].Type = PieceType.Pawn;
                            break;
                        }
                    case 1:
                        {
                            board[t_row, t_column].Type = PieceType.Knight;
                            break;
                        }
                    case 2:
                        {
                            board[t_row, t_column].Type = PieceType.Rook;
                            break;
                        }
                    case 3:
                        {
                            board[t_row, t_column].Type = PieceType.Bishop;
                            break;
                        }
                    case 4:
                        {
                            board[t_row, t_column].Type = PieceType.Queen;
                            break;
                        }
                    case 5:
                        {
                            board[t_row, t_column].Type = PieceType.King;
                            break;
                        }
                }
                board[f_row, f_column] = null;
            }
            return board;
        }

        public ChessPiece[,] Is_possible_move(Coordinate from, Coordinate to)
        {
            int f_row = from.X;
            int f_column = from.Y;
            int t_row = to.X;
            int t_column = to.Y;

            if (board[f_row, f_column] != null)
            {

                switch ((int)board[f_row, f_column].Type)
                {
                    case 0:
                        {
                            if ((int)board[f_row, f_column].Color == 0) //Black
                            {
                                if (f_row == t_row - 1 && f_column == t_column && board[t_row, t_column] is null) //Black Pawn move 1 up
                                {
                                    Move(f_row, f_column, t_row, t_column);
                                }
                                if (f_row == t_row - 2 && f_column == t_column && f_row == 1 && board[t_row, t_column] is null) //Black Pawn move 2 up
                                {
                                    Move(f_row, f_column, t_row, t_column);
                                }
                                if (f_row == t_row - 1 && f_column == t_column + 1 && board[t_row, t_column] is not null) //Black Pawn hit left
                                {
                                    Hit(f_row, f_column, t_row, t_column);
                                }
                                if (f_row == t_row - 1 && f_column == t_column - 1 && board[t_row, t_column] is not null) //Black Pawn hit right
                                {
                                    Hit(f_row, f_column, t_row, t_column);
                                }
                                break;
                            }
                            if ((int)board[f_row, f_column].Color == 1) //White
                            {
                                if (f_row == t_row + 1 && f_column == t_column && board[t_row, t_column] is null) //White Pawn move 1 down
                                {
                                    Move(f_row, f_column, t_row, t_column);
                                }
                                if (f_row == t_row + 2 && f_column == t_column && f_row == 6 && board[t_row, t_column] is null) //White Pawn move 2 down
                                {
                                    Move(f_row, f_column, t_row, t_column);
                                }
                                if (f_row == t_row + 1 && f_column == t_column + 1 && board[t_row, t_column] is not null) //White Pawn hit left
                                {
                                    Hit(f_row, f_column, t_row, t_column);
                                }
                                if (f_row == t_row + 1 && f_column == t_column - 1 && board[t_row, t_column] is not null) //White Pawn hit right
                                {
                                    Hit(f_row, f_column, t_row, t_column);
                                }
                                break;
                            }
                            break;

                        }
                    case 1:
                        {
                            if ((f_row == t_row + 2 && f_column == t_column + 1 && board[t_row, t_column] is null)  // 2 Down 1 Left
                             || (f_row == t_row + 2 && f_column == t_column - 1 && board[t_row, t_column] is null)  // 2 Down 1 Right 
                             || (f_row == t_row - 2 && f_column == t_column + 1 && board[t_row, t_column] is null)  // 2 Up   1 Left 
                             || (f_row == t_row - 2 && f_column == t_column - 1 && board[t_row, t_column] is null)  // 2 Up   1 Right
                             || (f_row == t_row + 1 && f_column == t_column + 2 && board[t_row, t_column] is null)  // 1 Down 2 Left 
                             || (f_row == t_row + 1 && f_column == t_column - 2 && board[t_row, t_column] is null)  // 1 Down 2 Right 
                             || (f_row == t_row - 1 && f_column == t_column + 2 && board[t_row, t_column] is null)  // 1 Up   2 Left
                             || (f_row == t_row - 1 && f_column == t_column - 2 && board[t_row, t_column] is null)) // 1 Up   2 Right
                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }
                            if ((f_row == t_row + 2 && f_column == t_column + 1 && board[t_row, t_column] is not null)   // 2 Down 1 Left
                             || (f_row == t_row + 2 && f_column == t_column - 1 && board[t_row, t_column] is not null)   // 2 Down 1 Right 
                             || (f_row == t_row - 2 && f_column == t_column + 1 && board[t_row, t_column] is not null)   // 2 Up   1 Left 
                             || (f_row == t_row - 2 && f_column == t_column - 1 && board[t_row, t_column] is not null)   // 2 Up   1 Right
                             || (f_row == t_row + 1 && f_column == t_column + 2 && board[t_row, t_column] is not null)   // 1 Down 2 Left 
                             || (f_row == t_row + 1 && f_column == t_column - 2 && board[t_row, t_column] is not null)   // 1 Down 2 Right 
                             || (f_row == t_row - 1 && f_column == t_column + 2 && board[t_row, t_column] is not null)   // 1 Up   2 Left
                             || (f_row == t_row - 1 && f_column == t_column - 2 && board[t_row, t_column] is not null))  // 1 Up   2 Right
                            {

                                Hit(f_row, f_column, t_row, t_column);
                                break;
                            }

                            break;
                        }

                    case 2:
                        {
                            #region _Rook_basic_moves
                            if ((f_row == t_row - 1 && f_column == t_column && board[t_row, t_column] is null)
                             || (f_row == t_row + 1 && f_column == t_column && board[t_row, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 1 && board[t_row, t_column] is null)
                             || (f_row == t_row && f_column == t_column + 1 && board[t_row, t_column] is null))
                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 2 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 2 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 2 && board[t_row, t_column] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 2 && board[t_row, t_column] is null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 3 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 3 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 3 && board[t_row, t_column] is null
                                               && board[t_row, t_column - 2] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 3 && board[t_row, t_column] is null
                                               && board[t_row, t_column + 2] is null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }
                            if ((f_row == t_row - 4 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row - 3, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 4 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row + 3, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 4 && board[t_row, t_column] is null
                                               && board[t_row, t_column - 3] is null
                                               && board[t_row, t_column - 2] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 4 && board[t_row, t_column] is null
                                               && board[t_row, t_column + 3] is null
                                               && board[t_row, t_column + 2] is null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 5 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row - 4, t_column] is null
                                 && board[t_row - 3, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 5 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row + 4, t_column] is null
                                 && board[t_row + 3, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 5 && board[t_row, t_column] is null
                                               && board[t_row, t_column - 4] is null
                                               && board[t_row, t_column - 3] is null
                                               && board[t_row, t_column - 2] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 5 && board[t_row, t_column] is null
                                               && board[t_row, t_column + 4] is null
                                               && board[t_row, t_column + 3] is null
                                               && board[t_row, t_column + 2] is null
                                               && board[t_row, t_column + 1] is null))


                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 6 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row - 5, t_column] is null
                                 && board[t_row - 4, t_column] is null
                                 && board[t_row - 3, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 6 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row + 5, t_column] is null
                                 && board[t_row + 4, t_column] is null
                                 && board[t_row + 3, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                            || (f_row == t_row && f_column == t_column - 6 && board[t_row, t_column] is null
                                              && board[t_row, t_column - 5] is null
                                              && board[t_row, t_column - 4] is null
                                              && board[t_row, t_column - 3] is null
                                              && board[t_row, t_column - 2] is null
                                              && board[t_row, t_column - 1] is null)
                            || (f_row == t_row && f_column == t_column + 6 && board[t_row, t_column] is null
                                              && board[t_row, t_column + 5] is null
                                              && board[t_row, t_column + 4] is null
                                              && board[t_row, t_column + 3] is null
                                              && board[t_row, t_column + 2] is null
                                              && board[t_row, t_column + 1] is null))
                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 7 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row - 6, t_column] is null
                                 && board[t_row - 5, t_column] is null
                                 && board[t_row - 4, t_column] is null
                                 && board[t_row - 3, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 7 && f_column == t_column && board[t_row, t_column] is null
                                 && board[t_row + 6, t_column] is null
                                 && board[t_row + 5, t_column] is null
                                 && board[t_row + 4, t_column] is null
                                 && board[t_row + 3, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 7 && board[t_row, t_column] is null
                                               && board[t_row, t_column - 6] is null
                                               && board[t_row, t_column - 5] is null
                                               && board[t_row, t_column - 4] is null
                                               && board[t_row, t_column - 3] is null
                                               && board[t_row, t_column - 2] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 7 && board[t_row, t_column] is null
                                               && board[t_row, t_column + 6] is null
                                               && board[t_row, t_column + 5] is null
                                               && board[t_row, t_column + 4] is null
                                               && board[t_row, t_column + 3] is null
                                               && board[t_row, t_column + 2] is null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }
                            #endregion
                            #region _Rook_basic_hits
                            if ((f_row == t_row - 1 && f_column == t_column && board[t_row, t_column] is not null)
                             || (f_row == t_row + 1 && f_column == t_column && board[t_row, t_column] is not null)
                             || (f_row == t_row && f_column == t_column - 1 && board[t_row, t_column] is not null)
                             || (f_row == t_row && f_column == t_column + 1 && board[t_row, t_column] is not null))
                            {
                                Hit(f_row, f_column, t_row, t_column);
                                break;
                            }
                            if ((f_row == t_row - 2 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 2 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 2 && board[t_row, t_column] is not null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 2 && board[t_row, t_column] is not null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Hit(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 3 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 3 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 3 && board[t_row, t_column] is not null
                                               && board[t_row, t_column - 2] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 3 && board[t_row, t_column] is not null
                                               && board[t_row, t_column + 2] is null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Hit(f_row, f_column, t_row, t_column);
                                break;
                            }
                            if ((f_row == t_row - 4 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row - 3, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 4 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row + 3, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 4 && board[t_row, t_column] is not null
                                               && board[t_row, t_column - 3] is null
                                               && board[t_row, t_column - 2] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 4 && board[t_row, t_column] is not null
                                               && board[t_row, t_column + 3] is null
                                               && board[t_row, t_column + 2] is null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Hit(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 5 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row - 4, t_column] is null
                                 && board[t_row - 3, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 5 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row + 4, t_column] is null
                                 && board[t_row + 3, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 5 && board[t_row, t_column] is not null
                                               && board[t_row, t_column - 4] is null
                                               && board[t_row, t_column - 5] is null
                                               && board[t_row, t_column - 2] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 5 && board[t_row, t_column] is not null
                                               && board[t_row, t_column + 4] is null
                                               && board[t_row, t_column + 3] is null
                                               && board[t_row, t_column + 2] is null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Hit(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 6 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row - 5, t_column] is null
                                 && board[t_row - 4, t_column] is null
                                 && board[t_row - 3, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 6 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row + 5, t_column] is null
                                 && board[t_row + 4, t_column] is null
                                 && board[t_row + 3, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                            || (f_row == t_row && f_column == t_column - 6 && board[t_row, t_column] is not null
                                              && board[t_row, t_column - 5] is null
                                              && board[t_row, t_column - 4] is null
                                              && board[t_row, t_column - 3] is null
                                              && board[t_row, t_column - 2] is null
                                              && board[t_row, t_column - 1] is null)
                            || (f_row == t_row && f_column == t_column + 6 && board[t_row, t_column] is not null
                                              && board[t_row, t_column + 5] is null
                                              && board[t_row, t_column + 4] is null
                                              && board[t_row, t_column + 3] is null
                                              && board[t_row, t_column + 2] is null
                                              && board[t_row, t_column + 1] is null))
                            {
                                Hit(f_row, f_column, t_row, t_column);
                                break;
                            }

                            if ((f_row == t_row - 7 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row - 6, t_column] is null
                                 && board[t_row - 5, t_column] is null
                                 && board[t_row - 4, t_column] is null
                                 && board[t_row - 3, t_column] is null
                                 && board[t_row - 2, t_column] is null
                                 && board[t_row - 1, t_column] is null)
                             || (f_row == t_row + 7 && f_column == t_column && board[t_row, t_column] is not null
                                 && board[t_row + 6, t_column] is null
                                 && board[t_row + 5, t_column] is null
                                 && board[t_row + 4, t_column] is null
                                 && board[t_row + 3, t_column] is null
                                 && board[t_row + 2, t_column] is null
                                 && board[t_row + 1, t_column] is null)
                             || (f_row == t_row && f_column == t_column - 7 && board[t_row, t_column] is not null
                                               && board[t_row, t_column - 6] is null
                                               && board[t_row, t_column - 5] is null
                                               && board[t_row, t_column - 4] is null
                                               && board[t_row, t_column - 3] is null
                                               && board[t_row, t_column - 2] is null
                                               && board[t_row, t_column - 1] is null)
                             || (f_row == t_row && f_column == t_column + 7 && board[t_row, t_column] is not null
                                               && board[t_row, t_column + 6] is null
                                               && board[t_row, t_column + 5] is null
                                               && board[t_row, t_column + 4] is null
                                               && board[t_row, t_column + 3] is null
                                               && board[t_row, t_column + 2] is null
                                               && board[t_row, t_column + 1] is null))
                            {
                                Hit(f_row, f_column, t_row, t_column);
                                break;
                            }
                            #endregion

                            break;
                        }
                       
                }
                return board;
            }
            return board;
            //todo
        }
    }
}