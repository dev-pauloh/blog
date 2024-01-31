using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportScreens
{
    public class ListUserReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Usuários");

            ListUsers();

            Console.ReadKey();
            MenuReportScreen.Load();
        }
        public static void ListUsers()
        {
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRoles();

            foreach (var user in users)
            {
                var roles = "";
                foreach (var role in user.Roles) roles += $", {role.Name}";
                Console.WriteLine($"{user.Name}, {user.Email}{roles}");

            }
        }
    }


}