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
            return null;
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
