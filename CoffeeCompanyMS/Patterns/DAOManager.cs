using CoffeeCompanyMS.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.Patterns
{
    // DAOManager is a singleton class
    // that manages the Data Access Objects (DAOs) in the application.
    internal class DAOManager
    {
        public static DAOManager Instance { get; private set; }

        public LocationDAO LocationDAO { get; private set; }
        public SupplierDAO SupplierDAO { get; private set; }
        public IngredientDAO IngredientDAO { get; private set; }
        public TransferOrderDAO TransferOrderDAO { get; private set; }
        public TransferOrderItemDAO TransferOrderItemDAO { get; private set; }
        public BatchDAO BatchDAO { get; private set; }
        public UserDAO UserDAO { get; private set; }

        private DAOManager() { }

        public static void Initialize()
        {
            // Create DAOs without dependencies first
            var ingredientDAO = new IngredientDAO();

            // DAOs that depend on others
            var supplierDAO = new SupplierDAO(ingredientDAO);
            var transferOrderItemDAO = new TransferOrderItemDAO(ingredientDAO);
            var transferOrderDAO = new TransferOrderDAO(transferOrderItemDAO);
            var batchDAO = new BatchDAO(ingredientDAO);
            var locationDAO = new LocationDAO(batchDAO);
            var userDAO = new UserDAO(locationDAO);

            // Assign all to instance
            Instance = new DAOManager
            {
                IngredientDAO = ingredientDAO,
                SupplierDAO = supplierDAO,
                TransferOrderItemDAO = transferOrderItemDAO,
                TransferOrderDAO = transferOrderDAO,
                BatchDAO = batchDAO,
                LocationDAO = locationDAO,
                UserDAO = userDAO,
            };
        }
    }

}
