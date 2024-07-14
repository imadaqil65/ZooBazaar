using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.User;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.ZooPartners
{
    public class ZooPartnerDB : IZooPartnerDB
    {
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn =
                new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436598;Database=dbi436598;Pwd=Hiccstrid;SslMode=none;");
            return conn;
        }
        public void AddZooPartner(ZooPartner zooPartner)
        {
            string command = "INSERT INTO `zb_zoopartner`(`Name`) VALUES (@name)";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@name", zooPartner.Name);
                MySqlDataReader reader = add.ExecuteReader();
            }
            //TODO: work on proper exhceptions
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }
        public void RemoveZooPartner(ZooPartner zooPartner)
        {
            string command = "DELETE FROM `zb_zoopartner` WHERE id = @ID";
            MySqlConnection conn = GetConnection();
            MySqlCommand add = new MySqlCommand(command, conn);
            try
            {
                conn.Open();
                add.Parameters.AddWithValue("@ID", zooPartner.Id);
                MySqlDataReader reader = add.ExecuteReader();
            }
            //TODO: work on proper exhceptions
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<ZooPartner> GetAllZooPartners()
        {
            List<ZooPartner> zooPartners = new List<ZooPartner>();
            string command = "SELECT * FROM `zb_zoopartner`";
            MySqlConnection conn = GetConnection();
            MySqlCommand read = new MySqlCommand(command, conn);
            try
            {
                conn.Open();

                MySqlDataReader reader = read.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("Id");
                    string name = reader.GetString("Name");
                    ZooPartner newZooPartner = new ZooPartner(name, id);
                    zooPartners.Add(newZooPartner);
                }
            }
            //TODO: work on proper exhceptions
            catch { }
            finally
            {
                conn.Close();
            }
            return zooPartners;
        }
    }
}