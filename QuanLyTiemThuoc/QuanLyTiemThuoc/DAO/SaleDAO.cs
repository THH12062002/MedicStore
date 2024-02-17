using QuanLyTiemThuoc.BUS;
using QuanLyTiemThuoc.DTO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTiemThuoc.DAO
{
    public class SaleDAO
    {
        private SqlDataAccessHelper dataAccessHelper; // Thay bằng chuỗi kết nối của bạn

        public SaleDAO()
        {
            dataAccessHelper = new SqlDataAccessHelper();
        }

        public List<SaleDTO> GetAllSales()
        {
           
            string query = "SELECT * FROM Sale";
            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);
            List<SaleDTO> sales = new List<SaleDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                SaleDTO sale = new SaleDTO
                {
                    SaleID = Convert.ToInt32(row["SaleID"]),
                    SaleDate = Convert.ToDateTime(row["SaleDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    SellerAccountID = Convert.ToInt32(row["SellerAccountID"]),                  
                };

                sales.Add(sale);
                
            }
            return sales;
        }

        public bool AddSale(SaleDTO saleDTO)
        {
            try
            {
                // Thực hiện thêm Sale vào Cơ sở dữ liệu
                string saleInsertQuery = "INSERT INTO Sale (SaleDate, TotalAmount, SellerAccountID) VALUES (@SaleDate, @TotalAmount, @SellerAccountID);";

                SqlParameter[] saleParameters =
                {
            new SqlParameter("@SaleDate", saleDTO.SaleDate),
            new SqlParameter("@TotalAmount", saleDTO.TotalAmount),
            new SqlParameter("@SellerAccountID", saleDTO.SellerAccountID)
        };

                // Thực hiện truy vấn
                dataAccessHelper.ExecuteInsertQuery(saleInsertQuery, saleParameters);

                // Trả về true để thể hiện thành công
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding sale to the database: {ex.Message}");
                // Xử lý exception tại đây nếu cần
                return false; // Trả về false để thể hiện lỗi
            }
        }

    }
}       
