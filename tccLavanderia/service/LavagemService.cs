using System.Data;
using tccLavanderia.dao;
using tccLavanderia.model;

namespace tccLavanderia.service
{
    public class LavagemService
    {
        LavagemDao lavagemDao = new LavagemDao();

        public bool salvar(Lavagem lavagem)
        {
            if (lavagem.id < 1)
            {
                return lavagemDao.salvar(lavagem);
            }
            else
            {
                return lavagemDao.editar(lavagem);
            }
        }

        public bool excluir(Lavagem lavagem)
        {
            return lavagemDao.excluir(lavagem);
        }

        public DataTable pesquisar(string pesquisa)
        {
            if (pesquisa == "")
            {
                pesquisa = null;
            }
            return lavagemDao.pesquisar(pesquisa);
        }

        public Lavagem consultarId(int id)
        {
            return lavagemDao.consultarId(id);
        }
    }
}
