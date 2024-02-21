using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyTiemThuoc.BUS
{
    public class SaleBUS
    {
        private SaleDAO saleDAO;

        public SaleBUS()
        {
            saleDAO = new SaleDAO();
        }

        public List<SaleDTO> GetAllSales()
        {
            try
            {
                return saleDAO.GetAllSales();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllSales - SaleBUS: {ex.Message}");
                return new List<SaleDTO>();
            }
        }

        public bool AddSale(decimal totalAmount, int sellerAccountID)
        {
            try
            {
                // Call the corresponding DAO method to add the sale
                return saleDAO.AddSale(totalAmount, sellerAccountID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SaleBUS - AddSale: {ex.Message}");
                // Handle exceptions here if needed
                return false; // Return false to indicate an error
            }
        }
        public int GetLatestSaleID()
        {
            try
            {
                // Call the corresponding DAO method to get the latest SaleID
                return saleDAO.GetLatestSaleID();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SaleBUS - GetLatestSaleID: {ex.Message}");
                // Handle exceptions here if needed
                // You may choose to return a default value or throw an exception based on your requirements
                return -1; // Return -1 to indicate an error
            }
        }
        public decimal GetTotalRevenueByDate(DateTime saleDate)
        {
            try
            {
                // Gọi phương thức tương ứng từ DAO và trả kết quả
                return saleDAO.GetTotalRevenueByDate(saleDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SaleBUS.GetTotalRevenueByDate: {ex.Message}");
                // Xử lý các ngoại lệ nếu cần
                return 0; // Hoặc trả về giá trị mặc định khác tùy thuộc vào yêu cầu của bạn
            }
        }
    }
}
