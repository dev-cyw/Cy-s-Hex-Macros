﻿namespace Cy_s_Hex_Macros
{
    partial class Game_Option
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game_Option));
            this.Open_File = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.README = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Open_File
            // 
            this.Open_File.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open_File.Location = new System.Drawing.Point(24, 10);
            this.Open_File.Name = "Open_File";
            this.Open_File.Size = new System.Drawing.Size(120, 35);
            this.Open_File.TabIndex = 0;
            this.Open_File.Text = "Open arm9.bin";
            this.Open_File.UseVisualStyleBackColor = true;
            this.Open_File.Click += new System.EventHandler(this.Open_File_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // README
            // 
            this.README.AutoSize = true;
            this.README.Location = new System.Drawing.Point(56, 48);
            this.README.Name = "README";
            this.README.Size = new System.Drawing.Size(50, 13);
            this.README.TabIndex = 31;
            this.README.TabStop = true;
            this.README.Text = "README";
            this.README.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.README_LinkClicked);
            // 
            // Game_Option
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(169, 70);
            this.Controls.Add(this.README);
            this.Controls.Add(this.Open_File);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game_Option";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHM Menu";
            this.Load += new System.EventHandler(this.Game_Option_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Open_File;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.LinkLabel README;
    }
}

