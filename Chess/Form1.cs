using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form_ChessBoard : Form
    {
        public Form_ChessBoard()
        {
            InitializeComponent();
            GameLogicManager.Initialize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
