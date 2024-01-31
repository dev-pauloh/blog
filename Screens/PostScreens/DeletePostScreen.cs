using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.PostScreens
{
    public static class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir Post");
            Console.WriteLine("--------------");

            Console.WriteLine("Qual o ID do post que deseja excluir?");
            var id = Console.ReadLine();

            Delete(int.Parse(id));

            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Post excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o Post!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}