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
    public partial class ConLavanderia : Form
    {
        private CadLavanderia cadLavanderia;
        private LavanderiaService lavanderiaService = new LavanderiaService();
        private Lavanderia lavanderia = new Lavanderia();

        public ConLavanderia()
        {
            InitializeComponent();
            
        }

       private void caregarDataGrid()
        {
            dataGridView1.DataSource =lavanderiaService.listarTudo();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lavanderiaService.pesquisar(txtId.Text, txtNome.Text);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            lavanderia = lavanderiaService.consultarId(edit);
            cadLavanderia = new CadLavanderia(lavanderia);
            cadLavanderia.ShowDialog();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadLavanderia = new CadLavanderia(new Lavanderia());
            cadLavanderia.ShowDialog();
        }

        private void ConLavanderia_Load(object sender, EventArgs e)
        {
            caregarDataGrid();
        }

        private void txtSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
