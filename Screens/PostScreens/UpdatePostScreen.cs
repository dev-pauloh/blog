using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar Post");
            Console.WriteLine("--------------");

            Console.WriteLine("ID:");
            var id = Console.ReadLine();
            Console.WriteLine("ID da Categoria:");
            var categoryId = Console.ReadLine();
            Console.WriteLine("ID do Autor:");
            var authorId = Console.ReadLine();
            Console.WriteLine("Título:");
            var title = Console.ReadLine();
            Console.WriteLine("Sumário:");
            var summary = Console.ReadLine();
            Console.WriteLine("Corpo:");
            var body = Console.ReadLine();
            Console.WriteLine("Slug:");
            var slug = Console.ReadLine();

            Update(new Post
            {
                Id = int.Parse(id),
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug
            });

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void Update(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Update(post);
                Console.WriteLine("Post atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o Post!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}