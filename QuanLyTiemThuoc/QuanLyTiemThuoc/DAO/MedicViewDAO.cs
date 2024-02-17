using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.DAO
{
    public class MedicViewDAO
    {
        private SqlDataAccessHelper dataAccessHelper;

        public MedicViewDAO()
        {
            dataAccessHelper = new SqlDataAccessHelper();
        }

        public List<MedicViewDTO> GetMedicViews(int categoryID)
        {
            string query = "SELECT MedicId, MName, MDate, EDate, Quantity, PerUnit, InputDate, BatchCode, BatchNumber, CategoryName, Description, Status " +
               "FROM Medic " +
               "JOIN Batch ON Medic.BatchID = Batch.BatchID " +
               "JOIN Category ON Medic.CategoryID = Category.CategoryID " +
               "WHERE Medic.CategoryID = @CategoryID";

            // Use SqlParameter to pass the parameter to the query
            SqlParameter[] parameters = { new SqlParameter("@CategoryID", categoryID) };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

            List<MedicViewDTO> medics = new List<MedicViewDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                MedicViewDTO medic = new MedicViewDTO
                {
                    MedicId = row["MedicId"].ToString(),
                    MName = row["MName"].ToString(),
                    MDate = Convert.ToDateTime(row["MDate"]),
                    EDate = Convert.ToDateTime(row["EDate"]),
                    InputDate = Convert.ToDateTime(row["InputDate"]),
                    Quantity = Convert.ToInt64(row["Quantity"]),
                    PerUnit = Convert.ToInt64(row["PerUnit"]),
                    BatchCode = row["BatchCode"].ToString(),
                    BatchNumber = Convert.ToInt32(row["BatchNumber"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Description = row["Description"].ToString(),
                    Status = row["Status"].ToString()
                };

                medics.Add(medic);
            }

            return medics;
        }
        public List<MedicViewDTO> GetMedicByMedicID(string medicID)
        {
            string query = "SELECT MName, MDate, EDate, Quantity, PerUnit, BatchNumber, CategoryName, Description " +
               "FROM Medic " +
               "JOIN Batch ON Medic.BatchID = Batch.BatchID " +
               "JOIN Category ON Medic.CategoryID = Category.CategoryID " +
               "WHERE Medic.MedicID = @MedicID";

            // Use SqlParameter to pass the parameter to the query
            SqlParameter[] parameters = { new SqlParameter("@MedicID", medicID) };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

            List<MedicViewDTO> medics = new List<MedicViewDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                MedicViewDTO medic = new MedicViewDTO
                {
                    MName = row["MName"].ToString(),
                    MDate = Convert.ToDateTime(row["MDate"]),
                    EDate = Convert.ToDateTime(row["EDate"]),
                    Quantity = Convert.ToInt64(row["Quantity"]),
                    PerUnit = Convert.ToInt64(row["PerUnit"]),
                    BatchNumber = Convert.ToInt32(row["BatchNumber"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Description = row["Description"].ToString(),
                };

                medics.Add(medic);
            }

            return medics;
        }
        public List<MedicViewDTO> GetExpiredMedicines()
        {
            string query = "SELECT MedicId, MName, MDate, EDate, Quantity, PerUnit, InputDate,BatchCode, BatchNumber, CategoryName, Description, Status " +
               "FROM Medic " +
               "JOIN Batch ON Medic.BatchID = Batch.BatchID " +
               "JOIN Category ON Medic.CategoryID = Category.CategoryID " +
               "WHERE Medic.Status  = N'Hết hạn'";

            // Use SqlParameter to pass the parameter to the query
            

            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            List<MedicViewDTO> medics = new List<MedicViewDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                MedicViewDTO medic = new MedicViewDTO
                {
                    MedicId = row["MedicId"].ToString(),
                    MName = row["MName"].ToString(),
                    MDate = Convert.ToDateTime(row["MDate"]),
                    EDate = Convert.ToDateTime(row["EDate"]),
                    Quantity = Convert.ToInt64(row["Quantity"]),
                    PerUnit = Convert.ToInt64(row["PerUnit"]),
                    BatchNumber = Convert.ToInt32(row["BatchNumber"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Description = row["Description"].ToString(),
                    InputDate = Convert.ToDateTime(row["InputDate"]),
                    BatchCode = row["BatchCode"].ToString(),
                    Status = row["Status"].ToString()
                };

                medics.Add(medic);
            }

            return medics;
        }
        public List<MedicViewDTO> GetValidMedicines()
        {
            string query = "SELECT MedicId, MName, MDate, EDate, Quantity, PerUnit, InputDate, BatchNumber, BatchCode, CategoryName, Description, Status " +
               "FROM Medic " +
               "JOIN Batch ON Medic.BatchID = Batch.BatchID " +
               "JOIN Category ON Medic.CategoryID = Category.CategoryID " +
               "WHERE Medic.Status  = N'Còn hạn'";

            // Use SqlParameter to pass the parameter to the query


            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            List<MedicViewDTO> medics = new List<MedicViewDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                MedicViewDTO medic = new MedicViewDTO
                {
                    MedicId = row["MedicId"].ToString(),
                    MName = row["MName"].ToString(),
                    MDate = Convert.ToDateTime(row["MDate"]),
                    EDate = Convert.ToDateTime(row["EDate"]),
                    Quantity = Convert.ToInt64(row["Quantity"]),
                    PerUnit = Convert.ToInt64(row["PerUnit"]),
                    BatchNumber = Convert.ToInt32(row["BatchNumber"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Description = row["Description"].ToString(),
                    InputDate = Convert.ToDateTime(row["InputDate"]),
                    BatchCode = row["BatchCode"].ToString(),
                    Status = row["Status"].ToString()
                };

                medics.Add(medic);
            }

            return medics;
        }
        public List<MedicViewDTO> GetAllMedicines()
        {
            string query = "SELECT MedicId, MName, MDate, EDate, Quantity, PerUnit, InputDate, BatchNumber, BatchCode, CategoryName, Description, Status " +
               "FROM Medic " +
               "JOIN Batch ON Medic.BatchID = Batch.BatchID " +
               "JOIN Category ON Medic.CategoryID = Category.CategoryID ";

            // Use SqlParameter to pass the parameter to the query


            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            List<MedicViewDTO> medics = new List<MedicViewDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                MedicViewDTO medic = new MedicViewDTO
                {
                    MedicId = row["MedicId"].ToString(),
                    MName = row["MName"].ToString(),
                    MDate = Convert.ToDateTime(row["MDate"]),
                    EDate = Convert.ToDateTime(row["EDate"]),
                    InputDate = Convert.ToDateTime(row["InputDate"]),
                    BatchCode = row["BatchCode"].ToString(),
                    Quantity = Convert.ToInt64(row["Quantity"]),
                    PerUnit = Convert.ToInt64(row["PerUnit"]),
                    BatchNumber = Convert.ToInt32(row["BatchNumber"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Description = row["Description"].ToString(),
                    Status = row["Status"].ToString()
                };

                medics.Add(medic);
            }

            return medics;
        }
    }
}
