using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.Admin
{
    public partial class UC_AddUser : UserControl
    {
        private UsersBUS usersBUS;
        private UsersDTO usersDTO;
        private UsersDAO usersDAO;
        public UC_AddUser()
        {
            InitializeComponent();
            usersDTO = new UsersDTO();
            usersBUS = new UsersBUS();
            usersDAO = new UsersDAO();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRole.SelectedIndex = -1;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtDegree.SelectedIndex = -1;
            txtPersonalID.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtGender.SelectedIndex = -1;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void CheckUsernameAndDisplayImage(string username)
        {
            // Kiểm tra xem username đã tồn tại hay chưa
            bool isUsernameExists = usersBUS.IsUsernameExists(username);

            // Tùy thuộc vào kết quả kiểm tra, hiển thị ảnh tương ứng
            if (isUsernameExists)
            {
                // Hiển thị ảnh khi username đã tồn tại
                pbCheckUsername.ImageLocation = @"D:\Sv_nam_4\PhatTrienPhanMemUngDung\MedicStore\QuanLyTiemThuoc\QuanLyTiemThuoc\Asset\image_pharmacy\no.png";
            }
            else
            {
                // Hiển thị ảnh khi username chưa tồn tại
                pbCheckUsername.ImageLocation = @"D:\Sv_nam_4\PhatTrienPhanMemUngDung\MedicStore\QuanLyTiemThuoc\QuanLyTiemThuoc\Asset\image_pharmacy\yes.png";
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            CheckUsernameAndDisplayImage(txtUsername.Text);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các trường trong UserControl
            string UserRole = txtRole.SelectedItem?.ToString();
            string Name = txtName.Text;
            string Mobile = txtPhone.Text;
            string Address = txtAddress.Text;
            string Degree = txtDegree.SelectedItem?.ToString();
            string PersonalID = txtPersonalID.Text;
            string Email = txtEmail.Text;
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            string Gender = txtGender.SelectedItem?.ToString();
            DateTime Dob = txtDob.Value;

            UsersDTO newUser = new UsersDTO
            {
                UserRole = UserRole,
                Name = Name,
                Mobile = Mobile,
                Address = Address,
                Degree = Degree,
                PersonalID = PersonalID,
                Email = Email,
                Username = Username,
                Password = Password,
                Gender = Gender,
                Dob = Dob.ToString("dd/MM/yyyy")
            };

            // Thực hiện thêm dữ liệu vào cơ sở dữ liệu
            bool success = usersBUS.InsertUser(newUser);

            if (success)
            {
                // Thêm thành công, bạn có thể thêm logic hiển thị thông báo thành công
                MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi thêm thành công, bạn có thể reset các trường
                btnReset_Click(sender, e);
            }
            else
            {
                // Thêm thất bại, bạn có thể hiển thị thông báo lỗi
                MessageBox.Show("Lỗi khi thêm người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}