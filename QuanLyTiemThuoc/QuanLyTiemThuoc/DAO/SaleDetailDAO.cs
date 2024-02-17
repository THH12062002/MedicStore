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
        public bool AddSaleDetails(List<SaleDetailDTO> saleDetails)
        {
            try
            {
                foreach (SaleDetailDTO saleDetail in saleDetails)
                {
                    // Insert SaleDetail
                    string saleDetailInsertQuery = "INSERT INTO SaleDetail (SaleID, MedicineID, QuantitySold, SalePrice, DiscountID) VALUES (@SaleID, @MedicineID, @QuantitySold, @SalePrice, @DiscountID)";
                    SqlParameter[] saleDetailParameters =
                    {
                new SqlParameter("@SaleID", saleDetail.SaleID),
                new SqlParameter("@MedicineID", saleDetail.MedicineID),
                new SqlParameter("@QuantitySold", saleDetail.QuantitySold),
                new SqlParameter("@SalePrice", saleDetail.SalePrice),
                new SqlParameter("@DiscountID", saleDetail.DiscountID)
            };
                    bool saleDetailInserted = dataAccessHelper.ExecuteInsertQuery(saleDetailInsertQuery, saleDetailParameters);

                    if (!saleDetailInserted)
                    {
                        // Nếu có lỗi khi thêm SaleDetail, trả về false
                        return false;
                    }

                    // Update TotalAmount in Sale table
                    string saleUpdateQuery = "UPDATE Sale SET TotalAmount = TotalAmount + @SalePrice WHERE SaleID = @SaleID";
                    SqlParameter[] saleUpdateParameters =
                    {
                new SqlParameter("@SaleID", saleDetail.SaleID),
                new SqlParameter("@SalePrice", saleDetail.SalePrice)
            };
                    bool saleUpdated = dataAccessHelper.ExecuteUpdateQuery(saleUpdateQuery, saleUpdateParameters);

                    if (!saleUpdated)
                    {
                        // Nếu có lỗi khi cập nhật TotalAmount, trả về false
                        return false;
                    }
                }

                // Nếu không có vấn đề gì xảy ra, trả về true
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding sale details to the database: {ex.Message}");
                // Handle the exception as needed
                return false;
            }
        }



    }
}
