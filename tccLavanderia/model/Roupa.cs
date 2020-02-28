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
        public Tipo tipo { get; set; }
        public string ano { get; set; }
        public string modelo { get; set; }
        public List<Lavagem> lavagens { get; set; }
        public Tecido tecido { get; set; }
        public string estacao { get; set; }

        public Roupa()
        {
            tecido = new Tecido();
            tipo = new Tipo();
            lavagens = new List<Lavagem>();
        }

        public Roupa(int id, Tipo tipo, string ano, string modelo, List<Lavagem> lavagens, Tecido tecido, string estacao)
        {
            this.id = id;
            this.tipo = tipo;
            this.ano = ano;
            this.modelo = modelo;
            this.lavagens = lavagens;
            this.tecido = tecido;
            this.estacao = estacao;
        }

    }
}
