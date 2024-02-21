using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;
using Guna.UI2.WinForms;
using System.Text;
using System.Xml.Linq;
using System;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_SellMedicine : UserControl
    {
        public int UserID { get; set; }
        private SaleDetailBUS saleDetailBUS;
        private MedicBUS medicBUS;
        private SaleDTO saleDTO;
        private DiscountBUS discountBUS;
        private SaleDetailDTO saleDetailDTO;
        private DiscountDTO discountDTO;
        private CategoryBUS categoryBUS;
        private SaleBUS saleBUS;
        private Dictionary<int, List<MedicDTO>> medicineData = new Dictionary<int, List<MedicDTO>>();
        private List<MedicDTO> cartItems = new List<MedicDTO>();

        public US_SellMedicine()
        {
            InitializeComponent();
            medicBUS = new MedicBUS();
            categoryBUS = new CategoryBUS();
            discountBUS = new DiscountBUS();
            saleDTO = new SaleDTO();
            saleDetailBUS = new SaleDetailBUS();
            saleDetailDTO = new SaleDetailDTO();
            discountDTO = new DiscountDTO();
            PopulateTreeView();
            txtUnitPrice.TextChanged += UpdateTotalPrice;
            txtQuantity.TextChanged += UpdateTotalPrice;
            txtDiscountPercentage.TextChanged += UpdateTotalPrice;
        }

        public US_SellMedicine(int userId)
        {
            InitializeComponent();
            this.UserID = userId;
            medicBUS = new MedicBUS();
            categoryBUS = new CategoryBUS();
            discountBUS = new DiscountBUS();
            saleDTO = new SaleDTO();
            saleDetailBUS = new SaleDetailBUS();
            saleDetailDTO = new SaleDetailDTO();
            discountDTO = new DiscountDTO();
            saleBUS = new SaleBUS();
            PopulateTreeView();
            txtUnitPrice.TextChanged += UpdateTotalPrice;
            txtQuantity.TextChanged += UpdateTotalPrice;
            txtDiscountPercentage.TextChanged += UpdateTotalPrice;
        }

        private void PopulateTreeView()
        {
            List<CategoryDTO> categories = categoryBUS.GetAllCategories();

            foreach (CategoryDTO category in categories)
            {
                TreeNode categoryNode = new TreeNode(category.CategoryName);
                categoryNode.Tag = category.CategoryID;

                List<MedicDTO> medicines = medicBUS.GetMedicByCategoryId(category.CategoryID);
                medicineData[category.CategoryID] = medicines;

                tvCategory.Nodes.Add(categoryNode);
            }
        }
        private MedicDTO GetSelectedMedicine(string medicId)
        {
            foreach (var medicines in medicineData.Values)
            {
                MedicDTO selectedMedicine = medicines.FirstOrDefault(m => m.MedicId == medicId);
                if (selectedMedicine != null)
                {
                    return selectedMedicine;
                }
            }

            return null;
        }

        private void UpdateTotalPrice(object sender, EventArgs e)
        {
            // Kiểm tra xem có thể chuyển đổi giá trị từ các TextBox sang số không
            if (decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) &&
                int.TryParse(txtQuantity.Text, out int quantity) &&
                decimal.TryParse(txtDiscountPercentage.Text, out decimal discount))
            {
                // Tính toán tổng giá trị
                decimal totalPrice = unitPrice * quantity * (1 - discount / 100);

                // Hiển thị giá trị tổng vào TextBox Total Price
                txtTotalPrice.Text = totalPrice.ToString("C");
            }
            else
            {
                // Nếu có lỗi chuyển đổi, có thể hiển thị thông báo hoặc thực hiện các xử lý khác tùy thuộc vào yêu cầu của bạn
                txtTotalPrice.Text = "Error";
            }
        }

        private decimal CalculateTotalAmount()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["TotalPrice"].Value != null)
                {
                    decimal totalPrice;
                    if (decimal.TryParse(row.Cells["TotalPrice"].Value.ToString(), out totalPrice))
                    {
                        total += totalPrice;
                    }
                }
            }

            return total;
        }

        private decimal CalculateTotalPrice(long unitPrice, long quantity, decimal discount)
        {
            // Tính toán tổng giá trị
            decimal totalPrice = unitPrice * quantity * (1 - discount / 100);

            return totalPrice;
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMedicineID.Text) && !string.IsNullOrEmpty(txtMedicineName.Text))
            {
                string medicineId = txtMedicineID.Text;
                string name = txtMedicineName.Text;
                DateTime expirationDate = txtExpirationDate.Value;
                string discountCode = txtDiscountCode.Text;

                if (long.TryParse(txtUnitPrice.Text, out long unitPrice) &&
                    int.TryParse(txtQuantity.Text, out int quantity) &&
                    decimal.TryParse(txtDiscountPercentage.Text, out decimal discountPercentage))
                {
                    // Kiểm tra xem thuốc đã tồn tại trong giỏ hàng hay chưa
                    bool medicineExists = cartItems.Any(item => item.MedicId == medicineId);

                    if (medicineExists)
                    {
                        // Thuốc đã tồn tại trong giỏ hàng, cập nhật quantity
                        var existingMedicine = cartItems.FirstOrDefault(item => item.MedicId == medicineId);

                        if (existingMedicine != null)
                        {
                            existingMedicine.Quantity += quantity;

                            // Cập nhật quantity trong DataGridView
                            UpdateDataGridViewRow(existingMedicine);
                        }
                    }
                    else
                    {
                        // Thuốc chưa tồn tại trong giỏ hàng, thêm mới vào giỏ hàng và DataGridView
                        MedicDTO newMedicDTO = new MedicDTO
                        {
                            MedicId = medicineId,
                            MName = name,
                            EDate = expirationDate,
                            PerUnit = unitPrice,
                            Quantity = quantity,
                            // Các thuộc tính khác của MedicDTO
                        };
                        DiscountDTO discountDTO = new DiscountDTO
                        {
                            DiscountCode = discountCode,
                            DiscountPercentage = discountPercentage
                        };

                        cartItems.Add(newMedicDTO);

                        // Thêm thông tin vào DataGridView
                        guna2DataGridView1.Rows.Add(
                            newMedicDTO.MedicId,
                            newMedicDTO.MName,
                            newMedicDTO.EDate,
                            newMedicDTO.PerUnit,
                            newMedicDTO.Quantity,
                            discountDTO.DiscountCode,
                            discountDTO.DiscountPercentage,
                            CalculateTotalPrice(newMedicDTO.PerUnit, newMedicDTO.Quantity, discountDTO.DiscountPercentage)
                        );

                        // Cập nhật lblTotal sau khi thêm vào DataGridView
                        decimal totalAmount = CalculateTotalAmount();
                        lblTotal.Text = $"Total Amount: {totalAmount:C}";

                        // Xóa thông tin từ các TextBox sau khi thêm vào DataGridView
                        ClearTextBoxes();
                    }
                }
            }
        }

        private void UpdateDataGridViewRow(MedicDTO existingMedicine)
        {
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["MedicineID"].Value != null && row.Cells["MedicineID"].Value.ToString() == existingMedicine.MedicId)
                {
                    // Cập nhật quantity trong DataGridView
                    row.Cells["Quantity"].Value = existingMedicine.Quantity;

                    // Cập nhật total price
                    row.Cells["TotalPrice"].Value = CalculateTotalPrice(existingMedicine.PerUnit, existingMedicine.Quantity, discountDTO.DiscountPercentage);

                    // Cập nhật lblTotal sau khi thêm vào DataGridView
                    decimal totalAmount = CalculateTotalAmount();
                    lblTotal.Text = $"Total Amount: {totalAmount:C}";

                    // Xóa thông tin từ các TextBox sau khi thêm vào DataGridView
                    ClearTextBoxes();
                    return;
                }
            }
        }


        private void ClearTextBoxes()
        {
            // Hàm để xóa thông tin từ các TextBox
            txtMedicineID.Text = "";
            txtMedicineName.Text = "";
            txtUnitPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDiscountPercentage.Text = "0";
            txtUnitPrice.Text = string.Empty;
            txtTotalPrice.Text = "$0.00";
            txtExpirationDate.Value = DateTime.Now;
        }

        private void tvCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Parent == null)
                {
                    int categoryId = Convert.ToInt32(e.Node.Tag);

                    // Lấy danh sách các thuốc thuộc Category đã chọn
                    List<MedicDTO> medicines = medicineData[categoryId];

                    // Xóa danh sách thuốc hiện tại trong ListView Medic
                    lvMedicine.Items.Clear();

                    foreach (MedicDTO medicine in medicines)
                    {
                        // Tạo một ListViewItem mới cho mỗi dòng và chỉ đặt giá trị MedicId vào Text
                        ListViewItem item = new ListViewItem(medicine.MedicId);

                        // Thêm ListViewItem vào ListView
                        lvMedicine.Items.Add(item);
                    }
                }
            }
        }

        private void lvMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMedicine.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvMedicine.SelectedItems[0];
                string selectedMedicId = selectedItem.SubItems[0].Text;

                // Lấy thông tin thuốc được chọn từ danh sách thuốc
                MedicDTO selectedMedicine = GetSelectedMedicine(selectedMedicId);

                if (selectedMedicine != null)
                {
                    // Hiển thị thông tin thuốc trong các ô TextBox tương ứng
                    txtMedicineID.Text = selectedMedicine.MedicId;
                    txtMedicineName.Text = selectedMedicine.MName;
                    txtExpirationDate.Value = selectedMedicine.EDate;
                    txtQuantity.Text = "0";
                    txtUnitPrice.Text = selectedMedicine.PerUnit.ToString();
                    txtDiscountPercentage.Text = "0";
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedCells.Count > 0)
            {
                // Lấy chỉ số của hàng được chọn
                int selectedIndex = guna2DataGridView1.SelectedCells[0].RowIndex;

                // Kiểm tra xem hàng đó có đang ở trạng thái "added" không
                if (guna2DataGridView1.Rows[selectedIndex].IsNewRow)
                {
                    // Nếu là hàng mới thêm và chưa được commit, chỉ cần xóa khỏi DataGridView
                    guna2DataGridView1.Rows.RemoveAt(selectedIndex);
                }
                else
                {
                    // Nếu không phải là hàng mới, thực hiện xóa
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này khỏi giỏ hàng không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Lấy thông tin thuốc từ DataGridView
                        string medicineID = guna2DataGridView1.Rows[selectedIndex].Cells["MedicineID"].Value?.ToString();

                        // Xóa hàng được chọn khỏi DataGridView
                        guna2DataGridView1.Rows.RemoveAt(selectedIndex);

                        // Xóa mục tương ứng từ cartItems
                        MedicDTO removedMedicine = cartItems.FirstOrDefault(item => item.MedicId == medicineID);
                        if (removedMedicine != null)
                        {
                            cartItems.Remove(removedMedicine);
                        }

                        // Cập nhật tổng giá trị
                        decimal totalAmount = CalculateTotalAmount();
                        lblTotal.Text = $"Total Amount: {totalAmount:C}";
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            decimal totalAmount = CalculateTotalAmount();
            int userID = this.UserID;
            bool addSale = saleBUS.AddSale(totalAmount, userID);
            if (addSale)
            {
                int saleID = saleBUS.GetLatestSaleID();
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    // Lấy giá trị từ cột 'DiscountCode' của từng hàng
                    string discountCode = row.Cells["DiscountCode"].Value?.ToString();
                    string medicineID = row.Cells["MedicineID"].Value?.ToString();
                    int id = medicBUS.GetID(medicineID);
                    int quantity = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["Quantity"].Value);
                    int unitPrice = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["UnitPrice"].Value);

                    decimal discountPercentage = Convert.ToDecimal(guna2DataGridView1.CurrentRow.Cells["DiscountPercentage"].Value);
                    decimal totalPrice = CalculateTotalPrice(unitPrice, quantity, discountPercentage);
                    // Kiểm tra nếu discountCode không rỗng hoặc null
                    if (!string.IsNullOrEmpty(discountCode))
                    {
                        int discountID = discountBUS.GetDiscountIDByCode(discountCode);
                        bool addSaleDetail = saleDetailBUS.AddSaleDetail(saleID, id, quantity, totalPrice, discountID);

                        // Thực hiện các thao tác mong muốn với giá trị discountCode ở đây
                        // Ví dụ: Thêm giá trị vào một danh sách, hiển thị trong TextBox, vv.
                    }
                    else
                    {
                        bool addSaleDetail = saleDetailBUS.AddSaleDetail(saleID, id, quantity, totalPrice, 11);
                    }
                    medicBUS.SellMedic(medicineID, quantity);
                }
                if (cartItems.Count > 0)
                {
                    StringBuilder receipt = new StringBuilder();
                    receipt.AppendLine("HÓA ĐƠN BÁN HÀNG");
                    receipt.AppendLine("----------------------");

                    foreach (var item in cartItems)
                    {
                        receipt.AppendLine($"{item.MedicId} - {item.MName} - {item.Quantity} - {item.Quantity * item.PerUnit:C}");
                    }

                    receipt.AppendLine("----------------------");
                    receipt.AppendLine($"Tổng cộng: {cartItems.Sum(item => item.Quantity * item.PerUnit):C}");

                    MessageBox.Show(receipt.ToString(), "Thông tin hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2DataGridView1.Rows.Clear();
                    cartItems.Clear();

                    ///UpdateCartDataGridView();
                    //CalculateTotalPrice();
                }
                else
                {
                    MessageBox.Show("Giỏ hàng trống. Vui lòng thêm thuốc vào giỏ hàng trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtDiscountCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscountPercentage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            long.TryParse(txtUnitPrice.Text, out long unitPrice);
            long.TryParse(txtQuantity.Text, out long quantity);
            decimal totalPrice = CalculateTotalPrice(unitPrice, quantity, 0);
            List<DiscountDTO> discountList = discountBUS.GetDiscountsBelowTotalSaleAmount(totalPrice);
            if (discountList != null && discountList.Count > 0)
            {

                // Use the first discount from the list
                DiscountDTO firstDiscount = discountList[0];
                if (firstDiscount != null && firstDiscount.EndDate < DateTime.Now)
                {
                    txtDiscountCode.Text = string.Empty;
                    txtDiscountPercentage.Text = "0";
                }
                else
                {
                    if (firstDiscount.DiscountCode == "null")
                    {
                        firstDiscount = discountList[1];
                        txtDiscountCode.Text = firstDiscount.DiscountCode;
                        txtDiscountPercentage.Text = firstDiscount.DiscountPercentage.ToString();
                    }
                    else
                    {
                        txtDiscountCode.Text = firstDiscount.DiscountCode;
                        txtDiscountPercentage.Text = firstDiscount.DiscountPercentage.ToString();

                        // Additional information, replace with your actual controls
                        // txtStartDate.Text = firstDiscount.StartDate.ToString();
                        // txtEndDate.Text = firstDiscount.EndDate.ToString();
                    }
                    // Populate the corresponding fields with discount information

                }

            }
            else
            {
                // No discounts found, continue with the program
                // Clear discount-related fields if needed
                txtDiscountCode.Text = string.Empty;
                txtDiscountPercentage.Text = "0";
                // Clear additional information fields if needed
                // txtStartDate.Text = string.Empty;
                // txtEndDate.Text = string.Empty;
            }
        }

        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string discountCode = txtDiscountCode.Text;
            DiscountDTO discountList = discountBUS.GetDiscountByCode(discountCode);
            long.TryParse(txtUnitPrice.Text, out long unitPrice);
            int.TryParse(txtQuantity.Text, out int quantity);
            decimal totalPrice = CalculateTotalPrice(unitPrice, quantity, 0);
            if (string.IsNullOrEmpty(discountCode))
            {
                // Handle the case where discountCode is null or empty
                MessageBox.Show("Mã giảm giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (totalPrice >= discountList.TotalSaleAmount)
            {

                // Kiểm tra hiệu lực của mã giảm giá
                if (discountList != null && discountList.EndDate < DateTime.Now)
                {
                    MessageBox.Show("Mã giảm giá đã hết hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal discountPercentage = discountList?.DiscountPercentage ?? 0;

                // Hiển thị thông tin giảm giá
                txtDiscountPercentage.Text = discountPercentage.ToString();
                txtTotalPrice.Text = CalculateTotalPrice(unitPrice, quantity, discountPercentage).ToString("C");
            }
            else
            {
                MessageBox.Show("Giá trị không đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtTotalPrice_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}