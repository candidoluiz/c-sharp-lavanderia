using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tccLavanderia.model;
using tccLavanderia.repository;

namespace tccLavanderia.dao
{
    public class LavagemDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        private DataTable dt;
        private MySqlDataReader dr;
        private Lavagem lavagem;

        string sql = "";

        public bool salvar(Lavagem lavagem)
        {
            sql = "insert into lavagem(processo) values(@processo)";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@processo", lavagem.processo);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool editar(Lavagem lavagem)
        {
            sql = "update lavagem set processo = @processo where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", lavagem.id);
                cmd.Parameters.AddWithValue("@processo", lavagem.processo);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool excluir(Lavagem lavagem)
        {
            sql = "delete from lavagem where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", lavagem.id);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public DataTable pesquisar(string id, string nome)
        {
            string valor = "%" + nome + "%";

            sql = "select l.id Cod, l.processo Processo from lavagem l " +
                    "where " +
                    "(@id  is null or l.id = @id) "+
                    "AND " +
                "(@nome is null or l.processo like @nome) order by l.processo";


            try
            {
                dt = new DataTable();
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", valor);
                cmd.Parameters.AddWithValue("@id", id);
                dt.Load(cmd.ExecuteReader());
                con.desconectar();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Lavagem consultarId(int id)
        {
            sql = "select * from lavagem l where l.id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lavagem = new Lavagem();
                    lavagem.id = Int16.Parse(dr["id"].ToString());
                    lavagem.processo = dr["processo"].ToString();
                }
                return lavagem;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
