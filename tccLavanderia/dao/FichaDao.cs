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
    public class FichaDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        MySqlCommand cmd;
        private DataTable dt;
        private MySqlDataReader dr;

        string sql = "";

        public bool salvar(Ficha ficha)
        {
            sql = "insert into ficha(lavanderia_id, roupa_id, entrada, empresa_id, quantidade) " +
                  "values(@lavanderia, @roupa, @entrada, @empresa, @quantidade)";

            try
            {
                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lavanderia_id", ficha.lavanderia.id);
                cmd.Parameters.AddWithValue("@roupa", ficha.roupa.ano);
                cmd.Parameters.AddWithValue("@entrada", ficha.entrada);
                cmd.Parameters.AddWithValue("@empresa", ficha.empresa.id);
                cmd.Parameters.AddWithValue("@quantidade", ficha.quantidade);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool editar(Ficha ficha)
        {
            sql = "update ficha set " +
                    "lavanderia_id = @lavanderia, " +
                    "roupa_id = @roupa, " +
                    "entrada = @entrada, " +
                    "empresa_id = @empresa, " +
                    "quantidade = @quantidade " +
                  "where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lavanderia_id", ficha.lavanderia.id);
                cmd.Parameters.AddWithValue("@roupa", ficha.roupa.ano);
                cmd.Parameters.AddWithValue("@entrada", ficha.entrada);
                cmd.Parameters.AddWithValue("@empresa", ficha.empresa.id);
                cmd.Parameters.AddWithValue("@quantidade", ficha.quantidade);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        private void excluir(int id)
        {
            sql = "delete from ficha where id=@id";

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
        /*
        public DataTable pesquisar(string id, string modelo, string lavanderia, string dataInicio, string dataFim)
        {
            string pId = "%" + id + "%";
            string pModelo = "%" + modelo + "%";
            string pLavanderia = "%" + lavanderia + "%";
            string pdataInicio = "%" + dataInicio + "%";
            string pdataFim = "%" + dataFim + "%";

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
        }*/
    }
}
