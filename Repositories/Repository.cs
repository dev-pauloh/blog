using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class //Deixa explícito que o T só pode ser uma classe
    {
        private readonly SqlConnection _connection; //somente para leitura

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<T> Get()
        => _connection.GetAll<T>(); // Busca todos os registros de uma tabela como um SELECT *

        public T Get(int Id)
           => _connection.Get<T>(Id);

        public void Create(T model)
            => _connection.Insert<T>(model);

        public void Update(T model)
                => _connection.Update<T>(model);

        public void Delete(T model)
                => _connection.Delete<T>(model);

        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }
    }
}