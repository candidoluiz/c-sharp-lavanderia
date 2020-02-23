using System;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.utils;

namespace tccLavanderia.view
{
    public partial class CadLavanderia : Form
    {
        private LavanderiaService lavanderiaService = new LavanderiaService();
        private Lavanderia lavanderia;
        private CidadeService cidadeService = new CidadeService();
        private Cidade cidade;  
        public CadLavanderia(Lavanderia lavanderia)
        {
            InitializeComponent();
            carregarUf();
            this.lavanderia = lavanderia;
            cbUf.SelectedIndex = -1;
            carregarCampos();
            desabilitarExcluir();
            //cbCidade.Enabled = false;
           
           
        }

        private void carregarCampos()
        {
            txtBairro.Text = lavanderia.bairro;
            txtCep.Text = lavanderia.cep;
            txtCnpj.Text = lavanderia.cnpj;
            txtCod.Text = Geral.removerZero(lavanderia.id);
            txtEndereco.Text = lavanderia.endereco;
            txtNome.Text = lavanderia.nome;
            txtNumero.Text = lavanderia.numero;
            if (String.IsNullOrEmpty(lavanderia.cidade.uf))
            {
                carregarUf();
            }
            else
            {
                cbUf.SelectedValue = lavanderia.cidade.uf;
                cbCidade.SelectedValue = lavanderia.cidade.id;
            }
           
        }

        private void desabilitarExcluir()
        {
            if(lavanderia.id == 0)
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
                txtCep.Text.Equals("")|| 
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
       
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            cidade = cidadeService.consultarId(Int16.Parse(cbCidade.SelectedValue.ToString()));
            lavanderia = new Lavanderia(
                lavanderia.id,
                txtNome.Text.ToUpper(),
                txtCnpj.Text.ToUpper(),
                txtEndereco.Text.ToUpper(),
                cidade,
                txtNumero.Text.ToUpper(), 
                txtBairro.Text.ToUpper(),
                txtCep.Text);

            if (this.validarCampos())
            {
                if (this.lavanderiaService.salvar(lavanderia))
                {
                    MessageBox.Show("Lavanderia salva com sucesso");
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
            if (MessageBox.Show("Deseja realmente excluir a lavanderia " + lavanderia.nome + " ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lavanderiaService.excluir(lavanderia);
                this.Dispose();
            }      
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbUf.SelectedIndex < 0 || String.IsNullOrEmpty(cbUf.SelectedValue.ToString()))
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

        private void carregarUf()
        {
            cbUf.DataSource = cidadeService.listarUf();
            cbUf.ValueMember = "uf";
            cbUf.DisplayMember = "uf";
        }
    }
}
