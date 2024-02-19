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


        // Thêm các phương thức khác nếu cần
    }
}
