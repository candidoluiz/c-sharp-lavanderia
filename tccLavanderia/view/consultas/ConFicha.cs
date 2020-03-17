using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.print;
using tccLavanderia.service;

namespace tccLavanderia.view
{
    public partial class ConFicha : Form
    {
        private CadFicha cadFicha;
        private Ficha ficha = new Ficha();
        private FichaService fichaService = new FichaService();
        private DateTime date = DateTime.Now;
        private PrintFichaView printFichaView;

        public ConFicha()
        {
            InitializeComponent();            
            dtpInicio.Value = new DateTime(date.Year, date.Month, 1);
            this.caregarDataGrid();
            this.carregarCombo();
        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = fichaService.pesquisar(null, null, null, dtpInicio.Value, dtpFim.Value);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadFicha = new CadFicha(new Ficha());
            cadFicha.ShowDialog();
            this.caregarDataGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            ficha = fichaService.consultarId(edit);
            cadFicha = new CadFicha(ficha);
            cadFicha.ShowDialog();
            this.caregarDataGrid();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fichaService.pesquisar(txtCodigo.Text, txtModelo.Text, null, dtpInicio.Value, dtpFim.Value);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataSetRelatorio dt = fichaService.imprimirFicha(dataGridView1);
            printFichaView = new PrintFichaView(dt);
            printFichaView.ShowDialog();           
        }
        private void carregarCombo()
        {
            cbLavanderia.ValueMember = "Cod";
            cbLavanderia.DisplayMember = "nome";
            cbLavanderia.DataSource = fichaService.carregarCombo();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
    }
}
