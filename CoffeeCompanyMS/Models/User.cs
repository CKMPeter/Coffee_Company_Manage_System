using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeCompanyMS.Forms.Authentication;
using CoffeeCompanyMS.UI;

namespace CoffeeCompanyMS.Models
{
    internal class User
    {
        private Guid id;
        private string email;
        private string name;
        private decimal initialSalary;
        private decimal currentSalary;
        private string phoneNumber;
        private string role;
        private Location location;

        // Constructor to initialize a User object with specified values
        public User(Guid id, string email, string name, decimal initialSalary, decimal currentSalary, string phoneNumber, string role, Location location)
        {
            this.id = id;
            this.email = email;
            this.name = name;
            this.initialSalary = initialSalary;
            this.currentSalary = currentSalary;
            this.phoneNumber = phoneNumber;
            this.role = role;
            this.location = location;
        }

        // Constructor to create a User object from a SqlDataReader
        public User(SqlDataReader reader, Func<Guid, Location> getLocationById)
        {
            id = Guid.Parse(reader["ID"].ToString());
            email = reader["Email"].ToString();
            name = reader["Name"].ToString();
            initialSalary = Convert.ToDecimal(reader["InitialSalary"]);
            currentSalary = Convert.ToDecimal(reader["CurrentSalary"]);
            phoneNumber = reader["PhoneNumber"].ToString();
            role = reader["UserRole"].ToString();

            // Retrieve the LocationID from the reader
            // and use the provided function to get the Location object
            if (!Guid.TryParse(reader["LocationID"].ToString(), out Guid locationId))
            {
                locationId = Guid.Empty; // Handle case where LocationID is not present or invalid
            }
            location = getLocationById(locationId);
        }

        public Guid Id
        {
            get => id;
            set => id = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public decimal InitialSalary
        {
            get => initialSalary;
            set => initialSalary = value;
        }

        public decimal CurrentSalary
        {
            get => currentSalary;
            set => currentSalary = value;
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set => phoneNumber = value;
        }

        public string Role
        {
            get => role;
            set => role = value;
        }

        public Location Location
        {
            get => location;
            set => location = value;
        }
    }
}
