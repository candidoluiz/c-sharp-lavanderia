using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static int altura()
        {
            return 700;
        }

        public static int largura()
        {
            return 1280;
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
