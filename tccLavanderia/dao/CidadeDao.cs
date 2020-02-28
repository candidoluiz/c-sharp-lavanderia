using MySql.Data.MySqlClient;
using System;
using System.Data;
using tccLavanderia.model;
using tccLavanderia.repository;

namespace tccLavanderia.dao
{
    public class CidadeDao
    {
        ConnectionFactory con = new ConnectionFactory();
        DataTable dt;
        MySqlDataReader dr;
        Cidade cidade;

        string sql = "";

        public bool salvar(Cidade cidade)
        {
            sql = "insert into cidade(nome, uf) values(@nome, @uf)";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", cidade.nome);
                cmd.Parameters.AddWithValue("@uf", cidade.uf);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool editar(Cidade cidade)
        {
            sql = "update cidade set nome = @nome, uf = @uf where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", cidade.id);
                cmd.Parameters.AddWithValue("@nome", cidade.nome);
                cmd.Parameters.AddWithValue("@uf", cidade.uf);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool excluir(Cidade cidade)
        {
            sql = "delete from cidade where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", cidade.id);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public DataTable pesquisar(string nome)
        {
            string valor = "%" + nome + "%";

            sql = "select c.id Cod, c.nome Cidade, c.uf Estado from cidade c where @nome is null or Nome like @nome";

            try
            {
                dt = new DataTable();
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", valor);
                dt.Load(cmd.ExecuteReader());
                con.desconectar();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cidade consultarId(int id)
        {
            sql = "select * from cidade c where c.id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cidade = new Cidade();
                    cidade.id = Int16.Parse(dr["id"].ToString());
                    cidade.nome= dr["nome"].ToString();
                    cidade.uf= dr["uf"].ToString();
                }
                return cidade;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable listarUf()
        {
            sql = "select distinct(c.uf) uf from cidade c";

            try
            {
                 dt = new DataTable();
                con.conectar();
                dt = con.retDataTable(sql);
                con.desconectar();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable listarCidadePorUf(string uf)
        {
            sql = "select c.nome, c.id from cidade c where c.uf = @uf";

            try
            {
                dt = new DataTable();
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@uf", uf);
                dt.Load(cmd.ExecuteReader());
                con.desconectar();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
