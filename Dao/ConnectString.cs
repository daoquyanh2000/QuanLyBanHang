using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

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
