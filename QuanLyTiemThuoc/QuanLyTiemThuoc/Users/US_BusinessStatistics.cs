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
            UpdateChart();
            txtStartDate.Value = DateTime.Now.Date;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void UpdateChart()
        {
            // Lấy ngày bắt đầu và ngày kết thúc từ DateTimePicker
            DateTime startDate = txtStartDate.Value;
            DateTime endDate = txtEndDate.Value;

            statisticChart.Series.Clear();
            if (endDate == startDate)
            {
                DateTime currentDate = startDate;
                // Tạo một series mới cho mỗi ngày
                Series daySeries = new Series(currentDate.ToString("dd-MM-yyyy"));
                daySeries.ChartType = SeriesChartType.Column;

                // Gọi hàm từ BUS để lấy doanh thu cho ngày hiện tại
                decimal dailyRevenue = saleBUS.GetTotalRevenueByDate(currentDate);

                // Thêm điểm dữ liệu vào series mới
                daySeries.Points.AddXY(currentDate.ToString("dd-MM-yyyy"), dailyRevenue);
                // Thêm series mới vào Chart
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
                    daySeries.Points.AddXY(currentDate.ToString("dd-MM-yyyy"), dailyRevenue);

                    // Thêm series mới vào Chart
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
    }
}
