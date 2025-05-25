using CoffeeCompanyMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCompanyMS.DAOs
{
    internal class LocationDAO : BaseDAO
    {
        private readonly BatchDAO batchDAO;

        public LocationDAO(BatchDAO batchDAO)
        {
            this.batchDAO = batchDAO;
        }

        public List<Location> GetAllLocations()
        {
            string query = "SELECT * FROM Location ORDER BY LocationIndex";
            return ExecuteQuery(query, reader => new Location(reader, batchDAO.GetBatchesByLocationID));
        }

        public Location GetLocationById(Guid id)
        {
            string query = "SELECT * FROM Location WHERE ID = @ID";
            var parameters = new Dictionary<string, object> { ["@ID"] = id };

            var result = ExecuteQuery(query, reader => new Location(reader, batchDAO.GetBatchesByLocationID), parameters);
            return result.Count > 0 ? result[0] : null;
        }

        public bool InsertLocation(Location location)
        {
            string query = @"
            INSERT INTO Location (LocationIndex, Address, MaintenanceCost)
            VALUES (@LocationIndex, @Address, @MaintenanceCost)";

            var parameters = new Dictionary<string, object>
            {
                ["@LocationIndex"] = location.LocationIndex,
                ["@Address"] = location.Address,
                ["@MaintenanceCost"] = location.MaintenanceCost
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool UpdateLocation(Location location)
        {
            string query = @"
            UPDATE Location
            SET LocationIndex = @LocationIndex,
                Address = @Address,
                MaintenanceCost = @MaintenanceCost
            WHERE ID = @ID";

            var parameters = new Dictionary<string, object>
            {
                ["@ID"] = location.Id,
                ["@LocationIndex"] = location.LocationIndex,
                ["@Address"] = location.Address,
                ["@MaintenanceCost"] = location.MaintenanceCost
            };

            return ExecuteNonQuery(query, parameters);
        }

        public bool DeleteLocation(Guid id)
        {
            string query = "DELETE FROM Location WHERE ID = @ID";
            var parameters = new Dictionary<string, object> { ["@ID"] = id };

            return ExecuteNonQuery(query, parameters);
        }
    }
}
