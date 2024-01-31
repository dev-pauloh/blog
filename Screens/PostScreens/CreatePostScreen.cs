using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;

namespace Blog.Screens.PostScreens
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Post");
            Console.WriteLine("--------------");

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

            Create(new Post
            {
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

        private static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o post!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}