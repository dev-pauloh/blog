using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[PostTag]")] //Colocar o nome da tabela sempre entre colchetes para evitar palavras reservadas
    public class PostTag
    {
        public int Id { get; set; }
        public string PostId { get; set; }
        public string TagId { get; set; }
    }
}