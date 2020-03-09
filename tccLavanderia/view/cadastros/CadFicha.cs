using System;
using System.Globalization;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.utils;

namespace tccLavanderia.view
{
    public partial class CadFicha : Form
    {
        Ficha ficha;
        FichaService fichaService = new FichaService();
        ValorLavagemService valorLavagemService = new ValorLavagemService();
        LavanderiaService lavanderiaService = new LavanderiaService();
        EmpresaService empresaService = new EmpresaService();
        RoupaService roupaService = new RoupaService();
        Lavanderia lavanderia = new Lavanderia();
        Empresa empresa = new Empresa();
        Roupa roupa = new Roupa();

        public CadFicha(Ficha ficha)
        {
            InitializeComponent();
            carregarCombos();
            this.ficha = ficha;
            desabilitarExcluir();
            limparCampos();
            carregarCampos();           
        }
        private void carregarCampos()
        {
            txtId.Text = Geral.removerZero(ficha.id);
            txtQuantidade.Text = ficha.quantidade.ToString();
            txtComposicao.Text = ficha.roupa.tecido.composicao;
            txtTecido.Text = ficha.roupa.tecido.nome;
            txtTipo.Text = ficha.roupa.tipo.nome;
            txtAno.Text = ficha.roupa.ano;
            txtColecao.Text = ficha.roupa.estacao;
            txtModelo.Text = ficha.roupa.modelo;
            if(!String.IsNullOrWhiteSpace(ficha.lavanderia.nome))
                cbLavanderia.SelectedValue = ficha.lavanderia.id;
            if(!String.IsNullOrWhiteSpace(ficha.empresa.nome))
                cbEmpresa.SelectedValue = ficha.empresa.id;
            if (!String.IsNullOrWhiteSpace(ficha.roupa.modelo))
                this.carregarCamposInformacao();           
        }

        private void carregarCombos()
        {
            cbLavanderia.DisplayMember = "nome";
            cbLavanderia.ValueMember = "cod";

            cbEmpresa.DisplayMember = "nome";
            cbEmpresa.ValueMember = "cod";

            cbLavanderia.DataSource = lavanderiaService.pesquisar(null, null);
            cbEmpresa.DataSource = empresaService.pesquisar(null, null);
            cbEmpresa.SelectedIndex = -1;
            cbLavanderia.SelectedIndex = -1;
        }

        private bool validarCampos()
        {
            if (txtModelo.Text.Trim().Equals("") ||
                txtQuantidade.Text.Equals("") ||
                cbEmpresa.SelectedIndex < 0 ||
                cbLavanderia.SelectedIndex < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void desabilitarExcluir()
        {
            btnExcluir.Enabled = ficha.id == 0 ? false : true;
        }

        private void limparCampos()
        {
            txtModelo.Text = "";
            txtQuantidade.Text = "";
            txtTecido.Text = "";
            txtTipo.Text = "";
            txtAno.Text = "";
            txtColecao.Text = "";
            txtComposicao.Text = "";
            lblTotal.Text = "-";
            lbLavagen.Items.Clear();
            cbEmpresa.SelectedIndex = -1;
            cbLavanderia.SelectedIndex = -1;
            roupa = new Roupa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                lavanderia.id = int.Parse(cbLavanderia.SelectedValue.ToString());
                empresa.id = int.Parse(cbEmpresa.SelectedValue.ToString());
                try
                {
                    roupa = roupaService.consultarId(null, txtModelo.Text);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ficha = new Ficha(ficha.id, lavanderia, dtpData.Value, roupa, int.Parse(txtQuantidade.Text), empresa);
                if (fichaService.salvar(ficha))
                {
                    MessageBox.Show("Ficha salva com sucesso");
                    this.limparCampos();
                    ficha = new Ficha();
                    txtModelo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            Geral.digitarSoNumeros(e);           
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
           
        }

        private void txtModelo_Leave(object sender, EventArgs e)
        {
            try
            {
                lbLavagen.Items.Clear();                
                this.carregarCamposInformacao();                                    
                txtTecido.Text = roupa.tecido.nome;
                txtTipo.Text = roupa.tipo.nome;
                txtAno.Text = roupa.ano;
                txtComposicao.Text = roupa.tecido.composicao;
                txtColecao.Text = roupa.estacao;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelo.Focus();
            }
           
        }

        private void cbLavanderia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtModelo.Text != "" )
            {
                try
                {
                    if(cbLavanderia.SelectedIndex != -1)
                        lblTotal.Text = valorLavagemService.valor(txtModelo.Text, cbLavanderia.SelectedValue.ToString(), txtQuantidade.Text).ToString("C", CultureInfo.CurrentCulture);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbLavanderia.SelectedIndex = -1;
                    cbLavanderia.Focus();
                }
                
            }
           
        }

        private void carregarCamposInformacao()
        {
            roupa = roupaService.consultarId(null, txtModelo.Text);
            foreach (Lavagem r in roupa.lavagens)
                lbLavagen.Items.Add(r.processo);
            lbLavagen.EndUpdate();
        }

    }
}
