namespace Cy_s_Hex_Macros
{
    partial class PlatinumHex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Trainer_Names = new System.Windows.Forms.Button();
            this.PlatTabs = new System.Windows.Forms.TabControl();
            this.arm9Tab = new System.Windows.Forms.TabPage();
            this.Overlay16Tab = new System.Windows.Forms.TabPage();
            this.critRate = new System.Windows.Forms.ComboBox();
            this.ApplyCrits = new System.Windows.Forms.Button();
            this.NewFile = new System.Windows.Forms.Button();
            this.ShinyNumBox = new System.Windows.Forms.NumericUpDown();
            this.ShinyApply = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PlatTabs.SuspendLayout();
            this.arm9Tab.SuspendLayout();
            this.Overlay16Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShinyNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Trainer_Names
            // 
            this.Trainer_Names.Location = new System.Drawing.Point(6, 6);
            this.Trainer_Names.Name = "Trainer_Names";
            this.Trainer_Names.Size = new System.Drawing.Size(156, 23);
            this.Trainer_Names.TabIndex = 0;
            this.Trainer_Names.Text = "DSPRE Trainer Names";
            this.Trainer_Names.UseVisualStyleBackColor = true;
            this.Trainer_Names.Click += new System.EventHandler(this.Trainer_Names_Click);
            // 
            // PlatTabs
            // 
            this.PlatTabs.Controls.Add(this.arm9Tab);
            this.PlatTabs.Controls.Add(this.Overlay16Tab);
            this.PlatTabs.Location = new System.Drawing.Point(12, 12);
            this.PlatTabs.Name = "PlatTabs";
            this.PlatTabs.SelectedIndex = 0;
            this.PlatTabs.Size = new System.Drawing.Size(365, 426);
            this.PlatTabs.TabIndex = 1;
            // 
            // arm9Tab
            // 
            this.arm9Tab.Controls.Add(this.ShinyNumBox);
            this.arm9Tab.Controls.Add(this.ShinyApply);
            this.arm9Tab.Controls.Add(this.Trainer_Names);
            this.arm9Tab.Location = new System.Drawing.Point(4, 22);
            this.arm9Tab.Name = "arm9Tab";
            this.arm9Tab.Padding = new System.Windows.Forms.Padding(3);
            this.arm9Tab.Size = new System.Drawing.Size(357, 400);
            this.arm9Tab.TabIndex = 0;
            this.arm9Tab.Text = "Arm9";
            this.arm9Tab.UseVisualStyleBackColor = true;
            // 
            // Overlay16Tab
            // 
            this.Overlay16Tab.Controls.Add(this.ApplyCrits);
            this.Overlay16Tab.Controls.Add(this.critRate);
            this.Overlay16Tab.Location = new System.Drawing.Point(4, 22);
            this.Overlay16Tab.Name = "Overlay16Tab";
            this.Overlay16Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Overlay16Tab.Size = new System.Drawing.Size(357, 400);
            this.Overlay16Tab.TabIndex = 1;
            this.Overlay16Tab.Text = "Overlay16";
            this.Overlay16Tab.UseVisualStyleBackColor = true;
            // 
            // critRate
            // 
            this.critRate.FormattingEnabled = true;
            this.critRate.Location = new System.Drawing.Point(6, 8);
            this.critRate.Name = "critRate";
            this.critRate.Size = new System.Drawing.Size(80, 21);
            this.critRate.TabIndex = 0;
            this.critRate.Text = "Crit Rate";
            // 
            // ApplyCrits
            // 
            this.ApplyCrits.Location = new System.Drawing.Point(92, 8);
            this.ApplyCrits.Name = "ApplyCrits";
            this.ApplyCrits.Size = new System.Drawing.Size(70, 21);
            this.ApplyCrits.TabIndex = 1;
            this.ApplyCrits.Text = "Apply";
            this.ToolTip.SetToolTip(this.ApplyCrits, "Credit to Lhea From Kingdom of DS Hacking");
            this.ApplyCrits.UseVisualStyleBackColor = true;
            this.ApplyCrits.Click += new System.EventHandler(this.ApplyCrits_Click);
            // 
            // NewFile
            // 
            this.NewFile.Location = new System.Drawing.Point(283, 3);
            this.NewFile.Name = "NewFile";
            this.NewFile.Size = new System.Drawing.Size(94, 27);
            this.NewFile.TabIndex = 2;
            this.NewFile.Text = "Open New File";
            this.NewFile.UseVisualStyleBackColor = true;
            this.NewFile.Click += new System.EventHandler(this.NewFile_Click);
            // 
            // ShinyNumBox
            // 
            this.ShinyNumBox.Location = new System.Drawing.Point(6, 35);
            this.ShinyNumBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ShinyNumBox.Name = "ShinyNumBox";
            this.ShinyNumBox.Size = new System.Drawing.Size(80, 20);
            this.ShinyNumBox.TabIndex = 6;
            this.ShinyNumBox.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // ShinyApply
            // 
            this.ShinyApply.Location = new System.Drawing.Point(92, 35);
            this.ShinyApply.Name = "ShinyApply";
            this.ShinyApply.Size = new System.Drawing.Size(70, 21);
            this.ShinyApply.TabIndex = 5;
            this.ShinyApply.Text = "Apply";
            this.ToolTip.SetToolTip(this.ShinyApply, "To calculate The shiny rate you can do *Your number* / 65535");
            this.ShinyApply.UseVisualStyleBackColor = true;
            this.ShinyApply.Click += new System.EventHandler(this.ShinyApply_Click);
            // 
            // PlatinumHex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 450);
            this.Controls.Add(this.NewFile);
            this.Controls.Add(this.PlatTabs);
            this.Name = "PlatinumHex";
            this.Text = "CHM Platinum";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlatinumHex_FormClosing);
            this.Load += new System.EventHandler(this.PlatinumHex_Load);
            this.PlatTabs.ResumeLayout(false);
            this.arm9Tab.ResumeLayout(false);
            this.Overlay16Tab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShinyNumBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Trainer_Names;
        private System.Windows.Forms.TabControl PlatTabs;
        private System.Windows.Forms.TabPage arm9Tab;
        private System.Windows.Forms.TabPage Overlay16Tab;
        private System.Windows.Forms.ComboBox critRate;
        private System.Windows.Forms.Button ApplyCrits;
        private System.Windows.Forms.Button NewFile;
        private System.Windows.Forms.NumericUpDown ShinyNumBox;
        private System.Windows.Forms.Button ShinyApply;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}