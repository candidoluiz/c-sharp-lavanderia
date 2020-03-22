using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tccLavanderia.repository
{
    class ConnectionFactory
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlCommandBuilder cb;
        DataTable dt;
        MySqlDataAdapter da;

        static string server = "localhost";
        static string port = "3306";
        static string dataBase = "tcclavanderia";
        static string userId = "root";
        static string psw = "";

        static string str = "server="+server+
            ";port="+port+
            ";database="+dataBase+
            ";User Id="+userId+
            ";password="+psw;

        public MySqlConnection conectar()
        {
            try
            {
                con = new MySqlConnection(str);
                con.Open();
                return con;
            }
            catch (Exception e)
            {
               
                throw e;
            }

        }

        public void desconectar()
        {
            try
            {
                //con = new MySqlConnection();
                con.Close();
                con.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public void executarSql(string sql)
        {
            try
            {
                conectar();
                cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable retDataTable(string sql)
        {
            try
            {
                conectar();
                dt = new DataTable();
                da = new MySqlDataAdapter(sql, con);
                cb = new MySqlCommandBuilder(da);
                da.Fill(dt);
                desconectar();
                return dt;


            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}