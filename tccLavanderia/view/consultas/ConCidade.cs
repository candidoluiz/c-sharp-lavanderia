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
    public partial class ConCidade : Form
    {
        private CadCidade cadCidade;
        private Cidade cidade = new Cidade();
        private CidadeService cidadeService = new CidadeService();
        public ConCidade()
        {
            InitializeComponent();
            caregarDataGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadCidade = new CadCidade(new Cidade());
            cadCidade.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            cidade = cidadeService.consultarId(edit);
            cadCidade = new CadCidade(cidade);
            cadCidade.ShowDialog();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cidadeService.pesquisar(txtNome.Text);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = cidadeService.pesquisar(null);
        }
    }
}
