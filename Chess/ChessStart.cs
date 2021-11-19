using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebServer;

namespace Chess
{
    public partial class ChessStart : Form
    {
        private OnlineGameHandler onlineGameHandler;
        public ChessStart()
        {
            InitializeComponent();
        }

        private void ChessStart_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Local_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ChessBoard local_game = new Form_ChessBoard();
            local_game.ShowDialog();
        }

        private void b_Online_Click(object sender, EventArgs e)
        {
            this.Hide();
            onlineGameHandler = new OnlineGameHandler();
            onlineGameHandler.Initialize(int.Parse(textbox_Portnumber.Text), textbox_EnemyURL.Text);
        }
    }
}
