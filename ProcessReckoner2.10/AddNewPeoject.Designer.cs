﻿namespace Reckoner_App
{
    partial class AddNewPeoject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewPeoject));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddNPtxt = new System.Windows.Forms.Button();
            this.ProjectTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NewBack = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AddModule = new System.Windows.Forms.Button();
            this.moduleTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddNPtxt);
            this.groupBox1.Controls.Add(this.ProjectTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10F);
            this.groupBox1.Location = new System.Drawing.Point(71, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Projects";
            // 
            // AddNPtxt
            // 
            this.AddNPtxt.BackColor = System.Drawing.Color.LightSteelBlue;
            this.AddNPtxt.Font = new System.Drawing.Font("Calibri", 9F);
            this.AddNPtxt.Image = ((System.Drawing.Image)(resources.GetObject("AddNPtxt.Image")));
            this.AddNPtxt.Location = new System.Drawing.Point(369, 83);
            this.AddNPtxt.Name = "AddNPtxt";
            this.AddNPtxt.Size = new System.Drawing.Size(37, 36);
            this.AddNPtxt.TabIndex = 12;
            this.AddNPtxt.UseVisualStyleBackColor = false;
            this.AddNPtxt.Click += new System.EventHandler(this.AddNewProject_Click);
            // 
            // ProjectTxt
            // 
            this.ProjectTxt.Location = new System.Drawing.Point(85, 38);
            this.ProjectTxt.Name = "ProjectTxt";
            this.ProjectTxt.Size = new System.Drawing.Size(321, 24);
            this.ProjectTxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11F);
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project : ";
            // 
            // NewBack
            // 
            this.NewBack.BackColor = System.Drawing.Color.Transparent;
            this.NewBack.FlatAppearance.BorderSize = 0;
            this.NewBack.Image = global::Reckoner_App.Properties.Resources.b2;
            this.NewBack.Location = new System.Drawing.Point(452, 375);
            this.NewBack.Name = "NewBack";
            this.NewBack.Size = new System.Drawing.Size(37, 36);
            this.NewBack.TabIndex = 15;
            this.NewBack.UseVisualStyleBackColor = false;
            this.NewBack.Click += new System.EventHandler(this.NewBack_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.AddModule);
            this.groupBox2.Controls.Add(this.moduleTxt);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10F);
            this.groupBox2.Location = new System.Drawing.Point(71, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 193);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Modules";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 11F);
            this.comboBox1.ItemHeight = 18;
            this.comboBox1.Location = new System.Drawing.Point(85, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(257, 26);
            this.comboBox1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11F);
            this.label3.Location = new System.Drawing.Point(10, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Project : ";
            // 
            // AddModule
            // 
            this.AddModule.BackColor = System.Drawing.Color.LightSteelBlue;
            this.AddModule.Font = new System.Drawing.Font("Calibri", 9F);
            this.AddModule.Image = ((System.Drawing.Image)(resources.GetObject("AddModule.Image")));
            this.AddModule.Location = new System.Drawing.Point(369, 129);
            this.AddModule.Name = "AddModule";
            this.AddModule.Size = new System.Drawing.Size(37, 36);
            this.AddModule.TabIndex = 12;
            this.AddModule.UseVisualStyleBackColor = false;
            this.AddModule.Click += new System.EventHandler(this.AddModule_Click);
            // 
            // moduleTxt
            // 
            this.moduleTxt.Location = new System.Drawing.Point(85, 84);
            this.moduleTxt.Name = "moduleTxt";
            this.moduleTxt.Size = new System.Drawing.Size(321, 24);
            this.moduleTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Module : ";
            // 
            // AddNewPeoject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(578, 435);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.NewBack);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddNewPeoject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Peoject";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewPeoject_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProjectTxt;
        private System.Windows.Forms.Button AddNPtxt;
        private System.Windows.Forms.Button NewBack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddModule;
        private System.Windows.Forms.TextBox moduleTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}