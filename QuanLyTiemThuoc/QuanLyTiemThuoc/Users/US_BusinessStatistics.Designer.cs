namespace QuanLyTiemThuoc.Users
{
    partial class US_BusinessStatistics
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(US_BusinessStatistics));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label7 = new Label();
            txtStartDate = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            txtEndDate = new DateTimePicker();
            btnApply = new Guna.UI2.WinForms.Guna2Button();
            statisticChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            btnSelect = new Guna.UI2.WinForms.Guna2Button();
            menuStrip1 = new MenuStrip();
            applyToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)statisticChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(14, 11);
            label7.Name = "label7";
            label7.Size = new Size(307, 46);
            label7.TabIndex = 12;
            label7.Text = "Business Statistics";
            label7.Click += label7_Click;
            // 
            // txtStartDate
            // 
            txtStartDate.CustomFormat = "dd/MM/yyyy";
            txtStartDate.Format = DateTimePickerFormat.Custom;
            txtStartDate.Location = new Point(99, 179);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.Size = new Size(149, 27);
            txtStartDate.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(99, 140);
            label2.Name = "label2";
            label2.Size = new Size(110, 28);
            label2.TabIndex = 15;
            label2.Text = "Start Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(301, 140);
            label3.Name = "label3";
            label3.Size = new Size(98, 28);
            label3.TabIndex = 16;
            label3.Text = "End Date";
            // 
            // txtEndDate
            // 
            txtEndDate.CustomFormat = "dd/MM/yyyy";
            txtEndDate.Format = DateTimePickerFormat.Custom;
            txtEndDate.Location = new Point(301, 179);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(149, 27);
            txtEndDate.TabIndex = 17;
            // 
            // btnApply
            // 
            btnApply.BorderRadius = 20;
            btnApply.CustomizableEdges = customizableEdges9;
            btnApply.DisabledState.BorderColor = Color.DarkGray;
            btnApply.DisabledState.CustomBorderColor = Color.DarkGray;
            btnApply.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnApply.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnApply.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnApply.ForeColor = Color.White;
            btnApply.Image = (Image)resources.GetObject("btnApply.Image");
            btnApply.ImageSize = new Size(35, 35);
            btnApply.Location = new Point(537, 155);
            btnApply.Name = "btnApply";
            btnApply.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnApply.Size = new Size(187, 51);
            btnApply.TabIndex = 18;
            btnApply.Text = "Apply";
            btnApply.Click += btnApply_Click;
            // 
            // statisticChart
            // 
            statisticChart.BackColor = SystemColors.Control;
            chartArea3.Name = "ChartArea1";
            statisticChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            statisticChart.Legends.Add(legend3);
            statisticChart.Location = new Point(756, 263);
            statisticChart.Name = "statisticChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Total Price";
            statisticChart.Series.Add(series3);
            statisticChart.Size = new Size(851, 653);
            statisticChart.TabIndex = 19;
            title3.Name = "Statistic Chart";
            statisticChart.Titles.Add(title3);
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.TargetControl = this;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle7.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            guna2DataGridView1.ColumnHeadersHeight = 45;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(40, 263);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.RowHeadersVisible = false;
            guna2DataGridView1.RowHeadersWidth = 51;
            guna2DataGridView1.RowTemplate.Height = 29;
            guna2DataGridView1.Size = new Size(669, 653);
            guna2DataGridView1.TabIndex = 20;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 45;
            guna2DataGridView1.ThemeStyle.ReadOnly = true;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 29;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.CellContentClick += guna2DataGridView1_CellContentClick;
            guna2DataGridView1.DataBindingComplete += guna2DataGridView1_DataBindingComplete;
            // 
            // btnSelect
            // 
            btnSelect.BorderRadius = 20;
            btnSelect.CustomizableEdges = customizableEdges11;
            btnSelect.DisabledState.BorderColor = Color.DarkGray;
            btnSelect.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSelect.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSelect.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSelect.FillColor = Color.FromArgb(0, 192, 192);
            btnSelect.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSelect.ForeColor = Color.White;
            btnSelect.Image = (Image)resources.GetObject("btnSelect.Image");
            btnSelect.Location = new Point(53, 959);
            btnSelect.Name = "btnSelect";
            btnSelect.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnSelect.Size = new Size(184, 56);
            btnSelect.TabIndex = 21;
            btnSelect.Text = "Select";
            btnSelect.Click += btnSelect_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { applyToolStripMenuItem, searchToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1667, 28);
            menuStrip1.TabIndex = 22;
            menuStrip1.Text = "menuStrip1";
            // 
            // applyToolStripMenuItem
            // 
            applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            applyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            applyToolStripMenuItem.Size = new Size(62, 24);
            applyToolStripMenuItem.Text = "Apply";
            applyToolStripMenuItem.Click += applyToolStripMenuItem_Click;
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            searchToolStripMenuItem.Size = new Size(67, 24);
            searchToolStripMenuItem.Text = "Search";
            searchToolStripMenuItem.Click += searchToolStripMenuItem_Click;
            // 
            // US_BusinessStatistics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnSelect);
            Controls.Add(guna2DataGridView1);
            Controls.Add(statisticChart);
            Controls.Add(btnApply);
            Controls.Add(txtEndDate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtStartDate);
            Controls.Add(label7);
            Controls.Add(menuStrip1);
            Name = "US_BusinessStatistics";
            Size = new Size(1667, 1102);
            ((System.ComponentModel.ISupportInitialize)statisticChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private DateTimePicker txtStartDate;
        private Label label2;
        private Label label3;
        private DateTimePicker txtEndDate;
        private Guna.UI2.WinForms.Guna2Button btnApply;
        private System.Windows.Forms.DataVisualization.Charting.Chart statisticChart;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2Button btnSelect;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem applyToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
    }
}
