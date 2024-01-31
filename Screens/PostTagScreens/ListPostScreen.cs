using System.Runtime.CompilerServices;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostTagScreens
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Posts");
            Console.WriteLine("--------------");
            List();
            Console.ReadKey();
            MenuPostTagScreen.Load();
        }

        private static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithTags();

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Id} - {post.Title}");
                foreach (var tag in post.Tags) Console.WriteLine($" - {tag.Id} - {tag.Name}");
            }
        }
    }
}