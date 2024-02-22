using QuanLyTiemThuoc.BUS;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_Dashboard : UserControl
    {
        private MedicBUS medicBUS;
        public US_Dashboard()
        {
            InitializeComponent();
            medicBUS = new MedicBUS();
            UpdateChart();
        }

        private void UpdateChart()
        {
            int countExpired = medicBUS.CountExpiredMedic();
            int countValid = medicBUS.CountActiveMedic();

            // Xóa dữ liệu cũ trên biểu đồ
            chart1.Series["Expired Medicine"].Points.Clear();
            chart1.Series["Valid Medicine"].Points.Clear();

            // Thêm dữ liệu mới
            chart1.Series["Expired Medicine"].Points.AddXY("Expired Medicine", countExpired);
            chart1.Series["Expired Medicine"].IsValueShownAsLabel = true;
            chart1.Series["Valid Medicine"].Points.AddXY("Valid Medicine", countValid);
            chart1.Series["Valid Medicine"].IsValueShownAsLabel = true;

            // Cập nhật lại biểu đồ
            chart1.Update();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Thực hiện Procedure
            medicBUS.CheckAndUpdateDrugStatus();

            // Cập nhật dữ liệu trên biểu đồ sau khi thực hiện Procedure
            UpdateChart();
        }

        private void toolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Thực hiện Procedure
            medicBUS.CheckAndUpdateDrugStatus();

            // Cập nhật dữ liệu trên biểu đồ sau khi thực hiện Procedure
            UpdateChart();
        }
    }
}
