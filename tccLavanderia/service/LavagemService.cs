﻿using System.Collections.Generic;
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

        public DataTable pesquisar(string id, string pesquisa)
        {
            id = string.IsNullOrWhiteSpace(id) ? id = null : id;
            pesquisa = string.IsNullOrWhiteSpace(pesquisa) ? pesquisa = null : pesquisa;

            return lavagemDao.pesquisar(id, pesquisa);
        }

        public Lavagem consultarId(int id)
        {
            return lavagemDao.consultarId(id);
        }

        public List<Lavagem> listarLavagem(int id)
        {
            return lavagemDao.listarLavagem(id);
        }
    }
}
