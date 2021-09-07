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

namespace Chess
{
    public partial class Form_ChessBoard : Form
    {
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

            }

        }
    }
}

/*
for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        if (x[i, j] is not null)
        {
            piece_type = (int)x[i, j].Type;
            piece_color = (int)x[i, j].Color;
            if (piece_color==0)
            {
                switch ((piece_type))
                {
                    case 0:
                        {
                            button.BackgroundImage = Image.FromFile(GetPath("b_pawn.png"));
                        }

                    default:
                        break;
                }
            }
        }
    }
}
*/