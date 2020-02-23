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

namespace tccLavanderia.view.cadastros
{
    public partial class CadTipo : Form
    {
        Tipo tipo;
        TipoService tipoService = new TipoService();

        public CadTipo(Tipo tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
            desabilitarExcluir();
            caregarCampos();
        }

        private void limparCampos()
        {
            txtNome.Text = "";
        }

        private void caregarCampos()
        {
            txtId.Text = Geral.removerZero(tipo.id);
            txtNome.Text = tipo.nome;
        }

        private void desabilitarExcluir()
        {
            if (tipo.id == 0)
            {
                btnExcluir.Enabled = false;
            }
        }

        private bool validarCampos()
        {
            if (txtNome.Text.Trim().Equals(""))
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
            tipo = new Tipo(tipo.id, txtNome.Text.ToUpper());
            if (validarCampos())
            {
                if (tipoService.salvar(tipo))
                {
                    MessageBox.Show("Tipo de Roupa salvo com sucesso");
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
            if (MessageBox.Show("Deseja realmente excluir o Tipo de Roupa " + tipo.nome + " ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tipoService.excluir(tipo);
                this.Dispose();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
