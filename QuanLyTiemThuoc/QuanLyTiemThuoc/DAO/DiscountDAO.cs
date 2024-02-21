using QuanLyTiemThuoc.DTO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTiemThuoc.DAO
{
    public class DiscountDAO
    {
        private readonly SqlDataAccessHelper dataAccessHelper;

        public DiscountDAO()
        {
            this.dataAccessHelper = new SqlDataAccessHelper();
        }

        public List<DiscountDTO> GetAllDiscounts()
        {
            List<DiscountDTO> discounts = new List<DiscountDTO>();

            string query = "SELECT * FROM Discount";
            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DiscountDTO discount = new DiscountDTO
                    {
                        DiscountID = Convert.ToInt32(row["DiscountID"]),
                        DiscountCode = row["DiscountCode"].ToString(),
                        StartDate = Convert.ToDateTime(row["StartDate"]),
                        EndDate = Convert.ToDateTime(row["EndDate"]),
                        TotalSaleAmount = Convert.ToDecimal(row["TotalSaleAmount"]),
                        DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"])
                    };

                    discounts.Add(discount);
                }
            }

            return discounts;
        }
        public DiscountDTO GetDiscountInfoByCode(string discountCode)
        {
            // Sử dụng tham số để tránh SQL injection
            string query = "SELECT * FROM Discount WHERE DiscountCode = @DiscountCode";

            SqlParameter[] parameters = { new SqlParameter("@DiscountCode", discountCode) };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);
            DiscountDTO discount = null;

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // Only create the DiscountDTO once, and assign its values in the loop
                discount = new DiscountDTO();

                foreach (DataRow row in dataTable.Rows)
                {
                    // Assign values to the existing discount object
                    discount.DiscountID = Convert.ToInt32(row["DiscountID"]);
                    discount.DiscountCode = row["DiscountCode"].ToString();
                    discount.StartDate = Convert.ToDateTime(row["StartDate"]);
                    discount.EndDate = Convert.ToDateTime(row["EndDate"]);
                    discount.TotalSaleAmount = Convert.ToDecimal(row["TotalSaleAmount"]);
                    discount.DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"]);
                }
            }

            return discount;
        }
        public List<DiscountDTO> GetDiscountsBelowTotalSaleAmount(decimal thresholdAmount)
        {
            // Sử dụng tham số để tránh SQL injection
            string query = "SELECT * FROM Discount WHERE TotalSaleAmount <= @ThresholdAmount ORDER BY TotalSaleAmount DESC";

            SqlParameter[] parameters = { new SqlParameter("@ThresholdAmount", thresholdAmount) };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

            List<DiscountDTO> discounts = new List<DiscountDTO>();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DiscountDTO discount = new DiscountDTO
                    {
                        DiscountID = Convert.ToInt32(row["DiscountID"]),
                        DiscountCode = row["DiscountCode"].ToString(),
                        StartDate = Convert.ToDateTime(row["StartDate"]),
                        EndDate = Convert.ToDateTime(row["EndDate"]),
                        TotalSaleAmount = Convert.ToDecimal(row["TotalSaleAmount"]),
                        DiscountPercentage = Convert.ToDecimal(row["DiscountPercentage"])
                    };

                    discounts.Add(discount);
                }
            }

            return discounts;
        }
        public int GetDiscountIDByCode(string discountCode)
        {
            int discountID = 0;
            try
            {
                // Sử dụng tham số để tránh SQL injection
                string query = "SELECT DiscountID FROM Discount WHERE DiscountCode = @DiscountCode";

                SqlParameter[] parameters = { new SqlParameter("@DiscountCode", discountCode) };

                // Execute the query
                DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    // Lấy DiscountID từ hàng đầu tiên của kết quả truy vấn
                    discountID = Convert.ToInt32(dataTable.Rows[0]["DiscountID"]);
                }

                // Nếu không tìm thấy DiscountID, trả về một giá trị mặc định hoặc xử lý tùy thuộc vào yêu cầu của bạn
                return discountID;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting DiscountID by DiscountCode: {ex.Message}");
                // Xử lý ngoại lệ ở đây nếu cần
                // Bạn có thể chọn trả về -1 hoặc ném một ngoại lệ khác tùy thuộc vào yêu cầu của bạn
                throw; // Hoặc trả về -1 nếu bạn không muốn ném ngoại lệ
            }
        }

        // Thêm các phương thức khác nếu cần
    }
}
