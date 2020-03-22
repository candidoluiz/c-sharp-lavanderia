using MySql.Data.MySqlClient;
using System;
using System.Data;
using tccLavanderia.model;
using tccLavanderia.repository;
using tccLavanderia.service;

namespace tccLavanderia.dao
{
    public class EmpresaDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        private DataTable dt;
        private MySqlDataReader dr;
        private Empresa empresa;
        private Cidade cidade;
        private CidadeService cidadeService = new CidadeService();

        string sql = "";

        public bool salvar(Empresa empresa)
        {
            sql = "insert into empresa(nome, cnpj, endereco, cidade_id, numero, bairro, cep) " +
                  "values(@nome, @cnpj, @endereco, @cidade, @numero, @bairro, @cep)";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nome", empresa.nome);
                cmd.Parameters.AddWithValue("@cnpj", empresa.cnpj);
                cmd.Parameters.AddWithValue("@endereco", empresa.endereco);
                cmd.Parameters.AddWithValue("@cidade", empresa.cidade.id);
                cmd.Parameters.AddWithValue("@numero", empresa.numero);
                cmd.Parameters.AddWithValue("@bairro", empresa.bairro);
                cmd.Parameters.AddWithValue("@cep", empresa.cep);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool editar(Empresa empresa)
        {
            sql = "update empresa set " +
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
                cmd.Parameters.AddWithValue("@id", empresa.id);
                cmd.Parameters.AddWithValue("@nome", empresa.nome);
                cmd.Parameters.AddWithValue("@cnpj", empresa.cnpj);
                cmd.Parameters.AddWithValue("@endereco", empresa.endereco);
                cmd.Parameters.AddWithValue("@cidade", empresa.cidade.id);
                cmd.Parameters.AddWithValue("@numero", empresa.numero);
                cmd.Parameters.AddWithValue("@bairro", empresa.bairro);
                cmd.Parameters.AddWithValue("@cep", empresa.cep);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public bool excluir(Empresa empresa)
        {
            sql = "delete from empresa where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", empresa.id);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public Empresa consultarId(int id)
        {
            sql = "select * from empresa where id = @id";

            try
            {
                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    empresa = new Empresa();
                    cidade = cidadeService.consultarId(int.Parse(dr["cidade_id"].ToString()));

                    empresa.bairro = dr["bairro"].ToString();
                    empresa.id = Int16.Parse(dr["id"].ToString());
                    empresa.cep = dr["cep"].ToString();
                    empresa.cidade = cidade;
                    empresa.cnpj = dr["cnpj"].ToString();
                    empresa.nome = dr["nome"].ToString();
                    empresa.numero = dr["numero"].ToString();
                    empresa.endereco = dr["endereco"].ToString();

                }
                con.desconectar();
                dr.Close();
                return empresa;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public DataTable pesquisar(string id, string nome)
        {
            string valor = "%" + nome + "%";

            sql = "select l.id Cod, l.nome Nome, l.endereco Endereco, l.bairro Bairro, l.numero Numero, c.nome Cidade, c.uf Uf from empresa l inner join cidade c on c.id = l.cidade_id " +
                    "where " +
                    "(cast(@id as UNSIGNED) is null or l.id = @id) " +
                    "AND " +
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
    }
}
