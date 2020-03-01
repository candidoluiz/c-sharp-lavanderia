using System;

namespace tccLavanderia.model
{
    public class Ficha
    {
        public int id { get; set; }
        public Lavanderia lavanderia { get; set; }
        public DateTime entrada { get; set; }
        public Roupa roupa { get; set; }
        public int quantidade { get; set; }
        public Empresa empresa { get; set; }

        public Ficha()
        {
            roupa = new Roupa();
            lavanderia = new Lavanderia();
            empresa = new Empresa();
        }

    }

}
