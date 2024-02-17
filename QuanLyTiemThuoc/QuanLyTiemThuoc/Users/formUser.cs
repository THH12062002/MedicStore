namespace QuanLyTiemThuoc.Users
{
    public partial class formUser : Form
    {
        public formUser()
        {
            InitializeComponent();
        }

        public formUser(String name)
        {
            InitializeComponent();
            lblUserName.Text = name;
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            uS_Dashboard1.Visible = false;
            uS_AddMedicine1.Visible = false;
            uS_ViewMedicine1.Visible = false;
            uS_ModifyMedicine1.Visible = false;
            uS_MedicineVlyCheck1.Visible = false;
            uS_SellMedicine1.Visible = false;
            uS_BusinessStatistics1.Visible = false;
            btnDashboard.PerformClick();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uS_Dashboard1.Visible = true;
            uS_Dashboard1.BringToFront();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            form_Login form_Login = new form_Login();
            form_Login.Show();
            this.Hide();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uS_AddMedicine1.Visible = true;
            uS_AddMedicine1.BringToFront();
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uS_ViewMedicine1.Visible = true;
            uS_ViewMedicine1.BringToFront();
        }

        private void btnModifyMedicine_Click(object sender, EventArgs e)
        {
            uS_ModifyMedicine1.Visible = true;
            uS_ModifyMedicine1.BringToFront();
        }

        private void btnMedicineVlyCheck_Click(object sender, EventArgs e)
        {
            uS_MedicineVlyCheck1.Visible = true;
            uS_MedicineVlyCheck1.BringToFront();
        }

        private void btnSellMedicine_Click(object sender, EventArgs e)
        {
            uS_SellMedicine1.Visible = true;
            uS_SellMedicine1.BringToFront();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            uS_BusinessStatistics1.Visible = true;
            uS_BusinessStatistics1.BringToFront();
        }
    }
}
