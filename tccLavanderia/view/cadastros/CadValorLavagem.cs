using System;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.utils;

namespace tccLavanderia.view.cadastros
{
    public partial class CadValorLavagem : Form
    {
        private LavanderiaService lavanderiaService = new LavanderiaService();
        private LavagemService lavagemService = new LavagemService();
        private ValorLavagemService valorLavagemService = new ValorLavagemService();
        private Lavanderia lavanderia = new Lavanderia();
        private Lavagem lavagem = new Lavagem();
        private ValorLavagem valorLavagem;

        

        public CadValorLavagem(ValorLavagem valorLavagem)
        {
            InitializeComponent();
            this.valorLavagem = valorLavagem;
            desabilitarExcluir();
            this.carregarCombos();
            this.limparCampos();
            carregarCampos();
        }

        private void carregarCampos()
        {
            txtValor.Text = valorLavagem.valor.ToString();
            txtCod.Text = Geral.removerZero(valorLavagem.id);                                             
            if (!String.IsNullOrWhiteSpace(valorLavagem.lavagem.processo))
                cbLavagem.SelectedValue = valorLavagem.lavagem.id;
            if (!String.IsNullOrWhiteSpace(valorLavagem.lavanderia.nome))
                cbLavanderia.SelectedValue = valorLavagem.lavanderia.id;
        }

        private void carregarCombos()
        {
            cbLavagem.ValueMember = "cod";
            cbLavagem.DisplayMember = "processo";
            cbLavagem.DataSource = lavagemService.pesquisar(null, null);

            cbLavanderia.ValueMember = "cod";
            cbLavanderia.DisplayMember = "nome";
            cbLavanderia.DataSource = lavanderiaService.pesquisar(null, null);
        }

        private void desabilitarExcluir()
        {
            btnExcluir.Enabled = valorLavagem.id == 0 ? false : true;
        }

        private void btnExcluir_Click(object sender, System.EventArgs e)
        {

            if (MessageBox.Show("Deseja realmente excluir o valor da lavagem " + valorLavagem.lavagem.processo + " ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                valorLavagemService.excluir(valorLavagem);
                this.Dispose();
            }
        }

        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtValor.Text) || 
                cbLavanderia.SelectedIndex < 0 || cbLavagem.SelectedIndex < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limparCampos()
        {

            txtValor.Text = "";
            cbLavanderia.SelectedIndex = -1;
            cbLavagem.SelectedIndex = -1;
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            if (this.validarCampos())
            {
                lavanderia.id = int.Parse(cbLavanderia.SelectedValue.ToString());
                lavagem.id = int.Parse(cbLavagem.SelectedValue.ToString());
                valorLavagem = new ValorLavagem(
                valorLavagem.id,
                lavanderia,
                lavagem,
                double.Parse(txtValor.Text));

                if (this.valorLavagemService.salvar(valorLavagem))
                {
                    MessageBox.Show("Valor da lavagem salvo com sucesso", "Valor salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.limparCampos();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
