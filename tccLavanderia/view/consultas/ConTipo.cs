using System;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.view.cadastros;

namespace tccLavanderia.view.consultas
{
    public partial class ConTipo : Form
    {
        private CadTipo cadTipo;
        private Tipo tipo = new Tipo();
        private TipoService tipoService = new TipoService();

        public ConTipo()
        {
            InitializeComponent();
            caregarDataGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadTipo = new CadTipo(new Tipo());
            cadTipo.ShowDialog();
            caregarDataGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            tipo = tipoService.consultarId(edit);
            cadTipo = new CadTipo(tipo);
            cadTipo.ShowDialog();
            caregarDataGrid();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tipoService.pesquisar(txtId.Text, txtNome.Text);
        }

        private void txtSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = tipoService.pesquisar(null, null);
        }
    }
}
