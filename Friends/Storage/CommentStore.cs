using Friends.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Storage
{
    public class CommentStore
    {
        private MySqlDatabase MySqlDatabase { get; set; }

        public CommentStore(MySqlDatabase mySqlDatabase)
        {
            MySqlDatabase = mySqlDatabase;
        }

        public async Task<List<Comment>> GetComments(int postId)
        {
            return null;
        }

        public async Task CreateComment(Comment comment)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO Commment(id, content, personUsername, postId, TimeOfSending) VALUES (@id, @content, @personUsername, @postId, @TimeOfSending);";
            cmd.Parameters.AddWithValue("@id", comment.ID);
            cmd.Parameters.AddWithValue("@content", comment.Content);
            cmd.Parameters.AddWithValue("@personUsername", comment.PersonUsername);
            cmd.Parameters.AddWithValue("@postId", comment.PostID);
            cmd.Parameters.AddWithValue("@TimeOfSending", comment.TimeOfCreation);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
