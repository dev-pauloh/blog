using Blog.Models;
using Blog.Repositories;
using Dapper;
using Microsoft.VisualBasic;

namespace Blog.Screens.ReportScreens
{
    public class ListCategoryPostReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Categorias com quantidade de posts");

            List();

            Console.ReadKey();
            MenuReportScreen.Load();
        }
        public static void List()
        {
            var repository = new CategoryRepository(Database.Connection);
            var categories = repository.GetWithPost();

            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id} - {category.Name}");
                foreach (var item in category.Posts) Console.WriteLine($" - {item.Title}");
            }
        }

    }
}