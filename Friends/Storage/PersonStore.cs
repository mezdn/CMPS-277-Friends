using Friends.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Storage
{
    public class PersonStore
    {
        private MySqlDatabase MySqlDatabase { get; set; }

        public PersonStore(MySqlDatabase mySqlDatabase)
        {
            MySqlDatabase = mySqlDatabase;
        }

        public async Task<List<Person>> GetPersons()
        {
            return null;
        }

        public async Task<IsFriendObject> GetPerson(string usernameA, string usernameB)
        {
            return null;
        }

        public async Task CreatePerson(Person person)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO person(username, pass, displayName, dateOfBirth, country, areaOfExpertiseName) VALUES (@username, @pass, @displayName, @dateOfBirth, @country, @areaOfExpertiseName);";
            cmd.Parameters.AddWithValue("@username", person.Username);
            cmd.Parameters.AddWithValue("@pass", person.Password);
            cmd.Parameters.AddWithValue("@displayName", person.DisplayName);
            cmd.Parameters.AddWithValue("@dateOfBirth", person.DateOfBirth);
            cmd.Parameters.AddWithValue("@country", person.Country);
            cmd.Parameters.AddWithValue("@areaOfExpertiseName", person.AreaOfExpertiseName);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task AddFriendship(string usernameA, string usernameB)
        {

        }

        public async Task RemoveFriendship(string usernameA, string usernameB)
        {

        }

        public async Task<int> Authenticate(string username, string password)
        {
            return 1;
        }
    }
}
