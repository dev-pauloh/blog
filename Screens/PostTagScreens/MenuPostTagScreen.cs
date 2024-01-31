namespace Blog.Screens.PostTagScreens
{
    public static class MenuPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular Tag ao Post");
            Console.WriteLine("---------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar posts");
            Console.WriteLine("2 - Listar tags");
            Console.WriteLine("3 - Vincular tag ao post");
            Console.WriteLine("4 - Excluir vínculo");
            Console.WriteLine("5 - Voltar");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListPostScreen.Load();
                    break;
                case 2:
                    ListTagScreen.Load();
                    break;
                case 3:
                    CreatePostTagScreen.Load();
                    break;
                case 4:
                    DeletePostTagScreen.Load();
                    break;
                case 5:
                    MainLoad.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}