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
    public class EmpresaService
    {
        EmpresaDao empresaDao = new EmpresaDao();

        public Empresa consultarId(int id)
        {
            return empresaDao.consultarId(id);
        }

        public bool salvar(Empresa empresa)
        {
            if (empresa.id < 1)
            {
                return empresaDao.salvar(empresa);
            }
            else
            {
                return empresaDao.editar(empresa);
            }

        }

        public bool excluir(Empresa empresa)
        {
            return empresaDao.excluir(empresa);
        }

        public DataTable pesquisar(string id, string nome)
        {
            if (id == "")
            {
                id = null;
            }
            if (nome == "")
            {
                nome = null;
            }
            return empresaDao.pesquisar(id, nome);
        }
    }
}
