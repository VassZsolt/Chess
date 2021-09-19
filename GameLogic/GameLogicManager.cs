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

        public ChessPiece[,] Move(Coordinate from, Coordinate to)
        {
            int f_row = from.X;
            int f_column = from.Y;
            int t_row = to.X;
            int t_column = to.Y;
        
            if(board[f_row,f_column]!=null)
            {

                switch ((int)board[f_row, f_column].Type)
                {
                    case 0:
                        {
                            if ((int)board[f_row, f_column].Color == 0) //Black
                            {
                                if (f_row == t_row - 1 && f_column == t_column && board[t_row, t_column] is null) //Black Pawn move 1 up
                                {
                                    board[t_row, t_column] = new ChessPiece();
                                    board[t_row, t_column].Type = PieceType.Pawn;
                                    board[t_row, t_column].Color = PieceColor.Black;
                                    board[f_row, f_column] = null;
                                    return board;
                                }
                                if (f_row == t_row - 2 && f_column == t_column && f_row==1 && board[t_row, t_column] is null) //Black Pawn move 2 up
                                {
                                    board[t_row, t_column] = new ChessPiece();
                                    board[t_row, t_column].Type = PieceType.Pawn;
                                    board[t_row, t_column].Color = PieceColor.Black;
                                    board[f_row, f_column] = null;
                                    return board;
                                }
                                if(f_row==t_row-1 && f_column == t_column + 1) //Black Pawn hit left
                                {
                                    if(board[t_row,t_column] is not null)
                                    {
                                        board[t_row, t_column].Type = PieceType.Pawn;
                                        board[t_row, t_column].Color = PieceColor.Black;
                                        board[f_row, f_column] = null;
                                        return board;
                                    }
                                }
                                if (f_row == t_row - 1 && f_column == t_column - 1) //Black Pawn hit right
                                {
                                    if (board[t_row, t_column] is not null)
                                    {
                                        board[t_row, t_column].Type = PieceType.Pawn;
                                        board[t_row, t_column].Color = PieceColor.Black;
                                        board[f_row, f_column] = null;
                                        return board;
                                    }
                                }

                            }
                            if ((int)board[f_row, f_column].Color == 1) //White
                            {
                                if (f_row == t_row + 1 && f_column == t_column && board[t_row, t_column] is null) //White Pawn move 1 down
                                {
                                    board[t_row, t_column] = new ChessPiece();
                                    board[t_row, t_column].Type = PieceType.Pawn;
                                    board[t_row, t_column].Color = PieceColor.White;
                                    board[f_row, f_column] = null;
                                    return board;
                                }
                                if (f_row == t_row + 2 && f_column == t_column && f_row == 6 && board[t_row, t_column] is null) //White Pawn move 2 down
                                {
                                    board[t_row, t_column] = new ChessPiece();
                                    board[t_row, t_column].Type = PieceType.Pawn;
                                    board[t_row, t_column].Color = PieceColor.White;
                                    board[f_row, f_column] = null;
                                    return board;
                                }
                                if (f_row == t_row + 1 && f_column == t_column + 1) //White Pawn hit left
                                {
                                    if (board[t_row, t_column] is not null)
                                    {
                                        board[t_row, t_column].Type = PieceType.Pawn;
                                        board[t_row, t_column].Color = PieceColor.White;
                                        board[f_row, f_column] = null;
                                        return board;
                                    }
                                }
                                if (f_row == t_row + 1 && f_column == t_column - 1) //White Pawn hit right
                                {
                                    if (board[t_row, t_column] is not null)
                                    {
                                        board[t_row, t_column].Type = PieceType.Pawn;
                                        board[t_row, t_column].Color = PieceColor.White;
                                        board[f_row, f_column] = null;
                                        return board;
                                    }
                                }

                            }
                            return board;

                        }
                    case 1:
                        {
                            if ((f_row == t_row + 2 && f_column == t_column + 1 && board[t_row,t_column] is null)   // 2 Down 1 Left
                            ||  (f_row == t_row + 2 && f_column == t_column - 1 && board[t_row, t_column] is null)  // 2 Down 1 Right 
                            ||  (f_row == t_row - 2 && f_column == t_column + 1 && board[t_row, t_column] is null)  // 2 Up   1 Left 
                            ||  (f_row == t_row - 2 && f_column == t_column - 1 && board[t_row, t_column] is null)  // 2 Up   1 Right
                            ||  (f_row == t_row + 1 && f_column == t_column + 2 && board[t_row, t_column] is null)  // 1 Down 2 Left 
                            ||  (f_row == t_row + 1 && f_column == t_column - 2 && board[t_row, t_column] is null)  // 1 Down 2 Right 
                            ||  (f_row == t_row - 1 && f_column == t_column + 2 && board[t_row, t_column] is null)  // 1 Up   2 Left
                            ||  (f_row == t_row - 1 && f_column == t_column - 2 && board[t_row, t_column] is null)) // 1 Up   2 Right
                            {
                                
                                if ((int)board[f_row, f_column].Color == 1 )       // White Knight simple move
                                {
                                    board[t_row, t_column] = new ChessPiece();
                                    board[t_row, t_column].Color = PieceColor.White;
                                    board[t_row, t_column].Type = PieceType.Knight;
                                    board[f_row, f_column] = null;
                                    return board;
                                }
                                if ((int)board[f_row, f_column].Color == 0 )      //Black Knight simple move
                                {
                                    board[t_row, t_column] = new ChessPiece();
                                    board[t_row, t_column].Color = PieceColor.Black;
                                    board[t_row, t_column].Type = PieceType.Knight;
                                    board[f_row, f_column] = null;
                                    return board;
                                }

                                return board;

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
                                
                                if ((int)board[f_row,f_column].Color==1 && (int)board[t_row,t_column].Color==0) //White Knight whith Black enemy
                                {
                                    board[t_row, t_column] = new ChessPiece();
                                    board[t_row, t_column].Color = PieceColor.White;
                                    board[t_row, t_column].Type = PieceType.Knight;
                                    board[f_row, f_column] = null;
                                    return board;
                                }
                                if ((int)board[f_row, f_column].Color == 0 && (int)board[t_row, t_column].Color == 1) //Black Knight whith White enemy
                                {
                                    board[t_row, t_column] = new ChessPiece();
                                    board[t_row, t_column].Color = PieceColor.Black;
                                    board[t_row, t_column].Type = PieceType.Knight;
                                    board[f_row, f_column] = null;
                                    return board;
                                }
                            }
                            
                                return board;
                        }
           
                    /*case 2:
                        {
                            if ((f_row == t_row && f_column != t_column) || (f_row != t_row && f_column == t_column))
                            {

                                int diff_row = -1, diff_column = -1;
                                diff_row = Math.Abs(f_row - t_row);
                                diff_column = Math.Abs(f_column - t_column);
                                


                                //_-----------------------------------------------
                                board[t_row, t_column] = new ChessPiece();
                                if ((int)board[f_row,f_column].Color==1) //White
                                {
                                    board[t_row, t_column].Color = PieceColor.White;
                                }
                                else
                                {
                                    board[t_row, t_column].Color = PieceColor.Black;
                                }
                                board[t_row, t_column].Type = PieceType.Rook;
                                board[f_row, f_column] = null;
                            }
                                return board;
                        }*/

                }
                
            }
            return board;
            //todo
        }
    }

}
   