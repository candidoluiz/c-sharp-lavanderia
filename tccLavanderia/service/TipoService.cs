using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tccLavanderia.dao;
using tccLavanderia.model;

namespace tccLavanderia.service
{
    public class TipoService
    {
        TipoDao tipoDao = new TipoDao();

        public bool salvar(Tipo tipo)
        {
            if (tipo.id < 1)
            {
                return tipoDao.salvar(tipo);
            }
            else
            {
                return tipoDao.editar(tipo);
            }
        }

        public bool excluir(Tipo tipo)
        {
            return tipoDao.excluir(tipo);
        }

        public DataTable pesquisar(string id, string pesquisa)
        {
            if (pesquisa == "")
            {
                pesquisa = null;
            }
            if (id == "")
            {
                id = null;
            }
            return tipoDao.pesquisar(id, pesquisa);
        }

        public Tipo consultarId(int id)
        {
            return tipoDao.consultarId(id);
        }
    }
}
