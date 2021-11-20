using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class OnlineGameHandler
    {
        private Form_ChessBoard local_game;
        public void Initialize(int portnumber, string EnemyURL)
        {
            Task.Run(() =>
            {
                WebServer.Program.Run(Handle, portnumber);
            });

            local_game = new Form_ChessBoard(true, EnemyURL);
            local_game.ShowDialog();
        }

        private void Handle(string command)
        {
            local_game.HandleOnlineCommand(command);
        }
    }
}
