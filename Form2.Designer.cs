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
            this.MainTab = new System.Windows.Forms.TabPage();
            this.ApplyCrits = new System.Windows.Forms.Button();
            this.critRate = new System.Windows.Forms.ComboBox();
            this.KadabEverstone = new System.Windows.Forms.Button();
            this.ShinyNumBox = new System.Windows.Forms.NumericUpDown();
            this.ShinyApply = new System.Windows.Forms.Button();
            this.MartsTab = new System.Windows.Forms.TabPage();
            this.StartersTab = new System.Windows.Forms.TabPage();
            this.NewFile = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PlatTabs.SuspendLayout();
            this.MainTab.SuspendLayout();
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
            this.PlatTabs.Controls.Add(this.MainTab);
            this.PlatTabs.Controls.Add(this.MartsTab);
            this.PlatTabs.Controls.Add(this.StartersTab);
            this.PlatTabs.Location = new System.Drawing.Point(12, 12);
            this.PlatTabs.Name = "PlatTabs";
            this.PlatTabs.SelectedIndex = 0;
            this.PlatTabs.Size = new System.Drawing.Size(365, 426);
            this.PlatTabs.TabIndex = 1;
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.ApplyCrits);
            this.MainTab.Controls.Add(this.critRate);
            this.MainTab.Controls.Add(this.KadabEverstone);
            this.MainTab.Controls.Add(this.ShinyNumBox);
            this.MainTab.Controls.Add(this.ShinyApply);
            this.MainTab.Controls.Add(this.Trainer_Names);
            this.MainTab.Location = new System.Drawing.Point(4, 22);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(357, 400);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "Main";
            this.MainTab.UseVisualStyleBackColor = true;
            // 
            // ApplyCrits
            // 
            this.ApplyCrits.Location = new System.Drawing.Point(281, 36);
            this.ApplyCrits.Name = "ApplyCrits";
            this.ApplyCrits.Size = new System.Drawing.Size(70, 21);
            this.ApplyCrits.TabIndex = 9;
            this.ApplyCrits.Text = "Apply";
            this.ToolTip.SetToolTip(this.ApplyCrits, "Credit to Lhea From Kingdom of DS Hacking");
            this.ApplyCrits.UseVisualStyleBackColor = true;
            this.ApplyCrits.Click += new System.EventHandler(this.ApplyCrits_Click);
            // 
            // critRate
            // 
            this.critRate.FormattingEnabled = true;
            this.critRate.Location = new System.Drawing.Point(195, 36);
            this.critRate.Name = "critRate";
            this.critRate.Size = new System.Drawing.Size(80, 21);
            this.critRate.TabIndex = 8;
            this.critRate.Text = "Crit Rate";
            // 
            // KadabEverstone
            // 
            this.KadabEverstone.Location = new System.Drawing.Point(195, 6);
            this.KadabEverstone.Name = "KadabEverstone";
            this.KadabEverstone.Size = new System.Drawing.Size(156, 23);
            this.KadabEverstone.TabIndex = 7;
            this.KadabEverstone.Text = "Kadabra Everstone";
            this.ToolTip.SetToolTip(this.KadabEverstone, "Credit to Critchy From Kingdom of DS Hacking");
            this.KadabEverstone.UseVisualStyleBackColor = true;
            this.KadabEverstone.Click += new System.EventHandler(this.KadabEverstone_Click);
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
            // MartsTab
            // 
            this.MartsTab.Location = new System.Drawing.Point(4, 22);
            this.MartsTab.Name = "MartsTab";
            this.MartsTab.Size = new System.Drawing.Size(357, 400);
            this.MartsTab.TabIndex = 2;
            this.MartsTab.Text = "Marts";
            this.MartsTab.UseVisualStyleBackColor = true;
            // 
            // StartersTab
            // 
            this.StartersTab.Location = new System.Drawing.Point(4, 22);
            this.StartersTab.Name = "StartersTab";
            this.StartersTab.Size = new System.Drawing.Size(357, 400);
            this.StartersTab.TabIndex = 3;
            this.StartersTab.Text = "Starters (Overlay78)";
            this.StartersTab.UseVisualStyleBackColor = true;
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
            this.MainTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShinyNumBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Trainer_Names;
        private System.Windows.Forms.TabControl PlatTabs;
        private System.Windows.Forms.TabPage MainTab;
        private System.Windows.Forms.Button NewFile;
        private System.Windows.Forms.NumericUpDown ShinyNumBox;
        private System.Windows.Forms.Button ShinyApply;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.TabPage MartsTab;
        private System.Windows.Forms.Button KadabEverstone;
        private System.Windows.Forms.TabPage StartersTab;
        private System.Windows.Forms.Button ApplyCrits;
        private System.Windows.Forms.ComboBox critRate;
    }
}