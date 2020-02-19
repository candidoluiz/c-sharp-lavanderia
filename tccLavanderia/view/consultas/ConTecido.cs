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
    public partial class ConTecido : Form
    {
        private CadTecido cadTecido;
        private Tecido tecido = new Tecido();
        private TecidoService tecidoService = new TecidoService();

        public ConTecido()
        {
            InitializeComponent();
            caregarDataGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cadTecido = new CadTecido(new Tecido());
            cadTecido.ShowDialog();
            caregarDataGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int edit = Int16.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            tecido = tecidoService.consultarId(edit);
            cadTecido = new CadTecido(tecido);
            cadTecido.ShowDialog();
            caregarDataGrid();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tecidoService.pesquisar(txtCod.Text, txtNome.Text);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void caregarDataGrid()
        {
            dataGridView1.DataSource = tecidoService.pesquisar(null, null);
        }
    }
}
