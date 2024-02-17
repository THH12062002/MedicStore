using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;
using System;
using System.Collections.Generic;

namespace QuanLyTiemThuoc.BUS
{
    public class CategoryBUS
    {
        private CategoryDAO categoryDAO;

        public CategoryBUS()
        {
            categoryDAO = new CategoryDAO();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            try
            {
                return categoryDAO.GetAllCategories();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllCategories: {ex.Message}");
                return new List<CategoryDTO>();
            }
        }

        public int GetCategoryId(string categoryName)
        {
            try
            {
                return categoryDAO.GetCategoryId(categoryName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCategoryId: {ex.Message}");
                return 0;
            }
        }

        public string GetCategoryToM(string categoryName)
        {
            try
            {
                return categoryDAO.GetCategoryToM(categoryName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCategoryToM: {ex.Message}");
                return string.Empty;
            }
        }
        public string GetCategoryName(int categoryID)
        {
            try
            {
                return categoryDAO.GetCategoryName(categoryID);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCategoryToM: {ex.Message}");
                return string.Empty;
            }
        }

        // Các phương thức khác nếu cần
    }
}
