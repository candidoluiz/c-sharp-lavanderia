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
    public class RoupaDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        private DataTable dt;
        private MySqlDataReader dr;
        private Roupa roupa;
        private RoupaLavagem roupaLavagem;

        string sql = "";

        public bool salvar(Roupa roupa)
        {
            sql = "insert into roupa(tipo, ano, referencia, tecido_id, estacao) " +
                  "values(@tipo, @ano, @referencia, @tecido, @estacao)";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@tipo", roupa.tipo);
                cmd.Parameters.AddWithValue("@ano", roupa.ano);
                cmd.Parameters.AddWithValue("@referencia", roupa.referencia);
                cmd.Parameters.AddWithValue("@tecido", roupa.tecido.id);
                cmd.Parameters.AddWithValue("@estacao", roupa.estacoes);
                salvarLavagem(roupa);
                cmd.ExecuteNonQuery();
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
            MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
            cmd.CommandText = sql;
            foreach (Lavagem lavagem in roupa.lavagens)
            {
                roupaLavagem = new RoupaLavagem();
                roupaLavagem.lavagem_id = lavagem.id;
                roupaLavagem.roupa_id = roupa.id;
                cmd.Parameters.AddWithValue("@lavagem", roupa.tecido.id);
                cmd.Parameters.AddWithValue("@roupa", roupa.id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
