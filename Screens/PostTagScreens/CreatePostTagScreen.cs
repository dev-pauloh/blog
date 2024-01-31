using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostTagScreens
{
    public static class CreatePostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo vínculo Post/Tag");
            Console.WriteLine("--------------");

            Console.WriteLine("Id Post:");
            var postId = Console.ReadLine();
            Console.WriteLine("Id Tag:");
            var tagId = Console.ReadLine();

            Create(new PostTag
            {
                PostId = postId,
                TagId = tagId
            });

            Console.ReadKey();
            MenuPostTagScreen.Load();
        }

        private static void Create(PostTag postTag)
        {
            try
            {
                var repository = new Repository<PostTag>(Database.Connection);
                repository.Create(postTag);
                Console.WriteLine("Post e Tag vinculados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular o post a tag!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}