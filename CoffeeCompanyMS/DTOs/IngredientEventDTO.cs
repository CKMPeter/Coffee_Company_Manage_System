using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.DTOs
{
    internal class IngredientEventDTO
    {
        public DateTime Date { get; set; }
        public string EventType { get; set; } // "Import", "Export", "Wastage"
        public string Ingredient { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public IngredientEventDTO(SqlDataReader reader, string eventType)
        {
            Date = Convert.ToDateTime(reader["ExpirationDate"]);
            EventType = eventType;
            Ingredient = reader["Name"].ToString();
            Quantity = Convert.ToInt32(reader["Quantity"]);
            Unit = reader["Unit"].ToString();
        }
    }
}
