using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.Models
{
    internal class Ingredient
    {
        private Guid id;
        private string name;
        private string unit;
        private decimal unitPrice;
        private int expirySpan;

        // Constructor to create an Ingredient object with specified values
        public Ingredient(Guid id, string name, string unit, decimal unitPrice, int expirySpan)
        {
            this.id = id;
            this.name = name;
            this.unit = unit;
            this.unitPrice = unitPrice;
            this.expirySpan = expirySpan;
        }

        // Constructor to create an Ingredient object from a SqlDataReader
        public Ingredient(SqlDataReader reader)
        {
            id = Guid.Parse(reader["ID"].ToString());
            name = reader["Name"].ToString() ?? string.Empty;
            unit = reader["Unit"].ToString() ?? string.Empty;
            unitPrice = Convert.ToDecimal(reader["UnitPrice"]);
            expirySpan = Convert.ToInt32(reader["ExpirySpan"]);
        }

        public Guid Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Unit
        {
            get => unit;
            set => unit = value;
        }

        public decimal UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }

        public int ExpirySpan
        {
            get => expirySpan;
            set => expirySpan = value;
        }
    }
}
