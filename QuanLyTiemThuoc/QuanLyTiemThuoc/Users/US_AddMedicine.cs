using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_AddMedicine : UserControl
    {
        private MedicBUS medicBUS;
        private BatchBUS batchBUS;
        private CategoryBUS categoryBUS;
        public US_AddMedicine()
        {
            InitializeComponent();
            medicBUS = new MedicBUS();
            batchBUS = new BatchBUS();
            categoryBUS = new CategoryBUS();
            txtMedicineID.ReadOnly = true;
            // Load danh sách loại thuốc vào combobox
            LoadCategories();
        }
        private void LoadCategories()
        {
            // Gọi phương thức GetAllCategories của CategoryBUS để lấy danh sách loại thuốc
            var categories = categoryBUS.GetAllCategories();

            // Gán danh sách loại thuốc vào ComboBox
            txtCategory.DataSource = categories;
            txtCategory.DisplayMember = "CategoryName";
            txtCategory.ValueMember = "CategoryID";
        }
        private void Reset()
        {
            txtMedicineID.Text = "";
            txtMedicineName.Text = "";
            txtBatch.Text = "";
            txtProductionDate.Value = DateTime.Now;
            txtExpirationDate.Value = DateTime.Now;
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtCategory.SelectedIndex = 0;
            txtDescription.Text = "";
        }

        private void btnAddMedicine_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMedicineName.Text) || string.IsNullOrEmpty(txtBatch.Text) ||
            string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtUnitPrice.Text) ||
             txtCategory.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra kiểu dữ liệu của các trường số
            if (!int.TryParse(txtBatch.Text, out int batchNumber) || batchNumber <= 0 ||
                !int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0 ||
                !long.TryParse(txtUnitPrice.Text, out long perUnit))
            {
                MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu cho các trường số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem ngày sản xuất và ngày hết hạn đã được chọn
            if (txtProductionDate.Value >= txtExpirationDate.Value)
            {
                MessageBox.Show("Ngày sản xuất phải trước ngày hết hạn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int CountBatch = batchBUS.CountBatch(batchNumber);

            if (CountBatch == 1)
            {
                string categoryName = txtCategory.Text;
                int categoryId = categoryBUS.GetCategoryId(categoryName);
                string batchCode = batchBUS.GetBatchCode(batchNumber);
                int batchId = batchBUS.GetBatchId(batchCode);
                string categoryToM = categoryBUS.GetCategoryToM(categoryName);
                string medicineID = medicBUS.GetMedicineID(categoryToM, batchCode);

                // Tạo một đối tượng MedicDTO từ thông tin người dùng nhập vào
                MedicDTO newMedic = new MedicDTO
                {
                    MedicId = medicineID,
                    MName = txtMedicineName.Text,
                    MDate = txtProductionDate.Value,
                    EDate = txtExpirationDate.Value,
                    Quantity = int.Parse(txtQuantity.Text),
                    PerUnit = long.Parse(txtUnitPrice.Text),
                    BatchID = batchId,
                    CategoryID = categoryId,
                    Description = txtDescription.Text
                };

                // Thực hiện hàm AddMedic để thêm thuốc vào cơ sở dữ liệu
                if (medicBUS.AddMedic(newMedic))
                {
                    // Thông báo thành công hoặc cập nhật giao diện nếu cần
                    MessageBox.Show("Thêm thuốc thành công!");
                    Reset();
                }
                else
                {
                    // Thông báo lỗi khi AddMedic không thành công
                    MessageBox.Show("Lỗi khi thêm thuốc!");
                }
            }
            else
            {
                bool batchInserted = batchBUS.InsertBatch(batchNumber);

                if (batchInserted)
                {
                    string categoryName = txtCategory.Text;
                    int categoryId = categoryBUS.GetCategoryId(categoryName);
                    string batchCode = batchBUS.GetBatchCode(batchNumber);
                    int batchId = batchBUS.GetBatchId(batchCode);
                    string categoryToM = categoryBUS.GetCategoryToM(categoryName);
                    string medicineID = medicBUS.GetMedicineID(categoryToM, batchCode);

                    // Tạo một đối tượng MedicDTO từ thông tin người dùng nhập vào
                    MedicDTO newMedic = new MedicDTO
                    {
                        MedicId = medicineID,
                        MName = txtMedicineName.Text,
                        MDate = txtProductionDate.Value,
                        EDate = txtExpirationDate.Value,
                        Quantity = int.Parse(txtQuantity.Text),
                        PerUnit = long.Parse(txtUnitPrice.Text),
                        BatchID = batchId,
                        CategoryID = categoryId,
                        Description = txtDescription.Text
                    };

                    // Thực hiện hàm AddMedic để thêm thuốc vào cơ sở dữ liệu
                    if (medicBUS.AddMedic(newMedic))
                    {
                        medicBUS.CheckAndUpdateDrugStatus();
                        // Thông báo thành công hoặc cập nhật giao diện nếu cần
                        MessageBox.Show("Thêm thuốc thành công!");
                        Reset();
                    }
                    else
                    {
                        // Thông báo lỗi khi AddMedic không thành công
                        MessageBox.Show("Lỗi khi thêm thuốc!");
                    }
                }
                else
                {
                    // Thông báo lỗi khi InsertBatch không thành công
                    MessageBox.Show("Lỗi khi thêm số lô hàng!");
                }
            }


        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtBatch_TextChanged_1(object sender, EventArgs e)
        {
            int batchNumber = 0; // Khởi tạo giá trị mặc định

            if (!string.IsNullOrEmpty(txtBatch.Text))
            {
                if (!int.TryParse(txtBatch.Text, out batchNumber) || batchNumber <= 0)
                {
                    MessageBox.Show("Vui lòng nhập đúng kiểu dữ liệu cho các trường số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string categoryName = txtCategory.Text;

            // Xử lý khi batchNumber chưa được gán giá trị
            if (batchNumber > 0)
            {
                string batchCode = batchBUS.GetBatchCode(batchNumber);
                string categoryToM = categoryBUS.GetCategoryToM(categoryName);
                string medicineID = medicBUS.GetMedicineID(categoryToM, batchCode);

                // Hiện lên Text MedicineID
                txtMedicineID.Text = medicineID;
            }
        }

        private void txtCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int batchNumber;

            if (int.TryParse(txtBatch.Text, out batchNumber))
            {
                string categoryName = txtCategory.Text;
                string batchCode = batchBUS.GetBatchCode(batchNumber);
                string categoryToM = categoryBUS.GetCategoryToM(categoryName);
                string medicineID = medicBUS.GetMedicineID(categoryToM, batchCode);
                txtMedicineID.Text = medicineID;
                // Giá trị đã được chuyển đổi thành công, sử dụng batchNumber ở đây
            }
                

                // Hiện lên Text MedicineID
               
            }

        }

    }

