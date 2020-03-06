namespace tccLavanderia.model
{
    public class ValorLavagem
    {
        public int id { get; set; }
        public Lavanderia lavanderia { get; set; }
        public Lavagem lavagem { get; set; }
        public double valor { get; set; }

        public ValorLavagem()
        {
            new Lavanderia();
            new Lavagem();
        }

        public ValorLavagem(int id, Lavanderia lavanderia, Lavagem lavagem, double valor )
        {
            this.id = id;
            this.lavanderia = lavanderia;
            this.lavagem = lavagem;
            this.valor = valor;
        }
    }


}
