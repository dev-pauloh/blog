using Blog.Models;
using Blog.Repositories;
using Dapper;
using Microsoft.VisualBasic;

namespace Blog.Screens.ReportScreens
{
    public class ListPostCategoryReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Posts com a categoria");

            List();

            Console.ReadKey();
            MenuReportScreen.Load();
        }
        public static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithCategory();

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Id} - {post.Title} Categoria: {post.Category.Name}");
            }
        }

    }
}