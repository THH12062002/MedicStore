using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemThuoc.DAO
{
    public class OrderDetailDAO
    {
        private SqlDataAccessHelper dataAccessHelper;

        public OrderDetailDAO()
        {
            dataAccessHelper = new SqlDataAccessHelper();
        }

        /*public List<DTO.OrderDetailDTO> GetOrderDetail()
        {
            string query = "SELECT MedicId, MName, MDate, EDate, Quantity, PerUnit, BatchID, CategoryID, Description, Status FROM Medic";
            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            List<OrderDetailDTO> orders = new List<OrderDetailDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                OrderDetailDTO order = new OrderDetailDTO
                {
                    MedicId = row["MedicId"].ToString(),
                    MName = row["MName"].ToString(),
                    MDate = Convert.ToDateTime(row["MDate"]),
                    EDate = Convert.ToDateTime(row["EDate"]),
                    Quantity = Convert.ToInt64(row["Quantity"]),
                    PerUnit = Convert.ToInt64(row["PerUnit"]),
                    BatchID = Convert.ToInt32(row["BatchID"]),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    Description = row["Description"].ToString(),
                    Status = row["Status"].ToString()
                };

                orders.Add(order);
            }

            return orders;
        }*/
        public List<OrderDetailDTO> GetSaleDetailsBySaleID(int saleID)
        {
            try
            {
                // Query to get sale details based on SaleID
                string query = @"SELECT M.MName, C.CategoryName, SD.QuantitySold, SD.SalePrice, D.DiscountPercentage, S.TotalAmount
                                 FROM SaleDetail SD
                                 JOIN Medic M ON SD.MedicineID = M.Id
                                 JOIN Sale S ON SD.SaleID = S.SaleID
                                 JOIN Discount D ON SD.DiscountID = D.DiscountID
                                 JOIN Category C ON M.CategoryID = C.CategoryID
                                 WHERE SD.SaleID = @SaleID";

                // Parameter for the SQL query
                SqlParameter[] parameters =
                {
                    new SqlParameter("@SaleID", saleID)
                };

                // Execute the query
                DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

                // List to store SaleDetailDTO objects
                List<OrderDetailDTO> saleDetails = new List<OrderDetailDTO>();

                // Convert DataTable to List of SaleDetailDTO
                foreach (DataRow row in dataTable.Rows)
                {
                    OrderDetailDTO saleDetail = new OrderDetailDTO
                    {
                        medicName = row["MName"].ToString(),
                        CategoryName = row["CategoryName"].ToString(),
                        quantitySold = Convert.ToInt32(row["QuantitySold"]),
                        totalPrice = Convert.ToDecimal(row["SalePrice"]),
                        discountPercentage = Convert.ToDecimal(row["DiscountPercentage"]),
                        totalAmount = Convert.ToDecimal(row["TotalAmount"])
                    };

                    saleDetails.Add(saleDetail);
                }

                return saleDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting sale details by SaleID: {ex.Message}");
                // Handle exceptions here if needed
                return null; // Return null to indicate an error
            }
        }
    }
}
