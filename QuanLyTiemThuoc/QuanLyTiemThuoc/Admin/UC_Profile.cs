using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.Admin
{
    public partial class UC_Profile : UserControl
    {
        private UsersDTO loggedInUser;
        private UsersBUS usersBUS;
        string username = form_Login.LoggedInUsername;

        public UC_Profile()
        {
            InitializeComponent();
            usersBUS = new UsersBUS();
        }

        private void UC_Profile_Load(object sender, EventArgs e)
        {
            ShowUserProfile(username);
        }

        public void ShowUserProfile(string username)
        {
            loggedInUser = usersBUS.GetUserInfoByUsername(username);

            if (loggedInUser != null)
            {
                lblUserName.Text = username;
                txtName.Text = loggedInUser.Name;
                txtRole.Text = loggedInUser.UserRole;
                txtGender.Text = loggedInUser.Gender;
                txtDegree.Text = loggedInUser.Degree;
                txtPhone.Text = loggedInUser.Mobile;
                txtAddress.Text = loggedInUser.Address;
                txtPersonalID.Text = loggedInUser.PersonalID;
                txtEmail.Text = loggedInUser.Email;
                txtPassword.Text = loggedInUser.Password;

                if (DateTime.TryParse(loggedInUser.Dob, out DateTime dob))
                {
                    txtDob.Value = dob;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string loggedInUsername = username;

            loggedInUser = usersBUS.GetUserInfoByUsername(username);

            if (loggedInUser != null)
            {
                UsersDTO updatedUser = new UsersDTO
                {
                    UserRole = txtRole.Text,
                    Name = txtName.Text,
                    Dob = txtDob.Value.ToString("dd/MM/yyyy"),
                    Mobile = txtPhone.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    PersonalID = txtPersonalID.Text,
                    Username = loggedInUsername,
                    Gender = txtGender.Text,
                    Degree = txtDegree.Text
                };

                bool updateResult = usersBUS.UpdateUserInfo(username, updatedUser);

                if (updateResult)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ShowUserProfile(username);
        }
    }
}
