using Friends.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
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
            var ret = new List<Comment>();

            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, personUsername, content, TimeOfSending FROM commment WHERE postId = @postId";
            cmd.Parameters.AddWithValue("@postId", postId);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var comment = new Comment
                    {
                        ID = reader.GetFieldValue<int>(0),
                        PostID = postId,
                        PersonUsername = reader.GetFieldValue<string>(1),
                        Content = reader.GetFieldValue<string>(2),
                        TimeOfCreation = reader.GetFieldValue<long>(3)
                    };
                    ret.Add(comment);
                }
            }
            return ret;
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
