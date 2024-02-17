using QuanLyTiemThuoc.DAO;
using QuanLyTiemThuoc.DTO;

namespace QuanLyTiemThuoc.BUS
{
    public class UsersBUS
    {
        private readonly UsersDAO usersDAO;

        public UsersBUS()
        {
            this.usersDAO = new UsersDAO();
        }

        public List<UsersDTO> GetAllUsers()
        {
            return usersDAO.GetAllUsers();
        }
        public bool UpdateUserInfo(string username, UsersDTO updatedUser)
        {
            return usersDAO.UpdateUserInfo(username, updatedUser);
        }

        public List<UsersDTO> GetFilteredUsers(string role, string gender)
        {
            return usersDAO.GetFilteredUsers(role, gender);
        }
        public List<UsersDTO> SearchUsersByUsername(string username)
        {
            return usersDAO.SearchUsersByUsername(username);
        }

        public bool AuthenticateUser(string username, string password)
        {
            return usersDAO.CheckUserExistence(username, password);
        }

        public UsersDTO GetUserInfoByUsername(string username)
        {
            return usersDAO.GetUserInfoByUsername(username);
        }

        public string GetUserRoleByUsername(string username)
        {
            return usersDAO.GetUserRoleByUsername(username);
        }

        public int CountAdmin()
        {
            return usersDAO.CountAdmin();
        }

        public int CountUsers()
        {
            return usersDAO.CountUsers();
        }

        public bool InsertUser(UsersDTO newUser)
        {
            return usersDAO.InsertUser(newUser);
        }

        public bool IsUsernameExists(string username)
        {
            return usersDAO.IsUsernameExists(username);
        }

        public bool DeleteUserByUsername(string username)
        {
            return usersDAO.DeleteUserByUsername(username);
        }
        

    }
}
