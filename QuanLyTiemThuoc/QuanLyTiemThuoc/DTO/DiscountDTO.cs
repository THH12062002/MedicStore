namespace QuanLyTiemThuoc.DTO
{
    public class DiscountDTO
    {
        public int DiscountID { get; set; }
        public string DiscountCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalSaleAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
    }

}
