using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[UserRole]")] //Colocar o nome da tabela sempre entre colchetes para evitar palavras reservadas
    public class UserRole
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}