using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.repository;
using tccLavanderia.service;

namespace tccLavanderia.dao
{
    public class LavanderiaDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        private DataTable dt;
        private MySqlDataReader dr;
        private Lavanderia lav;
        private Cidade cidade;
        private CidadeService cidadeService = new CidadeService();

        string sql = "";

        public bool salvar(Lavanderia lavanderia)
        {
            sql = "insert into lavanderia(nome, cnpj, endereco, cidade_id, numero, bairro, cep) "+
                  "values(@nome, @cnpj, @endereco, @cidade, @numero, @bairro, @cep)";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql,con.conectar());

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", lavanderia.nome);
                cmd.Parameters.AddWithValue("@cnpj", lavanderia.cnpj);
                cmd.Parameters.AddWithValue("@endereco", lavanderia.endereco);
                cmd.Parameters.AddWithValue("@cidade", lavanderia.cidade.id);
                cmd.Parameters.AddWithValue("@numero", lavanderia.numero);
                cmd.Parameters.AddWithValue("@bairro", lavanderia.bairro);
                cmd.Parameters.AddWithValue("@cep", lavanderia.cep);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {
                
                throw;
            }
            return true;
        }

        public bool editar(Lavanderia lavanderia)
        {
            sql = "update lavanderia set " +
            "nome = @nome, " +
            "cnpj = @cnpj, " +
            "endereco = @endereco, " +
            "cidade_id = @cidade, " +
            "numero = @numero, " +
            "bairro = @bairro, " +
            "cep = @cep " +
            "where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", lavanderia.id);
                cmd.Parameters.AddWithValue("@nome", lavanderia.nome);
                cmd.Parameters.AddWithValue("@cnpj", lavanderia.cnpj);
                cmd.Parameters.AddWithValue("@endereco", lavanderia.endereco);
                cmd.Parameters.AddWithValue("@cidade", lavanderia.cidade.id);
                cmd.Parameters.AddWithValue("@numero", lavanderia.numero);
                cmd.Parameters.AddWithValue("@bairro", lavanderia.bairro);
                cmd.Parameters.AddWithValue("@cep", lavanderia.cep);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
                
            return true;
        }

        public bool excluir(Lavanderia lavanderia)
        {
            sql = "delete from lavanderia where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", lavanderia.id);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public DataTable listarTudo()
        {
            sql = "select l.id Cod, l.nome Nome, l.endereco Endereco, l.bairro Bairro, l.numero Numero, c.nome Cidade, c.uf Uf from lavanderia l inner join cidade c on c.id = l.cidade_id";
            

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

        public DataTable pesquisar(string id, string nome)
        {
            string valor = "%" + nome + "%";

            sql = "select l.id Cod, l.nome Nome, l.endereco Endereco, l.bairro Bairro, l.numero Numero, c.nome Cidade, c.uf Uf from lavanderia l inner join cidade c on c.id = l.cidade_id " +
                    "where " +
                    "(cast(@id as UNSIGNED) is null or l.id = @id) "+
                    "AND "+
                    "(@nome is null or l.nome like @nome)";

            try
            {
                dt = new DataTable();
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
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

        public Lavanderia consultarId(int id)
        {
            sql = "select * from lavanderia where id = @id";
            
            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lav = new Lavanderia();
                    cidade = cidadeService.consultarId(int.Parse(dr["cidade_id"].ToString()));

                    lav.bairro = dr["bairro"].ToString();
                    lav.id = Int16.Parse(dr["id"].ToString());
                    lav.cep = dr["cep"].ToString();
                    lav.cidade = cidade;
                    lav.cnpj = dr["cnpj"].ToString();
                    lav.nome = dr["nome"].ToString();
                    lav.numero = dr["numero"].ToString();
                    lav.endereco = dr["endereco"].ToString();

                }
                return lav;

            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
    }
}
