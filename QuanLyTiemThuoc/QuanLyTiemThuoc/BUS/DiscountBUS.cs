using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyTiemThuoc.BUS
{
    public class DiscountBUS
    {
        private readonly DiscountDAO discountDAO;

        public DiscountBUS()
        {
            this.discountDAO = new DiscountDAO();
        }

        public List<DiscountDTO> GetAllDiscounts()
        {
            return discountDAO.GetAllDiscounts();
        }

        public DiscountDTO GetDiscountByCode(string discountCode)
        {
            return discountDAO.GetDiscountInfoByCode(discountCode);
        }
        public List<DiscountDTO> GetDiscountsBelowTotalSaleAmount(decimal thresholdAmount)
        {
            try
            {
                // You can add any additional business logic or validation here if needed

                return discountDAO.GetDiscountsBelowTotalSaleAmount(thresholdAmount);
            }
            catch (Exception ex)
            {
                // Handle exceptions according to your application's error-handling strategy
                // You may log the exception or throw a custom exception
                // For now, rethrowing the exception
                throw;
            }
        }
        // Thêm các phương thức khác nếu cần
    }
}
