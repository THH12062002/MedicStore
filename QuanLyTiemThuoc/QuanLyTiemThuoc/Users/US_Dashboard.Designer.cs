﻿using static Guna.UI2.WinForms.Suite.Descriptions;
using System.Xml.Linq;

namespace QuanLyTiemThuoc.Users
{
    partial class US_Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(US_Dashboard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label7 = new Label();
            panel1 = new Panel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pictureBox1 = new PictureBox();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            menuStrip1 = new MenuStrip();
            toolToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(3, 28);
            label7.Name = "label7";
            label7.Size = new Size(193, 46);
            label7.TabIndex = 9;
            label7.Text = "Dashboard";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(251, 191, 192);
            panel1.Controls.Add(guna2Button1);
            panel1.Controls.Add(chart1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(23, 109);
            panel1.Name = "panel1";
            panel1.Size = new Size(1619, 876);
            panel1.TabIndex = 10;
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges1;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Image = (Image)resources.GetObject("guna2Button1.Image");
            guna2Button1.ImageSize = new Size(30, 30);
            guna2Button1.Location = new Point(1415, 708);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button1.Size = new Size(142, 60);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Reload";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // chart1
            // 
            chart1.BackColor = Color.FromArgb(251, 191, 192);
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(1071, 43);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Color = Color.FromArgb(255, 128, 128);
            series1.Legend = "Legend1";
            series1.Name = "Expired Medicine";
            series2.ChartArea = "ChartArea1";
            series2.Color = Color.FromArgb(0, 118, 225);
            series2.Legend = "Legend1";
            series2.Name = "Valid Medicine";
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.Size = new Size(510, 791);
            chart1.TabIndex = 1;
            chart1.Text = "chart1";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(71, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(981, 791);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.TargetControl = this;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1667, 31);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolToolStripMenuItem
            // 
            toolToolStripMenuItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            toolToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            toolToolStripMenuItem.Size = new Size(76, 27);
            toolToolStripMenuItem.Text = "Reload";
            toolToolStripMenuItem.Click += toolToolStripMenuItem_Click;
            // 
            // US_Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(label7);
            Controls.Add(menuStrip1);
            Name = "US_Dashboard";
            Size = new Size(1667, 1101);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private Panel panel1;
        private PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolToolStripMenuItem;
    }
}
