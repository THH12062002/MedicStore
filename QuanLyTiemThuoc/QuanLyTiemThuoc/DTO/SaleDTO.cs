namespace QuanLyTiemThuoc.DTO
{
    public class SaleDTO
    {
        public int SaleID { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int SellerAccountID { get; set; }
        public string SellerAccountName { get; set;}
        
    }
}
