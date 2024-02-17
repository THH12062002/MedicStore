using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemThuoc.BUS
{
    public class MedicViewBUS
    {
        private MedicViewDAO medicViewDAO;

        // Add a constructor to initialize medicViewDAO
        public MedicViewBUS()
        {
            medicViewDAO = new MedicViewDAO();
        }

        public List<MedicViewDTO> GetMedicViews(int categoryId)
        {
            try
            {
                return medicViewDAO.GetMedicViews(categoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMedicByCategory - MedicBUS: {ex.Message}");
                return null;
            }
        }
        public List<MedicViewDTO> GetMedicByMedicID(string medicID)
        {
            try
            {
                return medicViewDAO.GetMedicByMedicID(medicID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMedicByCategory - MedicBUS: {ex.Message}");
                return null;
            }
        }
        public List<MedicViewDTO> GetExpiredMedicines()
        {
            try
            {
                return medicViewDAO.GetExpiredMedicines();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMedicByCategory - MedicBUS: {ex.Message}");
                return null;
            }
        }
        public List<MedicViewDTO> GetValidMedicines()
        {
            try
            {
                return medicViewDAO.GetValidMedicines();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMedicByCategory - MedicBUS: {ex.Message}");
                return null;
            }
        }
        public List<MedicViewDTO> GetAllMedicines()
        {
            try
            {
                return medicViewDAO.GetAllMedicines();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMedicByCategory - MedicBUS: {ex.Message}");
                return null;
            }
        }
    }
}
