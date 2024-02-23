using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemThuoc.DTO
{
    public class OrderDetailDTO
    {
        public string medicName { get; set; }
        public string CategoryName { get; set; }
        public long quantitySold { get; set; }

        public decimal discountPercentage { get; set; }
        public decimal totalPrice { get; set; }

    }
}
