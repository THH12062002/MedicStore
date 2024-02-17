using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_MedicineVlyCheck : UserControl
    {
        private MedicViewBUS medicViewBUS;
        public US_MedicineVlyCheck()
        {
            InitializeComponent();
            medicViewBUS = new MedicViewBUS();
            txtCheck.Items.Add("View All");
            txtCheck.Items.Add("Expired Medicine");
            txtCheck.Items.Add("Valid Medicine");

            // Mặc định chọn "Tất cả" khi khởi tạo
            txtCheck.SelectedIndex = 0;
            LoadMedicineData();
        }
        private void LoadMedicineData()
        {
            string selectedStatus = txtCheck.SelectedItem.ToString();

            // Gọi phương thức từ MedicViewBUS để lấy dữ liệu thuốc theo trạng thái
            // Chú ý: Cần thay đổi phương thức này dựa trên thực tế của ứng dụng của bạn
            var medicines = medicViewBUS.GetAllMedicines();
            if (selectedStatus == "Expired Medicine")
            {
                // Gọi phương thức để lấy danh sách thuốc hết hạn
                medicines = medicViewBUS.GetExpiredMedicines();
            }
            else if (selectedStatus == "Valid Medicine")
            {
                medicines = medicViewBUS.GetValidMedicines();
            }
            // Hiển thị dữ liệu lên DataGridView hoặc các thành phần khác trong giao diện
            guna2DataGridView1.DataSource = medicines;
        }
        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMedicineData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
