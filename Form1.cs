using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cy_s_Hex_Macros
{
    public partial class Game_Option : Form
    {
        public Game_Option()
        {
            InitializeComponent();
        }

        public static string binPath;
        int gameIndex;

        private void Game_Option_Load(object sender, EventArgs e)
        {
            GamesRefresh();
        }

        private void GameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Open_File.Enabled = true;
            gameIndex = GameSelect.SelectedIndex;
        }

        private void GamesRefresh()
        {
            string[] gamesList = { "Platinum", "Heartgold", "Soulsilver","Black", "White", "Black 2", "White 2" };
            foreach (string Game in gamesList)
            {
                GameSelect.Items.Add(Game);
            }
            Open_File.Enabled = false;
        }

        private void Open_File_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Binary Files (*.bin)|*.bin";
            openFileDialog.ShowDialog(this);
            binPath = openFileDialog.FileName;

            switch(gameIndex){
                case 0:
                    PlatinumHex Platinum = new PlatinumHex();
                    Platinum.RefToMenu = this;
                    this.Visible = false;
                    Platinum.Show();
                    break;
                case 1:

                    break;
                case 2:

                    break;
            }
        }
    }
}
