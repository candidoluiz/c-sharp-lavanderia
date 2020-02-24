using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tccLavanderia.dao;
using tccLavanderia.model;

namespace tccLavanderia.service
{
    public class RoupaService
    {
        RoupaDao roupaDao = new RoupaDao();

        public bool salvar(Roupa roupa)
        {
            if (roupa.id < 1)
            {
                return roupaDao.salvar(roupa);
            }
            else
            {
                return roupaDao.editar(roupa);
            }

        }

        public bool excluir(Roupa roupa)
        {
            return roupaDao.excluir(roupa);
        }
    }
}
