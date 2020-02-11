using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tccLavanderia.model
{
   public class Roupa
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string ano { get; set; }
        public string referencia { get; set; }
        public List<Lavagem> lavagens { get; set; }
        public Tecido tecido { get; set; }
        public Estacao estacoes { get; set; }

        public Roupa()
        {
            tecido = new Tecido();
        }

    }
}
