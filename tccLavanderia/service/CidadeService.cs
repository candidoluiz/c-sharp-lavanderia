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
    public class CidadeService
    {
        CidadeDao cidadeDao = new CidadeDao();

        public bool salvar(Cidade cidade)
        {
            if(cidade.id < 1)
            {
                return cidadeDao.salvar(cidade);
            }
            else
            {
                return cidadeDao.editar(cidade);
            }
        }

        public bool excluir(Cidade cidade)
        {
            return cidadeDao.excluir(cidade);
        }

        public DataTable pesquisar(string pesquisa)
        {
            if(pesquisa == "")
            {
                pesquisa = null;
            }
            return cidadeDao.pesquisar(pesquisa);
        }

        public DataTable listarTudo()
        {
            return cidadeDao.listarTudo();
        }

        public Cidade consultarId(int id)
        {
            return cidadeDao.consultarId(id);
        }

        public DataTable listarUf()
        {
            return cidadeDao.listarUf();
        }

        public DataTable listarCidadePorUf(string uf)
        {
            return cidadeDao.listarCidadePorUf(uf);
        }
    }
}
