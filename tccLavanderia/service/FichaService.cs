using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using tccLavanderia.dao;
using tccLavanderia.model;
using tccLavanderia.print;

namespace tccLavanderia.service
{
    public class FichaService
    {
        FichaDao fichaDao = new FichaDao();
        LavanderiaService lavanderiaService = new LavanderiaService();
        DataSetRelatorio ds;
        DataTable dt;

        public bool salvar(Ficha ficha)
        {
            return ficha.id < 1 ? fichaDao.salvar(ficha) : fichaDao.editar(ficha);
        }

        public bool excluir(Ficha ficha)
        {
            return fichaDao.excluir(ficha);
        }

        public DataTable pesquisar(string id, string modelo, string lavanderia, DateTime inicio, DateTime fim)
        {
            id = string.IsNullOrWhiteSpace(id) ? id = null : id;
            modelo = string.IsNullOrWhiteSpace(modelo) ? modelo = null : modelo;
            lavanderia = string.IsNullOrWhiteSpace(lavanderia) ? lavanderia = null : lavanderia;

            return fichaDao.pesquisar(id, modelo, lavanderia, inicio, fim);

        }

        public Ficha consultarId(int id)
        {
            return fichaDao.consultarId(id);
        }

        public DataSetRelatorio imprimirFicha(DataGridView linha)
        {
            ds = new DataSetRelatorio();
           


            foreach (var item in linha.Rows)
            {
                DataGridViewRow row = item as DataGridViewRow;
                if (row.Selected)
                {
                    dt = new DataTable();
                    dt = fichaDao.imprimirFicha(row.Cells[0].Value.ToString());
                    ds.Tables.Add(dt); /*
                    foreach(DataRow r in dt.Rows)
                    {
                        DataRow dtRow = ds.Tables[0].NewRow();
                        dtRow["cod"] = r["cod"];
                        dtRow["data"] = r["datas"];
                        dtRow["tipo"] = r["tipo"];
                        dtRow["empresa"] = r["empresa"];
                        dtRow["lavanderia"] = r["lavanderia"];
                        dtRow["quantidade"] = r["quantidade"];
                        dtRow["modelo"] = r["modelo"];
                        dtRow["lavagens"] = r["lavagens"];
                        dtRow["valorUnitario"] = r["valorUnitario"];
                        ds.Tables[0].Rows.Add(dtRow);
                    } */

                   

                }
            }

            return ds;
        }

       public DataTable carregarCombo()
        {
            return lavanderiaService.pesquisar(null, null);
        }
    }
}
