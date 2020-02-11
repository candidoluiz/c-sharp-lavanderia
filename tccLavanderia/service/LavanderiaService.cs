using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tccLavanderia.dao;
using tccLavanderia.model;

namespace tccLavanderia.service
{
   public class LavanderiaService
    {
        LavanderiaDao lavanderiaDao = new LavanderiaDao();

        public Lavanderia consultarId(int id )
        {
            return lavanderiaDao.consultarId(id);
        }

        public bool salvar(Lavanderia lavanderia)
        {
            if(lavanderia.id < 1)
            {
                return lavanderiaDao.salvar(lavanderia);
            }
            else
            {
                return lavanderiaDao.editar(lavanderia);
            }
            
        }

        public bool excluir(Lavanderia lavanderia)
        {
            return lavanderiaDao.excluir(lavanderia);
        }

        public DataTable listarTudo()
        {
            return lavanderiaDao.listarTudo();
        }

        public DataTable pesquisar(string id, string nome)
        {
            if(id == "")
            {
                id = null;
            }
            if(nome == "")
            {
                nome = null;
            }
            return lavanderiaDao.pesquisar(id, nome);
        }
    }        
}
