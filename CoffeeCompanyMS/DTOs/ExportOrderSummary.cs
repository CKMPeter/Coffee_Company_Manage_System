using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.DTOs
{
    internal class ExportOrderSummary
    {
        public Guid OrderID { get; set; }
        public string RecurrenceID { get; set; }
        public string DestinationName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public string ActualDeliveryDate { get; set; }
        public string Status { get; set; }

        public ExportOrderSummary(SqlDataReader reader)
        {
            OrderID = reader.GetGuid(reader.GetOrdinal("OrderID"));
            RecurrenceID = reader["RecurrenceID"].ToString();
            DestinationName = reader["DestinationName"].ToString();
            OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
            EstimatedDeliveryDate = reader.GetDateTime(reader.GetOrdinal("EstimatedDeliveryDate"));
            ActualDeliveryDate = reader["ActualDeliveryDate"].ToString();
            Status = reader["Status"].ToString();
        }
    }

}
