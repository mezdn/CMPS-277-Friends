using Friends.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Storage
{
    public class CategoriesStore
    {
        private MySqlDatabase MySqlDatabase { get; set; }

        public CategoriesStore(MySqlDatabase mySqlDatabase)
        {
            MySqlDatabase = mySqlDatabase;
        }

        public async Task<List<Category>> GetCategories()
        {
            return null;
        }

        public async Task<Category> GetCategory(int id)
        {
            return null;
        }

        public async Task CreateCategory(Category category)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO Cateogry(id, name, areaOfExpertiseName) VALUES (@id, @name, @areaOfExpertiseName);";
            cmd.Parameters.AddWithValue("@id", category.ID);
            cmd.Parameters.AddWithValue("@name", category.Name);
            cmd.Parameters.AddWithValue("@areaOfExpertiseName", category.AreaOfExpertiseName);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
