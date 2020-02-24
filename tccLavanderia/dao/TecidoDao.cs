using MySql.Data.MySqlClient;
using System;
using System.Data;
using tccLavanderia.model;
using tccLavanderia.repository;

namespace tccLavanderia.dao
{
    public class TecidoDao
    {

        private ConnectionFactory con = new ConnectionFactory();
        private DataTable dt;
        private MySqlDataReader dr;
        private Tecido tecido;

        string sql = "";

        public bool salvar(Tecido tecido)
        {
            sql = "insert into tecido(nome, composicao) values(@nome, @composicao)";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", tecido.nome);
                cmd.Parameters.AddWithValue("@composicao", tecido.composicao);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool editar(Tecido tecido)
        {
            sql = "update tecido set nome = @nome, composicao = @composicao where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", tecido.id);
                cmd.Parameters.AddWithValue("@nome", tecido.nome);
                cmd.Parameters.AddWithValue("@composicao", tecido.composicao);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool excluir(Tecido tecido)
        {
            sql = "delete from tecido where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", tecido.id);
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

            sql = "select t.id Cod, t.nome Nome, t.composicao Composição from tecido t " +
                    "where " +
                    "(@id  is null or t.id = @id) " +
                    "AND " +
                    "(@nome is null or t.nome like @nome) order by t.nome ";


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

        public Tecido consultarId(int id)
        {
            sql = "select * from tecido t where t.id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tecido = new Tecido();
                    tecido.id = Int16.Parse(dr["id"].ToString());
                    tecido.composicao = dr["composicao"].ToString();
                    tecido.nome = dr["nome"].ToString();
                }
                return tecido;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
