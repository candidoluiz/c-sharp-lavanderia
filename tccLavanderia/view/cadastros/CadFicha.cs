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
using tccLavanderia.utils;

namespace tccLavanderia.view
{
    public partial class CadFicha : Form
    {
        Ficha ficha;
        public CadFicha(Ficha ficha)
        {
            InitializeComponent();
            this.ficha = ficha;
            carregarCampos();

        }
        private void carregarCampos()
        {
            txtId.Text = Geral.removerZero(ficha.id);
            txtComposicao.Text = ficha.roupa.tecido.composicao;
            txtLavanderia.Text = ficha.lavanderia.nome;
            txtTecido.Text = ficha.roupa.tecido.nome;
            txtTipo.Text = ficha.roupa.tipo;
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}
