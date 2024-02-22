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
            txtTotalAmount.Text = totalAmount.ToString();
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
