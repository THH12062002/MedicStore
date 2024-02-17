using Guna.UI2.WinForms;
using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_ModifyMedicine : UserControl
    {
        private MedicBUS medicBUS;
        private MedicViewBUS medicviewBUS;
        private BatchBUS batchBUS;
        private CategoryBUS categoryBUS;

        private string currentMedicineID;
        public US_ModifyMedicine()
        {
            InitializeComponent();
            medicviewBUS = new MedicViewBUS();
            batchBUS = new BatchBUS();
            categoryBUS = new CategoryBUS();
            medicBUS = new MedicBUS();
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


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string MedicineID = txtMedicineID.Text;

            // Gọi phương thức từ MedicBUS để lấy thông tin thuốc từ MedicineID
            List<MedicDTO> medicines = medicBUS.GetAllMedicByMedicID(MedicineID);

            if (medicines != null && medicines.Count > 0)
            {
                // Assuming you want to display information for the first item in the list
                MedicDTO medicine = medicines[0];

                // Hiển thị thông tin thuốc lên giao diện
                txtMedicineName.Text = medicine.MName;
                txtBatch.Text = batchBUS.GetBatchNumber(medicine.BatchID).ToString();
                txtInputDate.Value = batchBUS.GetInputDate(medicine.BatchID);
                txtProductionDate.Value = medicine.MDate;
                txtExpirationDate.Value = medicine.EDate;
                txtQuantity.Text = medicine.Quantity.ToString();
                txtUnitPrice.Text = medicine.PerUnit.ToString();
                txtCategory.Text = categoryBUS.GetCategoryName(medicine.CategoryID);
                txtDescription.Text = medicine.Description;
            }
            else
            {
                // Nếu không tìm thấy thuốc, thông báo cho người dùng
                MessageBox.Show("Không tìm thấy thông tin thuốc.", "Thông báo");
                // Xóa thông tin trên giao diện
                ResetForm();
            }
        }

        private void btnUpdateMedicine_Click(object sender, EventArgs e)
        {
            string MedicineID = txtMedicineID.Text;
            string newName = txtMedicineName.Text;
            int newBatchNumber = int.Parse(txtBatch.Text);
            DateTime newProductionDate = txtProductionDate.Value;
            DateTime newExpirationDate = txtExpirationDate.Value;
            DateTime newInputDate = txtInputDate.Value;
            long newQuantity = long.Parse(txtQuantity.Text);
            long newUnit = long.Parse(txtUnitPrice.Text);
            string newCategoryName = txtCategory.Text;
            string newDescription = txtDescription.Text;
            int newBatchID = 0;
            int newCategoryID = categoryBUS.GetCategoryId(newCategoryName);
            if (batchBUS.IsBatchExist(newBatchNumber ,newInputDate))
            {
                newBatchID = batchBUS.GetBatchIdByBatch(newBatchNumber, newInputDate);// Fix this line
                
            }
            else
            {
                bool insertBatch = batchBUS.InsertBatchByBatch(newBatchNumber, newInputDate);
                if (insertBatch)
                {
                    string batchCode = batchBUS.GetBatchCode(newBatchNumber);
                    newBatchID = batchBUS.GetBatchId(batchCode);
                }
            }
            MedicDTO updatedMedicine = new MedicDTO
            {
                MedicId = MedicineID,
                MName = newName,
                MDate = newProductionDate,
                EDate = newExpirationDate,
                Quantity = newQuantity,
                PerUnit = newUnit,
                BatchID = newBatchID,
                CategoryID = newCategoryID,
                Description = newDescription
            };

            medicBUS.UpdateMedic(updatedMedicine);
            medicBUS.CheckAndUpdateDrugStatus();
            MessageBox.Show("Cập nhật thông tin thuốc thành công.", "Thông báo");
            ResetForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void ResetForm()
        {
            // Xóa thông tin trên giao diện
            txtMedicineID.Text = "";
            txtMedicineName.Text = "";
            txtBatch.Text = "";
            txtProductionDate.Value = DateTime.Now;
            txtExpirationDate.Value = DateTime.Now;
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtCategory.Text = "";
            txtDescription.Text = "";
            // Đặt MedicineID hiện tại về rỗng
            currentMedicineID = "";
        }
    }
}
