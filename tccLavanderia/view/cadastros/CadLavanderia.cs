using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        private LavagemService lavagemService = new LavagemService();
        private BindingList<ValorLavagem> lista = new BindingList<ValorLavagem>();
        private ValorLavagem valorLavagem;

        public CadLavanderia(Lavanderia lavanderia)
        {
            InitializeComponent();
            carregarUf();
            this.lavanderia = lavanderia;
            cbUf.SelectedIndex = -1;
            carregarCampos();
            desabilitarExcluir();
            this.carregarCombos();
            //cbCidade.Enabled = false;      
            this.adicionarDatagrid();  
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
            if (this.lavanderia.valorLavagens.Count > 0)
                lista = new BindingList<ValorLavagem>( this.lavanderia.valorLavagens);
           
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
            List<ValorLavagem> valorLavagens = lista.ToList();
            lavanderia = new Lavanderia(
                lavanderia.id,
                txtNome.Text.ToUpper(),
                txtCnpj.Text.ToUpper(),
                txtEndereco.Text.ToUpper(),
                cidade,
                txtNumero.Text.ToUpper(), 
                txtBairro.Text.ToUpper(),
                txtCep.Text,
                valorLavagens);

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

        private void carregarCombos()
        {
            cbLavagem.ValueMember = "Cod";
            cbLavagem.DisplayMember = "processo";
            cbLavagem.DataSource = lavagemService.pesquisar(null, null);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtValor.Text) || Double.Parse(txtValor.Text) == 0)
            {
                MessageBox.Show("Insira o valor da lavagem", "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                valorLavagem = new ValorLavagem();
                valorLavagem.lavagem = lavagemService.consultarId(Int16.Parse(cbLavagem.SelectedValue.ToString()));
                valorLavagem.valor = Double.Parse(txtValor.Text);
                if(verificarRepetido(dataGridView1, valorLavagem))
                    lista.Add(valorLavagem);
                this.adicionarDatagrid();
            }
        }

        private void adicionarDatagrid()
        {
            dataGridView1.Rows.Clear();
            foreach(ValorLavagem v in lista)
            {
                    dataGridView1.Rows.Add(v.lavagem.processo,v.valor.ToString("F"));
            }
           
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

            if(dataGridView1.Rows.Count > 0)
            {
                lista.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                this.adicionarDatagrid();
            }
           
        }

        private bool verificarRepetido(DataGridView dgv, ValorLavagem valor)
        {
            bool chave = true;

            foreach(DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value.Equals(valor.lavagem.processo))
                    chave = false;
                   
            }
            return chave;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Geral.monetario(ref txtValor);
        }
    }
}
