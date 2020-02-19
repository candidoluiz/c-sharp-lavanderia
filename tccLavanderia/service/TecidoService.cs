using System.Data;
using tccLavanderia.dao;
using tccLavanderia.model;

namespace tccLavanderia.service
{
    public class TecidoService
    {
        TecidoDao tecidoDao = new TecidoDao();

        public bool salvar(Tecido tecido)
        {
            if (tecido.id < 1)
            {
                return tecidoDao.salvar(tecido);
            }
            else
            {
                return tecidoDao.editar(tecido);
            }
        }

        public bool excluir(Tecido tecido)
        {
            return tecidoDao.excluir(tecido);
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
            return tecidoDao.pesquisar(id, pesquisa);
        }

        public Tecido consultarId(int id)
        {
            return tecidoDao.consultarId(id);
        }
    }
}
