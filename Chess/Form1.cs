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


namespace Chess
{
    public partial class Form_ChessBoard : Form
    {
        private static string GetPath(string figureFileName)
        {
            return Path.Combine(
             Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Images", figureFileName);
        }

        public GameLogicManager gameLogicManager;

        public int number_of_click = 0;

        public int db = 0;

        public Form_ChessBoard()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            gameLogicManager = new GameLogicManager();
            ChessPiece[,] x = gameLogicManager.Initialize();

            //while(true)
            //{
            foreach (Button button in Panel_Board.Controls)
            {

                int column = button.Name[0] - 65;
                int row = (int)char.GetNumericValue(button.Name[1]) - 1;

                #region _Teams_show
                if (x[row, column] != null)
                {
                    switch ((int)x[row, column].Type)
                    {
                        case 0: //Pawn
                            {
                                switch ((int)x[row, column].Color)
                                {
                                    case 0: //Black
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                                            break;
                                        }
                                    case 1: //White
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_pawn.png"));
                                            break;
                                        }
                                }
                                button.BackgroundImageLayout = ImageLayout.Center;
                                break;
                            }
                        case 1: //Knight
                            {
                                switch ((int)x[row, column].Color)
                                {
                                    case 0: //Black
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_knight.png"));
                                            break;
                                        }
                                    case 1: //White
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_knight.png"));
                                            break;
                                        }
                                }
                                button.BackgroundImageLayout = ImageLayout.Center;
                                break;
                            }
                        case 2: //Rook
                            {
                                switch ((int)x[row, column].Color)
                                {
                                    case 0: //Black
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_rook.png"));
                                            break;
                                        }
                                    case 1: //White
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_rook.png"));
                                            break;
                                        }
                                }
                                button.BackgroundImageLayout = ImageLayout.Center;
                                break;
                            }
                        case 3: //Bishop
                            {
                                switch ((int)x[row, column].Color)
                                {
                                    case 0: //Black
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_bishop.png"));
                                            break;
                                        }
                                    case 1: //White
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_bishop.png"));
                                            break;
                                        }
                                }
                                button.BackgroundImageLayout = ImageLayout.Center;
                                break;
                            }
                        case 4: //Queen
                            {
                                switch ((int)x[row, column].Color)
                                {
                                    case 0: //Black
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_queen.png"));
                                            break;
                                        }
                                    case 1: //White
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_queen.png"));
                                            break;
                                        }
                                }
                                button.BackgroundImageLayout = ImageLayout.Center;
                                break;
                            }
                        case 5: //King
                            {
                                switch ((int)x[row, column].Color)
                                {
                                    case 0: //Black
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_king.png"));
                                            break;
                                        }
                                    case 1: //White
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("w_king.png"));
                                            break;
                                        }
                                }
                                button.BackgroundImageLayout = ImageLayout.Center;
                                break;
                            }
                    }
                }
                #endregion
                button.Click += ButtonClicked;


                //}
            }


        }



        public Coordinate from = new Coordinate();
        public Coordinate to = new Coordinate();
        private void ButtonClicked(object sender, EventArgs e)
        {
            Button buttonPressed = (Button)sender;
            int column_c = buttonPressed.Name[0] - 65;
            int row_c = (int)char.GetNumericValue(buttonPressed.Name[1]) - 1;

            number_of_click++;
            if (number_of_click == 1)
            {
                from.X = row_c;
                from.Y = column_c;
            }
            if (number_of_click == 2)
            {
                to.X = row_c;
                to.Y = column_c;
                ChessPiece[,] x = gameLogicManager.Is_possible_move(from, to);
                number_of_click = 0;


                foreach (Button button in Panel_Board.Controls)
                {

                    int column = button.Name[0] - 65;
                    int row = (int)char.GetNumericValue(button.Name[1]) - 1;

                    #region _Teams_show
                    if (x[row, column] != null)
                    {
                        switch ((int)x[row, column].Type)
                        {
                            case 0: //Pawn
                                {
                                    switch ((int)x[row, column].Color)
                                    {
                                        case 0: //Black
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                                                break;
                                            }
                                        case 1: //White
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_pawn.png"));
                                                break;
                                            }
                                    }
                                    button.BackgroundImageLayout = ImageLayout.Center;
                                    break;
                                }
                            case 1: //Knight
                                {
                                    switch ((int)x[row, column].Color)
                                    {
                                        case 0: //Black
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_knight.png"));
                                                break;
                                            }
                                        case 1: //White
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_knight.png"));
                                                break;
                                            }
                                    }
                                    button.BackgroundImageLayout = ImageLayout.Center;
                                    break;
                                }
                            case 2: //Rook
                                {
                                    switch ((int)x[row, column].Color)
                                    {
                                        case 0: //Black
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_rook.png"));
                                                break;
                                            }
                                        case 1: //White
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_rook.png"));
                                                break;
                                            }
                                    }
                                    button.BackgroundImageLayout = ImageLayout.Center;
                                    break;
                                }
                            case 3: //Bishop
                                {
                                    switch ((int)x[row, column].Color)
                                    {
                                        case 0: //Black
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_bishop.png"));
                                                break;
                                            }
                                        case 1: //White
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_bishop.png"));
                                                break;
                                            }
                                    }
                                    button.BackgroundImageLayout = ImageLayout.Center;
                                    break;
                                }
                            case 4: //Queen
                                {
                                    switch ((int)x[row, column].Color)
                                    {
                                        case 0: //Black
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_queen.png"));
                                                break;
                                            }
                                        case 1: //White
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_queen.png"));
                                                break;
                                            }
                                    }
                                    button.BackgroundImageLayout = ImageLayout.Center;
                                    break;
                                }
                            case 5: //King
                                {
                                    switch ((int)x[row, column].Color)
                                    {
                                        case 0: //Black
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("b_king.png"));
                                                break;
                                            }
                                        case 1: //White
                                            {
                                                button.BackgroundImage = Image.FromFile(GetPath("w_king.png"));
                                                break;
                                            }
                                    }
                                    button.BackgroundImageLayout = ImageLayout.Center;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        button.BackgroundImage = null;
                    }
                    #endregion
                }


            }


        }
    }
}





/*
 foreach (Button button in Panel_Board.Controls)
            {
                int column = button.Name[0] - 65;
                int row = (int)char.GetNumericValue(button.Name[1]) - 1;

                //button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                //button.BackgroundImageLayout = ImageLayout.Center;

                ChessPiece chessField = Field[row, column];
                button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                button.BackgroundImageLayout = ImageLayout.Center;
            }
 */


/*Button buttonPressed = (Button)sender;
int column = buttonPressed.Name[0] - 65;
int row = (int)char.GetNumericValue(buttonPressed.Name[1]) - 1;
*/
