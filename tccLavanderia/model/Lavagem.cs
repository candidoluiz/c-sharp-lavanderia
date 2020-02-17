using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tccLavanderia.model
{
    public class Lavagem
    {
        public int id { get; set; }
        public string processo { get; set; }

        public Lavagem() { }

        public Lavagem(int id, string processo)
        {
            this.id = id;
            this.processo = processo;
        }
    }
}
