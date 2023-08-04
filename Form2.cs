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
    public partial class PlatinumHex : Form
    {
        
        public PlatinumHex()
        {
            InitializeComponent();
        }
        public Form RefToMenu { get; set; }
        public string arm9 = Game_Option.arm9;
        string overlay = Game_Option.arm9.Remove(Game_Option.arm9.Length - 8) + @"\overlay\overlay_0";
        bool close = true;
        

        private void PlatinumHex_Load(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void HexEdit(int offset, byte[] newData, string path)
        {
            BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
            binaryWriter.BaseStream.Seek(offset, SeekOrigin.Begin);
            binaryWriter.Write(newData);
            binaryWriter.Close();
        }

        private void RefreshItems()
        {
            ItemsList();
            string[] CritRate = { "Gen 6: 1/16", "Gen 7: 1/24"};
            foreach (string Crits in CritRate)
            {
                critRate.Items.Add(Crits);
            }

            BinaryReader reader = new BinaryReader(File.Open(arm9,FileMode.Open, FileAccess.Read));
            reader.BaseStream.Seek(0x79E50, SeekOrigin.Begin);
            string hexString = Convert.ToString(reader.ReadByte());
            reader.Close();
            ShinyNumBox.Value = Convert.ToInt16(hexString);
        }

        private void NewFile_Click(object sender, EventArgs e)
        {         
            DialogResult dialogResult =  MessageBox.Show("Are you sure", "Do you want to open a new file?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                close = false;
                this.RefToMenu.Show();
                this.Close();
            }
        }

        private void Trainer_Names_Click(object sender, EventArgs e)
        {
            byte[] DSPRE = new byte[] { 0x0C };
            HexEdit(0x791DE, DSPRE, arm9);
            MessageBox.Show("The hex has been changed!"); // Mikelan
        }

        private void PlatinumHex_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == true)
            {
                this.RefToMenu.Close();
            }
        }

        private void ShinyApply_Click(object sender, EventArgs e)
        {
            byte[] ShinyOdds = new byte[] { Convert.ToByte(ShinyNumBox.Value) };
            HexEdit(0x79E50, ShinyOdds, arm9);
            MessageBox.Show("The hex has been changed!"); //
        }

        private void KadabEverstone_Click(object sender, EventArgs e)
        {
            byte[] Kadabra = new byte[] { 0x00 };
            HexEdit(0x76BFE, Kadabra, arm9);
            MessageBox.Show("The hex has been changed!"); // Chritchy
        }

        private void ApplyCrits_Click(object sender, EventArgs e)
        {

            if (critRate.SelectedIndex == 0)
            {
                byte[] newData = new byte[] { 0x10, 0x08, 0x02, 0x01, 0x01 };// 1/16
                HexEdit(0x33A60, newData, overlay + "016.bin");
                MessageBox.Show("The hex has been changed!"); //Lhea in #Research-Chamber
            }
            if (critRate.SelectedIndex == 1)
            {
                byte[] newData = new byte[] { 0x18, 0x08, 0x02, 0x01, 0x01 }; // 1/24
                HexEdit(0x33A60, newData, overlay + "016.bin");
                MessageBox.Show("The hex has been changed!"); //Lhea in #Research-Chamber
            }
            if (critRate.Text == "Crit Rate")
            {
                MessageBox.Show("You have not Selected an option!");
            }
        }


        private void ItemsList()
        {
            string[] ItemsPlat = new string[468];
            ItemsPlat = File.ReadAllLines(@"C:\Users\cpoon\source\repos\Cy's Hex Macros\ItemsPlat.txt", Encoding.UTF8);    //Directory.GetCurrentDirectory() + "ItemsPlat.txt"
            int HexString;
            
            int[] ItemOffsets =
            {
                0xEBAFC, 0xEBB00, 0xEBB04, 0xEBB08, 0xEBB0C, 0xEBB10, 0xEBB14, 0xEBB18, 0xEBB1C, 0xEBB20, 0xEBB24, 0xEBB28, 0xEBB2C, 0xEBB30, 0xEBB34, 0xEBB38, 0xEBB3C, 0xEBB40,
            };

            //BinaryReader reader = new BinaryReader(File.Open(arm9, FileMode.Open, FileAccess.Read));            
           // reader.BaseStream.Seek(ItemOffsets[], SeekOrigin.Begin);
           // HexString = reader.ReadByte();
                
            //foreach(var Combobox in MartPanel.Controls.OfType<ComboBox>()) 
            {
            //     Combobox.SelectedIndex = HexString;
            }
            
            //reader.Close();
        }

    }
}
