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
    public partial class ConRoupa : Form
    {
        private CadRoupa cadRoupa;
        private Roupa roupa = new Roupa();
        public ConRoupa()
        {
            InitializeComponent();
            carregarColecao();
            this.Size = new Size(Geral.largura(),Geral.altura());
        }

        private void carregarColecao()
        {
            cbColecao.Items.Add(Estacao.vazio);
            cbColecao.Items.Add(Estacao.primavera);
            cbColecao.Items.Add(Estacao.primaveraVerao);
            cbColecao.Items.Add(Estacao.verao);
            cbColecao.Items.Add(Estacao.outono);
            cbColecao.Items.Add(Estacao.outonoInverno);
            cbColecao.Items.Add(Estacao.inverno);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadRoupa = new CadRoupa(new Roupa());
            cadRoupa.ShowDialog();
        }
    }
}
