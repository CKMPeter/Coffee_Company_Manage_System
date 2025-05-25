using CoffeeCompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.DAOs
{
    internal class UserDAO : BaseDAO
    {
        private readonly LocationDAO locationDAO;

        public UserDAO(LocationDAO locationDAO)
        {
            this.locationDAO = locationDAO;
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT * FROM Users ORDER BY Name";
            return ExecuteQuery(query, 
                reader => new User(reader, locationDAO.GetLocationById));
        }

        public User GetUserById(Guid id)
        {
            string query = "SELECT * FROM Users WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = id
            };

            var result = ExecuteQuery(query, 
                reader => new User(reader, locationDAO.GetLocationById), 
                parameters);
            return result.Count > 0 ? result[0] : null;
        }

        public User GetUserByEmail(string email)
        {
            string query = "SELECT * FROM Users WHERE Email = @Email";

            var parameters = new Dictionary<string, object>
            {
                ["@Email"] = email
            };

            var result = ExecuteQuery(query, 
                reader => new User(reader, locationDAO.GetLocationById), 
                parameters);
            return result.Count > 0 ? result[0] : null;
        }

        public bool InsertUser(User user)
        {
            string query = @"
        INSERT INTO Users (Email, Name, InitialSalary, CurrentSalary, PhoneNumber, LocationID, UserRole)
        VALUES (@Email, @Name, @InitialSalary, @CurrentSalary, @PhoneNumber, @LocationID, @UserRole)";

            var parameters = new Dictionary<string, object>
            {
                ["@Email"] = user.Email,
                ["@Name"] = user.Name,
                ["@InitialSalary"] = user.InitialSalary,
                ["@CurrentSalary"] = user.CurrentSalary,
                ["@PhoneNumber"] = user.PhoneNumber,
                ["@LocationID"] = user.Location.Id,
                ["@UserRole"] = user.Role
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool UpdateUser(User user)
        {
            string query = @"
        UPDATE Users
        SET Email = @Email,
            Name = @Name,
            InitialSalary = @InitialSalary,
            CurrentSalary = @CurrentSalary,
            PhoneNumber = @PhoneNumber,
            LocationID = @LocationID,
            UserRole = @UserRole
        WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = user.Id,
                ["@Email"] = user.Email,
                ["@Name"] = user.Name,
                ["@InitialSalary"] = user.InitialSalary,
                ["@CurrentSalary"] = user.CurrentSalary,
                ["@PhoneNumber"] = user.PhoneNumber,
                ["@LocationID"] = user.Location.Id,
                ["@UserRole"] = user.Role
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteUser(Guid id)
        {
            string query = "DELETE FROM Users WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = id
            };

            return ExecuteNonQuery(query, parameters);
        }
    }
}
