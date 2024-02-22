using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyTiemThuoc.BUS
{
    public class OrderDetailBUS
    {
        private OrderDetailDAO orderDetailDAO;

        public OrderDetailBUS()
        {
            orderDetailDAO = new OrderDetailDAO();
        }

        public List<OrderDetailDTO> GetOrderDetailsBySaleID(int saleID)
        {
            try
            {
                // Call the corresponding DAO method to get sale details
                return orderDetailDAO.GetSaleDetailsBySaleID(saleID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting order details by SaleID: {ex.Message}");
                // Handle exceptions here if needed
                return null; // Return null to indicate an error
            }
        }
    }
}
