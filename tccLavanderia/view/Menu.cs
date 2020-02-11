using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tccLavanderia.view;
using MySql.Data.MySqlClient;
using tccLavanderia.repository;
using tccLavanderia.model;

namespace tccLavanderia
{
    public partial class Form1 : Form
    {
        ConLavanderia conLavaderia;
        ConFicha conFicha;
        ConRoupa conRoupa;
        ConLavagens conLavagens;
        ConValorLavagens conValorLavagens;
        ConCidade conCidade;
        ConTecido conTecido;

        public Form1()
        {
            InitializeComponent();
        }

        private void lavanderiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conLavaderia = new ConLavanderia();
            conLavaderia.ShowDialog();
        }

        private void btnRoupa_Click(object sender, EventArgs e)
        {
            conRoupa = new ConRoupa();
            conRoupa.ShowDialog();
        }

        private void btnLavagens_Click(object sender, EventArgs e)
        {
            conLavagens = new ConLavagens();
            conLavagens.ShowDialog();
        }

        private void btnValorLavagem_Click(object sender, EventArgs e)
        {
            conValorLavagens = new ConValorLavagens();
            conValorLavagens.ShowDialog();
        }

        private void btnFicha_Click(object sender, EventArgs e)
        {
            conFicha = new ConFicha();
            conFicha.ShowDialog();
        }

        private void btnCidade_Click(object sender, EventArgs e)
        {
            conCidade = new ConCidade();
            conCidade.ShowDialog();
        }

        private void btnTecido_Click(object sender, EventArgs e)
        {
            conTecido = new ConTecido();
            conTecido.ShowDialog();
        }
    }
}
