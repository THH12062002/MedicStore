using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.DAO
{
    public class BatchDAO
    {
        private readonly SqlDataAccessHelper dataAccessHelper;

        public BatchDAO()
        {
            this.dataAccessHelper = new SqlDataAccessHelper();
        }

        public List<BatchDTO> GetAllBatches()
        {
            List<BatchDTO> batches = new List<BatchDTO>();

            string query = "SELECT * FROM Batch";
            var dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (System.Data.DataRow row in dataTable.Rows)
                {
                    BatchDTO batch = new BatchDTO
                    {
                        BatchID = Convert.ToInt32(row["BatchID"]),
                        InputDate = Convert.ToDateTime(row["InputDate"]),
                        BatchNumber = Convert.ToInt32(row["BatchNumber"]),
                        BatchCode = row["BatchCode"].ToString()
                    };

                    batches.Add(batch);
                }
            }

            return batches;
        }

        public int CountBatch(int batchNumber)
        {
            DateTime inputDate = DateTime.Now.Date;
            string query = "SELECT COUNT(*) FROM Batch WHERE [InputDate] = @InputDate AND [BatchNumber] = @BatchNumber";

            // Assuming that dataAccessHelper is an instance of a class that contains ExecuteSelectQuery method
            SqlParameter[] parameters = {
        new SqlParameter("@InputDate", inputDate),
        new SqlParameter("@BatchNumber", batchNumber)
    };

            DataTable result = dataAccessHelper.ExecuteSelectQuery(query, parameters);

            // Check if the result is not null and contains at least one row
            if (result != null && result.Rows.Count > 0)
            {
                // Access the count value in the first row and column
                return Convert.ToInt32(result.Rows[0][0]);
            }

            // Return 0 if there is no result or an error occurred
            return 0;
        }

        public bool InsertBatch( int batchNumber)
        {
            DateTime inputDate = DateTime.Now.Date;

            string query = "INSERT INTO Batch (InputDate, BatchNumber) VALUES (@InputDate, @BatchNumber)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@InputDate", System.Data.SqlDbType.Date) { Value = inputDate },
                new SqlParameter("@BatchNumber", System.Data.SqlDbType.Int) { Value = batchNumber }
            };
            return dataAccessHelper.ExecuteInsertQuery(query, parameters);
        }
        public bool InsertBatchByBatch(int batchNumber, DateTime inputDate)
        {
            string query = "INSERT INTO Batch (InputDate, BatchNumber) VALUES (@InputDate, @BatchNumber)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@InputDate", System.Data.SqlDbType.Date) { Value = inputDate },
                new SqlParameter("@BatchNumber", System.Data.SqlDbType.Int) { Value = batchNumber }
            };
            return dataAccessHelper.ExecuteInsertQuery(query, parameters);
        }
        public string GetBatchCode( int batchNumber)
        {
            DateTime inputDate = DateTime.Now.Date;
            string batchCode = string.Empty;

            try
            {
                string getBatchCodeQuery = "SELECT BatchCode FROM Batch WHERE InputDate = @InputDate AND BatchNumber = @BatchNumber";

                SqlParameter[] parameters = {
                    new SqlParameter("@InputDate", inputDate),
                    new SqlParameter("@BatchNumber", batchNumber)
                };

                var dataTable = dataAccessHelper.ExecuteSelectQuery(getBatchCodeQuery, parameters);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    batchCode = dataTable.Rows[0]["BatchCode"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBatchCode: {ex.Message}");
            }

            return batchCode;
        }
        public List<BatchDTO> GetBatchByBatchID(int batchID)
        {
            
                string getBatchCodeQuery = "SELECT BatchCode, BatchNumber FROM Batch WHERE BatchID = @BatchID";

                SqlParameter[] parameters = {
                    new SqlParameter("@BatchID", batchID)

                };

                var dataTable = dataAccessHelper.ExecuteSelectQuery(getBatchCodeQuery, parameters);
                List<BatchDTO> batchs = new List<BatchDTO>();
                foreach (DataRow row in dataTable.Rows)
                {
                    BatchDTO batch = new BatchDTO
                    {
                        BatchCode = dataTable.Rows[0]["BatchCode"].ToString(),
                        BatchNumber = Convert.ToInt32(dataTable.Rows[0]["BatchNumber"])
                    };
                    batchs.Add(batch);
                }

                return batchs;
        }

        public int GetBatchId(string batchCode)
        {
            int batchId = 0;
            string getBatchQuery = "SELECT BatchID FROM Batch WHERE BatchCode = @BatchCode";

            SqlParameter[] parameters = { new SqlParameter("@BatchCode", batchCode) };

            var dataTable = dataAccessHelper.ExecuteSelectQuery(getBatchQuery, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                batchId = Convert.ToInt32(dataTable.Rows[0]["BatchID"]);
            }

            return batchId;
        }
        public int GetBatchIdByBatch(int batchNumber, DateTime inputDate)
        {
            int batchId = 0;
            string getBatchQuery = "SELECT BatchID FROM Batch WHERE BatchNumber = @BatchNumber AND InputDate = @InputDate";

            SqlParameter[] parameters = { new SqlParameter("@BatchNumber", batchNumber),
                                            new SqlParameter("@InputDate", inputDate)};

            var dataTable = dataAccessHelper.ExecuteSelectQuery(getBatchQuery, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                batchId = Convert.ToInt32(dataTable.Rows[0]["BatchID"]);
            }

            return batchId;
        }
        public int GetBatchNumber(int batchID)
        {
            int batchNumber = 0;
            string getBatchQuery = "SELECT BatchNumber FROM Batch WHERE BatchID = @BatchID";

            SqlParameter[] parameters = { new SqlParameter("@BatchID", batchID) };

            var dataTable = dataAccessHelper.ExecuteSelectQuery(getBatchQuery, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                batchNumber = Convert.ToInt32(dataTable.Rows[0]["BatchNumber"]);
            }
            return batchNumber;
        }
        public DateTime GetInputDate(int batchID)
        {
            DateTime inputDate = DateTime.Now;
            string getBatchQuery = "SELECT InputDate FROM Batch WHERE BatchID = @BatchID";

            SqlParameter[] parameters = { new SqlParameter("@BatchID", batchID) };

            var dataTable = dataAccessHelper.ExecuteSelectQuery(getBatchQuery, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // Assuming 'InputDate' is a DateTime column in the DataTable
                object inputDateObject = dataTable.Rows[0]["InputDate"];

                if (inputDateObject != DBNull.Value)
                {
                    inputDate = (DateTime)inputDateObject;
                }
            }
            return inputDate;
        }
        public bool IsBatchExist(int batchNumber, DateTime inputDate)
        {
            string query = "SELECT COUNT(*) FROM Batch WHERE BatchNumber = @BatchNumber AND InputDate = @InputDate";
            SqlParameter[] parameters = { new SqlParameter("@BatchNumber", batchNumber),
                                            new SqlParameter("@InputDate", inputDate)};

            int batchCount = (int)dataAccessHelper.ExecuteSelectQuery(query, parameters).Rows[0][0];
            return batchCount > 0;
        }
    }
}