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

        public static string arm9;
        int gameIndex;

        private void Game_Option_Load(object sender, EventArgs e)
        {
            GamesRefresh();
        }

        private void GameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            gameIndex = GameSelect.SelectedIndex;
            Open_File.Enabled = true;
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
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                arm9 = openFileDialog.FileName;

                switch (gameIndex)
                {
                    case 0:
                        PlatinumHex Platinum = new PlatinumHex();
                        Platinum.RefToMenu = this;
                        this.Visible = false;
                        Platinum.Show();
                        break;
                    case 1:
                        HGSSHEX HG = new HGSSHEX();
                        HG.RefToMenu = this;
                        this.Visible = false;
                        HG.Show();
                        break;
                    case 2:
                        HGSSHEX SS = new HGSSHEX();
                        SS.RefToMenu = this;
                        this.Visible = false;
                        SS.Show();
                        break;
                }
            }
            else
            {
                return;
            }


        }

        private void README_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            README.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/dev-cyw/Cy-s-Hex-Macros/blob/master/README.md");
        }
    }
}
