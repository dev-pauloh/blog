using Microsoft.Data.SqlClient;

namespace Blog // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private const string CONNECTIONSTRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTIONSTRING);
            Database.Connection.Open();

            MainLoad.Load();

            Console.ReadKey();
            Database.Connection.Close();
        }
    }


}