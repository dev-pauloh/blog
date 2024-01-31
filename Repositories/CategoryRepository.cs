using System.Collections;
using System.Runtime.CompilerServices;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection; //somente para leitura
        public CategoryRepository(SqlConnection connection)
        : base(connection)
        {
            _connection = connection;
        }

        public List<Category> GetWithPost()
        {
            var query = @"
                SELECT
                    [Category].*,
                    [Post].*
                FROM
                    [Category]
                    LEFT JOIN [Post] ON [Category].[Id] = [Post].[CategoryId]
                
                ";

            var categories = new List<Category>();
            var items = _connection.Query<Category, Post, Category>(
                query,
                (category, post) =>
                {
                    var ctg = categories.Where(x => x.Id == category.Id).FirstOrDefault();
                    if (ctg == null)
                    {
                        ctg = category;
                        if (post != null)
                            ctg.Posts.Add(post);

                        categories.Add(ctg);
                    }
                    else
                    {
                        ctg.Posts.Add(post);
                    }
                    return category;
                },
                splitOn: "Id"
                );

            return categories;
        }
    }
}