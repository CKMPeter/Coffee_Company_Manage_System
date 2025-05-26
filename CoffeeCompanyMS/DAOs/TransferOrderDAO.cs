﻿using CoffeeCompanyMS.DTOs;
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

        public List<TransferOrder> GetTransferOrdersByDestinationId(Guid destinationId)
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

        /// <summary>
        /// Gets a list of import events for ingredients at a specific location
        /// with details like expiration date, name, quantity, and unit.
        /// </summary>
        public List<IngredientEventDTO> GetImportEventsByLocationId(Guid locationId)
        {
            string query = @"
                SELECT TOI.ExpirationDate, I.Name, TOI.Quantity, I.Unit
                    FROM TransferOrderItem TOI
                    JOIN TransferOrder TO_ ON TOI.TransferOrderID = TO_.ID
                    JOIN Ingredient I ON TOI.IngredientID = I.ID
                    WHERE TO_.DestinationID = @LocationID AND TO_.Status IN ('Confirmed', 'RecurringStopped')";

            var parameters = new Dictionary<string, object>
            {
                ["@LocationID"] = locationId
            };

            return ExecuteQuery(query, reader => new IngredientEventDTO(reader, "Import"), parameters);
        }

        /// <summary>
        /// Gets a list of export events for ingredients at a specific location
        /// with details like expiration date, name, quantity, and unit.
        /// </summary>
        public List<IngredientEventDTO> GetExportEventsByLocationId(Guid locationId)
        {
            string query = @"
                SELECT TOI.ExpirationDate, I.Name, TOI.Quantity, I.Unit
                    FROM TransferOrderItem TOI
                    JOIN TransferOrder TO_ ON TOI.TransferOrderID = TO_.ID
                    JOIN Ingredient I ON TOI.IngredientID = I.ID
                    WHERE TO_.DestinationID != @LocationID";

            var parameters = new Dictionary<string, object>
            {
                ["@LocationID"] = locationId
            };

            return ExecuteQuery(query, reader => new IngredientEventDTO(reader, "Export"), parameters);
        }

        public List<ImportOrderDTO> GetImportOrdersByLocation(Guid locationId)
        {
            string query = @"
                SELECT 
                    t.ID AS OrderID,
                    ISNULL(CAST(t.RecurrenceID AS VARCHAR(50)), 'No Recurrence') AS RecurrenceID,
                    s.Name AS SupplierName,
                    t.OrderDate,
                    t.EstimatedDeliveryDate,
                    ISNULL(CAST(t.ActualDeliveryDate AS VARCHAR(50)), 'NaN') AS ActualDeliveryDate,
                    t.Status
                FROM TransferOrder t
                JOIN TransferOrderItem toi ON t.ID = toi.TransferOrderID
                JOIN Ingredient i ON toi.IngredientID = i.ID
                JOIN Supplier s ON i.SupplierID = s.ID
                WHERE 
                    t.DestinationID = @LocationID
                    AND t.Status IN ('Pending', 'Delayed', 'Delivered')
                GROUP BY 
                    t.ID, t.RecurrenceID, s.Name, t.OrderDate, 
                    t.EstimatedDeliveryDate, t.ActualDeliveryDate, t.Status";

            var parameters = new Dictionary<string, object>
            {
                { "@LocationID", locationId }
            };

            return ExecuteQuery(query, reader => new ImportOrderDTO(reader), parameters);
        }

        public List<RecurringImportOrderDTO> GetActiveRecurringImportOrders(Guid locationId)
        {
            string query = @"
                WITH Latest AS (
                    SELECT 
                        RecurrenceID, 
                        MAX(OrderDate) AS LatestOrderDate
                    FROM TransferOrder
                    WHERE 
                        DestinationID = @LocationID
                        AND Status != 'RecurringStopped'
                        AND RecurrenceID IS NOT NULL
                    GROUP BY RecurrenceID
                )
                SELECT
                    lo.RecurrenceID,
                    (SELECT s.Name
                     FROM Supplier s
                     JOIN TransferOrder t2 ON s.ID = s.ID
                     WHERE t2.ID = t.ID) AS SupplierName,
                    t.RecurrencePeriod,
                    t.ID AS LatestOrderID,
                    lo.LatestOrderDate,
                    DATEADD(DAY, t.RecurrencePeriod, lo.LatestOrderDate) AS EstimatedNextOrderDate
                FROM Latest lo
                JOIN TransferOrder t
                  ON t.RecurrenceID = lo.RecurrenceID
                 AND t.OrderDate = lo.LatestOrderDate";

            var parameters = new Dictionary<string, object>
            {
                ["@LocationID"] = locationId
            };

            return ExecuteQuery(query, reader => new RecurringImportOrderDTO(reader), parameters);
        }

        public List<ExportOrderSummary> GetExportOrderSummariesByLocationId(Guid locationId)
        {
            string query = @"
                SELECT 
                    t.ID AS OrderID,
                    ISNULL(CAST(t.RecurrenceID AS VARCHAR(50)), 'No Recurrence') AS RecurrenceID,
                    'Store Branch ' + CAST(l.LocationIndex AS VARCHAR(10)) AS DestinationName,
                    t.OrderDate,
                    t.EstimatedDeliveryDate,
                    ISNULL(CAST(t.ActualDeliveryDate AS VARCHAR(50)), 'NaN') AS ActualDeliveryDate,
                    t.Status
                FROM TransferOrder t
                JOIN Location l ON t.DestinationID = l.ID
                WHERE t.DestinationID != @LocationID
                  AND t.Status IN ('Pending', 'Delayed', 'Delivered')";

            var parameters = new Dictionary<string, object>
            {
                ["@LocationID"] = locationId
            };

            return ExecuteQuery(query, reader => new ExportOrderSummary(reader), parameters);
        }

    }
}
