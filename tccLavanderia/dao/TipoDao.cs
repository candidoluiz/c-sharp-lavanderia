using MySql.Data.MySqlClient;
using System;
using System.Data;
using tccLavanderia.model;
using tccLavanderia.repository;

namespace tccLavanderia.dao
{
    public class TipoDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        private DataTable dt;
        private MySqlDataReader dr;
        private Tipo tipo;

        string sql = "";

        public bool salvar(Tipo tipo)
        {
            sql = "insert into tipo(nome) values(@nome)";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", tipo.nome);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool editar(Tipo tipo)
        {
            sql = "update tipo set nome = @nome where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", tipo.id);
                cmd.Parameters.AddWithValue("@nome", tipo.nome);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool excluir(Tipo tipo)
        {
            sql = "delete from tipo where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", tipo.id);
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

            sql = "select t.id Cod, t.nome Tipo from tipo t " +
                    "where " +
                    "(@id  is null or t.id = @id) " +
                    "AND " +
                    "(@nome is null or t.nome like @nome) ";


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

        public Tipo consultarId(int id)
        {
            sql = "select * from tipo t where t.id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tipo = new Tipo();
                    tipo.id = Int16.Parse(dr["id"].ToString());
                    tipo.nome = dr["nome"].ToString();
                }
                return tipo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
