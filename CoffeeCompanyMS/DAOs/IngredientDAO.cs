using CoffeeCompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.DAOs
{
    internal class IngredientDAO : BaseDAO
    {
        public List<Ingredient> GetAllIngredients()
        {
            string query = "SELECT * FROM Ingredient ORDER BY Name";
            return ExecuteQuery(query, reader => new Ingredient(reader));
        }

        public Ingredient GetIngredientById(Guid id)
        {
            string query = "SELECT * FROM Ingredient WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = id
            };

            var result = ExecuteQuery(query, reader => new Ingredient(reader), parameters);

            return result.Count > 0 ? result[0] : null;
        }

        public List<Ingredient> GetIngredientsBySupplierId(Guid supplierId)
        {
            string query = @"SELECT * FROM Ingredient 
                WHERE SupplierID = @SupplierID ORDER BY Name";

            var parameters = new Dictionary<string, object>
            {
                ["@SupplierID"] = supplierId
            };

            return ExecuteQuery(query, reader => new Ingredient(reader), parameters);
        }

        // Insert with SupplierID
        public bool InsertIngredient(Ingredient ingredient, Guid supplierId)
        {
            string query = @"
        INSERT INTO Ingredient (Name, Unit, UnitPrice, ExpirySpan, SupplierID)
        VALUES (@Name, @Unit, @UnitPrice, @ExpirySpan, @SupplierID)";

            var parameters = new Dictionary<string, object>
            {
                ["@Name"] = ingredient.Name,
                ["@Unit"] = ingredient.Unit,
                ["@UnitPrice"] = ingredient.UnitPrice,
                ["@ExpirySpan"] = ingredient.ExpirySpan,
                ["@SupplierID"] = supplierId
            };

            return ExecuteNonQuery(query, parameters);
        }

        // Insert base ingredient (only Name and Unit)
        public bool InsertIngredient(string name, string unit)
        {
            string query = @"INSERT INTO Ingredient (Name, Unit) VALUES (@Name, @Unit)";

            var parameters = new Dictionary<string, object>
            {
                ["@Name"] = name,
                ["@Unit"] = unit
            };

            return ExecuteNonQuery(query, parameters);
        }


        // Update ingredient ignoring SupplierID
        public bool UpdateIngredient(Ingredient ingredient)
        {
            string query = @"
        UPDATE Ingredient
        SET Name = @Name,
            Unit = @Unit,
            UnitPrice = @UnitPrice,
            ExpirySpan = @ExpirySpan
        WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = ingredient.Id,
                ["@Name"] = ingredient.Name,
                ["@Unit"] = ingredient.Unit,
                ["@UnitPrice"] = ingredient.UnitPrice,
                ["@ExpirySpan"] = ingredient.ExpirySpan
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteIngredient(Guid id)
        {
            string query = "DELETE FROM Ingredient WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = id
            };

            return ExecuteNonQuery(query, parameters);
        }
    }
}
