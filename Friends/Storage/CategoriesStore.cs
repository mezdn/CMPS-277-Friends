using Friends.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
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
            var ret = new List<Category>();

            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT name, areaOfExpertiseName FROM category";

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var category = new Category
                    {
                        Name = reader.GetFieldValue<string>(0),
                        AreaOfExpertiseName = reader.GetFieldValue<string>(1)
                    };
                    ret.Add(category);
                }
            }
            return ret;
        }

        public async Task<Category> GetCategory(string name)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT name, areaOfExpertiseName FROM category WHERE name = @name";
            cmd.Parameters.AddWithValue("@name", name);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var category = new Category
                    {
                        Name = reader.GetFieldValue<string>(0),
                        AreaOfExpertiseName = reader.GetFieldValue<string>(1)
                    };
                    return category;
                }
            }
            return null;
        }

        public async Task CreateCategory(Category category)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO Category(name, areaOfExpertiseName) VALUES (@name, @areaOfExpertiseName);";
            cmd.Parameters.AddWithValue("@name", category.Name);
            cmd.Parameters.AddWithValue("@areaOfExpertiseName", category.AreaOfExpertiseName);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
