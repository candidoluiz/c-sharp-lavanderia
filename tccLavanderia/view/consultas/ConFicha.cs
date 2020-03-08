using System;
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
        DateTime date = DateTime.Now;

        public ConFicha()
        {
            InitializeComponent();
            this.caregarDataGrid();
            dtpInicio.Value = new DateTime(date.Year, date.Month, 1);
        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = fichaService.pesquisar(null, null, null, dtpInicio.Value, dtpFim.Value);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadFicha = new CadFicha(new Ficha());
            cadFicha.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            ficha = fichaService.consultarId(edit);
            cadFicha = new CadFicha(ficha);
            cadFicha.ShowDialog();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fichaService.pesquisar(txtCodigo.Text, txtModelo.Text, null, dtpInicio.Value, dtpFim.Value);
        }
    }
}
