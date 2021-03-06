﻿using System;
using System.Data;
using tccLavanderia.dao;
using tccLavanderia.model;

namespace tccLavanderia.service
{
    public class RoupaService
    {
        RoupaDao roupaDao = new RoupaDao();
        Roupa roupa;

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

        public DataTable pesquisar(string modelo, string tipo, string ano, string estacao)
        {
            if (String.IsNullOrWhiteSpace(modelo))
                modelo = null;
            if (String.IsNullOrWhiteSpace(tipo))
                tipo = null;
            if (String.IsNullOrWhiteSpace(ano))
                ano = null;
            if (String.IsNullOrWhiteSpace(estacao))
                estacao = null;

            return roupaDao.pesquisar(modelo, tipo, ano, estacao);
        }

        public Roupa consultarId(string id, string modelo)
        {
            roupa = roupaDao.consultarId(id, modelo);
            if (roupa.modelo != null)
                return roupaDao.consultarId(id, modelo);
            else
                throw new Exception("Roupa não cadastrada");
        }
    }
}
