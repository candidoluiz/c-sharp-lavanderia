using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tccLavanderia.model
{
    public class Lavanderia
    {
      
        public int id { get; set; }
        public string nome { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public Cidade cidade { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }

        public Lavanderia(int id, string nome, string cnpj, string endereco, Cidade cidade, string numero, string bairro, string cep)
        {
            this.id = id;
            this.nome = nome;
            this.cnpj = cnpj;
            this.endereco = endereco;
            this.cidade = cidade;
            this.numero = numero;
            this.bairro = bairro;
            this.cep = cep;
        }

        public Lavanderia()
        {
            cidade = new Cidade();
        }

    }
}
