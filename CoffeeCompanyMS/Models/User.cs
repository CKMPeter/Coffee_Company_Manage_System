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
        private string _email;
        private string _name;
        private string _locationID;
        private string _role;

        public User(string email, string name, string locationID, string role) {
            _email = email;
            _name = name;
            _locationID = locationID;
            _role = role;
        }

        public string LocationID { get { return _locationID; } }

        public string Role { get { return _role; } }
    }
}
