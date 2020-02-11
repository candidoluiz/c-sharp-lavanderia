using System;

namespace tccLavanderia.model
{
    public class Ficha
    {
        public int id { get; set; }
        public Lavanderia lavanderia { get; set; }
        public DateTime data { get; set; }
        public Roupa roupa { get; set; }

        public Ficha()
        {
            roupa = new Roupa();
            lavanderia = new Lavanderia();
        }

    }

}
