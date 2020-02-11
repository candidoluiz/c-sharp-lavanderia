using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tccLavanderia.model
{
    public class Cidade
    {     
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        public Cidade() { }

        public Cidade(int id, string nome, string uf)
        {
            this.id = id;
            this.nome = nome;
            this.uf = uf;
        }
    }
}
