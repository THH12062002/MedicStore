using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.Admin
{

    public partial class UC_ViewUser : UserControl
    {
        private UsersBUS usersBUS;
        private UsersDTO usersDTO;
        private UsersDAO usersDAO;
        public UC_ViewUser()
        {
            InitializeComponent();
            usersDTO = new UsersDTO();
            usersBUS = new UsersBUS();
            usersDAO = new UsersDAO();
            LoadUserData();

            txtRole.SelectedIndex = txtGender.SelectedIndex = 2;
        }

        private void LoadUserData()
        {

            try
            {
                dataGridView1.DataSource = usersBUS.GetAllUsers();
                txtSearch.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string selectedRole = txtRole.SelectedItem.ToString();
            string selectedGender = txtGender.SelectedItem.ToString();

            // Gọi hàm lọc từ BUS và hiển thị kết quả trực tiếp trong DataGridView
            dataGridView1.DataSource = usersBUS.GetFilteredUsers(selectedRole, selectedGender);
            txtSearch.Text = string.Empty;
            // Xóa cột Password nếu có
            if (dataGridView1.Columns.Contains("Password"))
            {
                dataGridView1.Columns.Remove("Password");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Xóa cột Password nếu có
            if (dataGridView1.Columns.Contains("Password"))
            {
                dataGridView1.Columns.Remove("Password");
                dataGridView1.Columns.Remove("Id");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadUserData();
            txtRole.SelectedIndex = txtGender.SelectedIndex = 2;
        }

        private void DisplaySearchResultInDataGridView(List<UsersDTO> searchResult)
        {
            dataGridView1.DataSource = null; // Xóa dữ liệu hiện tại
            dataGridView1.DataSource = searchResult; // Hiển thị kết quả tìm kiếm
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            List<UsersDTO> searchResult = usersBUS.SearchUsersByUsername(searchText);
            DisplaySearchResultInDataGridView(searchResult);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Lấy username từ dòng được chọn trong DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string selectedUsername = dataGridView1.SelectedRows[0].Cells["Username"].Value.ToString();

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa người dùng {selectedUsername} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Gọi hàm DeleteUserByUsername từ UsersBUS để xóa người dùng
                    bool deleted = usersBUS.DeleteUserByUsername(selectedUsername);

                    if (deleted)
                    {
                        MessageBox.Show("Người dùng đã được xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi xóa, cập nhật lại hiển thị trong DataGridView
                        LoadUserData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa người dùng. Đã xảy ra lỗi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
