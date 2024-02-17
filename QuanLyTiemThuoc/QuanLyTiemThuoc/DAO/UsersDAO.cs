using QuanLyTiemThuoc.DTO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyTiemThuoc.DAO
{
    public class UsersDAO
    {
        private SqlDataAccessHelper dataAccessHelper;

        public UsersDAO()
        {
            this.dataAccessHelper = new SqlDataAccessHelper();
        }

        public List<UsersDTO> GetAllUsers()
        {
            string query = "SELECT Id, UserRole, Name, Dob, Address, Degree, PersonalID, Mobile, Email, Username, Gender FROM Users";
            DataTable dataTable = dataAccessHelper.ExecuteSelectAllQuery(query);

            List<UsersDTO> users = new List<UsersDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                UsersDTO user = new UsersDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserRole = row["UserRole"].ToString(),
                    Name = row["Name"].ToString(),
                    Dob = row["Dob"].ToString(),
                    Address = row["Address"].ToString(),
                    Degree = row["Degree"].ToString(),
                    PersonalID = row["PersonalID"].ToString(),
                    Mobile = row["Mobile"].ToString(),
                    Email = row["Email"].ToString(),
                    Username = row["Username"].ToString(),
                    Gender = row["Gender"].ToString(),
                };

                users.Add(user);
            }

            return users;
        }

        public List<UsersDTO> GetFilteredUsers(string role, string gender)
        {
            string query = "SELECT Id, UserRole, Name, Dob, Address, Degree, PersonalID, Mobile, Email, Username, Gender " +
                           "FROM Users WHERE (@Role = 'Select All' OR UserRole = @Role) AND (@Gender = 'Select All' OR Gender = @Gender)";

            SqlParameter[] parameters =
            {
        new SqlParameter("@Role", role),
        new SqlParameter("@Gender", gender)
    };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

            List<UsersDTO> filteredUsers = new List<UsersDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                UsersDTO user = new UsersDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserRole = row["UserRole"].ToString(),
                    Name = row["Name"].ToString(),
                    Dob = row["Dob"].ToString(),
                    Address = row["Address"].ToString(),
                    Degree = row["Degree"].ToString(),
                    PersonalID = row["PersonalID"].ToString(),
                    Mobile = row["Mobile"].ToString(),
                    Email = row["Email"].ToString(),
                    Username = row["Username"].ToString(),
                    Gender = row["Gender"].ToString(),
                };

                filteredUsers.Add(user);
            }

            return filteredUsers;
        }

        public List<UsersDTO> SearchUsersByUsername(string username)
        {
            string query = "SELECT Id, UserRole, Name, Dob, Address, Degree, PersonalID, Mobile, Email, Username, Gender " +
                           "FROM Users WHERE Username LIKE @Username";

            SqlParameter[] parameters =
            {
        new SqlParameter("@Username", SqlDbType.VarChar) { Value = $"%{username}%" }
    };

            return MapUserDTOs(dataAccessHelper.ExecuteSelectQuery(query, parameters));
        }

        private List<UsersDTO> MapUserDTOs(DataTable dataTable)
        {
            List<UsersDTO> users = new List<UsersDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                UsersDTO user = new UsersDTO
                {
                    Id = Convert.ToInt32(row["Id"]),
                    UserRole = row["UserRole"].ToString(),
                    Name = row["Name"].ToString(),
                    Dob = row["Dob"].ToString(),
                    Address = row["Address"].ToString(),
                    Degree = row["Degree"].ToString(),
                    PersonalID = row["PersonalID"].ToString(),
                    Mobile = row["Mobile"].ToString(),
                    Email = row["Email"].ToString(),
                    Username = row["Username"].ToString(),
                    Gender = row["Gender"].ToString(),
                };

                users.Add(user);
            }

            return users;
        }

        public UsersDTO GetUserInfoByUsername(string username)
        {
            string query = "SELECT Id, UserRole, Name, Dob, Address, Degree, PersonalID, Mobile, Email, Username, Password, Gender FROM Users WHERE Username = @Username";
            SqlParameter[] parameters = { new SqlParameter("@Username", SqlDbType.VarChar) { Value = username } };

            DataTable dataTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                UsersDTO user = new UsersDTO
                {
                    Id = Convert.ToInt32(dataTable.Rows[0]["Id"]),
                    UserRole = dataTable.Rows[0]["UserRole"].ToString(),
                    Name = dataTable.Rows[0]["Name"].ToString(),
                    Dob = dataTable.Rows[0]["Dob"].ToString(),
                    Address = dataTable.Rows[0]["Address"].ToString(),
                    Degree = dataTable.Rows[0]["Degree"].ToString(),
                    PersonalID = dataTable.Rows[0]["PersonalID"].ToString(),
                    Mobile = dataTable.Rows[0]["Mobile"].ToString(),
                    Email = dataTable.Rows[0]["Email"].ToString(),
                    Username = dataTable.Rows[0]["Username"].ToString(),
                    Password = dataTable.Rows[0]["Password"].ToString(),
                    Gender = dataTable.Rows[0]["Gender"].ToString(),
                };

                return user;
            }

            return null;
        }

        public bool UpdateUserInfo(string username, UsersDTO updatedUser)
        {
            string query = "UPDATE Users " +
                           "SET UserRole = @UserRole, " +
                           "    Name = @Name, " +
                           "    Dob = @Dob, " +
                           "    Address = @Address, " +
                           "    Degree = @Degree, " +
                           "    PersonalID = @PersonalID, " +
                           "    Mobile = @Mobile, " +
                           "    Email = @Email, " +
                           "    Password = @Password, " +
                           "    Gender = @Gender " +
                           "WHERE Username = @Username";

            SqlParameter[] parameters =
            {
        new SqlParameter("@UserRole", updatedUser.UserRole),
        new SqlParameter("@Name", updatedUser.Name),
        new SqlParameter("@Dob", updatedUser.Dob),
        new SqlParameter("@Address", updatedUser.Address),
        new SqlParameter("@Degree", updatedUser.Degree),
        new SqlParameter("@PersonalID", updatedUser.PersonalID),
        new SqlParameter("@Mobile", updatedUser.Mobile),
        new SqlParameter("@Email", updatedUser.Email),
        new SqlParameter("@Password", updatedUser.Password),
        new SqlParameter("@Gender", updatedUser.Gender),
        new SqlParameter("@Username", username)
    };

            return dataAccessHelper.ExecuteUpdateQuery(query, parameters);
        }


        public bool CheckUserExistence(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", SqlDbType.VarChar) { Value = username },
                new SqlParameter("@Password", SqlDbType.VarChar) { Value = password }
    };

            int userCount = (int)dataAccessHelper.ExecuteSelectQuery(query, parameters).Rows[0][0];

            return userCount > 0;
        }

        public string GetUserRoleByUsername(string username)
        {
            try
            {
                string query = "SELECT UserRole FROM Users WHERE Username = @Username";
                SqlParameter[] parameters = { new SqlParameter("@Username", SqlDbType.VarChar) { Value = username } };

                DataTable resultTable = dataAccessHelper.ExecuteSelectQuery(query, parameters);

                if (resultTable.Rows.Count > 0)
                {
                    // Lấy giá trị userRole từ bảng kết quả
                    string userRole = resultTable.Rows[0]["UserRole"].ToString();
                    return userRole;
                }

                // Trường hợp không tìm thấy người dùng
                return "NotFound";
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ theo cách bạn muốn, ví dụ: log lỗi
                Console.WriteLine($"Error in GetUserRoleByUsername: {ex.Message}");
                return "Error";
            }
        }


        public int CountAdmin()
        {
            string query = "SELECT COUNT(*) FROM Users WHERE UserRole = 'Admin'";
            return (int)dataAccessHelper.ExecuteSelectAllQuery(query).Rows[0][0];
        }

        public int CountUsers()
        {
            string query = "SELECT COUNT(*) FROM Users WHERE UserRole = 'Pharmacist'";
            return (int)dataAccessHelper.ExecuteSelectAllQuery(query).Rows[0][0];
        }

        public bool InsertUser(UsersDTO newUser)
        {
            string query = "INSERT INTO Users (UserRole, Name, Dob, Address, Degree, PersonalID, Mobile, Email, Username, Password, Gender) " +
                           "VALUES (@UserRole, @Name, @Dob, @Address, @Degree, @PersonalID, @Mobile, @Email, @Username, @Password, @Gender)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@UserRole", newUser.UserRole),
                new SqlParameter("@Name", newUser.Name),
                new SqlParameter("@Dob", newUser.Dob),
                new SqlParameter("@Address", newUser.Address),
                new SqlParameter("@Degree", newUser.Degree),
                new SqlParameter("@PersonalID", newUser.PersonalID),
                new SqlParameter("@Mobile", newUser.Mobile),
                new SqlParameter("@Email", newUser.Email),
                new SqlParameter("@Username", newUser.Username),
                new SqlParameter("@Password", newUser.Password),
                new SqlParameter("@Gender", newUser.Gender)
            };

            return dataAccessHelper.ExecuteInsertQuery(query, parameters);
        }

        public bool IsUsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            SqlParameter[] parameters = { new SqlParameter("@Username", username) };

            int userCount = (int)dataAccessHelper.ExecuteSelectQuery(query, parameters).Rows[0][0];
            return userCount > 0;
        }

        public bool DeleteUserByUsername(string username)
        {
            string query = "DELETE FROM Users WHERE Username = @Username";
            SqlParameter[] parameters = { new SqlParameter("@Username", username) };

            return dataAccessHelper.ExecuteDeleteQuery(query, parameters);
        }

        private bool ComparePasswords(string storedPassword, string inputPassword)
        {
            return storedPassword.Equals(inputPassword);
        }

        public string GetUsernameById(int userId)
        {
            try
            {
                string query = "SELECT Username FROM Users WHERE Id = @Id";

                SqlParameter[] parameters =
                {
                new SqlParameter("@Id", SqlDbType.Int) { Value = userId }
            };

                object result = dataAccessHelper.ExecuteSelectQuery(query, parameters);

                if (result != null)
                {
                    return result.ToString();
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting username by ID: {ex.Message}");
                // Xử lý exception tại đây nếu cần
                return null;
            }
        }
    }
}
