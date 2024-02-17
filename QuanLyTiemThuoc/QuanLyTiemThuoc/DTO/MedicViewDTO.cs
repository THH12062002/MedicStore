using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemThuoc.DTO
{
    public class MedicViewDTO
    {
        public string MedicId { get; set; }
        public string MName { get; set; }
        public DateTime MDate { get; set; }
        public DateTime EDate { get; set; }
        public long Quantity { get; set; }
        public long PerUnit { get; set; }
        public DateTime InputDate { get; set; }
        public int BatchNumber { get; set; }
        public string BatchCode { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
