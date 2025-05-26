using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.DTOs
{
    internal class BatchDetailsDTO
    {
        public Guid BatchID { get; set; }
        public string IngredientName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }

        public BatchDetailsDTO(SqlDataReader reader)
        {
            BatchID = Guid.Parse(reader["BatchID"].ToString());
            IngredientName = reader["IngredientName"].ToString();
            Quantity = Convert.ToInt32(reader["Quantity"]);
            Unit = reader["Unit"].ToString();
            ReceiptDate = Convert.ToDateTime(reader["ReceiptDate"]);
            ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

            // Compute status in C#
            string status;
            int daysLeft = (ExpirationDate - DateTime.Today).Days;
            if (daysLeft >= 7)
                status = "Fresh";
            else if (daysLeft > 0)
                status = "Expiring Soon";
            else
                status = "Expired";
            Status = status;
        }
    }

}
