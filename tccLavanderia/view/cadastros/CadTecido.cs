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
using tccLavanderia.utils;

namespace tccLavanderia.view
{
    public partial class CadTecido : Form
    {
        private Tecido tecido;
        TecidoService tecidoService = new TecidoService();

        public CadTecido(Tecido tecido)
        {
            InitializeComponent();
            this.tecido = tecido;
            desabilitarExcluir();
            caregarCampos();
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtComposicao.Text = "";
        }

        private void caregarCampos()
        {
            txtId.Text = Geral.removerZero(tecido.id);
            txtNome.Text = tecido.nome;
            txtComposicao.Text = tecido.composicao;
        }

        private void desabilitarExcluir()
        {
            if (tecido.id == 0)
            {
                btnExcluir.Enabled = false;
            }
        }

        private bool validarCampos()
        {
            if (txtNome.Text.Trim().Equals("") || txtComposicao.Text.Trim().Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            tecido = new Tecido(tecido.id, txtNome.Text.ToUpper(), txtComposicao.Text.ToUpper());
            if (validarCampos())
            {
                if (tecidoService.salvar(tecido))
                {
                    MessageBox.Show("Tecido salvo com sucesso");
                    this.limparCampos();
                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o tecido " + tecido.nome + " ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tecidoService.excluir(tecido);
                this.Dispose();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
