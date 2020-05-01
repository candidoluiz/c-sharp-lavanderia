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
    public partial class CadRoupa : Form
    {
        Roupa roupa;
        RoupaService roupaService = new RoupaService();
        TecidoService tecidoService = new TecidoService();
        TipoService tipoService = new TipoService();
        LavagemService lavagemSerice = new LavagemService();
        Tecido tecido = new Tecido();
        Tipo tipo = new Tipo();
        BindingList<Lavagem> lista = new BindingList<Lavagem>();
        BindingList<RoupaLavagem> listaRL = new BindingList<RoupaLavagem>();
        Lavagem lavagem;
        RoupaLavagem roupaLavagem;

        public CadRoupa(Roupa roupa)
        {
            InitializeComponent();
            this.roupa = roupa;
            this.carregarColecao();
            this.desabilitarExcluir();
            this.carregarCombos();
            this.limparCampos();
            this.carregarCampos();
            this.adicionarDatagrid();

        }

        private void carregarColecao()
        {
            cbColecao.Items.Add(Estacao.primavera);
            cbColecao.Items.Add(Estacao.primaveraVerao);
            cbColecao.Items.Add(Estacao.verao);
            cbColecao.Items.Add(Estacao.outono);
            cbColecao.Items.Add(Estacao.outonoInverno);
            cbColecao.Items.Add(Estacao.inverno);
        }

        private void carregarCampos()
        {
            txtAno.Text = roupa.ano;
            txtModelo.Text = roupa.modelo;
            txtId.Text = Geral.removerZero(roupa.id);
            if(!String.IsNullOrWhiteSpace(roupa.tipo.nome))
                cbTipo.SelectedValue = roupa.tipo.id;
            if (!String.IsNullOrWhiteSpace(roupa.tecido.nome))
                cbTecido.SelectedValue = roupa.tecido.id;
            if (!String.IsNullOrWhiteSpace(roupa.estacao))
                cbColecao.SelectedItem = roupa.estacao;
            if (roupa.lavagens.Count > 0) { }
                lista = new BindingList<Lavagem>(roupa.lavagens);

            //lbProcessoAdicionados.DataSource = lista;


        }

        private void limparCampos()
        {
            txtAno.Text = "";
            txtModelo.Text = "";
            cbColecao.SelectedIndex = -1;
            cbTecido.SelectedIndex = -1;
            cbTipo.SelectedIndex = -1;
        }

        private void carregarCombos()
        {
            cbTecido.DisplayMember = "nome";
            cbTecido.ValueMember = "cod";
            cbTecido.DataSource = tecidoService.pesquisar(null, null);

            cbTipo.DisplayMember = "tipo";
            cbTipo.ValueMember = "cod";
            cbTipo.DataSource = tipoService.pesquisar(null, null);

            cbLavagem.DisplayMember = "processo";
            cbLavagem.ValueMember = "Cod";
            cbLavagem.DataSource = lavagemSerice.pesquisar(null, null);
            /*
            lbProcesso.DisplayMember = "processo";
            lbProcesso.ValueMember = "cod";
            lbProcesso.DataSource = lavagemSerice.pesquisar(null,null);

            lbProcessoAdicionados.DisplayMember = "processo";
            lbProcessoAdicionados.ValueMember = "cod"; */
        }

        private bool validarCampos()
        {
            if (txtAno.Text.Trim().Equals("") ||
                txtModelo.Text.Equals("") ||
                cbColecao.SelectedIndex < 0 ||
                cbTecido.SelectedIndex < 0 ||
                cbTipo.SelectedIndex < 0)
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
            if (roupa.id == 0)
            {
                btnExcluir.Enabled = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                List<Lavagem> listLavagem = lista.ToList();
                tecido.id = int.Parse(cbTecido.SelectedValue.ToString());
                tipo.id = int.Parse(cbTipo.SelectedValue.ToString());
                roupa = new Roupa(roupa.id, tipo, txtAno.Text, txtModelo.Text.ToUpper(), listLavagem, tecido, cbColecao.SelectedItem.ToString());

                if (roupaService.salvar(roupa))
                {
                    MessageBox.Show("Roupa salva com sucesso");
                    this.limparCampos();
                    txtAno.Focus();
                    roupa = new Roupa();
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }         
        }
        /*
        private List<Lavagem> trocarLista()
        {
            Lavagem l;
            List<Lavagem> rls = new List<Lavagem>();

            foreach(RoupaLavagem rl in listaRL)
            {
                l = new Lavagem();
                l = rl.lavagem;
                rls.Add(l);
            }
            return rls;
        }*/

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir o modelo de roupa " + roupa.modelo + " ?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                roupaService.excluir(roupa);
                this.Dispose();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
                lavagem = new Lavagem();
                lavagem = lavagemSerice.consultarId(Int16.Parse(cbLavagem.SelectedValue.ToString()));
                if (verificarRepetido(dataGridView1, roupaLavagem))
                 lista.Add(lavagem);
                this.adicionarDatagrid();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                lista.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                this.adicionarDatagrid();
            }

        }

        private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtAno_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private bool verificarRepetido(DataGridView dgv, RoupaLavagem roupaLavagem)
        {
            bool chave = true;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value.Equals(roupaLavagem.lavagem.processo))
                    chave = false;

            }
            return chave;
        }

        private void adicionarDatagrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Lavagem v in lista)
            {
                dataGridView1.Rows.Add(v.processo);
            }

        }

    }
}
