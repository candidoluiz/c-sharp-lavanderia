using System;
using System.Data;
using tccLavanderia.dao;
using tccLavanderia.model;

namespace tccLavanderia.service
{
    public class FichaService
    {
        FichaDao fichaDao = new FichaDao();

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
    }
}
