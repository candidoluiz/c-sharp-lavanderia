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
    public partial class ConLavagens : Form
    {
        private CadLavagens cadLavagem;
        private LavagemService lavagemService;
        private Lavagem lavagem = new Lavagem();

        public ConLavagens()
        {
            InitializeComponent();
            caregarDataGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadLavagem = new CadLavagens(new Lavagem());
            cadLavagem.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            lavagem = lavagemService.consultarId(edit);
            cadLavagem = new CadLavagens(cadLavagem);
            cadLavagem.ShowDialog();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lavagemService.pesquisar(txtProcesso.Text);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = lavagemService.pesquisar(null);
        }
    }
}
