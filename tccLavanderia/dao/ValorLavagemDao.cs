using MySql.Data.MySqlClient;
using System;
using System.Data;
using tccLavanderia.model;
using tccLavanderia.repository;
using tccLavanderia.service;

namespace tccLavanderia.dao
{
    public class ValorLavagemDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        MySqlCommand cmd;
        private DataTable dt;
        private MySqlDataReader dr;

        string sql = "";
        ValorLavagem valorLavagem;
        Lavanderia lavanderia;
        Lavagem lavagem;
        LavanderiaService lavanderiaService;
        LavagemService lavagemService;

        public bool salvar(ValorLavagem valorLavagem)
        {
            sql = "insert into valor_lavagem(lavanderia_id, lavagem_id, valor) " +
                  "values(@lavanderia, @lavagem, @valor)";

            try
            {

                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lavanderia", valorLavagem.lavanderia.id);
                cmd.Parameters.AddWithValue("@lavagem", valorLavagem.lavagem.id);
                cmd.Parameters.AddWithValue("@valor", valorLavagem.valor);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool editar(ValorLavagem valorLavagem)
        {
            sql = "update valor_lavagem set " +
                    "lavanderia_id = @lavanderia, " +
                    "lavagem_id = @lavagem, " +
                    "valor = @valor, " +
                  "where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lavanderia_id", valorLavagem.lavanderia.id);
                cmd.Parameters.AddWithValue("@lavagem", valorLavagem.lavagem.id);
                cmd.Parameters.AddWithValue("@valor", valorLavagem.valor);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public bool excluir(ValorLavagem valorLavagem)
        {
            sql = "delete from valor_lavagem where id=@id";

            try
            {
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", valorLavagem.id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public DataTable pesquisar(string lavanderia, string lavagem)
        {
            string pLavanderia = "%" + lavanderia + "%";
            string pLavagem = "%" + lavagem + "%";

            sql = "select * from lavagem l INNER JOIN valor_lavagem vl ON l.id = vl.lavagem_id INNER JOIN lavanderia lv ON lv.id = vl.lavanderia_id "+
                "where " +
               "(@lavagem is null or l.processo like @lavagem) " +
               "AND " +
               "(@lavanderia is null or lv.nome like @lavanderia) ";

            try
            {
                dt = new DataTable();
                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lavagem", pLavagem);
                cmd.Parameters.AddWithValue("@lavanderia", pLavanderia);
                dt.Load(cmd.ExecuteReader());
                con.desconectar();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ValorLavagem consultarId(int id)
        {
            sql = "select * from valor_lavagem where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    valorLavagem = new ValorLavagem();
                    lavanderia = lavanderiaService.consultarId(int.Parse(dr["lavanderia_id"].ToString()));
                    lavagem = lavagemService.consultarId(int.Parse(dr["lavagem_id"].ToString()));

                    valorLavagem.id = int.Parse(dr["id"].ToString());
                    valorLavagem.lavagem = lavagem;
                    valorLavagem.lavanderia = lavanderia;
                    valorLavagem.valor = Double.Parse(dr["valor"].ToString());                   
                }
                return valorLavagem;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
