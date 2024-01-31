using Blog.Models;
using Blog.Repositories;
using Dapper;
using Microsoft.VisualBasic;

namespace Blog.Screens.ReportScreens
{
    public class ListTagReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Tags com quantidade de posts");

            List();

            Console.ReadKey();
            MenuReportScreen.Load();
        }
        public static void List()
        {
            var repository = new TagRepository(Database.Connection);
            var tags = repository.GetWithPost();

            foreach (var item in tags)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug}) Posts: {item.Posts.Count}");
        }

    }
}