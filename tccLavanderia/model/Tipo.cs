using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tccLavanderia.model
{
    public class Tipo
    {
        public int id { get; set; }
        public string nome { get; set; }

        public Tipo() { }

        public Tipo(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
    }
}
