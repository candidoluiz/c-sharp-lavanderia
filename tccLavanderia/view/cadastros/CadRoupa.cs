using System;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.utils;

namespace tccLavanderia.view
{
    public partial class CadRoupa : Form
    {
        Roupa roupa;
        RoupaService roupaService = new RoupaService();
        TecidoService tecidoService = new TecidoService();
        Tecido tecido;

        public CadRoupa(Roupa roupa)
        {
            InitializeComponent();
            this.roupa = roupa;
            this.carregarColecao();
            this.desabilitarExcluir();
            carregarTecido();
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

        private void carregarCampos()
        {
            txtAno.Text = roupa.ano;
            txtModelo.Text = roupa.modelo;
            //txtTipo.Text = roupa.tipo;
            txtId.Text = Geral.removerZero(roupa.id);

        }

        private void carregarTecido()
        {
            cbTecido.DisplayMember = "nome";
            cbTecido.ValueMember = "cod";
            cbTecido.DataSource = tecidoService.pesquisar(null, null);
        }

        private void desabilitarExcluir()
        {
            if (roupa.id == 0)
            {
                btnExcluir.Enabled = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            tecido = tecidoService.consultarId(Int16.Parse(cbTecido.SelectedValue.ToString()));
            roupa = new Roupa(roupa.id, null, txtAno.Text, txtModelo.Text, null, tecido, cbColecao.SelectedItem.ToString());

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }
    }
}
