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

        public bool AddSaleDetails(List<SaleDetailDTO> saleDetail)
        {
            try
            {
                return saleDetailDAO.AddSaleDetails(saleDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddSaleDetail - SaleDetailBUS: {ex.Message}");
                return false;
            }
        }
    }
}
