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
using tccLavanderia.view.cadastros;

namespace tccLavanderia.view.consultas
{
    public partial class ConEmpresa : Form
    {
        private CadEmpresa cadEmpresa;
        private EmpresaService empresaService = new EmpresaService();
        private Empresa empresa = new Empresa();

        public ConEmpresa()
        {
            InitializeComponent();
            this.caregarDataGrid();
        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = empresaService.pesquisar(null, null);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadEmpresa = new CadEmpresa(new Empresa());
            cadEmpresa.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            empresa = empresaService.consultarId(edit);
            cadEmpresa = new CadEmpresa(empresa);
            cadEmpresa.ShowDialog();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = empresaService.pesquisar(txtId.Text, txtNome.Text);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
