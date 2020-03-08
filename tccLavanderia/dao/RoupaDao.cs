using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using tccLavanderia.model;
using tccLavanderia.repository;
using tccLavanderia.service;

namespace tccLavanderia.dao
{
    public class RoupaDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        MySqlCommand cmd;
        private DataTable dt;
        private MySqlDataReader dr;
        private Roupa roupa;
        private TecidoService tecidoService = new TecidoService();
        private TipoService tipoService = new TipoService();
        private Tecido tecido;
        private Tipo tipo;
        private List<Lavagem> lavagem;
        private LavagemService lavagemService = new LavagemService();

        string sql = "";

        public bool salvar(Roupa roupa)
        {
            sql = "insert into roupa(tipo_id, ano, modelo, tecido_id, estacao) " +
                  "values(@tipo, @ano, @modelo, @tecido, @estacao)";

            try
            {
                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@tipo", roupa.tipo.id);
                cmd.Parameters.AddWithValue("@ano", roupa.ano);
                cmd.Parameters.AddWithValue("@modelo", roupa.modelo);
                cmd.Parameters.AddWithValue("@tecido", roupa.tecido.id);
                cmd.Parameters.AddWithValue("@estacao", roupa.estacao);
                cmd.ExecuteNonQuery();
                sql = "select max(r.id) from roupa r";
                cmd = new MySqlCommand(sql, con.conectar());
                roupa.id = (int)cmd.ExecuteScalar();
                salvarLavagem(roupa);
                con.desconectar();
            }
            catch (Exception e)
            {

                throw e;
            }
            return true;
        }

        public bool editar(Roupa roupa)
        {
            sql = "update roupa set tipo_id = @tipo, ano = @ano, modelo = @modelo, tecido_id = @tecido, estacao = @estacao  where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", roupa.id);
                cmd.Parameters.AddWithValue("@tipo", roupa.tipo.id);
                cmd.Parameters.AddWithValue("@ano", roupa.ano);
                cmd.Parameters.AddWithValue("@modelo", roupa.modelo);
                cmd.Parameters.AddWithValue("@estacao", roupa.estacao);
                cmd.Parameters.AddWithValue("@tecido", roupa.tecido.id);
                excluirLavagem(roupa.id);                
                cmd.ExecuteNonQuery();
                salvarLavagem(roupa);
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        private void salvarLavagem(Roupa roupa)
        {
             sql = "insert into roupa_lavagem(roupa_id, lavagem_id) values(@roupa, @lavagem)";       
            foreach (Lavagem lavagem in roupa.lavagens)
            {
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lavagem", lavagem.id);
                cmd.Parameters.AddWithValue("@roupa", roupa.id);       
                cmd.ExecuteNonQuery();
            }
        }

        private void excluirLavagem(int id)
        {
            sql = "delete from roupa_lavagem where roupa_id=@id";

            try
            {                
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public DataTable pesquisar(string modelo, string tipo, string ano, string estacao)
        {
            string pTipo = "%" + tipo + "%";

            sql = "SELECT r.id Cod, r.modelo Modelo, t.nome Tipo, r.estacao Estacao, r.ano Ano from roupa r INNER JOIN tipo t ON t.id=r.tipo_id " +
                "where " +
                "(@modelo is null or r.modelo = @modelo) " +
                "AND " +
                "(@tipo is null or t.nome like @tipo) " +
                "AND " +
                "(@ano is null or r.ano = @ano) " +
                "AND " +
                "(@estacao is null or r.estacao = @estacao)"; 

            try
            {
                dt = new DataTable();
                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@modelo", modelo);
                cmd.Parameters.AddWithValue("@tipo", pTipo);
                cmd.Parameters.AddWithValue("@ano", ano);
                cmd.Parameters.AddWithValue("@estacao", estacao);
                dt.Load(cmd.ExecuteReader());
                con.desconectar();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool excluir(Roupa roupa)
        {
            sql = "delete from roupa where id = @id";

            try
            {
                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", roupa.id);
                cmd.ExecuteNonQuery();
                excluirLavagem(roupa.id);
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public Roupa consultarId(string id, string modelo)
        {
            sql = "select * from roupa r where "+
                "(@id is null or r.id = @id) " +
                "AND " +
                "(@modelo is null or r.modelo = @modelo)";
            roupa = new Roupa();
            try
            {
                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@modelo", modelo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    tecido = tecidoService.consultarId(int.Parse(dr["tecido_id"].ToString()));
                    tipo = tipoService.consultarId(int.Parse(dr["tipo_id"].ToString()));
                    lavagem = lavagemService.listarLavagem(int.Parse(dr["id"].ToString()));
                    
                    roupa.ano = dr["ano"].ToString();
                    roupa.id = Int16.Parse(dr["id"].ToString());
                    roupa.estacao = dr["estacao"].ToString();
                    roupa.modelo = dr["modelo"].ToString();
                    roupa.tecido = tecido;
                    roupa.tipo = tipo;
                    roupa.lavagens = lavagem;

                }
                return roupa;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
