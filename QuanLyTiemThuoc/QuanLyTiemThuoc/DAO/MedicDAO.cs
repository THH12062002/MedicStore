using QuanLyTiemThuoc.DTO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTiemThuoc.DAO
{
    public class MedicDAO
    {
        private SqlDataAccessHelper dataAccessHelper;

        public MedicDAO()
        {
            dataAccessHelper = new SqlDataAccessHelper();
        }

        public List<DTO.MedicDTO> GetAllMedic()
        {
            string query = "SELECT MedicId, MName, MDate, EDate, Quantity, PerUnit, BatchID, CategoryID, Description, Status FROM Medic";
            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            List<MedicDTO> medics = new List<MedicDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                MedicDTO medic = new MedicDTO
                {
                    MedicId = row["MedicId"].ToString(),
                    MName = row["MName"].ToString(),              
                    MDate = Convert.ToDateTime(row["MDate"]),
                    EDate = Convert.ToDateTime(row["EDate"]),
                    Quantity = Convert.ToInt64(row["Quantity"]),
                    PerUnit = Convert.ToInt64(row["PerUnit"]),
                    BatchID = Convert.ToInt32(row["BatchID"]),
                    CategoryID = Convert.ToInt32(row["CategoryID"]),
                    Description = row["Description"].ToString(),
                    Status = row["Status"].ToString()
                };

                medics.Add(medic);
            }

            return medics;
        }
        public int GetId(string medicID)
        {
            int id = 0;
            string getIDQuery = "SELECT Id FROM Medic WHERE MedicID = @MedicID";

            SqlParameter[] parameters = { new SqlParameter("@MedicID", medicID) };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(getIDQuery, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
            }

            return id;
        }
        public int CountExpiredMedic()
        {
            int count = 0;

            string query = "SELECT COUNT(*) FROM Medic WHERE Status = N'Hết hạn'";
            SqlParameter[] parameters = { };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                count = Convert.ToInt32(dataTable.Rows[0][0]);
            }

            return count;
        }

        public int CountActiveMedic()
        {
            int count = 0;

            string query = "SELECT COUNT(*) FROM Medic WHERE Status = N'Còn hạn'";
            SqlParameter[] parameters = { };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                count = Convert.ToInt32(dataTable.Rows[0][0]);
            }

            return count;
        }



        public bool AddMedic(MedicDTO newMedic)
        {
            try
            {

                string query = "INSERT INTO Medic (MedicId, MName, MDate, EDate, Quantity, PerUnit, BatchID, CategoryID, Description) " +
                               "VALUES (@MedicId, @MName, @MDate, @EDate, @Quantity, @PerUnit, @BatchID, @CategoryID, @Description)";

                SqlParameter[] parameters = {
                    new SqlParameter("@MedicId", newMedic.MedicId),
                    new SqlParameter("@MName", newMedic.MName),
                    new SqlParameter("@MDate", newMedic.MDate),
                    new SqlParameter("@EDate", newMedic.EDate),
                    new SqlParameter("@Quantity", newMedic.Quantity),
                    new SqlParameter("@PerUnit", newMedic.PerUnit),
                    new SqlParameter("@BatchID", newMedic.BatchID),
                    new SqlParameter("@CategoryID", newMedic.CategoryID),
                    new SqlParameter("@Description", newMedic.Description),
                };

                dataAccessHelper.ExecuteInsertQuery(query, parameters);

                Console.WriteLine("Medic added successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public void UpdateMedic(MedicDTO updatedMedic)
        {
            try
            {

                string query = "UPDATE Medic SET MName = @MName, MDate = @MDate, EDate = @EDate, " +
                               "Quantity = @Quantity, PerUnit = @PerUnit, BatchID = @BatchID, CategoryID = @CategoryID, " +
                               "Description = @Description " +
                               "WHERE MedicId = @MedicId";

                SqlParameter[] parameters = {
                    new SqlParameter("@MedicId", updatedMedic.MedicId),
                    new SqlParameter("@MName", updatedMedic.MName),
                    new SqlParameter("@MDate", updatedMedic.MDate),
                    new SqlParameter("@EDate", updatedMedic.EDate),
                    new SqlParameter("@Quantity", updatedMedic.Quantity),
                    new SqlParameter("@PerUnit", updatedMedic.PerUnit),
                    new SqlParameter("@BatchID", updatedMedic.BatchID),
                    new SqlParameter("@CategoryID", updatedMedic.CategoryID),
                    new SqlParameter("@Description", updatedMedic.Description),
                };

                dataAccessHelper.ExecuteUpdateQuery(query, parameters);

                Console.WriteLine("Medic updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public void CheckAndUpdateDrugStatus()
        {
            try
            {
                string query = " UPDATE Medic\r\n    SET Status = N'Hết hạn'\r\n    WHERE [EDate] < GETDATE(); ";

                SqlParameter[] parameters = {
                    
                };

                dataAccessHelper.ExecuteUpdateQuery(query, parameters);

                Console.WriteLine("Medic updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public string GetMedicineID(string categoryToM, string batchCode)
        {
            try
            {
                string medicineID = $"{categoryToM}{batchCode}";

                return medicineID;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMedicineID: {ex.Message}");
                return null;
            }
        }

        public List<MedicDTO> GetAllMedicByMedicID(string MedicID)
        {
            try
            {
                string query = "SELECT MName, MDate, EDate, Quantity, PerUnit, BatchID, CategoryID, Description " +
                               "FROM Medic " +
                               "WHERE MedicID = @MedicID";

                SqlParameter[] parameters = {
                    new SqlParameter("@MedicID", MedicID)
                };

                DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

                List<MedicDTO> medics = new List<MedicDTO>();

                foreach (DataRow row in dataTable.Rows)
                {
                    MedicDTO medic = new MedicDTO
                    {
                        MName = row["MName"].ToString(),
                        MDate = Convert.ToDateTime(row["MDate"]),
                        EDate = Convert.ToDateTime(row["EDate"]),
                        Quantity = Convert.ToInt64(row["Quantity"]),
                        PerUnit = Convert.ToInt64(row["PerUnit"]),
                        BatchID = Convert.ToInt32(row["BatchID"]),
                        CategoryID = Convert.ToInt32(row["CategoryID"]),
                        Description = row["Description"].ToString(),
                    };

                    medics.Add(medic);
                }

                return medics;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllMedicByCategory: {ex.Message}");
                return null;
            }
        }
        public List<MedicDTO> SearchMedicByName(string keyword)
        {
            try
            {
                string query = "SELECT MedicId, MName, MDate, EDate, Quantity, PerUnit, BatchID, CategoryID, Description, Status " +
                               "FROM Medic " +
                               "WHERE MName LIKE @Keyword";

                SqlParameter[] parameters = {
            new SqlParameter("@Keyword", "%" + keyword + "%")
        };

                DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

                List<MedicDTO> medics = new List<MedicDTO>();

                foreach (DataRow row in dataTable.Rows)
                {
                    MedicDTO medic = new MedicDTO
                    {
                        MedicId = row["MedicId"].ToString(),
                        MName = row["MName"].ToString(),
                        MDate = Convert.ToDateTime(row["MDate"]),
                        EDate = Convert.ToDateTime(row["EDate"]),
                        Quantity = Convert.ToInt64(row["Quantity"]),
                        PerUnit = Convert.ToInt64(row["PerUnit"]),
                        BatchID = Convert.ToInt32(row["BatchID"]),
                        CategoryID = Convert.ToInt32(row["CategoryID"]),
                        Description = row["Description"].ToString(),
                        Status = row["Status"].ToString()
                    };

                    medics.Add(medic);
                }

                return medics;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchMedicByName: {ex.Message}");
                return null;
            }
        }
        public bool DeleteMedic(string medicId)
        {
            try
            {
                string query = "DELETE FROM Medic WHERE MedicId = @MedicId";

                SqlParameter[] parameters = {
            new SqlParameter("@MedicId", medicId)
        };

                dataAccessHelper.ExecuteDeleteQuery(query, parameters);

                Console.WriteLine("Medic deleted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteMedic: {ex.Message}");
                return false;
            }
        }
        public List<MedicDTO> GetMedicByCategoryId(int categoryId)
        {
            try
            {
                string query = "SELECT MedicId, MName, MDate, EDate, Quantity, PerUnit, BatchID, CategoryID, Description, Status " +
                               "FROM Medic " +
                               "WHERE CategoryID = @CategoryId And Status = N'Còn hạn'";

                SqlParameter[] parameters = {
            new SqlParameter("@CategoryId", categoryId)
        };

                DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

                List<MedicDTO> medics = new List<MedicDTO>();

                foreach (DataRow row in dataTable.Rows)
                {
                    MedicDTO medic = new MedicDTO
                    {
                        MedicId = row["MedicId"].ToString(),
                        MName = row["MName"].ToString(),
                        MDate = Convert.ToDateTime(row["MDate"]),
                        EDate = Convert.ToDateTime(row["EDate"]),
                        Quantity = Convert.ToInt64(row["Quantity"]),
                        PerUnit = Convert.ToInt64(row["PerUnit"]),
                        BatchID = Convert.ToInt32(row["BatchID"]),
                        CategoryID = Convert.ToInt32(row["CategoryID"]),
                        Description = row["Description"].ToString(),
                        Status = row["Status"].ToString()
                    };

                    medics.Add(medic);
                }

                return medics;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMedicByCategoryId: {ex.Message}");
                return null;
            }
        }

        public bool SellMedic(string medicId, int soldQuantity)
        {
            try
            {
                // Kiểm tra xem thuốc có tồn tại trong cơ sở dữ liệu không
                string checkExistenceQuery = "SELECT Quantity FROM Medic WHERE MedicId = @MedicId";
                SqlParameter[] checkExistenceParams = { new SqlParameter("@MedicId", medicId) };
                DataTable existenceTable = dataAccessHelper.ExecuteSelectQuery(checkExistenceQuery, checkExistenceParams);

                if (existenceTable != null && existenceTable.Rows.Count > 0)
                {
                    // Lấy số lượng hiện tại của thuốc
                    int currentQuantity = Convert.ToInt32(existenceTable.Rows[0]["Quantity"]);

                    // Kiểm tra xem có đủ số lượng để bán hay không
                    if (currentQuantity >= soldQuantity)
                    {
                        // Trừ số lượng đã bán từ số lượng hiện tại
                        int updatedQuantity = currentQuantity - soldQuantity;

                        // Cập nhật số lượng trong cơ sở dữ liệu
                        string updateQuantityQuery = "UPDATE Medic SET Quantity = @UpdatedQuantity WHERE MedicId = @MedicId";
                        SqlParameter[] updateQuantityParams = {
                        new SqlParameter("@UpdatedQuantity", updatedQuantity),
                        new SqlParameter("@MedicId", medicId)
                    };

                        dataAccessHelper.ExecuteUpdateQuery(updateQuantityQuery, updateQuantityParams);

                        Console.WriteLine($"Medic {medicId} sold successfully. Remaining quantity: {updatedQuantity}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"Error: Not enough quantity available for Medic {medicId}");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Medic {medicId} not found in the database.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SellMedic: {ex.Message}");
                return false;
            }
        }

        // Thêm các phương thức khác nếu cần
    }
}
