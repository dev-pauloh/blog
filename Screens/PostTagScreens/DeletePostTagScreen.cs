using Blog.Models;
using Blog.Repositories;
using Dapper;

namespace Blog.Screens.PostTagScreens
{
    public static class DeletePostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir vínculo");
            Console.WriteLine("--------------");

            Console.WriteLine("Id Post:");
            var postId = Console.ReadLine();
            Console.WriteLine("Id Tag:");
            var tagId = Console.ReadLine();

            Delete(
                new PostTag
                {
                    PostId = postId,
                    TagId = tagId
                });

            Console.ReadKey();
            MenuPostTagScreen.Load();
        }

        private static void Delete(PostTag postTag)
        {
            try
            {

                var deleteQuery = "DELETE [PostTag] WHERE [PostId]=@postId AND [TagId]=@tagId";
                var rows = Database.Connection.Execute(deleteQuery, postTag);

                Console.WriteLine($"{rows} registros excluídos");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o vínculo!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}