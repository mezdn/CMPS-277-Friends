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
            var ret = new List<Group>();

            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, name, adminUsername, dateOfCreation FROM groups";

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var group = new Group
                    {
                        ID = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(0),
                        AdminUsername = reader.GetFieldValue<string>(0),
                        DateOfCreation = reader.GetFieldValue<long>(0)
                    };
                    ret.Add(group);
                }
            }
            return ret;
        }

        public async Task<GroupMemberObject> GetGroupAndMember(int id, String username)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT g.id, g.name, g.adminUsername, g.dateOfCreation, m.username FROM groups as g
                                LEFT OUTER JOIN groupmember as m ON g.id = m.groupId
                                WHERE g.id = @id AND m.username = @username";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var group = new Group
                    {
                        ID = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1),
                        AdminUsername = reader.GetFieldValue<string>(2),
                        DateOfCreation = reader.GetFieldValue<long>(3)
                    };
                    var groupMemberObject = new GroupMemberObject
                    {
                        Group = group,
                        Username = null
                    };
                    if (!reader.IsDBNull(4))
                    {
                        groupMemberObject.Username = reader.GetFieldValue<string>(4);
                    }
                    return groupMemberObject;
                }
            }
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
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO groupmember(groupId, username) VALUES (@groupId, @username);";
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.Parameters.AddWithValue("@username", username);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task ExitGroup(int groupId, string username)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"DELETE FROM groupmember WHERE groupId = @groupId AND username = @username;";
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.Parameters.AddWithValue("@username", username);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
