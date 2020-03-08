using System.Data;
using tccLavanderia.dao;
using tccLavanderia.model;

namespace tccLavanderia.service
{
    public class ValorLavagemService
    {
        ValorLavagemDao valorLavagemDao = new ValorLavagemDao();


        public ValorLavagem consultarId(int id)
        {
            return valorLavagemDao.consultarId(id);
        }

        public bool salvar(ValorLavagem valorLavagem)
        {
            if (valorLavagem.id < 1)
            {
                return valorLavagemDao.salvar(valorLavagem);
            }
            else
            {
                return valorLavagemDao.editar(valorLavagem);
            }

        }

        public bool excluir(ValorLavagem valorLavagem)
        {
            return valorLavagemDao.excluir(valorLavagem);
        }

        public DataTable pesquisar(string lavanderia, string lavagem)
        {
            lavanderia = string.IsNullOrWhiteSpace(lavanderia) ? null : lavanderia;
            lavagem = string.IsNullOrWhiteSpace(lavagem) ? null : lavagem;
            
            return valorLavagemDao.pesquisar(lavanderia, lavagem);
        }

        public double valor(string modelo, string lavanderiaId, string quantidade)
        {
            try
            {
                return valorLavagemDao.valor(modelo, lavanderiaId) * double.Parse(quantidade);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
