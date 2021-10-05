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
                            if (board[t_row, t_column] is null)
                            {
                                if (board[f_row, f_column].Color == PieceColor.Black && f_row == t_row - 1 && f_column == t_column                   //Black Pawn move 1 up
                                || board[f_row, f_column].Color == PieceColor.Black && f_row == t_row - 2 && f_column == t_column && f_row == 1      //Black Pawn move 2 up
                                || board[f_row, f_column].Color == PieceColor.White && f_row == t_row + 1 && f_column == t_column                    //White Pawn move 1 down
                                || board[f_row, f_column].Color == PieceColor.White && f_row == t_row + 2 && f_column == t_column && f_row == 6)     //White Pawn move 2 down
                                {
                                    Move(f_row, f_column, t_row, t_column);
                                }
                            }
                            else if (board[t_row, t_column] is not null)
                            {

                                if (board[f_row, f_column].Color == PieceColor.Black && f_row == t_row - 1 && f_column == t_column + 1                //Black Pawn hit left         
                                || board[f_row, f_column].Color == PieceColor.Black && f_row == t_row - 1 && f_column == t_column - 1                 //Black Pawn hit right
                                || board[f_row, f_column].Color == PieceColor.White && f_row == t_row + 1 && f_column == t_column + 1                 //White Pawn hit left
                                || board[f_row, f_column].Color == PieceColor.White && f_row == t_row + 1 && f_column == t_column - 1)                //White Pawn hit right
                                {
                                    Move(f_row, f_column, t_row, t_column);
                                }
                            }
                            break;

                        }
                    case 1:
                        {
                            if ((f_row == t_row + 2 && f_column == t_column + 1)  // 2 Down 1 Left
                             || (f_row == t_row + 2 && f_column == t_column - 1)  // 2 Down 1 Right 
                             || (f_row == t_row - 2 && f_column == t_column + 1)  // 2 Up   1 Left 
                             || (f_row == t_row - 2 && f_column == t_column - 1)  // 2 Up   1 Right
                             || (f_row == t_row + 1 && f_column == t_column + 2)  // 1 Down 2 Left 
                             || (f_row == t_row + 1 && f_column == t_column - 2)  // 1 Down 2 Right 
                             || (f_row == t_row - 1 && f_column == t_column + 2)  // 1 Up   2 Left
                             || (f_row == t_row - 1 && f_column == t_column - 2)) // 1 Up   2 Right
                            {
                                Move(f_row, f_column, t_row, t_column);
                                break;
                            }
                            break;
                        }
                    case 2:
                        {
                            int i = 0;
                            int db = 0;
                            bool possible = true;

                            i = f_row;
                            if (i < t_row && f_column == t_column) //Moving Up
                            {
                                do
                                {
                                    if (board[i + 1, t_column] is not null && possible)
                                    {
                                        if (board[f_row, t_column].Color == PieceColor.Black && board[i + 1, t_column].Color == PieceColor.White && i + 1 == t_row
                                         || board[f_row, t_column].Color == PieceColor.White && board[i + 1, t_column].Color == PieceColor.Black && i + 1 == t_row)
                                        {
                                            possible = true;
                                            db++;
                                        }
                                        else
                                        {
                                            possible = false;
                                        }
                                    }
                                    if (board[i + 1, t_column] is null && possible)
                                    {
                                        possible = true;
                                    }
                                    i++;
                                } while (i < t_row);
                            }
                             if (i > t_row && f_column == t_column) //Moving Down
                            {
                                do
                                {
                                    if (board[i - 1, t_column] is not null && possible)
                                    {
                                        if (board[f_row, t_column].Color == PieceColor.Black && board[i - 1, t_column].Color == PieceColor.White && i - 1 == t_row
                                         || board[f_row, t_column].Color == PieceColor.White && board[i - 1, t_column].Color == PieceColor.Black && i - 1 == t_row)
                                        {
                                            possible = true;
                                            db++;
                                        }
                                        else
                                        {
                                            possible = false;
                                        }
                                    }
                                    if (board[i - 1, t_column] is null && possible)
                                    {
                                        possible = true;
                                    }
                                    i--;
                                } while (i > t_row);
                            }
                            i = f_column;
                            if (f_row == t_row && f_column < t_column) //Moving Right
                            {
                                do
                                {
                                    if (board[t_row, i + 1] is not null && possible)
                                    {
                                        if (board[t_row, f_column].Color == PieceColor.Black && board[t_row, i + 1].Color == PieceColor.White && i + 1 == t_column
                                         || board[t_row, f_column].Color == PieceColor.White && board[t_row, i + 1].Color == PieceColor.Black && i + 1 == t_column)
                                        {
                                            possible = true;
                                            db++;
                                        }
                                        else
                                        {
                                            possible = false;
                                        }
                                    }
                                    if (board[t_row, i + 1] is null && possible)
                                    {
                                        possible = true;
                                    }
                                    i++;
                                } while (i < t_row);
                            }
                            if (f_row == t_row && f_column > t_column) //Moving Left
                            {
                                do
                                {
                                    if (board[t_row, i - 1] is not null && possible)
                                    {
                                        if (board[t_row, f_column].Color == PieceColor.Black && board[t_row, i - 1].Color == PieceColor.White && i - 1 == t_column
                                         || board[t_row, f_column].Color == PieceColor.White && board[t_row, i - 1].Color == PieceColor.Black && i - 1 == t_column)
                                        {
                                            possible = true;
                                            db++;
                                        }
                                        else
                                        {
                                            possible = false;
                                        }
                                    }
                                    if (board[t_row, i - 1] is null && possible)
                                    {
                                        possible = true;
                                    }
                                    i--;
                                } while (i > t_row);
                            }
                            if (possible && db < 2)
                            {
                                Move(f_row, f_column, t_row, t_column);
                            }
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