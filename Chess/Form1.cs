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

        private GameLogicManager gameLogicManager;

        public Form_ChessBoard()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameLogicManager = new GameLogicManager();
            ChessPiece[,] x = gameLogicManager.Initialize();
            int piece_type, piece_color;

            foreach (Button button in Panel_Board.Controls)
            {
                int column = button.Name[0] - 65;
                int row = (int)char.GetNumericValue(button.Name[1]) - 1;
                #region _Black_team
                if (row==6)
                {
                    button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                    button.BackgroundImageLayout = ImageLayout.Center;
                }
                if(row==7 && column==0 || row == 7 && column == 7)
                {
                    button.BackgroundImage = Image.FromFile(GetPath("b_rook.png"));
                    button.BackgroundImageLayout = ImageLayout.Center;
                }
                if (row == 7 && column == 1 || row == 7 && column == 6)
                {
                    button.BackgroundImage = Image.FromFile(GetPath("b_knight.png"));
                    button.BackgroundImageLayout = ImageLayout.Center;
                }
                if (row == 7 && column == 2 || row == 7 && column == 5)
                {
                    button.BackgroundImage = Image.FromFile(GetPath("b_bishop.png"));
                    button.BackgroundImageLayout = ImageLayout.Center;
                }
                if (row == 7 && column == 4)
                {
                    button.BackgroundImage = Image.FromFile(GetPath("b_king.png"));
                    button.BackgroundImageLayout = ImageLayout.Center;
                }
                if (row == 7 && column == 3)
                {
                    button.BackgroundImage = Image.FromFile(GetPath("b_queen.png"));
                    button.BackgroundImageLayout = ImageLayout.Center;
                }
                #endregion

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


/*
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (x[i, j] is not null)
                        {
                            piece_type = (int)x[i, j].Type;
                            piece_color = (int)x[i, j].Color;
                            if (piece_color == 0)
                            {
                                switch (piece_type)
                                {
                                    case 0:
                                        {
                                            button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                                            button.BackgroundImageLayout = ImageLayout.Center;
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
*/