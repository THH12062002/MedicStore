using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyTiemThuoc.BUS
{
    public class SaleDetailBUS
    {
        private SaleDetailDAO saleDetailDAO;

        public SaleDetailBUS()
        {
            saleDetailDAO = new SaleDetailDAO();
        }

        public List<SaleDetailDTO> GetAllSaleDetails()
        {
            try
            {
                return saleDetailDAO.GetAllSaleDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllSaleDetails - SaleDetailBUS: {ex.Message}");
                return new List<SaleDetailDTO>();
            }
        }
        public bool AddSaleDetail(int saleID, int medicineID, int quantitySold, decimal salePrice, int discountID)
        {
            try
            {
                // Gọi hàm tương ứng trong DAO để thêm SaleDetail vào cơ sở dữ liệu
                return saleDetailDAO.AddSaleDetail(saleID, medicineID, quantitySold, salePrice, discountID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding sale detail: {ex.Message}");
                // Xử lý exception tại đây nếu cần
                return false;
            }
        }
    }
}
