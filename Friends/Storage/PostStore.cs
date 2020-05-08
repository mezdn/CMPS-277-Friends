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
            var ret = new List<Post>();

            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, username, content, timeOfCreation, groupId, categoryName FROM person";

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var post = new Post
                    {
                        ID = reader.GetFieldValue<int>(0),
                        PersonUsername = reader.GetFieldValue<string>(1),
                        Content = reader.GetFieldValue<string>(2),
                        TimeOfCreation = reader.GetFieldValue<long>(3),
                        GroupID = reader.GetFieldValue<int>(4),
                        CategoryName = reader.GetFieldValue<string>(5)
                    };
                    ret.Add(post);
                }
            }
            return ret;
        }

        public async Task<Post> GetPost(int id)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, username, content, timeOfCreation, groupId, categoryName FROM person WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var post = new Post
                    {
                        ID = reader.GetFieldValue<int>(0),
                        PersonUsername = reader.GetFieldValue<string>(1),
                        Content = reader.GetFieldValue<string>(2),
                        TimeOfCreation = reader.GetFieldValue<long>(3),
                        GroupID = reader.GetFieldValue<int>(4),
                        CategoryName = reader.GetFieldValue<string>(5)
                    };
                    return post;
                }
            }
            return null;
        }

        public async Task<Post> GetPostVerify(int id, string username)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT id, username, content, timeOfCreation, groupId, categoryName FROM person
                                   WHERE id = @id AND username = @username";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var post = new Post
                    {
                        ID = reader.GetFieldValue<int>(0),
                        PersonUsername = reader.GetFieldValue<string>(1),
                        Content = reader.GetFieldValue<string>(2),
                        TimeOfCreation = reader.GetFieldValue<long>(3),
                        GroupID = reader.GetFieldValue<int>(4),
                        CategoryName = reader.GetFieldValue<string>(5)
                    };
                    return post;
                }
            }
            return null;
        }

        public async Task CreatePost(Post post)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO post(id, username, content, groupId, timeOfCreation, categoryName) VALUES (@id, @username, @content, @groupId, @timeOfCreation, @categoryName);";
            cmd.Parameters.AddWithValue("@id", post.ID);
            cmd.Parameters.AddWithValue("@username", post.PersonUsername);
            cmd.Parameters.AddWithValue("@content", post.Content);
            cmd.Parameters.AddWithValue("@groupId", post.GroupID);
            cmd.Parameters.AddWithValue("@timeOfCreation", post.TimeOfCreation);
            cmd.Parameters.AddWithValue("@categoryName", post.CategoryName);

            await cmd.ExecuteNonQueryAsync();
        }

        //Update only after verifying username
        public async Task UpdatePost(Post post, string username)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"UPDATE post SET username = @username, content = @content, groupId = @groupId, 
                                timeOfCreation = @timeOfCreation, categoryName = @categoryName
                                WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", post.ID);
            cmd.Parameters.AddWithValue("@username", post.PersonUsername);
            cmd.Parameters.AddWithValue("@content", post.Content);
            cmd.Parameters.AddWithValue("@groupId", post.GroupID);
            cmd.Parameters.AddWithValue("@timeOfCreation", post.TimeOfCreation);
            cmd.Parameters.AddWithValue("@categoryName", post.CategoryName);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeletePost(int id)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"DELETE FROM post WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task LikePost(int id, string username)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO likes(postId, username) VALUES (@id, @username);";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@id", username);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task UnlikePost(int id, string username)
        {
            var cmd = MySqlDatabase.Connection.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"DELETE FROM likes WHERE postId = @id AND username = @username;";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
