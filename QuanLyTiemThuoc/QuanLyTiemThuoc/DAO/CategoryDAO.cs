using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTiemThuoc.DAO
{
    public class CategoryDAO
    {
        private readonly SqlDataAccessHelper dataAccessHelper;

        public CategoryDAO()
        {
            this.dataAccessHelper = new SqlDataAccessHelper();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<CategoryDTO> categories = new List<CategoryDTO>();

            string query = "SELECT * FROM Category";
            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    CategoryDTO category = new CategoryDTO
                    {
                        CategoryID = Convert.ToInt32(row["CategoryID"]),
                        CategoryName = row["CategoryName"].ToString()
                    };

                    categories.Add(category);
                }
            }

            return categories;
        }

        public int GetCategoryId(string categoryName)
        {
            int categoryId = 0;
            string getCategoryQuery = "SELECT CategoryID FROM Category WHERE CategoryName = @CategoryName";

            SqlParameter[] parameters = { new SqlParameter("@CategoryName", categoryName) };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(getCategoryQuery, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                categoryId = Convert.ToInt32(dataTable.Rows[0]["CategoryID"]);
            }

            return categoryId;
        }

        public string GetCategoryToM(string categoryName)
        {
            string categoryToM = ""; // Sử dụng biến categoryToM để lưu giá trị

            string getCategoryQuery = "SELECT ToM FROM Category WHERE CategoryName = @CategoryName";

            SqlParameter[] parameters = { new SqlParameter("@CategoryName", categoryName) };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(getCategoryQuery, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                categoryToM = dataTable.Rows[0]["ToM"].ToString();
            }

            return categoryToM; // Trả về giá trị ToM
        }
        public string GetCategoryName(int categoryID)
        {
            string categoryName = "";
            // Sử dụng biến categoryToM để lưu giá trị

            string getCategoryQuery = "SELECT CategoryName FROM Category WHERE CategoryID = @CategoryID";

            SqlParameter[] parameters = { new SqlParameter("@CategoryID", categoryID) };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(getCategoryQuery, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                categoryName = dataTable.Rows[0]["CategoryName"].ToString();
            }

            return categoryName; // Trả về giá trị ToM
        }


    }
}
