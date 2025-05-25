using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.Models
{
    internal class Supplier
    {
        private Guid id;
        private DateTime contractStartDate;
        private string name;
        private string phoneNum;
        private string ownerName;
        private string email;
        private string address;
        private List<Ingredient> ingredients;

        // Constructor to create a Supplier object with specified values
        public Supplier(Guid id, DateTime contractStartDate, string name, string phoneNum, string ownerName, string email, string address, List<Ingredient> ingredients)
        {
            this.id = id;
            this.contractStartDate = contractStartDate;
            this.name = name;
            this.phoneNum = phoneNum;
            this.ownerName = ownerName;
            this.email = email;
            this.address = address;
            this.ingredients = ingredients ?? new List<Ingredient>();
        }

        // Constructor to create a Supplier object from a SqlDataReader
        public Supplier(SqlDataReader reader, Func<Guid, List<Ingredient>> loadIngredients)
        {
            id = Guid.Parse(reader["ID"].ToString());
            contractStartDate = DateTime.Parse(reader["ContractStartDate"].ToString());
            name = reader["Name"].ToString() ?? string.Empty;
            phoneNum = reader["PhoneNum"].ToString() ?? string.Empty;
            ownerName = reader["OwnerName"].ToString() ?? string.Empty;
            email = reader["Email"].ToString() ?? string.Empty;
            address = reader["Address"].ToString() ?? string.Empty;
            ingredients = loadIngredients(id) ?? new List<Ingredient>();
        }

        public Guid Id { get => id; set => id = value; }
        public DateTime ContractStartDate { get => contractStartDate; set => contractStartDate = value; }
        public string Name { get => name; set => name = value; }
        public string PhoneNum { get => phoneNum; set => phoneNum = value; }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public List<Ingredient> Ingredients { get => ingredients; private set => ingredients = value; }

        // Method to add an ingredient to the supplier
        public void AddIngredient(Ingredient ingredient)
        {
            if (ingredient != null && !ingredients.Any(i => i.Id == ingredient.Id))
            {
                ingredients.Add(ingredient);
            }
        }

        // Method to remove an ingredient from the supplier
        public void RemoveIngredient(Guid ingredientId)
        {
            var ingredient = ingredients.FirstOrDefault(i => i.Id == ingredientId);
            if (ingredient != null)
            {
                ingredients.Remove(ingredient);
            }
        }
    }
}
