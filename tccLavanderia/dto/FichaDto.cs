namespace tccLavanderia.dto
{
    public class FichaDto
    {        
        public int id { get; set; }
        public string modelo { get; set; }
        public string tipo { get; set; }
        public string cidade { get; set; }
        public string lavanderia { get; set; }
        public string data { get; set; }
        public string quantidade { get; set; }
        public string empresa { get; set; }
        public string valorUnitario { get; set; }
        public string valorTotal { get; set; }
        public string lavagens { get; set; }
        public string empresaCnpj { get; set; }
        public string lavanderiaCnpj { get; set; }

        public FichaDto()
        {
        }
       
    }
}
