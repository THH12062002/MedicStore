namespace QuanLyTiemThuoc.DTO
{
    public class SaleDetailDTO
    {
        public int SaleDetailID { get; set; }
        public int SaleID { get; set; }
        public int MedicineID { get; set; }
        public int QuantitySold { get; set; }
        public decimal SalePrice { get; set; }
        public int DiscountID { get; set; }
    }
}
