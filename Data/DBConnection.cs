using System.Data.SqlClient;

namespace MVC_Project.Data
{
    public class DBConnection
    {
        private string Sqlstring = string.Empty;

        public DBConnection() {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            Sqlstring = builder.GetSection("ConnectionStrings:DBConnection").Value;
        }

        public string getSQLConString()
        {
            return Sqlstring;
        }
    }
}