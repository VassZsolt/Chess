using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Threading;
using System.Net.Http;

namespace Chess
{
    public partial class Form_ChessBoard : Form
    {
        private static string GetPath(string figureFileName)
        {
            return Path.Combine(
             Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images", figureFileName);
        }

        internal void HandleOnlineCommand(string command)
        {
            Coordinate coordinates = JsonConvert.DeserializeObject<Coordinate>(command);
            foreach (Button button in Panel_Board.Controls)
            {
                int Column = button.Name[0] - 65;
                int Row = (int)char.GetNumericValue(button.Name[1]) - 1;

                if(coordinates.Row==Row && coordinates.Column == Column)
                {
                    ButtonClicked2(button, false);
                }
                
            }
        }

        public GameLogicManager gameLogicManager;
        public int number_of_click = 0;
        public int db = 0;
        private ChessPiece[,] c_board;
        public Form_ChessBoard()
        {
            InitializeComponent();
            this.is_online_game = false;
        }
        public Form_ChessBoard(bool is_Online, string enemyURL)
        {
            InitializeComponent();
            this.is_online_game = is_Online;
            this.enemyURL = enemyURL;
            httpClient = new HttpClient();
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            gameLogicManager = new GameLogicManager();
            c_board = gameLogicManager.Initialize();

            foreach (Button button in Panel_Board.Controls)
            {
                Coordinate coordinate = new Coordinate();
                coordinate.Column = button.Name[0] - 65;
                coordinate.Row = (int)char.GetNumericValue(button.Name[1]) - 1;

                #region _Teams_show
                if (c_board[coordinate.Row, coordinate.Column] != null)
                {
                    switch (c_board[coordinate.Row, coordinate.Column].Type)
                    {
                        case PieceType.Pawn:
                            {
                                switch (c_board[coordinate.Row, coordinate.Column].Color)
                                {
                                    case PieceColor.Black:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                                            break;
                                        }
                                    case PieceColor.White:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_pawn.png"));
                                            break;
                                        }
                                }
                                break;
                            }
                        case PieceType.Knight:
                            {
                                switch (c_board[coordinate.Row, coordinate.Column].Color)
                                {
                                    case PieceColor.Black:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_knight.png"));
                                            break;
                                        }
                                    case PieceColor.White:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_knight.png"));
                                            break;
                                        }
                                }
                                break;
                            }
                        case PieceType.Rook:
                            {
                                switch (c_board[coordinate.Row, coordinate.Column].Color)
                                {
                                    case PieceColor.Black:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_rook.png"));
                                            break;
                                        }
                                    case PieceColor.White:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_rook.png"));
                                            break;
                                        }
                                }
                                break;
                            }
                        case PieceType.Bishop:
                            {
                                switch (c_board[coordinate.Row, coordinate.Column].Color)
                                {
                                    case PieceColor.Black:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_bishop.png"));
                                            break;
                                        }
                                    case PieceColor.White:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_bishop.png"));
                                            break;
                                        }
                                }
                                break;
                            }
                        case PieceType.Queen:
                            {
                                switch (c_board[coordinate.Row, coordinate.Column].Color)
                                {
                                    case PieceColor.Black:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_queen.png"));
                                            break;
                                        }
                                    case PieceColor.White:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_queen.png"));
                                            break;
                                        }
                                }
                                break;
                            }
                        case PieceType.King:
                            {
                                switch (c_board[coordinate.Row, coordinate.Column].Color)
                                {
                                    case PieceColor.Black:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_king.png"));
                                            break;
                                        }
                                    case PieceColor.White:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_king.png"));
                                            break;
                                        }
                                }
                                break;
                            }

                    }
                    button.BackgroundImageLayout = ImageLayout.Center;
                }
                #endregion
                button.Click += ButtonClicked;


            }
        }

        public Coordinate from = new Coordinate();
        public Coordinate to = new Coordinate();
        private readonly bool is_online_game;
        private readonly string enemyURL;
        private readonly HttpClient httpClient;

        private void ButtonClicked(object sender, EventArgs e)
        {
            ButtonClicked2(sender, true);
        }

        private void ButtonClicked2(object sender, bool is_local_click)
        {
            Button buttonPressed = (Button)sender;
            int column_c = buttonPressed.Name[0] - 65;
            int row_c = (int)char.GetNumericValue(buttonPressed.Name[1]) - 1;


            number_of_click++;
            if (number_of_click == 1)
            {
                if (buttonPressed.BackgroundImage != null)
                {
                    from.Row = row_c;
                    from.Column = column_c;
                }
                else
                {
                    number_of_click--;
                }
            }
            if (number_of_click == 2)
            {
                to.Row = row_c;
                to.Column = column_c;
                bool is_check_mate = gameLogicManager.GameLogic(from, to);
                number_of_click = 0;

                if (is_check_mate)
                {
                    End_game();
                }

                foreach (Button button in Panel_Board.Controls)
                {
                    Coordinate coordinate = new Coordinate();
                    coordinate.Column = button.Name[0] - 65;
                    coordinate.Row = (int)char.GetNumericValue(button.Name[1]) - 1;

                    #region _Teams_show
                    if (c_board[coordinate.Row, coordinate.Column] != null)
                    {
                        switch (c_board[coordinate.Row, coordinate.Column].Type)
                        {
                            case PieceType.Pawn:
                                {
                                    switch (c_board[coordinate.Row, coordinate.Column].Color)
                                    {
                                        case PieceColor.Black:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                                                break;
                                            }
                                        case PieceColor.White:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_pawn.png"));
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case PieceType.Knight:
                                {
                                    switch (c_board[coordinate.Row, coordinate.Column].Color)
                                    {
                                        case PieceColor.Black:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_knight.png"));
                                                break;
                                            }
                                        case PieceColor.White:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_knight.png"));
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case PieceType.Rook:
                                {
                                    switch (c_board[coordinate.Row, coordinate.Column].Color)
                                    {
                                        case PieceColor.Black:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_rook.png"));
                                                break;
                                            }
                                        case PieceColor.White:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_rook.png"));
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case PieceType.Bishop:
                                {
                                    switch (c_board[coordinate.Row, coordinate.Column].Color)
                                    {
                                        case PieceColor.Black:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_bishop.png"));
                                                break;
                                            }
                                        case PieceColor.White:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_bishop.png"));
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case PieceType.Queen:
                                {
                                    switch (c_board[coordinate.Row, coordinate.Column].Color)
                                    {
                                        case PieceColor.Black:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_queen.png"));
                                                break;
                                            }
                                        case PieceColor.White:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_queen.png"));
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case PieceType.King:
                                {
                                    switch (c_board[coordinate.Row, coordinate.Column].Color)
                                    {
                                        case PieceColor.Black:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_king.png"));
                                                break;
                                            }
                                        case PieceColor.White:
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_king.png"));
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }
                        button.BackgroundImageLayout = ImageLayout.Center;
                    }
                    else
                    {
                        button.BackgroundImage = null;
                    }
                    #endregion 
                }     
            }
            if(is_online_game&&is_local_click)
            {
                Coordinate coordinate = new Coordinate();
                coordinate.Column = column_c;
                coordinate.Row = row_c;
                string json = JsonConvert.SerializeObject(coordinate);
                httpClient.PostAsync(enemyURL, new StringContent(json)).Wait();
            }
        }

        public void End_game()
        {
            MessageBox.Show("Game Over!");
            return;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form_ChessBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);  //kill Chess.exe from Handler
        }
    }
}