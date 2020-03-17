using System;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.view.cadastros;

namespace tccLavanderia.view
{
    public partial class ConValorLavagens : Form
    {
        private CadValorLavagem cadValorLavagem;
        private ValorLavagemService valorLavagemService = new ValorLavagemService();
        private ValorLavagem valorLavagem = new ValorLavagem();

        public ConValorLavagens()
        {
            InitializeComponent();
            caregarDataGrid();
            consultarLavanderia();
            cbLavanderia.SelectedValue = -1;
        }

        private void consultarLavanderia()
        {
            cbLavanderia.ValueMember = "nome";
            cbLavanderia.DisplayMember = "nome";
            cbLavanderia.DataSource = valorLavagemService.consultarLavanderia();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadValorLavagem = new CadValorLavagem(new ValorLavagem());
            cadValorLavagem.ShowDialog();
            this.caregarDataGrid();
        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = valorLavagemService.pesquisar(null, null);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            valorLavagem = valorLavagemService.consultarId(edit);
            cadValorLavagem = new CadValorLavagem(valorLavagem);
            cadValorLavagem.ShowDialog();
            this.caregarDataGrid();
        }

        private void txtSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string valor = cbLavanderia.SelectedIndex == -1 ? null : cbLavanderia.SelectedValue.ToString();
            dataGridView1.DataSource = valorLavagemService.pesquisar(valor, txtLavagem.Text);
        }
    }
}
