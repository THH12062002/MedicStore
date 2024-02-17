using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyTiemThuoc.BUS
{
    public class BatchBUS
    {
        private BatchDAO batchDAO;

        public BatchBUS()
        {
            batchDAO = new BatchDAO();
        }

        public List<BatchDTO> GetAllBatches()
        {
            try
            {
                return batchDAO.GetAllBatches();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllBatches: {ex.Message}");
                return new List<BatchDTO>();
            }
        }

        public bool InsertBatch(int batchNumber)
        {
            try
            {
                return batchDAO.InsertBatch(batchNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertBatch: {ex.Message}");
                return false;
            }
        }
        public bool InsertBatchByBatch(int batchNumber, DateTime inputDate)
        {
            try
            {
                return batchDAO.InsertBatchByBatch(batchNumber, inputDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertBatch: {ex.Message}");
                return false;
            }
        }
        public int CountBatch(int batchNumber)
        {
            return batchDAO.CountBatch(batchNumber);
        }

        public string GetBatchCode( int batchNumber)
        {

            try
            {
                return batchDAO.GetBatchCode( batchNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBatchCode: {ex.Message}");
                return string.Empty;
            }
        }
        public List<BatchDTO> GetBatchByBatchID(int batchID)
        {
            
                return batchDAO.GetBatchByBatchID(batchID);
            
            
        }

        public int GetBatchId(string batchCode)
        {
            try
            {
                return batchDAO.GetBatchId(batchCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBatchId: {ex.Message}");
                return 0;
            }
        }
        public int GetBatchIdByBatch(int batchNumber, DateTime inputDate)
        {
            try
            {
                return batchDAO.GetBatchIdByBatch(batchNumber, inputDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBatchId: {ex.Message}");
                return 0;
            }
        }
        public int GetBatchNumber(int batchID)
        {
            try
            {
                return batchDAO.GetBatchNumber(batchID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBatchId: {ex.Message}");
                return 0;
            }
        }
        public DateTime GetInputDate(int batchID)
        {
            try
            {
                return batchDAO.GetInputDate(batchID);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in GetInputDate: {e.Message}");
                // You need to return a value here, such as DateTime.MinValue or handle it accordingly based on your logic.
                return DateTime.MinValue;
            }
        }
        public bool IsBatchExist(int batchNumber, DateTime inputDate)
        {
            try
            {
                batchDAO.IsBatchExist(batchNumber, inputDate);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddMedic: {ex.Message}");
                return false;
            }
        }


        // Các phương thức khác nếu cần
    }
}
