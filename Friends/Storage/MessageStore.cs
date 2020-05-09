using Friends.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Storage
{
    public class MessageStore
    {
        private MySqlDatabase MySqlDatabase { get; set; }

        public MessageStore(MySqlDatabase mySqlDatabase)
        {
            MySqlDatabase = mySqlDatabase;
        }

        public async Task<List<Message>> GetMessages(string user1, string user2)
        {
            var ret = new List<Message>();

            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, content, recieverUsername, senderUsername, timeOfSending FROM message
                                WHERE (senderUsername = @user1 AND recieverUsername = @user2) OR (senderUsername = @user2 AND recieverUsername = @user1)";

            cmd.Parameters.AddWithValue("@user1", user1);
            cmd.Parameters.AddWithValue("@user2", user2);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var message = new Message
                    {
                        ID = reader.GetFieldValue<int>(0),
                        Content = reader.GetFieldValue<string>(1),
                        RecieverUsername = reader.GetFieldValue<string>(2),
                        SenderUsername = reader.GetFieldValue<string>(3),
                        TimeOfSending = reader.GetFieldValue<long>(4)
                    };
                    ret.Add(message);
                }
            }
            return ret;
        }

        public async Task CreateMessage(Message message)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO message(id, content, senderUsername, recieverUsername, timeOfSending) VALUES (@id, @content, @senderUsername, @recieverUsername, @timeOfSending);";
            cmd.Parameters.AddWithValue("@id", message.ID);
            cmd.Parameters.AddWithValue("@content", message.Content);
            cmd.Parameters.AddWithValue("@senderUsername", message.SenderUsername);
            cmd.Parameters.AddWithValue("@recieverUsername", message.RecieverUsername);
            cmd.Parameters.AddWithValue("@timeOfSending", message.TimeOfSending);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
