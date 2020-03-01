﻿using System;
using System.Windows.Forms;
using tccLavanderia.model;
using tccLavanderia.service;
using tccLavanderia.utils;

namespace tccLavanderia.view
{
    public partial class CadFicha : Form
    {
        Ficha ficha;
        LavanderiaService lavanderiaService = new LavanderiaService();
        EmpresaService empresaService = new EmpresaService();
        RoupaService roupaService = new RoupaService();
        Lavanderia lavanderia = new Lavanderia();
        Empresa empresa = new Empresa();
        Roupa roupa = new Roupa();

        public CadFicha(Ficha ficha)
        {
            InitializeComponent();
            this.ficha = ficha;
            carregarCampos();
            carregarCombos();
            desabilitarExcluir();

        }
        private void carregarCampos()
        {
            txtId.Text = Geral.removerZero(ficha.id);
            txtComposicao.Text = ficha.roupa.tecido.composicao;
            txtLavanderia.Text = ficha.lavanderia.nome;
            txtTecido.Text = ficha.roupa.tecido.nome;
        }

        private void carregarCombos()
        {
            cbLavanderia.DisplayMember = "nome";
            cbLavanderia.ValueMember = "cod";

            cbEmpresa.DisplayMember = "nome";
            cbEmpresa.ValueMember = "cod";

            cbLavanderia.DataSource = lavanderiaService.pesquisar(null, null);
            cbEmpresa.DataSource = empresaService.pesquisar(null, null);
        }

        private void desabilitarExcluir()
        {
            btnExcluir.Enabled = ficha.id == 0 ? false : true;
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            lavanderia.id = int.Parse(cbLavanderia.SelectedValue.ToString());
            empresa.id = int.Parse(cbEmpresa.SelectedValue.ToString());
            roupa = null;
            ficha = new Ficha(ficha.id,lavanderia,dtpData.Value,roupa,int.Parse(txtQuantidade.Text),empresa);
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
