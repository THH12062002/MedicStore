using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemThuoc.Users
{
    public partial class Orders : Form
    {
        OrderDetailBUS orderDetailBUS;
        OrderDetailDTO orderDetailDTO;

        public Orders()
        {
            InitializeComponent();
        }

        public Orders(int saleID, decimal totalAmount)
        {
            InitializeComponent();
            orderDetailDTO = new OrderDetailDTO();
            orderDetailBUS = new OrderDetailBUS();
            ShowOrderDetail(saleID);
            txtTotalAmount.Text = totalAmount.ToString("C");
            guna2DataGridView1.CellFormatting += Guna2DataGridView1_CellFormatting;
        }

        private void Guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang xử lý cột totalPrice hoặc totalAmount và giá trị không phải là null
            if ((guna2DataGridView1.Columns[e.ColumnIndex].Name == "totalPrice" ) && e.Value != null)
            {
                // Định dạng giá trị của cột thành chuỗi tiền tệ
                e.Value = string.Format("{0:C}", e.Value);
                e.FormattingApplied = true; // Đánh dấu là đã áp dụng định dạng
            }
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "discountPercentage" && e.Value != null)
            {
                // Chuyển giá trị sang dạng số và chia cho 100 để có giá trị phần trăm đúng
                decimal discountPercentage = Convert.ToDecimal(e.Value);
                e.Value = string.Format("{0:P}", discountPercentage / 100);
                e.FormattingApplied = true; // Đánh dấu là đã áp dụng định dạng
            }
        }


        public void ShowOrderDetail(int saleID)
        {
            var oderDetail = orderDetailBUS.GetOrderDetailsBySaleID(saleID);
            guna2DataGridView1.DataSource = oderDetail;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }
}
