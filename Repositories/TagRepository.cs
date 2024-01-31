using System.Collections;
using System.Runtime.CompilerServices;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection; //somente para leitura
        public TagRepository(SqlConnection connection)
        : base(connection)
        {
            _connection = connection;
        }

        public List<Tag> GetWithPost()
        {
            var query = @"
                SELECT
                    [Tag].*,
                    [Post].*
                FROM
                    [Tag]
                    LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                    LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]
                ";

            var tags = new List<Tag>();
            var items = _connection.Query<Tag, Post, Tag>(
                query,
                (tag, post) =>
                {
                    var tg = tags.Where(x => x.Id == tag.Id).FirstOrDefault();
                    if (tg == null)
                    {
                        tg = tag;
                        if (post != null)
                            tg.Posts.Add(post);

                        tags.Add(tg);
                    }
                    else
                    {
                        tg.Posts.Add(post);
                    }
                    return tag;
                },
                splitOn: "Id"
                );

            return tags;
        }
    }
}