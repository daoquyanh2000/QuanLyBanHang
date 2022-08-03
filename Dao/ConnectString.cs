using System.Configuration;

namespace QuanLyBanHang.Dao
{
    public class ConnectString
    {
        public static string Setup()
        {
            return ConfigurationManager.ConnectionStrings["StoreContext"].ConnectionString;
        }
    }
}