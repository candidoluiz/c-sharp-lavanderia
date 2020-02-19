using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tccLavanderia.model
{
   public class Tecido
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string composicao { get; set; }

       public Tecido() { }

        public Tecido(int id, string nome, string composicao)
        {
            this.id = id;
            this.nome = nome;
            this.composicao = composicao;
        }
    }
}
