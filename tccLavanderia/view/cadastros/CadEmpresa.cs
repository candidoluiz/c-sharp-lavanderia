using System;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.utils;

namespace tccLavanderia.view.cadastros
{
    public partial class CadEmpresa : Form
    {
        private EmpresaService empresaService = new EmpresaService();
        private Empresa empresa;
        private CidadeService cidadeService = new CidadeService();
        private Cidade cidade;

        public CadEmpresa(Empresa empresa)
        {
            InitializeComponent();
            carregarUf();
            this.empresa = empresa;
            cbUf.SelectedIndex = -1;
            carregarCampos();
            desabilitarExcluir();
        }

        private void carregarCampos()
        {
            txtBairro.Text = empresa.bairro;
            txtCep.Text = empresa.cep;
            txtCnpj.Text = empresa.cnpj;
            txtCod.Text = Geral.removerZero(empresa.id);
            txtEndereco.Text = empresa.endereco;
            txtNome.Text = empresa.nome;
            txtNumero.Text = empresa.numero;
            if (String.IsNullOrEmpty(empresa.cidade.uf))
            {
                carregarUf();
            }
            else
            {
                cbUf.SelectedValue = empresa.cidade.uf;
                cbCidade.SelectedValue = empresa.cidade.id;
            }

        }

        private void desabilitarExcluir()
        {
            if (empresa.id == 0)
            {
                btnExcluir.Enabled = false;
            }
        }

        private void limparCampos()
        {
            txtBairro.Text = "";
            txtCep.Text = "";
            txtCnpj.Text = "";
            txtCod.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
            txtNumero.Text = "";
        }

        private bool validarCampos()
        {
            if (txtBairro.Text.Trim().Equals("") ||
                txtCep.Text.Equals("") ||
                txtCnpj.Text.Trim().Equals("") ||
                txtEndereco.Text.Trim().Equals("") ||
                txtNome.Text.Trim().Equals("") ||
                txtNumero.Text.Trim().Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void carregarUf()
        {
            cbUf.DataSource = cidadeService.listarUf();
            cbUf.ValueMember = "uf";
            cbUf.DisplayMember = "uf";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (this.validarCampos())
            {
                cidade = cidadeService.consultarId(Int16.Parse(cbCidade.SelectedValue.ToString()));
                empresa = new Empresa(
                    empresa.id,
                    txtNome.Text.ToUpper(),
                    txtCnpj.Text.ToUpper(),
                    txtEndereco.Text.ToUpper(),
                    cidade,
                    txtNumero.Text.ToUpper(),
                    txtBairro.Text.ToUpper(),
                    txtCep.Text);
                if (this.empresaService.salvar(empresa))
                {
                    MessageBox.Show("Empresa salva com sucesso");
                    this.limparCampos();
                    txtNome.Focus();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUf.SelectedIndex < 0 || String.IsNullOrEmpty(cbUf.SelectedValue.ToString()))
            {
                cbCidade.Enabled = false;
            }
            else
            {
                cbCidade.Enabled = true;
                cbCidade.DataSource = cidadeService.listarCidadePorUf(cbUf.SelectedValue.ToString());
                cbCidade.ValueMember = "id";
                cbCidade.DisplayMember = "nome";

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir a empresa " + empresa.nome + " ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                empresaService.excluir(empresa);
                this.Dispose();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
