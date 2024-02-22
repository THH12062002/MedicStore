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

        public List<SaleDTO> GetAllSalesByDate(DateTime startDate, DateTime endDate)
        {
            DateTime SD = startDate.Date;
            DateTime ED = endDate.Date;
            string query = "select SaleID, SaleDate, TotalAmount, Users.Name  from Sale join Users on SellerAccountID = Users.Id  where SaleDate between @StartDate and @EndDate";
            SqlParameter[] parameter =
                 {
                    new SqlParameter("@StartDate", SD),
                    new SqlParameter("@EndDate", ED),
                };
            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameter);
            List<SaleDTO> sales = new List<SaleDTO>();
            foreach (DataRow row in dataTable.Rows)
            {
                SaleDTO sale = new SaleDTO
                {
                    SaleID= Convert.ToInt32(row["SaleID"]),
                    SaleDate = Convert.ToDateTime(row["SaleDate"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    SellerAccountName = row["Name"].ToString()
                };

                sales.Add(sale);

            }
            return sales;
        }

        public bool AddSale(decimal totalAmount, int sellerAccountID)
        {
            try
            {
                // Query to insert a new sale into the 'Sale' table
                string saleInsertQuery = "INSERT INTO Sale (SaleDate, TotalAmount, SellerAccountID) VALUES (@SaleDate, @TotalAmount, @SellerAccountID);";

                // Parameters for the SQL query
                SqlParameter[] saleParameters =
                {
                    new SqlParameter("@SaleDate", DateTime.Now),
                    new SqlParameter("@TotalAmount", totalAmount),
                    new SqlParameter("@SellerAccountID", sellerAccountID)
                };

                // Execute the insert query with parameters
                dataAccessHelper.ExecuteInsertQuery(saleInsertQuery, saleParameters);

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
        public int GetLatestSaleID()
        {
            int saleID = 0;
            try
            {
                // Query to get the latest SaleID from the 'Sale' table
                string query = "SELECT TOP 1 SaleID FROM Sale ORDER BY SaleID DESC;";

                // Execute the query
                DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    // Get the SaleID from the first row
                    saleID = Convert.ToInt32(dataTable.Rows[0]["SaleID"]);
                }

                // If no SaleID is found, return a default value or throw an exception
                // You may choose to return -1 or throw an exception based on your requirements
                return saleID;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting latest SaleID: {ex.Message}");
                // Handle exceptions here if needed
                // You may choose to return -1 or throw an exception based on your requirements
                return -1;
            }
        }

        public decimal GetTotalRevenueByDate(DateTime saleDate)
        {
            DateTime saleDateDay = saleDate.Date;
            decimal totalRevenue = 0;
            try
            {
                // Query to calculate total revenue for a specific date
                string query = "SELECT SUM(TotalAmount) AS TotalRevenue FROM Sale WHERE SaleDate = @SaleDate";

                // Parameter for the SQL query
                SqlParameter[] parameters =
                {
            new SqlParameter("@SaleDate", saleDateDay)
        };

                // Execute the query
                DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

                if (dataTable.Rows.Count > 0 && dataTable.Rows[0]["TotalRevenue"] != DBNull.Value)
                {
                    // Get the TotalRevenue from the first row
                    totalRevenue = Convert.ToDecimal(dataTable.Rows[0]["TotalRevenue"]);
                }

                // If no TotalRevenue is found, return 0 or throw an exception based on your requirements
                // You may choose to return -1 or throw an exception based on your requirements
                return totalRevenue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting total revenue by date: {ex.Message}");
                // Handle exceptions here if needed
                // You may choose to return -1 or throw an exception based on your requirements
                return -1;
            }
        }


    }

}
