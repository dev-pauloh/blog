namespace Blog.Screens.ReportScreens
{
    public static class MenuReportScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatórios");
            Console.WriteLine("---------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("");
            Console.WriteLine("1 - Listar usuários com perfis");
            Console.WriteLine("2 - Listar categorias com quantidade de posts");
            Console.WriteLine("3 - Listar tags com quantidade de posts");
            Console.WriteLine("4 - Listar posts das categorias");
            Console.WriteLine("5 - Listar posts com a categoria");
            Console.WriteLine("6 - Listar posts com tags");
            Console.WriteLine("7 - Voltar");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListUserReportScreen.Load();
                    break;
                case 2:
                    ListCategoryReportScreen.Load();
                    break;
                case 3:
                    ListTagReportScreen.Load();
                    break;
                case 4:
                    ListCategoryPostReportScreen.Load();
                    break;
                case 5:
                    ListPostCategoryReportScreen.Load();
                    break;
                case 6:
                    ListPostTagReportScreen.Load();
                    break;
                case 7:
                    MainLoad.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}