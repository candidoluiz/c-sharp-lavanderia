using System;
using System.Drawing;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.utils;

namespace tccLavanderia.view
{
    public partial class ConRoupa : Form
    {
        private CadRoupa cadRoupa;
        private Roupa roupa = new Roupa();
        TipoService tipoService = new TipoService();
        RoupaService roupaService = new RoupaService();
        public ConRoupa()
        {
            InitializeComponent();
            carregarCombo();
            caregarDataGrid();
            this.Size = new Size(Geral.largura(),Geral.altura());
        }

        private void carregarCombo()
        {
            cbColecao.Items.Add(Estacao.nada);
            cbColecao.Items.Add(Estacao.primavera);
            cbColecao.Items.Add(Estacao.primaveraVerao);
            cbColecao.Items.Add(Estacao.verao);
            cbColecao.Items.Add(Estacao.outono);
            cbColecao.Items.Add(Estacao.outonoInverno);
            cbColecao.Items.Add(Estacao.inverno);

            cbTipo.DisplayMember = "tipo";
            cbTipo.ValueMember = "cod";
            cbTipo.DataSource = tipoService.pesquisar(null, null);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadRoupa = new CadRoupa(new Roupa());
            cadRoupa.ShowDialog();
        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = roupaService.pesquisar(null,null,null,null);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = roupaService.pesquisar(txtModelo.Text.ToUpper(), cbTipo.Text, txtAno.Text, cbColecao.SelectedItem != null ? cbColecao.SelectedItem.ToString() : "");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string edit = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            roupa = roupaService.consultarId(edit, null);
            cadRoupa = new CadRoupa(roupa);
            cadRoupa.ShowDialog();
            caregarDataGrid();
        }
    }
}
