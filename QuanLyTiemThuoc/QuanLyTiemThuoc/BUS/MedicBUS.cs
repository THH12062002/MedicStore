using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyTiemThuoc.BUS
{
    public class MedicBUS
    {
        private MedicDAO medicDAO;

        public MedicBUS()
        {
            medicDAO = new MedicDAO();
        }

        public List<MedicDTO> GetAllMedic()
        {
            try
            {
                return medicDAO.GetAllMedic();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMedic: {ex.Message}");
                return new List<MedicDTO>();
            }
        }

        public int CountExpiredMedic()
        {
            try
            {
                return medicDAO.CountExpiredMedic();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CountExpiredMedic: {ex.Message}");
                return 0;
            }
        }

        public int CountActiveMedic()
        {
            try
            {
                return medicDAO.CountActiveMedic();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CountActiveMedic: {ex.Message}");
                return 0;
            }
        }

        public bool AddMedic(MedicDTO newMedic)
        {
            try
            {
                medicDAO.AddMedic(newMedic);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddMedic: {ex.Message}");
                return false;
            }
        }

        public void UpdateMedic(MedicDTO updatedMedic)
        {
            try
            {
                medicDAO.UpdateMedic(updatedMedic);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateMedic: {ex.Message}");
            }
        }

        public void CheckAndUpdateDrugStatus()
        {
            try
            {
                medicDAO.CheckAndUpdateDrugStatus();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CheckAndUpdateDrugStatus: {ex.Message}");
            }
        }

        public string GetMedicineID(string categoryToM, string batchCode)
        {
            try
            {
                return medicDAO.GetMedicineID(categoryToM, batchCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMedicineID: {ex.Message}");
                return null;
            }
        }

        public List<MedicDTO> GetAllMedicByMedicID(string medicID)
        {
            try
            {
                return medicDAO.GetAllMedicByMedicID(medicID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMedicByCategory - MedicBUS: {ex.Message}");
                return null;
            }
        }
        public List<MedicDTO> SearchMedicByName(string keyword)
        {
            try
            {
                return medicDAO.SearchMedicByName(keyword);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchMedicByName - MedicBUS: {ex.Message}");
                return null;
            }
        }
        public bool DeleteMedic(string medicId)
        {
            try
            {
                medicDAO.DeleteMedic(medicId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Delete: {ex.Message}");
                return false;
            }
        }
        public List<MedicDTO> GetMedicByCategoryId(int categoryId)
        {
            return medicDAO.GetMedicByCategoryId(categoryId);
        }
    }
}
