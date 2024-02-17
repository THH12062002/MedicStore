namespace QuanLyTiemThuoc.DTO
{
    public class MedicDTO
    {
        public string MedicId { get; set; }
        public string MName { get; set; }
        public DateTime MDate { get; set; }
        public DateTime EDate { get; set; }
        public long Quantity { get; set; }
        public long PerUnit { get; set; }
        public int BatchID { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
