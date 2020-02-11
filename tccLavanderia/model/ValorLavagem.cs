using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tccLavanderia.model
{
    public class ValorLavagem
    {
        public int id { get; set; }
        public Lavanderia lavanderia { get; set; }
        public Lavagem lavagem { get; set; }
        public double valor { get; set; }
    }
}
