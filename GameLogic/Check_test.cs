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
        public bool is_Check(Coordinate from, Coordinate to,bool swap)
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
            if(swap)
            {
                board[to.Row, to.Column] = new ChessPiece(); 
                board[to.Row, to.Column].Type = board[from.Row, from.Column].Type;
                board[to.Row, to.Column].Color = board[from.Row, from.Column].Color;
                board[from.Row, from.Column] = null;
            }
            else
            {
                to.Row = from.Row;
                to.Column = from.Column;
            }


            switch (board[to.Row, to.Column].Type)
            {
                case PieceType.Pawn:
                    {

                        GameLogic.Pawn pawn = new GameLogic.Pawn();
                        is_check = pawn.can_give_chess(to, king_position);
                        break;

                    }
                case PieceType.Knight:
                    {
                        GameLogic.Knight knight = new GameLogic.Knight();
                        is_check = knight.is_possible_move(to, king_position);
                        break;
                    }
                case PieceType.Rook:
                    {
                        GameLogic.Rook rook = new GameLogic.Rook();
                        is_check = rook.is_possible_move(to, king_position);
                        break;
                    }
                case PieceType.Bishop:
                    {
                        GameLogic.Bishop bishop = new GameLogic.Bishop();
                        is_check = bishop.is_possible_move(to, king_position);
                        break;
                    }
                case PieceType.Queen:
                    {
                        GameLogic.Queen queen = new GameLogic.Queen();
                        is_check = queen.is_possible_move(to, king_position);
                        break;
                    }
                case PieceType.King:
                    {
                        GameLogic.King king = new GameLogic.King();
                        is_check = king.entering_into_check(to, king_position);
                        if(to.Row==king_position.Row && to.Column==king_position.Column)
                        {
                            is_check = true;
                        }
                        break;
                    }
            }
            if (swap)
            {
                board[from.Row, from.Column] = new ChessPiece();
                board[from.Row, from.Column].Type = board[to.Row, to.Column].Type;
                board[from.Row, from.Column].Color = board[to.Row, to.Column].Color;
                board[to.Row, to.Column] = null;
            }
            return is_check;
        }

        public List<Coordinate> Hitable(Coordinate from, Coordinate to)
        {
            bool possible = false;
            List<Coordinate> hitable_from = new List<Coordinate>();
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
                        possible = king.is_possible_move(from, to);
                        break;
                    }

            }

            //--------------
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
                        if (board[temp_from.Row, temp_from.Column] != null)
                        {
                            if (board[to.Row, to.Column] is not null)
                            {
                                if (board[temp_from.Row, temp_from.Column].Color != board[to.Row, to.Column].Color)
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
                                        hitable_from.Add(temp_from);
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return hitable_from;
        }


        public List<Coordinate> Protectable(Coordinate from, Coordinate to)
        {
            bool possible = false;
            Coordinate check_from = new Coordinate();
            List<Coordinate> protectable = new List<Coordinate>();
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

            }

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
                //lekértük a király pozit
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
                            if (hitable && db<1)
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
                Coordinate protectable_coordinate = new Coordinate();
                for (int row=0; row<8;row++)
                {
                    for (int column=0;column<8;column++)
                    {
                        if(board[row,column] is null)
                        {
                            board[row, column] = new ChessPiece();
                            board[row, column].Type = PieceType.Pawn;
                            board[row, column].Color = board[king_position.Row, king_position.Column].Color;
                            protectable_coordinate.Row = row;
                            protectable_coordinate.Column = column;
                            is_check = is_Check(check_from, king_position, false);
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
