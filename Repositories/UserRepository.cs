using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection; //somente para leitura

        public UserRepository(SqlConnection connection)
        : base(connection)
            => _connection = connection;

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
                ";

            var users = new List<User>();
            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) => //função para relacionar os resultados no split
                {
                    var usr = users.Where(x => x.Id == user.Id).FirstOrDefault();// Verifica se o item já existe na lista users
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role); // se não existe adiciona na lista Roles do objeto

                        users.Add(usr); // se não existe adiciona na lista users
                    }
                    else
                    {
                        usr.Roles.Add(role); //se já existe adiciona somente na lista Roles do objeto
                    }
                    return user;
                },
                splitOn: "Id" //Split das colunas das duas tabelas o que estiver antes de Id será user e o que estiver depois será role
                );

            return users; //retorna a  lista users
        }
    }
}