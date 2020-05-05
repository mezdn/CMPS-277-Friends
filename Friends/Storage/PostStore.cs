using Friends.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friends.Storage
{
    public class PostStore
    {
        private MySqlDatabase MySqlDatabase { get; set; }

        public PostStore(MySqlDatabase mySqlDatabase)
        {
            MySqlDatabase = mySqlDatabase;
        }

        public async Task<List<Post>> GetPosts(string username)
        {
            return null;
        }

        public async Task<Post> GetPost(int id)
        {
            return null;
        }

        public async Task<Post> GetPostVerify(int id, string username)
        {
            return null;
        }

        public async Task CreatePost(Post post)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO post(id, username, content, groupId, timeOfCreation) VALUES (@id, @username, @content, @groupId, @timeOfCreation);";
            cmd.Parameters.AddWithValue("@id", post.ID);
            cmd.Parameters.AddWithValue("@username", post.PersonUsername);
            cmd.Parameters.AddWithValue("@content", post.Content);
            cmd.Parameters.AddWithValue("@groupId", post.GroupID);
            cmd.Parameters.AddWithValue("@timeOfCreation", post.TimeOfCreation);

            await cmd.ExecuteNonQueryAsync();
        }

        //Update only after verifying username
        public async Task UpdatePost(Post post, string username)
        {

        }

        public async Task DeletePost(int id)
        {

        }

        public async Task LikePost(int id, string username)
        {

        }

        public async Task UnlikePost(int id, string username)
        {

        }
    }
}
