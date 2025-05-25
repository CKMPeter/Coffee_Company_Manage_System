using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.Models
{
    internal class Batch
    {
        private Guid id;
        private int quantity;
        private DateTime receiptDate;
        private DateTime expirationDate;
        private Ingredient ingredient;

        // Constructor to initialize a Batch object with specified values
        public Batch(Guid id, int quantity, DateTime receiptDate, DateTime expirationDate, Ingredient ingredient)
        {
            this.id = id;
            this.quantity = quantity;
            this.receiptDate = receiptDate;
            this.expirationDate = expirationDate;
            this.ingredient = ingredient;
        }

        // Constructor to create a Batch object from a SqlDataReader
        public Batch(SqlDataReader reader, Func<Guid, Ingredient> getIngredientById)
        {
            id = Guid.Parse(reader["ID"].ToString());
            quantity = Convert.ToInt32(reader["Quantity"]);
            receiptDate = Convert.ToDateTime(reader["ReceiptDate"]);
            expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

            // Retrieve the IngredientID from the reader
            // and use the provided function to get the Ingredient object
            var ingredientId = Guid.Parse(reader["IngredientID"].ToString());
            ingredient = getIngredientById(ingredientId);
        }

        public Guid Id
        {
            get => id;
            set => id = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public DateTime ReceiptDate
        {
            get => receiptDate;
            set => receiptDate = value;
        }

        public DateTime ExpirationDate
        {
            get => expirationDate;
            set => expirationDate = value;
        }

        public Ingredient Ingredient
        {
            get => ingredient;
            set => ingredient = value;
        }
    }
}
