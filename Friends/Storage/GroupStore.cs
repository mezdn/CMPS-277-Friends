using Friends.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Storage
{
    public class GroupStore
    {
        private MySqlDatabase MySqlDatabase { get; set; }

        public GroupStore(MySqlDatabase mySqlDatabase)
        {
            MySqlDatabase = mySqlDatabase;
        }

        public async Task<List<Group>> GetGroups()
        {
            return null;
        }

        public async Task<GroupMemberObject> GetGroupAndMember(int id, String username)
        {
            return null;
        }

        public async Task CreateGroup(Group group)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO Groups(id, name, adminUsername, dateOfCreation) VALUES (@id, @name, @adminUsername, @dateOfCreation);";
            cmd.Parameters.AddWithValue("@id", group.ID);
            cmd.Parameters.AddWithValue("@name", group.Name);
            cmd.Parameters.AddWithValue("@adminUsername", group.AdminUsername);
            cmd.Parameters.AddWithValue("@dateOfCreation", group.DateOfCreation);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task EnterGroup(int groupId, string username)
        {

        }

        public async Task ExitGroup(int groupId, string username)
        {

        }
    }
}
