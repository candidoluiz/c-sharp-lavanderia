using System.Windows.Forms;

namespace tccLavanderia.utils
{
    class Geral
    {
        public static string removerZero(long id)
        {
            if (id < 1)
                return null;
            else
                return id.ToString();
        }
      
        public static void digitarSoNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
