using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_ViewMedicine : UserControl
    {
        private MedicBUS medicBUS;
        private CategoryBUS categoryBUS;
        private MedicViewBUS medicViewBUS;
        public US_ViewMedicine()
        {
            InitializeComponent();
            medicBUS = new MedicBUS();
            categoryBUS = new CategoryBUS();
            medicViewBUS = new MedicViewBUS();
            // Load danh sách loại thuốc vào combobox
            LoadCategories();

            // Hiển thị toàn bộ danh sách thuốc khi khởi tạo
            LoadMedicinesByCategory();
        }
        private void LoadCategories()
        {
            try
            {
                // Gọi phương thức GetAllCategories của CategoryBUS để lấy danh sách loại thuốc
                var categories = categoryBUS.GetAllCategories();

                // Gán danh sách loại thuốc vào ComboBox
                txtFilter.Items.Add("Null");
                txtFilter.DataSource = categories;
                txtFilter.DisplayMember = "CategoryName";
                txtFilter.ValueMember = "CategoryID";

                txtFilter.SelectedIndex = 0;

                // Gọi phương thức để tải dữ liệu theo loại thuốc đã chọn
                LoadMedicinesByCategory();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LoadCategories: {ex.Message}");
            }
        }
        private void LoadMedicinesByCategory()
        {
            if (txtFilter.SelectedValue != null)
            {
                // Lấy giá trị CategoryID của loại thuốc được chọn
                CategoryDTO selectedCategory = (CategoryDTO)txtFilter.SelectedItem;
                int selectedCategoryId = selectedCategory.CategoryID;

                // Gọi phương thức GetAllMedicByCategory của MedicBUS để lấy danh sách dược phẩm theo loại thuốc
                var medicines = medicViewBUS.GetMedicViews(selectedCategoryId);
                //var batch = batchBUS.GetBatchByBatchID(selectedCategoryId);
                //var category = categoryBUS.GetCategoryName(selectedCategoryId);
                // Gán danh sách dược phẩm vào Guna2DataGridView1
                guna2DataGridView1.DataSource = medicines;
            }
            else
            {
                // Nếu txtFilter.SelectedValue là null, hiển thị toàn bộ dược phẩm
                var allMedicines = medicBUS.GetAllMedic();
                // Gán danh sách dược phẩm vào Guna2DataGridView1
                guna2DataGridView1.DataSource = allMedicines;
            }
        }

        private void txtFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFilter.SelectedValue != null)
            {
                LoadMedicinesByCategory();
            }
            else
            {
                // Nếu giá trị được chọn là null, hiển thị toàn bộ dược phẩm
                LoadMedicinesByCategory();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            // Kiểm tra nếu có từ khoá tìm kiếm
            if (!string.IsNullOrEmpty(keyword))
            {
                // Gọi phương thức SearchMedicByName của MedicBUS để tìm kiếm dược phẩm theo tên
                var medicines = medicBUS.SearchMedicByName(keyword);

                // Gán danh sách dược phẩm vào Guna2DataGridView1
                guna2DataGridView1.DataSource = medicines;
            }
            else
            {
                // Nếu không có từ khoá tìm kiếm, hiển thị lại toàn bộ dược phẩm
                LoadMedicinesByCategory();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Lấy MedicId từ cột đầu tiên của dòng được chọn
                string medicIdToDelete = guna2DataGridView1.SelectedRows[0].Cells["MedicId"].Value.ToString();

                // Gọi phương thức xóa thuốc của MedicBUS
                bool isDeleted = medicBUS.DeleteMedic(medicIdToDelete);

                if (isDeleted)
                {
                    MessageBox.Show("Thuốc đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sau khi xóa thành công, cập nhật hiển thị danh sách thuốc
                    LoadMedicinesByCategory();
                }
                else
                {
                    MessageBox.Show("Không thể xóa thuốc. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadMedicinesByCategory();
        }
    }
}
