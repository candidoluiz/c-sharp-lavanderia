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
    public partial class CadCidade : Form
    {
        private Cidade cidade;
        CidadeService cidadeService = new CidadeService();

        public CadCidade(Cidade cidade)
        {
            InitializeComponent();
            this.cidade = cidade;
            desabilitarExcluir();
            caregarCampos();
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtUf.Text = "";
        }

        private void caregarCampos()
        {
            txtCod.Text = Geral.removerZero(cidade.id);
            txtNome.Text = cidade.nome;
            txtUf.Text = cidade.uf;
        }

        private void desabilitarExcluir()
        {
            if (cidade.id == 0)
            {
                btnExcluir.Enabled = false;
            }
        }

        private bool validarCampos()
        {
            if (txtUf.Text.Trim().Equals("") || txtNome.Text.Trim().Equals(""))
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
            cidade = new Cidade(cidade.id, txtNome.Text.ToUpper(), txtUf.Text.ToUpper());
            if (validarCampos())
            {
                if (cidadeService.salvar(cidade))
                {
                    MessageBox.Show("Cidade salva com sucesso");
                    this.limparCampos();
                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }         
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja realmente excluir a cidade " + cidade.nome + " ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cidadeService.excluir(cidade);
                this.Dispose();
            }        
        }
    }
}
