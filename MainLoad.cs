using Blog.Screens.CategoryScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.PostTagScreens;
using Blog.Screens.ReportScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserRoleScreens;
using Blog.Screens.UserScreens;

namespace Blog
{
    public class MainLoad
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de post");
            Console.WriteLine("4 - Gestão de categoria");
            Console.WriteLine("5 - Gestão de tag");
            Console.WriteLine("6 - Vincular perfil/usuário");
            Console.WriteLine("7 - Vincular post/tag");
            Console.WriteLine("8 - Relatórios");
            Console.WriteLine("9 - Sair");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 2:
                    MenuRoleScreen.Load();
                    break;
                case 3:
                    MenuPostScreen.Load();
                    break;
                case 4:
                    MenuCategoryScreen.Load();
                    break;
                case 5:
                    MenuTagScreen.Load();
                    break;
                case 6:
                    MenuUserRoleScreen.Load();
                    break;
                case 7:
                    MenuPostTagScreen.Load();
                    break;
                case 8:
                    MenuReportScreen.Load();
                    break;
                case 9:
                    System.Environment.Exit(0);
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}