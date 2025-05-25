using CoffeeCompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.DAOs
{
    internal class TransferOrderDAO : BaseDAO
    {
        private readonly TransferOrderItemDAO transferOrderItemDAO;

        public TransferOrderDAO(TransferOrderItemDAO transferOrderItemDAO)
        {
            this.transferOrderItemDAO = transferOrderItemDAO;
        }

        public List<TransferOrder> GetAllTransferOrders()
        {
            string query = "SELECT * FROM TransferOrder ORDER BY OrderDate DESC";
            return ExecuteQuery(query, reader => new TransferOrder(reader, transferOrderItemDAO.GetItemsByTransferOrderId));
        }

        public TransferOrder GetTransferOrderById(Guid id)
        {
            string query = "SELECT * FROM TransferOrder WHERE ID = @ID";
            var parameters = new Dictionary<string, object> { ["@ID"] = id };

            var result = ExecuteQuery(query, reader => new TransferOrder(reader, transferOrderItemDAO.GetItemsByTransferOrderId), parameters);
            return result.Count > 0 ? result[0] : null;
        }

        public List<TransferOrder> GetImportOrders(Guid destinationId)
        {
            string query = @"
                SELECT * FROM TransferOrder 
                WHERE DestinationID = @DestinationID 
                ORDER BY OrderDate DESC";
            var parameters = new Dictionary<string, object>
            {
                ["@DestinationID"] = destinationId
            };

            return ExecuteQuery(query, reader => new TransferOrder(reader, transferOrderItemDAO.GetItemsByTransferOrderId), parameters);
        }

        public List<TransferOrder> GetExportOrders(Guid destinationId)
        {
            string query = @"
                SELECT * FROM TransferOrder 
                WHERE DestinationID != @DestinationID 
                ORDER BY OrderDate DESC";
            var parameters = new Dictionary<string, object>
            {
                ["@DestinationID"] = destinationId
            };

            return ExecuteQuery(query, reader => new TransferOrder(reader, transferOrderItemDAO.GetItemsByTransferOrderId), parameters);
        }

        // Insert with all fields including RecurrenceID
        // used for re-newing recurring orders
        public bool InsertTransferOrder(DateTime orderDate, DateTime estimatedDeliveryDate, DateTime? actualDeliveryDate, string status, Guid recurrenceId, int recurrencePeriod, Guid destinationId)
        {
            string query = @"
        INSERT INTO TransferOrder (OrderDate, EstimatedDeliveryDate, ActualDeliveryDate, Status, RecurrenceID, RecurrencePeriod, DestinationID)
        VALUES (@OrderDate, @EstimatedDeliveryDate, @ActualDeliveryDate, @Status, @RecurrenceID, @RecurrencePeriod, @DestinationID)";

            var parameters = new Dictionary<string, object>
            {
                ["@OrderDate"] = orderDate,
                ["@EstimatedDeliveryDate"] = estimatedDeliveryDate,
                ["@ActualDeliveryDate"] = actualDeliveryDate.HasValue ? (object)actualDeliveryDate.Value : DBNull.Value,
                ["@Status"] = status,
                ["@RecurrenceID"] = recurrenceId,
                ["@RecurrencePeriod"] = recurrencePeriod,
                ["@DestinationID"] = destinationId
            };

            return ExecuteNonQuery(query, parameters);
        }


        // Insert with only non-default fields (EstimatedDeliveryDate, RecurrencePeriod, DestinationID)
        public bool InsertTransferOrder(DateTime estimatedDeliveryDate, int recurrencePeriod, Guid destinationId)
        {
            string query = @"
                INSERT INTO TransferOrder (EstimatedDeliveryDate, RecurrencePeriod, DestinationID)
                VALUES (@EstimatedDeliveryDate, @RecurrencePeriod, @DestinationID)";

            var parameters = new Dictionary<string, object>
            {
                ["@EstimatedDeliveryDate"] = estimatedDeliveryDate,
                ["@RecurrencePeriod"] = recurrencePeriod,
                ["@DestinationID"] = destinationId
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Update excluding all GUIDs (ID, RecurrenceID, DestinationID)
        public bool UpdateTransferOrder(TransferOrder order)
        {
            string query = @"
                UPDATE TransferOrder
                SET OrderDate = @OrderDate,
                    EstimatedDeliveryDate = @EstimatedDeliveryDate,
                    ActualDeliveryDate = @ActualDeliveryDate,
                    Status = @Status,
                    RecurrencePeriod = @RecurrencePeriod
                WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = order.Id,
                ["@OrderDate"] = order.OrderDate,
                ["@EstimatedDeliveryDate"] = order.EstimatedDeliveryDate,
                ["@ActualDeliveryDate"] = order.ActualDeliveryDate.HasValue ? (object)order.ActualDeliveryDate.Value : DBNull.Value,
                ["@Status"] = order.Status,
                ["@RecurrencePeriod"] = order.RecurrencePeriod
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteTransferOrder(Guid id)
        {
            string query = "DELETE FROM TransferOrder WHERE ID = @ID";
            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = id
            };

            return ExecuteNonQuery(query, parameters);
        }
    }
}
