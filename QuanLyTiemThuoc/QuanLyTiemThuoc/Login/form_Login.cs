using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;
using QuanLyTiemThuoc.Users;

namespace QuanLyTiemThuoc
{
    public partial class form_Login : Form
    {
        public static string LoggedInUsername { get; private set; }
        private UsersBUS usersBUS;
        private UsersDTO usersDTO;

        public form_Login()
        {
            InitializeComponent();
            usersBUS = new UsersBUS();
            usersDTO = new UsersDTO();
            InitializeStatusStrip();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void InitializeStatusStrip()
        {
            // Tạo ToolStripStatusLabel cho Username
            ToolStripStatusLabel usernameStatusLabel = new ToolStripStatusLabel("Enter your username");
            statusStrip1.Items.Add(usernameStatusLabel);

            // Tạo ToolStripStatusLabel cho Password
            ToolStripStatusLabel passwordStatusLabel = new ToolStripStatusLabel("Enter your password");
            statusStrip1.Items.Add(passwordStatusLabel);

            // Gắn ToolStripStatusLabel cho TextBox tương ứng
            txtUsername.Tag = usernameStatusLabel;
            txtPassword.Tag = passwordStatusLabel;
        }

        private void UpdateStatusLabel(ToolStripStatusLabel label, string message, bool isError = false)
        {
            label.Text = message;
            label.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Black;
        }

        private void PerformLogin()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Sử dụng UsersBUS để xác thực người dùng
            bool isAuthenticated = usersBUS.AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                // Lấy thông tin người dùng sau khi xác thực
                usersDTO = usersBUS.GetUserInfoByUsername(username);
                LoggedInUsername = username;
                if (usersDTO != null)
                {
                    // Xác thực thành công

                    if (usersDTO.UserRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // Nếu vai trò là admin, hiển thị formAdmin
                        formAdmin formAdmin = new formAdmin(usersDTO.Name);
                        formAdmin.Show();
                    }
                    else if (usersDTO.UserRole.Equals("Pharmacist", StringComparison.OrdinalIgnoreCase))
                    {
                        // Nếu vai trò là user, hiển thị formUser
                        formUser formUser = new formUser(usersDTO.Name, usersDTO.Id);
                        formUser.Show();
                        this.Hide();
                    }

                    // Ẩn form đăng nhập
                    this.Hide();
                }
            }
            else
            {
                UpdateStatusLabel((ToolStripStatusLabel)txtUsername.Tag, "Incorrect username!", true);
                UpdateStatusLabel((ToolStripStatusLabel)txtPassword.Tag, "Incorrect password!", true);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu người dùng ấn phím Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Thực hiện đăng nhập tương tự như khi nhấn nút Login
                PerformLogin();
            }
        }

        private void form_Login_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            UpdateStatusLabel((ToolStripStatusLabel)txtUsername.Tag, "Enter your username");
            UpdateStatusLabel((ToolStripStatusLabel)txtPassword.Tag, "");
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            UpdateStatusLabel((ToolStripStatusLabel)txtUsername.Tag, "");   
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            UpdateStatusLabel((ToolStripStatusLabel)txtPassword.Tag, "");
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            UpdateStatusLabel((ToolStripStatusLabel)txtUsername.Tag, "");
            UpdateStatusLabel((ToolStripStatusLabel)txtPassword.Tag, "Enter your password");
        }
    }
}