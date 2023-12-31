﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        readonly string overlay = Game_Option.arm9.Remove(Game_Option.arm9.Length - 8) + @"\overlay\overlay_0";
        bool close = true;
        string[] ItemsPlat = new string[468];
        string[] Pokemon = new string[493];
        readonly int[] ItemOffsets =
            {
                0xEBAFC, 0xEBB00, 0xEBB04, 0xEBB08, 0xEBB0C, 0xEBB10, 0xEBB14, 0xEBB18, 0xEBB1C, 0xEBB20, 0xEBB24, 0xEBB28, 0xEBB2C, 0xEBB30, 0xEBB34, 0xEBB38, 0xEBB3C, 0xEBB40, 0xEBB44
            };
        readonly int[] LevelOffsets =
            {
                0xEBAFE, 0xEBB02, 0xEBB06, 0xEBB0A, 0xEBB0E, 0xEBB12, 0xEBB16, 0xEBB1A, 0xEBB1E, 0xEBB22, 0xEBB26, 0xEBB2A, 0xEBB2E, 0xEBB32, 0xEBB36, 0xEBB3A, 0xEBB3E, 0xEBB42, 0xEBB46
            };
        readonly int[] StarterOffsets =
            {
                0x1BC0, 0x1BC4, 0x1BC8,
            };


        private void PlatinumHex_Load(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void HexEdit(int Offset, byte[] newData, string path) //General Hex edit
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
                MessageBox.Show("An execption occured:" + ex,"ERROR" ,MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void RefreshItems()
        {
            PopulateComboBoxes();
            FindDefault();
        }

        private void NewFile_Click(object sender, EventArgs e) //Closes the current form and makes the menu visible
        {         
            DialogResult dialogResult =  MessageBox.Show("Are you sure", "Do you want to open a new file?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                close = false;
                this.RefToMenu.Show();
                this.Close();
            }
        }

        private void Trainer_Names_Click(object sender, EventArgs e) // Mikelan
        {
            byte[] DSPRE = new byte[] { 0x0C };
            HexEdit(0x791DE, DSPRE, arm9);
            MessageBox.Show("The hex has been changed!");
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
            HexEdit(0x75E50, ShinyOdds, arm9);
            MessageBox.Show("The hex has been changed!");
        }

        private void KadabEverstone_Click(object sender, EventArgs e) // Chritchy
        {
            byte[] Kadabra = new byte[] { 0x00 };
            HexEdit(0x76BFE, Kadabra, arm9);
            MessageBox.Show("The hex has been changed!");
        }

        private void ApplyCrits_Click(object sender, EventArgs e)//Lhea
        {

            if (critRate.SelectedIndex == 0)
            {
                byte[] newData = new byte[] { 0x10, 0x08, 0x02, 0x01, 0x01 };// 1/16
                HexEdit(0x33A60, newData, overlay + "016.bin");
                MessageBox.Show("The hex has been changed!");
            }
            if (critRate.SelectedIndex == 1)
            {
                byte[] newData = new byte[] { 0x18, 0x08, 0x02, 0x01, 0x01 }; // 1/24
                HexEdit(0x33A60, newData, overlay + "016.bin");
                MessageBox.Show("The hex has been changed!"); 
            }
            if (critRate.Text == "Crit Rate")
            {
                MessageBox.Show("You have not Selected an option!");
            }
        }


        private void FindDefault() //Reads the values from the files
        {
            byte[] HexBytes;
            int HexString;
            int i = 0;
            try
            {
                BinaryReader reader = new BinaryReader(File.Open(arm9, FileMode.Open, FileAccess.Read));
                foreach (var Combobox in MartPanel.Controls.OfType<System.Windows.Forms.ComboBox>())
                {
                    reader.BaseStream.Seek(ItemOffsets[i], SeekOrigin.Begin);
                    HexString = reader.ReadByte();
                    Combobox.SelectedIndex = HexString;
                    i++;
                }
                i = 0;
                foreach (var NumericUpDown in MartPanel.Controls.OfType<NumericUpDown>())
                {
                    reader.BaseStream.Seek(LevelOffsets[i], SeekOrigin.Begin);
                    HexString = reader.ReadByte();
                    NumericUpDown.Value = Convert.ToByte(HexString);
                    i++;
                }
                reader.Close();
                BinaryReader BinRead = new BinaryReader(File.Open(overlay + "078.bin", FileMode.Open, FileAccess.Read));
                i = 0;
                foreach (var Control in StartersTab.Controls.OfType<System.Windows.Forms.ComboBox>())
                {
                    BinRead.BaseStream.Seek(StarterOffsets[i], SeekOrigin.Begin);
                    HexBytes = BinRead.ReadBytes(2);
                    Control.SelectedIndex = BitConverter.ToInt16(HexBytes, 0) - 1;
                    i++;
                }
                BinRead.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An execption occured:" + ex);
            }

            try
            {
                BinaryReader reader = new BinaryReader(File.Open(arm9, FileMode.Open, FileAccess.Read));
                reader.BaseStream.Seek(0x75E50, SeekOrigin.Begin);
                int hexString = reader.ReadByte();
                reader.Close();
                ShinyNumBox.Value = hexString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An execption occured:" + ex);
            }

        }
        private void PopulateComboBoxes()
        {
            ItemsPlat = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Other\ItemsPlat.txt", Encoding.UTF8);
            Pokemon = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\Other\Pokemons.txt", Encoding.UTF8);
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerAsync();
            while (worker.IsBusy == true)
            {
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

                Slot3Box.Update();
                Slot3Box.Items.AddRange(Pokemon);
                Slot3Box.EndUpdate();

                Slot1Box.Update();
                Slot1Box.Items.AddRange(Pokemon);
                Slot1Box.EndUpdate();

                Slot2Box.Update();
                Slot2Box.Items.AddRange(Pokemon);
                Slot2Box.EndUpdate();


                PlatTabs.SelectTab(1);
                PlatTabs.SelectTab(2);
                PlatTabs.SelectTab(0);

                string[] CritRate = { "Gen 6: 1/16", "Gen 7: 1/24" };
                foreach (string Crits in CritRate)
                {
                    critRate.Items.Add(Crits);
                }

                Application.DoEvents();
            }
        }

        private void Apply_Mart_Click(object sender, EventArgs e) //Iterates through each control and applys the items and levels from the mart

        {
            int i = 0;
            int HexString;
            BinaryWriter MartWriter = new BinaryWriter(File.Open(arm9, FileMode.Open, FileAccess.ReadWrite));
            foreach(var Control in MartPanel.Controls.OfType<NumericUpDown>())
            {
                MartWriter.BaseStream.Seek(LevelOffsets[i], SeekOrigin.Begin);
                HexString = (int)Control.Value;
                MartWriter.Write((byte)HexString);
                i++;
            }
            i = 0;
            foreach (var Control in MartPanel.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                MartWriter.BaseStream.Seek(ItemOffsets[i], SeekOrigin.Begin);
                HexString = (int)Control.SelectedIndex;
                MartWriter.Write((byte)HexString);
                i++;
            }
            MartWriter.Close();
            MessageBox.Show("The Mart Has Changed!");
        }

        private void ApplyStarters_Click(object sender, EventArgs e)//Iterates through each control and applys the pokemon and sprites from the starters
        {
            byte[] newData = BitConverter.GetBytes(Slot1Box.SelectedIndex + 1);
            HexEdit(StarterOffsets[0], newData, overlay + "078.bin");

            newData = BitConverter.GetBytes(Slot2Box.SelectedIndex + 1);
            HexEdit(StarterOffsets[1], newData, overlay + "078.bin");

            newData = BitConverter.GetBytes(Slot3Box.SelectedIndex + 1);
            HexEdit(StarterOffsets[2], newData, overlay + "078.bin");

            int ID1 = 516 - (Slot1Box.SelectedIndex + 1);
            int ID2 = 520 - (Slot2Box.SelectedIndex + 1);
            int ID3 = 524 - (Slot3Box.SelectedIndex + 1);

            if (Slot1Box.SelectedIndex + 1 <= 255)
            {
                byte[] SpriteBytes = { 0x81, 0x20, 0x80, 0x00, 0x28, 0x18, 0x29, 0x1C, (byte)(Slot1Box.SelectedIndex + 1), 0x22}; 
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(overlay + "078.bin", FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(0x690, SeekOrigin.Begin);
                binaryWriter.Write(SpriteBytes);
                binaryWriter.Close();
            }
            else if (Slot1Box.SelectedIndex + 1 > 255 && Slot1Box.SelectedIndex + 1 < 261)
            {
                MessageBox.Show("The Sprite Wont Change!");
            }
            else if (Slot1Box.SelectedIndex >= 261)
            {
                byte[] SpriteBytes = { 0x81, 0x22, 0x92, 0x00, 0xA8, 0x18, 0x29, 0x1C, (byte)(ID1), 0x3A };
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(overlay + "078.bin", FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(0x690, SeekOrigin.Begin);
                binaryWriter.Write(SpriteBytes);
                binaryWriter.Close();
            }


            if (Slot2Box.SelectedIndex <= 255)
            {
                byte[] SpriteBytes = { 0x82, 0x20, 0x80, 0x00, 0x28, 0x18, 0x29, 0x1C, (byte)(Slot2Box.SelectedIndex + 1), 0x22 };
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(overlay + "078.bin", FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(0x69E, SeekOrigin.Begin);
                binaryWriter.Write(SpriteBytes);
                binaryWriter.Close();
            }
            else if (Slot2Box.SelectedIndex + 1 > 255 && Slot2Box.SelectedIndex + 1 < 265)
            {
                MessageBox.Show("The Sprite Wont Change!");
            }
            else if (Slot2Box.SelectedIndex >= 265)
            {
                byte[] SpriteBytes = { 0x82, 0x22, 0x92, 0x00, 0xA8, 0x18, 0x29, 0x1C, (byte)(ID2), 0x3A };
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(overlay + "078.bin", FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(0x69E, SeekOrigin.Begin);
                binaryWriter.Write(SpriteBytes);
                binaryWriter.Close();
            }

            if (Slot3Box.SelectedIndex <= 255)
            {
                byte[] SpriteBytes = { 0x83, 0x20, 0x80, 0x00, 0x28, 0x18, 0x29, 0x1C, (byte)(Slot3Box.SelectedIndex + 1), 0x22 };
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(overlay + "078.bin", FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(0x6AC, SeekOrigin.Begin);
                binaryWriter.Write(SpriteBytes);
                binaryWriter.Close();
            }
            else if (Slot3Box.SelectedIndex + 1 > 255 && Slot3Box.SelectedIndex + 1 < 269)
            {
                MessageBox.Show("The Sprite Wont Change!");
            }
            else if (Slot3Box.SelectedIndex >= 269)
            {
                byte[] SpriteBytes = { 0x83, 0x22, 0x92, 0x00, 0xA8, 0x18, 0x29, 0x1C, (byte)(ID3), 0x3A };
                BinaryWriter binaryWriter = new BinaryWriter(File.Open(overlay + "078.bin", FileMode.Open, FileAccess.ReadWrite));
                binaryWriter.BaseStream.Seek(0x6AC, SeekOrigin.Begin);
                binaryWriter.Write(SpriteBytes);
                binaryWriter.Close();
            }

            MessageBox.Show("The Starters have been changed!");//turtleissac
        }

        private void DefaultTextSpeed_Click(object sender, EventArgs e)//lhea
        {
            byte[] newData = { 0x02 };
            HexEdit(0x27A2E, newData, arm9);
            MessageBox.Show("The Hex has been changed!");
        }

        private void DefaultSetMode_Click(object sender, EventArgs e)//lhea
        {
            byte[] newData = { 0x40, 0x20, 0x01, 0x43 };
            HexEdit(0x27A3E, newData, arm9);
            MessageBox.Show("The Hex has been changed!");
        }

        private void SpeedHP_Click(object sender, EventArgs e)//adastra
        {
            byte[] newData = { 0x88, 0x1E };
            HexEdit(0x2D046, newData, overlay + "016.bin");
            MessageBox.Show("The Hex has been changed!");
        }

        private void SkipRivalName_Click(object sender, EventArgs e)//lhea
        {
            byte[] newData = { 0xD6, 0x0C };
            HexEdit(0x166A, newData, overlay + "073.bin");
            newData = new byte[] { 0x5A,  0x20 };
            HexEdit(0x2256, newData, overlay + "073.bin");
            newData = new byte[] { 0x02, 0x21 };
            HexEdit(0x228E, newData, overlay + "073.bin");
            MessageBox.Show("Your rival will now receive a default name as specified from Text Archive 389, entry 37!");
        }

        private void RemoveOWpoison_Click(object sender, EventArgs e)//lhea
        {
            byte[] newData = { 0x05, 0xE0, 0xC0, 0x46, 0xC0, 0x46, 0xC0, 0x46, 0xC0, 0x46, 0xC0, 0x46, 0xC0, 0x46 };
            HexEdit(0x1BAE, newData, overlay + "005.bin");
            MessageBox.Show("The Hex has been changed!");
        }

        private void RemoveMarshStep_Click(object sender, EventArgs e)//lhea
        {
            byte[] newData = { 0x05, 0xE0, 0xC0, 0x46, 0xC0, 0x46, 0xC0, 0x46, 0xC0, 0x46, 0xC0, 0x46, 0xC0, 0x46 };
            HexEdit(0x1BBC, newData, overlay + "005.bin");
            MessageBox.Show("The Hex has been changed!");
        }

        private void ShayminCheck_Click(object sender, EventArgs e)//adastra
        {
            byte[] newData = { 0xC0, 0x46, 0xC0, 0x46 };
            HexEdit(0x77B6C, newData ,arm9);
            MessageBox.Show("The Hex has been changed!");
        }

        private void PickupEdit_Click(object sender, EventArgs e)//adastra
        {
            PickupEditor pickupEdit = new PickupEditor();
            pickupEdit.ShowDialog();
        }
    }
}
