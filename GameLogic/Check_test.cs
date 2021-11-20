using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class Check_test
    {
        bool is_check = false;
        ChessPiece[,] board = GameLogicManager.board;
        internal List<Coordinate> get_King_positions()
        {
            List<Coordinate> king_positions = new List<Coordinate>();
            Coordinate king_position = new Coordinate();
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (board[row, column] is not null)
                    {
                        if (board[row, column].Type == PieceType.King)
                        {
                            king_position.Row = row;
                            king_position.Column = column;
                            king_positions.Add(king_position);
                        }
                    }
                }
            }
            return king_positions;
        }
        internal bool is_possible_Move(Coordinate from, Coordinate to)
        {
            bool possible = false;
            switch (board[from.Row, from.Column].Type)
            {

                case PieceType.Pawn:
                    {
                        bool moveable = false;
                        bool hitable = false;
                        GameLogic.Pawn pawn = new GameLogic.Pawn();
                        moveable = pawn.is_possible_move(from, to);
                        hitable = pawn.is_possible_hit(from, to);
                        if (moveable || hitable)
                        {
                            possible = true;
                        }
                        break;

                    }
                case PieceType.Knight:
                    {
                        GameLogic.Knight knight = new GameLogic.Knight();
                        possible = knight.is_possible_move(from, to);
                        break;
                    }
                case PieceType.Rook:
                    {
                        GameLogic.Rook rook = new GameLogic.Rook();
                        possible = rook.is_possible_move(from, to);
                        break;
                    }
                case PieceType.Bishop:
                    {
                        GameLogic.Bishop bishop = new GameLogic.Bishop();
                        possible = bishop.is_possible_move(from, to);
                        break;
                    }
                case PieceType.Queen:
                    {
                        GameLogic.Queen queen = new GameLogic.Queen();
                        possible = queen.is_possible_move(from, to);
                        break;
                    }
                case PieceType.King:
                    {
                        GameLogic.King king = new GameLogic.King();
                        possible = king.entering_into_check(from, to);
                        break;
                    }

            }
            return possible;
        }

        internal bool is_Check(PieceColor target_king_color) //we use the color of the enemy king (like target color)
        {
            bool is_check = false;
            List<Coordinate> king_positions = get_King_positions();
            bool hitable = false;
            Coordinate target_king_position = new Coordinate();

            if (target_king_color == board[king_positions[0].Row, king_positions[0].Column].Color)
            {
                target_king_position.Row = king_positions[0].Row;
                target_king_position.Column = king_positions[0].Column;
            }
            else
            {
                target_king_position.Row = king_positions[1].Row;
                target_king_position.Column = king_positions[1].Column;
            }

            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    Coordinate temp_from = new Coordinate();
                    temp_from.Row = row;
                    temp_from.Column = column;
                    if (board[temp_from.Row, temp_from.Column] != null) //we can only move with piece
                    {
                        if (board[temp_from.Row, temp_from.Column].Color != target_king_color) //we can't hit friendly pieces
                        {
                            switch (board[temp_from.Row, temp_from.Column].Type)
                            {
                                case PieceType.Pawn:
                                    {
                                        GameLogic.Pawn pawn = new GameLogic.Pawn();
                                        hitable = pawn.can_give_chess(temp_from, target_king_position);
                                        break;

                                    }
                                case PieceType.Knight:
                                    {
                                        GameLogic.Knight knight = new GameLogic.Knight();
                                        hitable = knight.is_possible_move(temp_from, target_king_position);
                                        break;
                                    }
                                case PieceType.Rook:
                                    {
                                        GameLogic.Rook rook = new GameLogic.Rook();
                                        hitable = rook.is_possible_move(temp_from, target_king_position);
                                        break;
                                    }
                                case PieceType.Bishop:
                                    {
                                        GameLogic.Bishop bishop = new GameLogic.Bishop();
                                        hitable = bishop.is_possible_move(temp_from, target_king_position);
                                        break;
                                    }
                                case PieceType.Queen:
                                    {
                                        GameLogic.Queen queen = new GameLogic.Queen();
                                        hitable = queen.is_possible_move(temp_from, target_king_position);
                                        break;
                                    }
                            }
                            if (hitable)
                            {
                                is_check = true;
                            }

                        }
                    }
                }
            }
            return is_check;
        }

        internal Coordinate Hitable_from(Coordinate to)
        {
            Coordinate hitable_from = new Coordinate();
            hitable_from.Row = -1;
            hitable_from.Column = -1;
            bool hitable = false;

            if (!hitable)
            {
                for (int row = 0; row < 8; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        Coordinate temp_from = new Coordinate();
                        temp_from.Row = row;
                        temp_from.Column = column;
                        if (board[temp_from.Row, temp_from.Column] != null) //we can only move with piece
                        {
                            if (board[to.Row, to.Column] is not null) //we can only hit piece
                            {
                                if (board[temp_from.Row, temp_from.Column].Color != board[to.Row, to.Column].Color) //we can't hit friendly pieces
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
                                        hitable_from.Row = temp_from.Row;
                                        hitable_from.Column = temp_from.Column;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return hitable_from;
        }
        internal List<Coordinate> Protectable(Coordinate from, Coordinate to)
        {
            bool possible = is_possible_Move(from, to);
            Coordinate check_from = new Coordinate();
            List<Coordinate> protectable = new List<Coordinate>();

            if (possible) //amennyiben a lépés szabályos
            {
                Coordinate king_position = new Coordinate();
                for (int row = 0; row < 8; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        if (board[row, column] is not null)
                        {
                            if (board[row, column].Type == PieceType.King)
                            {
                                if (board[row, column].Color == board[from.Row, from.Column].Color)
                                {
                                    king_position.Row = row;
                                    king_position.Column = column;
                                }
                            }
                        }
                    }
                }
                //we got the king position
                bool hitable = false;
                int db = 0;
                for (int row = 0; row < 8; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        Coordinate temp_from = new Coordinate();
                        temp_from.Row = row;
                        temp_from.Column = column;
                        if (board[temp_from.Row, temp_from.Column] != null)
                        {
                            if (board[temp_from.Row, temp_from.Column].Color != board[king_position.Row, king_position.Column].Color)
                            {
                                switch (board[temp_from.Row, temp_from.Column].Type)
                                {
                                    case PieceType.Pawn:
                                        {
                                            GameLogic.Pawn pawn = new GameLogic.Pawn();
                                            hitable = pawn.can_give_chess(temp_from, king_position);
                                            break;

                                        }
                                    case PieceType.Knight:
                                        {
                                            GameLogic.Knight knight = new GameLogic.Knight();
                                            hitable = knight.is_possible_move(temp_from, king_position);
                                            break;
                                        }
                                    case PieceType.Rook:
                                        {
                                            GameLogic.Rook rook = new GameLogic.Rook();
                                            hitable = rook.is_possible_move(temp_from, king_position);
                                            break;
                                        }
                                    case PieceType.Bishop:
                                        {
                                            GameLogic.Bishop bishop = new GameLogic.Bishop();
                                            hitable = bishop.is_possible_move(temp_from, king_position);
                                            break;
                                        }
                                    case PieceType.Queen:
                                        {
                                            GameLogic.Queen queen = new GameLogic.Queen();
                                            hitable = queen.is_possible_move(temp_from, king_position);
                                            break;
                                        }
                                    case PieceType.King:
                                        {
                                            GameLogic.King king = new GameLogic.King();
                                            hitable = king.is_possible_move(temp_from, king_position);
                                            break;
                                        }
                                }
                            }
                            if (hitable && db < 1)
                            {
                                check_from.Row = temp_from.Row;
                                check_from.Column = temp_from.Column;
                                db++;
                            }
                        }
                    }
                }

                //now we know which piece attack the king
                //-------------------------------------
                Coordinate temp_protectable_coordinate = new Coordinate();
                temp_protectable_coordinate.Row = -1;
                temp_protectable_coordinate.Row = -1;
                Coordinate protectable_coordinate = new Coordinate();
                for (int row = 0; row < 8; row++)
                {
                    for (int column = 0; column < 8; column++)
                    {
                        if (board[row, column] is null)
                        {
                            board[row, column] = new ChessPiece();
                            board[row, column].Type = PieceType.Pawn;
                            board[row, column].Color = board[king_position.Row, king_position.Column].Color;
                            protectable_coordinate.Row = row;
                            protectable_coordinate.Column = column;
                            is_check = is_Check(board[from.Row, from.Column].Color);
                            if (is_check == false)
                            {
                                protectable.Add(protectable_coordinate);
                            }
                            board[row, column] = null;
                        }
                    }
                }


            }
            return protectable;
        }



        internal int number_of_possible_moves(PieceColor target_king_color)
        {
            List<Coordinate> king_positions = get_King_positions();
            int number_of_possible_moves = 0;
            Coordinate target_king_position = new Coordinate();
            if (target_king_color == board[king_positions[0].Row, king_positions[0].Column].Color)
            {
                target_king_position.Row = king_positions[0].Row;
                target_king_position.Column = king_positions[0].Column;
            }
            else
            {
                target_king_position.Row = king_positions[1].Row;
                target_king_position.Column = king_positions[1].Column;
            }
            List<Coordinate> basicKingSteps = new List<Coordinate>();
            Coordinate coordinate = new Coordinate();
            #region _Something_not_intresting
            if (target_king_position.Row < 7)
            {
                coordinate.Row = target_king_position.Row + 1;
                coordinate.Column = target_king_position.Column;
                basicKingSteps.Add(coordinate);
            }
            if (target_king_position.Row > 0)
            {
                coordinate.Row = target_king_position.Row - 1;
                coordinate.Column = target_king_position.Column;
                basicKingSteps.Add(coordinate);
            }
            if (target_king_position.Column < 7)
            {
                coordinate.Row = target_king_position.Row;
                coordinate.Column = target_king_position.Column + 1;
                basicKingSteps.Add(coordinate);
            }
            if (target_king_position.Column > 0)
            {
                coordinate.Row = target_king_position.Row;
                coordinate.Column = target_king_position.Column - 1;
                basicKingSteps.Add(coordinate);
            }
            if (target_king_position.Row < 7 && target_king_position.Column < 7)
            {
                coordinate.Row = target_king_position.Row + 1;
                coordinate.Column = target_king_position.Column + 1;
                basicKingSteps.Add(coordinate);
            }
            if (target_king_position.Row > 0 && target_king_position.Column > 0)
            {
                coordinate.Row = target_king_position.Row - 1;
                coordinate.Column = target_king_position.Column - 1;
                basicKingSteps.Add(coordinate);
            }
            if (target_king_position.Row < 7 && target_king_position.Column > 0)
            {
                coordinate.Row = target_king_position.Row + 1;
                coordinate.Column = target_king_position.Column - 1;
                basicKingSteps.Add(coordinate);
            }
            if (target_king_position.Row > 0 && target_king_position.Column < 7)
            {
                coordinate.Row = target_king_position.Row - 1;
                coordinate.Column = target_king_position.Column + 1;
                basicKingSteps.Add(coordinate);
            }
            #endregion
            bool is_possible_move = false;
            King king = new King();
            for (int i = 0; i < basicKingSteps.Count; i++)
            {
                coordinate.Row = basicKingSteps[i].Row;
                coordinate.Column = basicKingSteps[i].Column;
                if(board[coordinate.Row,coordinate.Column] is not null)
                {
                    if (board[target_king_position.Row, target_king_position.Column].Color != board[coordinate.Row, coordinate.Column].Color)
                    {
                        is_possible_move = king.entering_into_check(target_king_position, coordinate);
                        if (is_possible_move)
                        {
                            number_of_possible_moves++;
                        }
                    }
                }
                else
                {
                    is_possible_move = king.entering_into_check(target_king_position, coordinate);
                    if (is_possible_move)
                    {
                        number_of_possible_moves++;
                    }
                }

            }
            return number_of_possible_moves;
        }
    }
}
