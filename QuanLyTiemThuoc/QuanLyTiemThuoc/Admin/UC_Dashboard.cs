using QuanLyTiemThuoc.BUS;

namespace QuanLyTiemThuoc.Admin
{
    public partial class UC_Dashboard : UserControl
    {
        private UsersBUS usersBUS;
        public UC_Dashboard()
        {
            InitializeComponent();
            usersBUS = new UsersBUS(); // Khởi tạo đối tượng BUS trong hàm khởi tạo
            UpdateUserCounts();
        }
        private void UpdateUserCounts()
        {
            // Sử dụng các phương thức từ BUS để lấy số lượng người dùng
            int adminCount = usersBUS.CountAdmin();
            int userCount = usersBUS.CountUsers();

            // Hiển thị số người dùng trong các Label
            label11.Text = adminCount.ToString();
            label12.Text = userCount.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UpdateUserCounts();
        }
    }
}
