﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Cy_s_Hex_Macros
{
    public partial class HGSSHEX : Form
    {
        public HGSSHEX()
        {
            InitializeComponent();
        }
        public string arm9 = Game_Option.arm9;
        public Form RefToMenu { get; set; }
        bool close = true;
        readonly string overlay = Game_Option.arm9.Remove(Game_Option.arm9.Length - 8) + @"\overlay\overlay_0";
        string[] Pokemon = new string[493];
        string[] ItemsPlat = new string[468];
        readonly int[] StarterOffsets =
            {
                0x108514, 0x108518, 0x10851C, 0x1A98, 0x1A9C, 0x1AA0,
            };
        readonly int[] ItemOffsets =
            {
                0xFBF22, 0xFBF26, 0xFBF2A, 0xFBF2E, 0xFBF32, 0xFBF36, 0xFBF3A, 0xFBF3E, 0xFBF42, 0xFBF46, 0xFBF4A, 0xFBF4E, 0xFBF52, 0xFBF56, 0xFBF5A, 0xFBF5E, 0xFBF62, 0xFBF66, 0xFBF6A
            };
        readonly int[] LevelOffsets =
            {
                0xFBF24, 0xFBF28, 0xFBF2C, 0xFBF30, 0xFBF34, 0xFBF38, 0xFBF3C, 0xFBF30, 0xFBF44, 0xFBF48, 0xFBF4C, 0xFBF50, 0xFBF54, 0xFBF58, 0xFBF5C, 0xFBF60, 0xFBF64, 0xFBF68, 0xFBF6C
            };

        private void HexEdit(int Offset, byte[] newData, string path)
        {
            try
            {
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(Offset, SeekOrigin.Begin);
                binaryWriter.Write(newData);
                binaryWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An execption occured:" + ex);
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            Populate();
            findDefaults();
        }

        private void ShinyApply_Click(object sender, EventArgs e)
        {
            byte[] ShinyOdds = new byte[] { Convert.ToByte(ShinyNumBox.Value) };
            Console.WriteLine(ShinyOdds[0]);
            HexEdit(0x70080, ShinyOdds, arm9);
            MessageBox.Show("The hex has been changed!"); //
        }

        private void DefaultTextSpeed_Click(object sender, EventArgs e)
        {
            byte[] newData = { 0x02 };
            HexEdit(0x2ACBA, newData, arm9);//adastra
            MessageBox.Show("The Hex has been changed!");
        }

        private void DefaultSetMode_Click(object sender, EventArgs e)
        {
            byte[] newData = { 0x01, 0x20, 0x70, 0x47 };
            HexEdit(0x2AD90, newData, arm9);
            byte[] NewData = { 0x02, 0x88, 0x40, 0x21, 0x0A, 0x43, 0x01, 0x80, 0x70, 0x47 };
            HexEdit(0x2AD98, newData, arm9);
            MessageBox.Show("The Hex has been changed!");
        }

        private void NewFile_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure", "Do you want to open a new file?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                close = false;
                this.RefToMenu.Show();
                this.Close();
            }
        }

        private void HGSSHEX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == true)
            {
                this.RefToMenu.Close();
            }
        }

        private void KadabEverstone_Click(object sender, EventArgs e)
        {
            byte[] Kadabra = new byte[] { 0x00 };
            HexEdit(0x70E9A, Kadabra, arm9);
            MessageBox.Show("The hex has been changed!"); // Chritchy
        }

        private void SpeedHP_Click(object sender, EventArgs e)
        {
            byte[] newData = { 0x40, 0x02 };
            HexEdit(0x2E17A, newData, overlay + "012.bin");//adastra
            MessageBox.Show("The Hex has been changed!");
        }

        private void Trainer_Names_Click(object sender, EventArgs e)
        {
            byte[] DSPRE = new byte[] { 0x0C };
            HexEdit(0x7342EE, DSPRE, arm9);
            MessageBox.Show("The hex has been changed!"); // Mikelan
        }

        private void ApplyStarters_Click(object sender, EventArgs e)
        {
            byte[] newData = BitConverter.GetBytes(Slot1Box.SelectedIndex + 1);
            HexEdit(StarterOffsets[0], newData, arm9);

            newData = BitConverter.GetBytes(Slot2Box.SelectedIndex + 1);
            HexEdit(StarterOffsets[1], newData, arm9);

            newData = BitConverter.GetBytes(Slot3Box.SelectedIndex + 1);
            HexEdit(StarterOffsets[2], newData, arm9);

            MessageBox.Show("The Starters have been changed!");
        }

        private void Populate()
        {
            Pokemon = File.ReadAllLines(@"C:\Users\cpoon\source\repos\Cy's Hex Macros\Pokemons.txt", Encoding.UTF8);
            
            Slot1Box.Update();
            Slot1Box.Items.AddRange(Pokemon);
            Slot1Box.EndUpdate();

            Slot2Box.Update();
            Slot2Box.Items.AddRange(Pokemon);
            Slot2Box.EndUpdate();

            Slot3Box.Update();
            Slot3Box.Items.AddRange(Pokemon);
            Slot3Box.EndUpdate();

            BinaryReader BinRead = new BinaryReader(File.Open(arm9, FileMode.Open, FileAccess.Read));
            int i = 0;
            byte[] HexBytes;
            foreach (var Control in StartersTab.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                BinRead.BaseStream.Seek(StarterOffsets[i], SeekOrigin.Begin);
                HexBytes = BinRead.ReadBytes(2);
                Control.SelectedIndex = BitConverter.ToInt16(HexBytes, 0) - 1;
                i++;
            }
            BinRead.Close();
        }

        private void findDefaults()
        {
            int HexString;
            int i = 0;
            BinaryReader reader = new BinaryReader(File.Open(arm9, FileMode.Open, FileAccess.Read));
            try
            {
                reader.BaseStream.Seek(0x70080, SeekOrigin.Begin);
                int hexString = reader.ReadByte();
                reader.Close();
                ShinyNumBox.Value = hexString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An execption occured:" + ex);
            }

            BinaryReader reader2 = new BinaryReader(File.Open(arm9, FileMode.Open, FileAccess.Read));
            foreach (var Combobox in MartPanel.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                reader2.BaseStream.Seek(ItemOffsets[i], SeekOrigin.Begin);
                HexString = reader2.ReadByte();
                Combobox.SelectedIndex = HexString;
                i++;
            }
            i = 0;
            foreach (var NumericUpDown in MartPanel.Controls.OfType<NumericUpDown>())
            {
                reader2.BaseStream.Seek(LevelOffsets[i], SeekOrigin.Begin);
                HexString = reader2.ReadByte();
                NumericUpDown.Value = Convert.ToByte(HexString);
                i++;
            }
            reader2.Close();
        }
    }
}
