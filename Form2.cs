using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cy_s_Hex_Macros
{
    public partial class PlatinumHex : Form
    {
        
        public PlatinumHex()
        {
            InitializeComponent();
        }
        public string binPath = Game_Option.binPath;
        byte[] newData;
        public Form RefToMenu { get; set; }

        private void PlatinumHex_Load(object sender, EventArgs e)
        {
            if (System.IO.Path.GetFileName(binPath) == "arm9.bin")
            {
                Overlay16Tab.Enabled = false;
            }
            if(System.IO.Path.GetFileName(binPath) == "overlay_0016.bin")
            {
                arm9Tab.Enabled = false;
                CritRefresh();
            }
        }
        private void CritRefresh()
        {
            string[] CritRate = { "Gen 6: 1/16", "Gen 7: 1/24"};
            foreach (string Crits in CritRate)
            {
                critRate.Items.Add(Crits);
            }
        }

        private void ApplyCrits_Click(object sender, EventArgs e)
        {

            if (critRate.SelectedIndex == 0)
            {
                Crit16();
            }
            if (critRate.SelectedIndex == 1)
            {
                Crit24();
            }
            if (critRate.Text == "Crit Rate")
            {
                MessageBox.Show("You have not Selected an option!");
            }
        }
        private void Crit24()
        {
            BinaryWriter Crit = new BinaryWriter(File.Open(binPath, FileMode.Open, FileAccess.ReadWrite));
            int offset = 0x33A60;
            byte[] newData = new byte[] { 0x18, 0x08, 0x02, 0x01, 0x01 }; // 1/24
            Crit.BaseStream.Seek(offset, SeekOrigin.Begin);
            Crit.Write(newData);
            Crit.Close();
            MessageBox.Show("The hex has been changed!"); //Lhea in #Research-Chamber
        }
        private void Crit16()
        {
            BinaryWriter Crit = new BinaryWriter(File.Open(binPath, FileMode.Open, FileAccess.ReadWrite));
            int offset = 0x33A60;
            byte[] newData = new byte[] { 0x10, 0x08, 0x02, 0x01, 0x01 }; // 1/16
            Crit.BaseStream.Seek(offset, SeekOrigin.Begin);
            Crit.Write(newData);
            Crit.Close();
            MessageBox.Show("The hex has been changed!"); //Lhea in #Research-Chamber
        }


        private void NewFile_Click(object sender, EventArgs e)
        {         
            DialogResult dialogResult =  MessageBox.Show("Are you sure", "Do you want to open a new file?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                this.RefToMenu.Show();
            }
        }

        private void Trainer_Names_Click(object sender, EventArgs e)
        {
            BinaryWriter Trainer = new BinaryWriter(File.Open(binPath, FileMode.Open, FileAccess.ReadWrite));
            int offset = 0x791DE;
            Trainer.BaseStream.Seek(offset, SeekOrigin.Begin);
            Trainer.Write(0x0C);
            Trainer.Close();
            MessageBox.Show("The hex has been changed!");
        }

        private void PlatinumHex_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RefToMenu.Close();
        }

        private void ShinyApply_Click(object sender, EventArgs e)
        {

            BinaryWriter Shiny = new BinaryWriter(File.Open(binPath, FileMode.Open, FileAccess.ReadWrite));
            byte[] ShinyOdds = new byte[] { Convert.ToByte(ShinyNumBox.Value) };
            int offset = 0x79E50;
            Shiny.BaseStream.Seek(offset, SeekOrigin.Begin);
            Shiny.Write(ShinyOdds);
            Shiny.Close();
            MessageBox.Show("The hex has been changed!");
        }
    }
}
