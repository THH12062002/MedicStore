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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(US_BusinessStatistics));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            ((System.ComponentModel.ISupportInitialize)statisticChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
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
            // 
            // txtStartDate
            // 
            txtStartDate.Format = DateTimePickerFormat.Short;
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
            txtEndDate.Format = DateTimePickerFormat.Short;
            txtEndDate.Location = new Point(301, 179);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(149, 27);
            txtEndDate.TabIndex = 17;
            // 
            // btnApply
            // 
            btnApply.BorderRadius = 20;
            btnApply.CustomizableEdges = customizableEdges1;
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
            btnApply.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnApply.Size = new Size(187, 51);
            btnApply.TabIndex = 18;
            btnApply.Text = "Apply";
            btnApply.Click += btnApply_Click;
            // 
            // statisticChart
            // 
            statisticChart.BackColor = SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            statisticChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            statisticChart.Legends.Add(legend1);
            statisticChart.Location = new Point(756, 263);
            statisticChart.Name = "statisticChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Total Price";
            statisticChart.Series.Add(series1);
            statisticChart.Size = new Size(851, 653);
            statisticChart.TabIndex = 19;
            title1.Name = "Statistic Chart";
            statisticChart.Titles.Add(title1);
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.TargetControl = this;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.BackgroundColor = Color.Turquoise;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 4;
            guna2DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.Location = new Point(53, 263);
            guna2DataGridView1.Name = "guna2DataGridView1";
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
            guna2DataGridView1.ThemeStyle.BackColor = Color.Turquoise;
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            guna2DataGridView1.ThemeStyle.ReadOnly = false;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 29;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // btnSelect
            // 
            btnSelect.BorderRadius = 20;
            btnSelect.CustomizableEdges = customizableEdges3;
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
            btnSelect.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnSelect.Size = new Size(184, 56);
            btnSelect.TabIndex = 21;
            btnSelect.Text = "Select";
            btnSelect.Click += btnSelect_Click;
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
            Name = "US_BusinessStatistics";
            Size = new Size(1667, 1102);
            ((System.ComponentModel.ISupportInitialize)statisticChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
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
    }
}
