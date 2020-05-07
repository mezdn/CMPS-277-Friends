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
            var ret = new List<Person>();

            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT username, displayName, country, dateOfBirth, areaOfExpertiseName FROM person";

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var person = new Person
                    {
                        Username = reader.GetFieldValue<string>(0),
                        DisplayName = reader.GetFieldValue<string>(1),
                        Country = reader.GetFieldValue<string>(2),
                        DateOfBirth = reader.GetFieldValue<long>(3),
                        AreaOfExpertiseName = reader.GetFieldValue<string>(4)
                    };
                    ret.Add(person);
                }
            }
            return ret;
        }

        public async Task<IsFriendObject> GetPerson(string usernameA, string usernameB)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT p.username, p.displayName, p.country, p.dateOfBirth, p.areaOfExpertiseName, f.user2 
                                FROM person as p LEFT OUTER JOIN friends as f ON p.username = f.user1 
                                WHERE p.username = @usernameA AND f.user2 = @usernameB";
            cmd.Parameters.AddWithValue("@usernameA", usernameA);
            cmd.Parameters.AddWithValue("@usernameB", usernameB);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var person = new Person
                    {
                        Username = reader.GetFieldValue<string>(0),
                        DisplayName = reader.GetFieldValue<string>(1),
                        Country = reader.GetFieldValue<string>(2),
                        DateOfBirth = reader.GetFieldValue<long>(3),
                        AreaOfExpertiseName = reader.GetFieldValue<string>(4)
                    };
                    var isFriendObject = new IsFriendObject
                    {
                        Person = person,
                        Username2 = null
                    };
                    if (!reader.IsDBNull(5))
                    {
                        isFriendObject.Username2 = reader.GetFieldValue<string>(5);
                    }
                    return isFriendObject;
                }
            }
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
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO friends(user1, user2) VALUES (@usernameA, @username2);";
            cmd.Parameters.AddWithValue("@usernameA", usernameA);
            cmd.Parameters.AddWithValue("@usernameB", usernameB);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task RemoveFriendship(string usernameA, string usernameB)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"DELETE FROM friends WHERE user1 = @usernameA AND user2 = @usernameB;";
            cmd.Parameters.AddWithValue("@usernameA", usernameA);
            cmd.Parameters.AddWithValue("@usernameB", usernameB);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<int> Authenticate(string username, string password)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT count(*) FROM person WHERE username = @username AND pass = @pass";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pass", password);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    return reader.GetFieldValue<int>(0);
                }
            }
            return 0;
        }
    }
}
