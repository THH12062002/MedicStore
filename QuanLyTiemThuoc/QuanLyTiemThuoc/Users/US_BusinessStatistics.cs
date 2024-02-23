using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_BusinessStatistics : UserControl
    {
        private SaleBUS saleBUS;
        private SaleDTO saleDTO;
        private SaleDetailDTO saleDetailDTO;

        public US_BusinessStatistics()
        {
            InitializeComponent();
            saleBUS = new SaleBUS();
            saleDTO = new SaleDTO();
            saleDetailDTO = new SaleDetailDTO();
            guna2DataGridView1.CellFormatting += Guna2DataGridView1_CellFormatting;
            txtStartDate.Value = DateTime.Now.Date;
            txtEndDate.Value = DateTime.Now.Date;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            UpdateChart(txtStartDate.Value, txtEndDate.Value);
        }

        private void Guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang xử lý cột TotalAmount và giá trị không phải là null
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "TotalAmount" && e.Value != null)
            {
                // Định dạng giá trị của cột TotalAmount thành chuỗi tiền tệ
                e.Value = string.Format("{0:C}", e.Value);
                e.FormattingApplied = true; // Đánh dấu là đã áp dụng định dạng
            }
        }

        private void UpdateChart(DateTime startDate, DateTime endDate)
        {
            statisticChart.Series.Clear();
            if (endDate == startDate)
            {
                DateTime currentDate = startDate;
                Series daySeries = new Series(currentDate.ToString("dd-MM-yyyy"));
                daySeries.ChartType = SeriesChartType.Column;

                // Gọi hàm từ BUS để lấy doanh thu cho ngày hiện tại
                decimal dailyRevenue = saleBUS.GetTotalRevenueByDate(currentDate);

                // Thêm điểm dữ liệu vào series mới
                DataPoint dataPoint = new DataPoint();

                dataPoint.SetValueXY(currentDate.ToString("dd-MM-yyyy"), Convert.ToDouble(dailyRevenue));
                
                // Định dạng giá trị của DataPoint thành chuỗi tiền tệ
                dataPoint.Label = dailyRevenue.ToString("C");

                // Thêm series mới vào Chart
                daySeries.Points.Add(dataPoint);
                statisticChart.Series.Add(daySeries);
                statisticChart.ChartAreas[0].AxisX.Interval = 1;
                statisticChart.Series[currentDate.ToString("dd-MM-yyyy")].IsValueShownAsLabel = true;
                statisticChart.Visible = true;
                var oder = saleBUS.GetAllSalesByDate(txtStartDate.Value, txtEndDate.Value);
                guna2DataGridView1.DataSource = oder;
            }
            else if (endDate > startDate)
            {
                for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
                {
                    // Tạo một series mới cho mỗi ngày
                    Series daySeries = new Series(currentDate.ToString("dd-MM-yyyy"));
                    daySeries.ChartType = SeriesChartType.Column;

                    // Gọi hàm từ BUS để lấy doanh thu cho ngày hiện tại
                    decimal dailyRevenue = saleBUS.GetTotalRevenueByDate(currentDate);

                    // Thêm điểm dữ liệu vào series mới
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.SetValueXY(currentDate.ToString("dd-MM-yyyy"), Convert.ToDouble(dailyRevenue));

                    // Định dạng giá trị của DataPoint thành chuỗi tiền tệ
                    dataPoint.Label = dailyRevenue.ToString("C");

                    // Thêm series mới vào Chart
                    daySeries.Points.Add(dataPoint);
                    statisticChart.Series.Add(daySeries);
                    statisticChart.ChartAreas[0].AxisX.Interval = 1;
                    statisticChart.Series[currentDate.ToString("dd-MM-yyyy")].IsValueShownAsLabel = true;
                }
                statisticChart.Visible = true;
                var oder = saleBUS.GetAllSalesByDate(txtStartDate.Value, txtEndDate.Value);
                guna2DataGridView1.DataSource = oder;
            }
            else
            {
                MessageBox.Show("Start Date must be less or equal than End Date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedRowIndex = guna2DataGridView1.SelectedRows[0].Index;

                // Get the index of the column containing SaleID
                int idColumnIndex = guna2DataGridView1.Columns["SaleID"].Index;

                // Get the index of the column containing TotalAmount
                int totalAmountIndex = guna2DataGridView1.Columns["TotalAmount"].Index;

                if (selectedRowIndex >= 0)
                {
                    // Get the SaleID and TotalAmount from the selected row
                    int selectedOrder = Convert.ToInt32(guna2DataGridView1.Rows[selectedRowIndex].Cells[idColumnIndex].Value);
                    decimal totalAmount = Convert.ToDecimal(guna2DataGridView1.Rows[selectedRowIndex].Cells[totalAmountIndex].Value);

                    // Create an instance of the Orders form with the selected SaleID and TotalAmount
                    Orders order = new Orders(selectedOrder, totalAmount);

                    // Show the Orders form
                    order.ShowDialog();
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (guna2DataGridView1.Columns.Contains("SellerAccountID"))
            {
                guna2DataGridView1.Columns.Remove("SellerAccountID");
            }

        }

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateChart(txtStartDate.Value, txtEndDate.Value);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedRowIndex = guna2DataGridView1.SelectedRows[0].Index;

                // Get the index of the column containing SaleID
                int idColumnIndex = guna2DataGridView1.Columns["SaleID"].Index;

                // Get the index of the column containing TotalAmount
                int totalAmountIndex = guna2DataGridView1.Columns["TotalAmount"].Index;

                if (selectedRowIndex >= 0)
                {
                    // Get the SaleID and TotalAmount from the selected row
                    int selectedOrder = Convert.ToInt32(guna2DataGridView1.Rows[selectedRowIndex].Cells[idColumnIndex].Value);
                    decimal totalAmount = Convert.ToDecimal(guna2DataGridView1.Rows[selectedRowIndex].Cells[totalAmountIndex].Value);

                    // Create an instance of the Orders form with the selected SaleID and TotalAmount
                    Orders order = new Orders(selectedOrder, totalAmount);

                    // Show the Orders form
                    order.ShowDialog();
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void ClearChart()
        {
            // Xóa tất cả các series trên biểu đồ
            statisticChart.Series.Clear();

            // Xóa tất cả các dữ liệu trên biểu đồ
            foreach (var chartArea in statisticChart.ChartAreas)
            {
                chartArea.AxisX.Interval = 0; // Đặt Interval về 0 để xóa các điểm dữ liệu trên trục X
                chartArea.AxisY.Interval = 0; // Đặt Interval về 0 để xóa các điểm dữ liệu trên trục Y
                chartArea.AxisX.CustomLabels.Clear(); // Xóa các nhãn tùy chỉnh trên trục X
                chartArea.AxisY.CustomLabels.Clear(); // Xóa các nhãn tùy chỉnh trên trục Y
            }
        }
        private void US_BusinessStatistics_Load(object sender, EventArgs e)
        {
            txtStartDate.Value = DateTime.Now.Date;
            txtEndDate.Value = DateTime.Now.Date;
            DateTime loadDate = txtStartDate.Value.AddDays(-1);
            UpdateChart(loadDate, txtEndDate.Value);
            ClearChart();
        }
    }
}
