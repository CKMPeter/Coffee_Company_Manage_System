using CoffeeCompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.DAOs
{
    internal class BatchDAO : BaseDAO
    {
        private readonly IngredientDAO ingredientDAO;

        public BatchDAO(IngredientDAO ingredientDAO)
        {
            this.ingredientDAO = ingredientDAO;
        }

        public List<Batch> GetAllBatches()
        {
            string query = "SELECT * FROM Batch";
            return ExecuteQuery(query, reader => new Batch(reader, ingredientDAO.GetIngredientById));
        }

        public List<Batch> GetBatchesByLocationID(Guid locationId)
        {
            string query = "SELECT * FROM Batch WHERE LocationID = @LocationID";
            var parameters = new Dictionary<string, object> { ["@LocationID"] = locationId };

            return ExecuteQuery(query, reader => new Batch(reader, ingredientDAO.GetIngredientById), parameters);
        }

        public Batch GetBatchById(Guid id)
        {
            string query = "SELECT * FROM Batch WHERE ID = @ID";
            var parameters = new Dictionary<string, object> { ["@ID"] = id };

            var result = ExecuteQuery(query, reader => new Batch(reader, ingredientDAO.GetIngredientById), parameters);
            return result.Count > 0 ? result[0] : null;
        }

        public bool InsertBatch(int quantity, DateTime receiptDate, DateTime expirationDate, Guid ingredientId, Guid locationId)
        {
            string query = @"
        INSERT INTO Batch (Quantity, ReceiptDate, ExpirationDate, IngredientID, LocationID)
        VALUES (@Quantity, @ReceiptDate, @ExpirationDate, @IngredientID, @LocationID)";

            var parameters = new Dictionary<string, object>
            {
                ["@Quantity"] = quantity,
                ["@ReceiptDate"] = receiptDate,
                ["@ExpirationDate"] = expirationDate,
                ["@IngredientID"] = ingredientId,
                ["@LocationID"] = locationId
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool UpdateBatch(Batch batch)
        {
            string query = @"
        UPDATE Batch
        SET Quantity = @Quantity,
            ReceiptDate = @ReceiptDate,
            ExpirationDate = @ExpirationDate
        WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = batch.Id,
                ["@Quantity"] = batch.Quantity,
                ["@ReceiptDate"] = batch.ReceiptDate,
                ["@ExpirationDate"] = batch.ExpirationDate
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteBatch(Guid id)
        {
            string query = "DELETE FROM Batch WHERE ID = @ID";
            var parameters = new Dictionary<string, object> { ["@ID"] = id };

            return ExecuteNonQuery(query, parameters);
        }
    }

}
