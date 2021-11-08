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
        public Coordinate get_King_position(Coordinate from, Coordinate to)
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
                            if (board[row, column].Color != board[from.Row, from.Column].Color)
                            {
                                king_position.Row = row;
                                king_position.Column = column;
                            }
                        }
                    }
                }
            }
            if (board[from.Row, from.Column].Type == PieceType.King)
            {
                king_position.Row = to.Row;
                king_position.Column = to.Column;
            }
            return king_position;
        }
        public bool is_possible_Move(Coordinate from, Coordinate to)
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
        public bool is_Check(Coordinate from, Coordinate to, bool swap)
        {
            bool possible = false;
            Coordinate hitable_from = new Coordinate();
            Coordinate king_position = get_King_position(from, to);
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
            if(!swap)
            {
                swap = true; //we make a temporary replace from the "from" coordinate to the "to" coordinate
                board[to.Row, to.Column] = new ChessPiece();
                board[to.Row, to.Column].Type = board[from.Row, from.Column].Type;
                board[to.Row, to.Column].Color = board[from.Row, from.Column].Color;
                board[from.Row, from.Column] = null;
            }
            //-------------------------------------------------------

            switch (board[to.Row, to.Column].Type)
            {
                case PieceType.Pawn:
                    {
                        GameLogic.Pawn pawn = new GameLogic.Pawn();
                        hitable = pawn.can_give_chess(to, king_position);
                        break;

                    }
                case PieceType.Knight:
                    {
                        GameLogic.Knight knight = new GameLogic.Knight();
                        hitable = knight.is_possible_move(to, king_position);
                        break;
                    }
                case PieceType.Rook:
                    {
                        GameLogic.Rook rook = new GameLogic.Rook();
                        hitable = rook.is_possible_move(to, king_position);
                        break;
                    }
                case PieceType.Bishop:
                    {
                        GameLogic.Bishop bishop = new GameLogic.Bishop();
                        hitable = bishop.is_possible_move(to, king_position);
                        break;
                    }
                case PieceType.Queen:
                    {
                        GameLogic.Queen queen = new GameLogic.Queen();
                        hitable = queen.is_possible_move(to, king_position);
                        break;
                    }
            }
            if (hitable)
            {
                can_hit++;
            }
            if (swap) //we make back the replace
            {
                board[from.Row, from.Column] = new ChessPiece();
                board[from.Row, from.Column].Type = board[to.Row, to.Column].Type;
                board[from.Row, from.Column].Color = board[to.Row, to.Column].Color;
                board[to.Row, to.Column] = null;

                if (temp_to_Needed)
                {
                    board[to.Row, to.Column] = new ChessPiece();
                    to.Row = temp_to.Row;
                    to.Column = temp_to.Column;
                    board[to.Row, to.Column].Color = temp_to_Color;
                    board[to.Row, to.Column].Type = temp_to_Type;
                }
            }
            if (can_hit != 0)
            {
                possible = true;
            }
            return possible;
        }
        public Coordinate Hitable_from(Coordinate from, Coordinate to)
        {
            bool possible = is_possible_Move(from,to);
            Coordinate hitable_from = new Coordinate();

            if (possible)
            {
                bool hitable = false;
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
            else
            {
                hitable_from.Row = -1;
                hitable_from.Column = -1;
            }
            return hitable_from;
        }

        public List<Coordinate> Protectable(Coordinate from, Coordinate to)
        {
            bool possible = is_possible_Move(from,to);
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
                            is_check = is_Check(check_from, check_from, true);
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
    }
}
