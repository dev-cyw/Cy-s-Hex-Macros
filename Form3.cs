using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cy_s_Hex_Macros
{
    public partial class PickupEditor : Form
    {
        public string arm9 = Game_Option.arm9;
        static string overlay = Game_Option.arm9.Remove(Game_Option.arm9.Length - 8) + @"\overlay\overlay_0";
        
        
        BinaryReader reader = new BinaryReader(File.Open(overlay + "016.bin", FileMode.Open, FileAccess.Read));

        public PickupEditor()
        {
            InitializeComponent();
        }

        private void PickupEditor_Load(object sender, EventArgs e)
        {
            int i = 0;
            string[] ItemsPlats = File.ReadAllLines(@"C:\Users\cpoon\source\repos\Cy's Hex Macros\ItemsPlat.txt", Encoding.UTF8);
            int[] ItemOffsets = 
            {
                0x3352C, 0x3352E, 0x33530, 0x33532, 0x33534, 0x33536, 0x33538, 0x3353A, 0x3353C, 0x3353E, 0x33540, 0x33542, 0x33544, 0x33546, 0x33548, 0x3354A, 0x3354C, 0x3354E,
                0x33450, 0x33452, 0x33454, 0x33456, 0x33458, 0x3345A, 0x3345C, 0x3345E, 0x33452, 0x33460, 0x33462,
            };

            foreach (var Control in this.Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                byte[] bytes;
                Control.Items.AddRange(ItemsPlats);
                reader.BaseStream.Seek(ItemOffsets[i], SeekOrigin.Begin);
                bytes = reader.ReadBytes(2);
                Control.SelectedIndex = BitConverter.ToInt16(bytes, 0);
                i++;
            }
            reader.Close();          
        }

        private void PickupEditor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
