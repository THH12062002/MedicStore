using QuanLyTiemThuoc.DTO;
using System.Data.SqlClient;

namespace QuanLyTiemThuoc.DAO
{
    public class DiscountDAO
    {
        private string connectionString; // Thay bằng chuỗi kết nối của bạn

        public DiscountDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<DiscountDTO> GetAllDiscounts()
        {
            List<DiscountDTO> discounts = new List<DiscountDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Discount";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DiscountDTO discount = new DiscountDTO
                            {
                                DiscountID = Convert.ToInt32(reader["DiscountID"]),
                                DiscountCode = reader["DiscountCode"].ToString(),
                                StartDate = Convert.ToDateTime(reader["StartDate"]),
                                EndDate = Convert.ToDateTime(reader["EndDate"]),
                                TotalSaleAmount = Convert.ToDecimal(reader["TotalSaleAmount"]),
                                DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"])
                            };

                            discounts.Add(discount);
                        }
                    }
                }
            }

            return discounts;
        }

        // Thêm các phương thức khác nếu cần
    }
}
