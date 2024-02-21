using QuanLyTiemThuoc.BUS;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_BusinessStatistics : UserControl
    {
        private SaleBUS saleBUS;
        public US_BusinessStatistics()
        {
            InitializeComponent();
            saleBUS = new SaleBUS();
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
            endDate = endDate.AddDays(1);
            statisticChart.Series.Clear();

            // Duyệt qua từng ngày trong khoảng thời gian
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
            }
            statisticChart.Visible = true;
        }


    }
}
