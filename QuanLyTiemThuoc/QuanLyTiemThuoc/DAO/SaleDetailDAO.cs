using QuanLyTiemThuoc.DTO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTiemThuoc.DAO
{
    public class SaleDetailDAO
    {
        private SqlDataAccessHelper dataAccessHelper; // Thay bằng chuỗi kết nối của bạn
        public SaleDetailDAO()
        {
            dataAccessHelper = new SqlDataAccessHelper();
        }

        public List<SaleDetailDTO> GetAllSaleDetails()
        {
            string query = "SELECT * FROM SaleDetail";
            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);
            List<SaleDetailDTO> saleDetails = new List<SaleDetailDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                SaleDetailDTO saleDetail = new SaleDetailDTO
                {
                    SaleDetailID = Convert.ToInt32(row["SaleDetailID"]),
                    SaleID = Convert.ToInt32(row["SaleID"]),
                    MedicineID = Convert.ToInt32(row["MedicineID"]),
                    QuantitySold = Convert.ToInt32(row["QuantitySold"]),
                    SalePrice = Convert.ToDecimal(row["SalePrice"]),
                    DiscountID = Convert.ToInt32(row["DiscountID"])
                };

                saleDetails.Add(saleDetail);
            }
            return saleDetails;
        }
        
        public bool AddSaleDetail(int saleID, int medicineID, int quantitySold, decimal salePrice, int discountID)
        {
            try
            {
                // Query to insert a new sale into the 'Sale' table
                string saleDetailInsertQuery = "INSERT INTO SaleDetail (SaleID, MedicineID, QuantitySold, SalePrice, DiscountID) VALUES (@SaleID, @MedicineID, @QuantitySold, @SalePrice, @DiscountID)";
                // Parameters for the SQL query
                SqlParameter[] saleParameters =
                {
                    new SqlParameter("@SaleID", saleID),
                    new SqlParameter("@MedicineID", medicineID),
                    new SqlParameter("@QuantitySold", quantitySold),
                    new SqlParameter("@SalePrice", salePrice),
                    new SqlParameter("@DiscountID", discountID)
                };

                // Execute the insert query with parameters
                dataAccessHelper.ExecuteInsertQuery(saleDetailInsertQuery, saleParameters);

                // Return true to indicate success
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding sale to the database: {ex.Message}");
                // Handle exceptions here if needed
                return false; // Return false to indicate an error
            }
        }


    }
}
