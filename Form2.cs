using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        string[] ItemsPlat = new string[468];


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
            PopulateComboBoxes();
            ItemsList();
            string[] CritRate = { "Gen 6: 1/16", "Gen 7: 1/24"};
            foreach (string Crits in CritRate)
            {
                critRate.Items.Add(Crits);
            }

            BinaryReader reader = new BinaryReader(File.Open(arm9,FileMode.Open, FileAccess.Read));
            reader.BaseStream.Seek(0x79E50, SeekOrigin.Begin);
            int hexString = reader.ReadByte();
            reader.Close();
            ShinyNumBox.Value = hexString;
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
            int HexString;
            int i = 0;

            int[] ItemOffsets =
            {
                0xEBAFC, 0xEBB00, 0xEBB04, 0xEBB08, 0xEBB0C, 0xEBB10, 0xEBB14, 0xEBB18, 0xEBB1C, 0xEBB20, 0xEBB24, 0xEBB28, 0xEBB2C, 0xEBB30, 0xEBB34, 0xEBB38, 0xEBB3C, 0xEBB40, 0xEBB44
            };

            BinaryReader reader = new BinaryReader(File.Open(arm9, FileMode.Open, FileAccess.Read));                            
            foreach(var Combobox in MartPanel.Controls.OfType<ComboBox>()) 
            {
                reader.BaseStream.Seek(ItemOffsets[i], SeekOrigin.Begin);
                HexString = reader.ReadByte();
                Combobox.SelectedIndex = HexString;
                i++;
            }
            
            reader.Close();
        }
        private void PopulateComboBoxes()
        {
            //Directory.GetCurrentDirectory() + "ItemsPlat.txt"
            ItemsPlat = File.ReadAllLines(@"C:\Users\cpoon\source\repos\dev-cyw\Cy-s-Hex-Macros\ItemsPlat.txt", Encoding.UTF8);
            BackgroundWorker worker = new BackgroundWorker();

            MartBox1.Update();
            MartBox1.Items.AddRange(ItemsPlat);
            MartBox1.EndUpdate();

            MartBox2.Update();
            MartBox2.Items.AddRange(ItemsPlat);
            MartBox2.EndUpdate();

            MartBox3.Update();
            MartBox3.Items.AddRange(ItemsPlat);
            MartBox3.EndUpdate();

            MartBox4.Update();
            MartBox4.Items.AddRange(ItemsPlat);
            MartBox4.EndUpdate();

            MartBox5.Update();
            MartBox5.Items.AddRange(ItemsPlat);
            MartBox5.EndUpdate();

            MartBox6.Update();
            MartBox6.Items.AddRange(ItemsPlat);
            MartBox6.EndUpdate();

            MartBox7.Update();
            MartBox7.Items.AddRange(ItemsPlat);
            MartBox7.EndUpdate();

            MartBox8.Update();
            MartBox8.Items.AddRange(ItemsPlat);
            MartBox8.EndUpdate();

            MartBox9.Update();
            MartBox9.Items.AddRange(ItemsPlat);
            MartBox9.EndUpdate();

            MartBox10.Update();
            MartBox10.Items.AddRange(ItemsPlat);
            MartBox10.EndUpdate();

            MartBox11.Update();
            MartBox11.Items.AddRange(ItemsPlat);
            MartBox11.EndUpdate();

            MartBox12.Update();
            MartBox12.Items.AddRange(ItemsPlat);
            MartBox12.EndUpdate();

            MartBox13.Update();
            MartBox13.Items.AddRange(ItemsPlat);
            MartBox13.EndUpdate();

            MartBox14.Update();
            MartBox14.Items.AddRange(ItemsPlat);
            MartBox14.EndUpdate();

            MartBox15.Update();
            MartBox15.Items.AddRange(ItemsPlat);
            MartBox15.EndUpdate();

            MartBox16.Update();
            MartBox16.Items.AddRange(ItemsPlat);
            MartBox16.EndUpdate();

            MartBox17.Update();
            MartBox17.Items.AddRange(ItemsPlat);
            MartBox17.EndUpdate();

            MartBox18.Update();
            MartBox18.Items.AddRange(ItemsPlat);
            MartBox18.EndUpdate();

            MartBox19.Update();
            MartBox19.Items.AddRange(ItemsPlat);
            MartBox19.EndUpdate();

            worker.RunWorkerAsync();
            Stopwatch stopwatch = new Stopwatch();
            while (worker.IsBusy == true)
            {
                stopwatch.Start();
                PlatTabs.SelectTab(1);
                PlatTabs.SelectTab(0);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed.ToString());
                Application.DoEvents();
            }
        }

    }
}
