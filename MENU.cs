using Cy_s_Hex_Macros.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private void Game_Option_Load(object sender, EventArgs e)
        {
            if (Settings.Default.README == false)
            {
                MessageBox.Show("If you have not read the readme\nPlease do so it contains important infomation", "README", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Settings.Default.README = true;
                Settings.Default.Save();
                //If you dont read the readme then smh
            }
        }

        private void Open_File_Click(object sender, EventArgs e) //Opens the arm9 file and opens the correct form
        {

            openFileDialog.FileName = string.Empty;
            openFileDialog.Filter = "arm9 Files|*arm9.bin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                arm9 = openFileDialog.FileName;
                if (!arm9.EndsWith("arm9.bin") || !File.Exists(arm9))
                {
                    MessageBox.Show("Path contains an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Headers = arm9.Remove(arm9.Length - 8) + @"header.bin";
                int GameIndex = 0;
                BinaryReader HeaderRead = new BinaryReader(File.Open(Headers, FileMode.Open, FileAccess.Read));
                HeaderRead.BaseStream.Seek(0xC, SeekOrigin.Begin);
                byte[] HeaderBytes = HeaderRead.ReadBytes(4);
                foreach(byte b in HeaderBytes)
                {
                    GameIndex += (int)b;
                }
                HeaderRead.Close();

                switch (GameIndex)
                {
                    case 301:
                        PlatinumHex Platinum = new PlatinumHex();
                        Platinum.RefToMenu = this;
                        this.Visible = false;
                        Platinum.Show();
                        break;
                    case 297: case 293:
                        HGSSHEX HGSS = new HGSSHEX();
                        HGSS.RefToMenu = this;
                        this.Visible = false;
                        HGSS.Show();
                        break;
                    default:
                        if (File.Exists(Headers))
                        {
                            MessageBox.Show("Header is Different Than Expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            else
            {

                return;
            }

        }
        private void README_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)// Opens the readme
        {
            README.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/dev-cyw/Cy-s-Hex-Macros/blob/master/README.md");
        }
    }
}
