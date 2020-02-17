using System;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.utils;

namespace tccLavanderia.view
{
    public partial class CadLavagens : Form
    {
        private Lavagem lavagem;
        private LavagemService lavagemService = new LavagemService();

        public CadLavagens(Lavagem lavagem)
        {
            InitializeComponent();
            this.lavagem = lavagem;
            desabilitarExcluir();
            caregarCampos();
        }

        private void limparCampos()
        {
            txtProcesso.Text = "";
        }

        private void caregarCampos()
        {
            txtCod.Text = Geral.removerZero(lavagem.id);
            txtProcesso.Text = lavagem.processo;
        }

        private void desabilitarExcluir()
        {
            if (lavagem.id == 0)
            {
                btnExcluir.Enabled = false;
            }
        }

        private bool validarCampos()
        {
            if (txtProcesso.Text.Trim().Equals(""))
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
            lavagem = new Lavagem(lavagem.id, txtProcesso.Text.ToUpper());
            if (validarCampos())
            {
                if (lavagemService.salvar(lavagem))
                {
                    MessageBox.Show("Lavagem salva com sucesso");
                    this.limparCampos();
                    txtProcesso.Focus();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir a lavagem " + lavagem.processo + " ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lavagemService.excluir(lavagem);
                this.Dispose();
            }
        }
    }
}
