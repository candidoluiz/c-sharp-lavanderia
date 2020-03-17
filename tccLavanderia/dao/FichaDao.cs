using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using tccLavanderia.model;
using tccLavanderia.repository;
using tccLavanderia.service;

namespace tccLavanderia.dao
{
    public class FichaDao
    {
        private ConnectionFactory con = new ConnectionFactory();
        MySqlCommand cmd;
        private DataTable dt;
        private MySqlDataReader dr;
        Ficha ficha;
        Roupa roupa;
        Lavanderia lavanderia;
        Empresa empresa;
        EmpresaService empresaService = new EmpresaService();
        RoupaService roupaService = new RoupaService();
        LavanderiaService lavanderiaService = new LavanderiaService();

        string sql = "";

        public bool salvar(Ficha ficha)
        {
            sql = "insert into ficha(lavanderia_id, roupa_id, data, empresa_id, quantidade) " +
                  "values(@lavanderia, @roupa, @entrada, @empresa, @quantidade)";

            try
            {

                string dia = ficha.entrada.ToString("yyyy/MM/dd");

                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lavanderia", ficha.lavanderia.id);
                cmd.Parameters.AddWithValue("@roupa", ficha.roupa.id);
                cmd.Parameters.AddWithValue("@entrada",dia);
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
                    "data = @entrada, " +
                    "empresa_id = @empresa, " +
                    "quantidade = @quantidade " +
                  "where id = @id";

            try
            {
                string dia = ficha.entrada.ToString("yyyy/MM/dd");

                con.conectar();
                MySqlCommand cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@lavanderia", ficha.lavanderia.id);
                cmd.Parameters.AddWithValue("@roupa", ficha.roupa.id);
                cmd.Parameters.AddWithValue("@entrada", dia);
                cmd.Parameters.AddWithValue("@empresa", ficha.empresa.id);
                cmd.Parameters.AddWithValue("@quantidade", ficha.quantidade);
                cmd.Parameters.AddWithValue("@id", ficha.id);
                cmd.ExecuteNonQuery();
                con.desconectar();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public bool excluir(Ficha ficha)
        {
            sql = "delete from ficha where id=@id";

            try
            {
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", ficha.id);
                cmd.ExecuteNonQuery();
        
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
        
        public DataTable pesquisar(string id, string modelo, string lavanderia, DateTime dataInicio, DateTime dataFim)
        {
            string pLavanderia = "%" + lavanderia + "%";
            string pDataInicio = dataInicio.ToString("yyyy/MM/dd");
            string pDataFim =dataFim.ToString("yyyy/MM/dd");

            sql = "select f.id Cod, r.modelo Modelo, tp.nome Tipo, e.nome Empresa, lav.nome Lavanderia, f.data Data, f.quantidade Quantidade, CAST(sum(vl.valor)  as DECIMAL(12,2)) 'Valor Unitário', cast((f.quantidade*sum(vl.valor)) as DECIMAL(12,2)) Total  from ficha f " +
                    "INNER JOIN roupa r ON r.id = f.roupa_id " +
                    "INNER JOIN tecido t ON t.id =r.tecido_id " +
                    "INNER JOIN tipo tp ON tp.id=r.tipo_id " +
                    "INNER JOIN roupa_lavagem rp ON rp.roupa_id = r.id " +
                    "INNER JOIN lavagem l ON l.id = rp.lavagem_id " +
                    "INNER JOIN valor_lavagem vl ON vl.lavagem_id = l.id " +
                    "INNER JOIN lavanderia lav ON lav.id = vl.lavanderia_id " +
                    "INNER JOIN empresa e ON e.id = f.empresa_id " +
                "where " +
                "(@id is null or f.id = @id) " +
                "AND " +
                "(@modelo is null or r.modelo = @modelo) " +
                "AND " +
                "(@lavanderia is null or lav.nome like @lavanderia) " +
                "AND " +
                "(f.data BETWEEN @inicio AND @fim )";

            try
            {
                dt = new DataTable();
                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@modelo", modelo);
                cmd.Parameters.AddWithValue("@lavanderia", pLavanderia);
                cmd.Parameters.AddWithValue("@inicio", pDataInicio);
                cmd.Parameters.AddWithValue("@fim", pDataFim);
                dt.Load(cmd.ExecuteReader());
                con.desconectar();
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Ficha consultarId(int id)
        {
            sql = "select * from ficha where id = @id";
            ficha = new Ficha();
            try
            {
                con.conectar();
                cmd = new MySqlCommand(sql, con.conectar());
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    lavanderia = lavanderiaService.consultarId(int.Parse(dr["lavanderia_id"].ToString()));
                    roupa = roupaService.consultarId(dr["roupa_id"].ToString(),null);
                    empresa = empresaService.consultarId(int.Parse(dr["empresa_id"].ToString()));

                    ficha.id = Int16.Parse(dr["id"].ToString());
                    ficha.empresa = empresa;
                    ficha.entrada = DateTime.Parse(dr["data"].ToString());
                    ficha.lavanderia = lavanderia;
                    ficha.quantidade = int.Parse(dr["quantidade"].ToString());
                    ficha.roupa = roupa;                    
                }
                con.desconectar();
                dr.Close();
                return ficha;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
