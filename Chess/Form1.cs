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
            ChessPiece[,] x =gameLogicManager.Initialize();
            
            
        }

    }
}
