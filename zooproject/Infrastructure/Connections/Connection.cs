using Domain.Domain.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Exceptions;
namespace zooproject.Infrastructure.Connections
{
    public class Connection
    {
        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
                conn.Open();
                return conn;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
                throw new SqlException("No Connection Could Be Established");
            }
        }
    }
}