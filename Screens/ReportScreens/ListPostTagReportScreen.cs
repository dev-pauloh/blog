using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.ReportScreens
{
    public class ListPostTagReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Post com tags");

            List();

            Console.ReadKey();
            MenuReportScreen.Load();
        }
        public static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithTags();

            foreach (var post in posts)
            {
                var tags = "";
                foreach (var tag in post.Tags) tags += $", {tag.Name}";
                Console.WriteLine($"{post.Title}{tags}");

            }
        }
    }


}