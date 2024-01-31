using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Role]")] //Colocar o nome da tabela sempre entre colchetes para evitar palavras reservadas
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}