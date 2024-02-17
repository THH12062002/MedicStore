using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;
using Guna.UI2.WinForms;
using System.Text;

namespace QuanLyTiemThuoc.Users
{
    public partial class US_SellMedicine : UserControl
    {
        private SaleDetailBUS saleDetailBUS;
        private MedicBUS medicBUS;
        private SaleDTO saleDTO;
        private SaleDetailDTO saleDetailDTO;
        private DiscountDTO discountDTO;
        private CategoryBUS categoryBUS;
        private Dictionary<int, List<MedicDTO>> medicineData = new Dictionary<int, List<MedicDTO>>();
        private List<MedicDTO> cartItems = new List<MedicDTO>();

        public US_SellMedicine()
        {
            InitializeComponent();
            medicBUS = new MedicBUS();
            categoryBUS = new CategoryBUS();
            saleDTO = new SaleDTO();
            saleDetailBUS = new SaleDetailBUS();
            saleDetailDTO = new SaleDetailDTO();
            discountDTO = new DiscountDTO();
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
                // Lấy thông tin từ TextBox và các control khác
                string medicineId = txtMedicineID.Text;
                string name = txtMedicineName.Text;
                DateTime expirationDate = txtExpirationDate.Value;
                string discountCode = txtDiscountCode.Text;

                if (long.TryParse(txtUnitPrice.Text, out long unitPrice) &&
                    int.TryParse(txtQuantity.Text, out int quantity) &&
                    decimal.TryParse(txtDiscountPercentage.Text, out decimal discountPercentage))
                {
                    bool medicineExists = false;
                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        if (row.Cells["MedicineID"].Value != null && row.Cells["MedicineID"].Value.ToString() == medicineId)
                        {
                            medicineExists = true;
                            break;
                        }
                    }

                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm thuốc này vào giỏ hàng không?", "Xác nhận thêm vào giỏ hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Tạo các đối tượng DTO
                        MedicDTO medicDTO = new MedicDTO
                        {
                            MedicId = txtMedicineID.Text,
                            MName = txtMedicineName.Text,
                            EDate = txtExpirationDate.Value,
                            PerUnit = long.Parse(txtUnitPrice.Text),
                        };

                        SaleDTO saleDTO = new SaleDTO
                        {
                            SaleDate = DateTime.Now,
                            TotalAmount = CalculateTotalAmount()
                        };

                        DiscountDTO discountDTO = new DiscountDTO
                        {
                            DiscountCode = txtDiscountCode.Text,
                            DiscountPercentage = decimal.Parse(txtDiscountPercentage.Text),
                        };

                        // Tạo danh sách SaleDetailDTO từ DataGridView
                        List<SaleDetailDTO> saleDetailsList = new List<SaleDetailDTO>();

                        foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                        {
                            SaleDetailDTO saleDetailDTO = new SaleDetailDTO
                            {
                                // Điền thông tin từ DataGridView vào SaleDetailDTO
                                SaleID = 1,
                                MedicineID = Convert.ToInt32(row.Cells["MedicineID"].Value),
                                QuantitySold = Convert.ToInt32(row.Cells["Quantity"].Value),
                                SalePrice = Convert.ToDecimal(row.Cells["TotalPrice"].Value),
                                DiscountID = 1
                    };

                            saleDetailsList.Add(saleDetailDTO);
                        }

                        bool success = saleDetailBUS.AddSaleDetails(saleDetailsList);

                        if (success)
                        {
                            MessageBox.Show("Thêm vào cơ sở dữ liệu thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi khi thêm vào cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // Xử lý lỗi nếu cần
                        }

                        if (medicineExists)
                        {
                            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                            {
                                if (row.Cells["MedicineID"].Value != null && row.Cells["MedicineID"].Value.ToString() == medicineId)
                                {
                                    row.Cells["Quantity"].Value = Convert.ToInt64(row.Cells["Quantity"].Value) + quantity;

                                    decimal totalPrice = CalculateTotalPrice(unitPrice, Convert.ToInt64(row.Cells["Quantity"].Value), discountPercentage);
                                    row.Cells["TotalPrice"].Value = totalPrice;

                                    break;
                                }
                            }
                        }
                        else
                        {
                            // Thêm dữ liệu vào DataGridView
                            guna2DataGridView1.Rows.Add(
                                medicDTO.MedicId,
                                medicDTO.MName,
                                medicDTO.EDate,
                                medicDTO.PerUnit,
                                saleDetailDTO.QuantitySold,
                                discountDTO.DiscountCode,
                                discountDTO.DiscountPercentage,
                                saleDetailDTO.SalePrice
                            );
                        }

                        // Xóa thông tin từ các TextBox sau khi thêm vào DataGridView
                        ClearTextBoxes();

                        // Cập nhật lblTotal sau khi thêm vào DataGridView
                        decimal totalAmount = CalculateTotalAmount();
                        lblTotal.Text = $"Total Amount: {totalAmount:C}";
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập các giá trị số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thuốc từ danh sách trước khi thêm vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    txtQuantity.Text = selectedMedicine.Quantity.ToString();
                    txtUnitPrice.Text = selectedMedicine.PerUnit.ToString();
                    txtDiscountPercentage.Text = "0";
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng được chọn không
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                // Lấy chỉ số của hàng được chọn
                int selectedIndex = guna2DataGridView1.SelectedRows[0].Index;

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này khỏi giỏ hàng không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra xác nhận từ người dùng
                if (result == DialogResult.Yes)
                {
                    // Xóa hàng được chọn khỏi DataGridView
                    guna2DataGridView1.Rows.RemoveAt(selectedIndex);
                    decimal totalAmount = CalculateTotalAmount();
                    lblTotal.Text = $"Total Amount: {totalAmount:C}";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
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
}
