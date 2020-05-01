using System;
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

        public static void monetario(ref TextBox txtValor)
        {
            string numero = string.Empty;
            double valor = 0;

            try
            {
                numero = txtValor.Text.Replace(",", "").Replace(".", "");
                if (numero.Equals(""))
                    numero = "";

                numero = numero.PadLeft(3, '0');

                if (numero.Length > 3 & numero.Substring(0, 1) == "0")
                    numero = numero.Substring(1, numero.Length - 1);
                valor = Convert.ToDouble(numero) / 100;
                txtValor.Text = string.Format("{0:N}", valor);
                txtValor.SelectionStart = txtValor.Text.Length;
            }
            catch (Exception) { };
        }
    }
}
