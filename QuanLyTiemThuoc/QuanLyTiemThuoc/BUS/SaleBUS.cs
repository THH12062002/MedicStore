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

        public bool AddSale(SaleDTO saleDTO)
        {
            try
            {
                return saleDAO.AddSale(saleDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddSaleDetail - SaleDetailBUS: {ex.Message}");
                return false;
            }
        }
    }
}
