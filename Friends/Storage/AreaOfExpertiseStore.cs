using Friends.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Storage
{
    public class AreaOfExpertiseStore
    {
        private MySqlDatabase MySqlDatabase { get; set; }

        public AreaOfExpertiseStore(MySqlDatabase mySqlDatabase)
        {
            MySqlDatabase = mySqlDatabase;
        }

        public async Task<List<AreaOfExpertise>> GetAreas()
        {
            var ret = new List<AreaOfExpertise>();

            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT Name, yearEmerged FROM AreaOfExpertise";

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var area = new AreaOfExpertise
                    {
                        Name = reader.GetFieldValue<string>(0),
                        YearEmerged = reader.GetFieldValue<int>(1)
                    };
                    //if (!reader.IsDBNull(2))
                    //    t.Completed = reader.GetFieldValue<DateTime>(2);

                    ret.Add(area);
                }
            }
            return ret;
        }

        public async Task<AreaOfExpertise> GetArea(string name)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT yearEmerged FROM AreaOfExpertise WHERE name = @name";
            cmd.Parameters.AddWithValue("@name", name);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var area = new AreaOfExpertise
                    {
                        Name = name,
                        YearEmerged = reader.GetFieldValue<int>(0)
                    };
                    return area;
                }
            }
            return null;
        }

        public async Task CreateArea(AreaOfExpertise areaOfExpertise)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO AreaOfExpertise(name, yearEmerged) VALUES (@name, @yearEmerged);";
            cmd.Parameters.AddWithValue("@name", areaOfExpertise.Name);
            cmd.Parameters.AddWithValue("@yearEmerged", areaOfExpertise.YearEmerged);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
