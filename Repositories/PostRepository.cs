using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection; //somente para leitura

        public PostRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<Post> GetWithTags()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Tag].*
                FROM
                    [Post]
                    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]
                ";

            var posts = new List<Post>();
            var items = _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) => //função para relacionar os resultados no split
                {
                    var pst = posts.Where(x => x.Id == post.Id).FirstOrDefault();// Verifica se o item já existe na lista posts
                    if (pst == null)
                    {
                        pst = post;
                        if (tag != null)
                            pst.Tags.Add(tag); // se não existe adiciona na lista Tags do objeto

                        posts.Add(pst); // se não existe adiciona na lista posts
                    }
                    else
                    {
                        pst.Tags.Add(tag); //se já existe adiciona somente na lista Tags do objeto
                    }
                    return post;
                },
                splitOn: "Id" //Split das colunas das duas tabelas o que estiver antes de Id será post e o que estiver depois será tag
                );

            return posts; //retorna a  lista posts
        }

        public IEnumerable<Post> GetWithCategory()
        {
            var query = @"
                SELECT
                    *
                FROM
                    [Post]
                INNER JOIN
                    [Category] ON [Post].[CategoryId] = [Category].[Id]
                ";

            var items = _connection.Query<Post, Category, Post>(
                query,
                (post, category) => //função para relacionar os resultados
                {
                    post.Category = category;
                    return post;
                },
                splitOn: "Id" //Split das colunas das duas tabelas na coluna Id
                );

            return items; //retorna a  lista posts
        }
    }
}