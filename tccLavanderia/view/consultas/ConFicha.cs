using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;

namespace tccLavanderia.view
{
    public partial class ConFicha : Form
    {
        private CadFicha cadFicha;
        private Ficha ficha = new Ficha();
        private FichaService fichaService = new FichaService();

        public ConFicha()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadFicha = new CadFicha(new Ficha());
            cadFicha.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ficha = fichaService.consultarId();
            cadFicha = new CadFicha(ficha);
            cadFicha.ShowDialog();
        }
    }
}
