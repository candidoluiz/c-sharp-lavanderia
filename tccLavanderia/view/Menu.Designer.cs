

namespace tccLavanderia
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {                        
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFicha = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnRoupa = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLavagens = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLavanderia = new System.Windows.Forms.ToolStripMenuItem();
            this.btnValorLavagem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCidade = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTecido = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTipoRoupa = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFicha,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFicha
            // 
            this.btnFicha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFicha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnFicha.Image = ((System.Drawing.Image)(resources.GetObject("btnFicha.Image")));
            this.btnFicha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFicha.Name = "btnFicha";
            this.btnFicha.Size = new System.Drawing.Size(44, 23);
            this.btnFicha.Text = "Ficha";
            this.btnFicha.Click += new System.EventHandler(this.btnFicha_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRoupa,
            this.btnLavagens,
            this.btnLavanderia,
            this.btnValorLavagem,
            this.btnCidade,
            this.btnTecido,
            this.btnTipoRoupa,
            this.btnEmpresa});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(83, 23);
            this.toolStripDropDownButton1.Text = "Cadastros";
            // 
            // btnRoupa
            // 
            this.btnRoupa.Name = "btnRoupa";
            this.btnRoupa.Size = new System.Drawing.Size(202, 24);
            this.btnRoupa.Text = "Roupas";
            this.btnRoupa.Click += new System.EventHandler(this.btnRoupa_Click);
            // 
            // btnLavagens
            // 
            this.btnLavagens.Name = "btnLavagens";
            this.btnLavagens.Size = new System.Drawing.Size(202, 24);
            this.btnLavagens.Text = "Lavagens";
            this.btnLavagens.Click += new System.EventHandler(this.btnLavagens_Click);
            // 
            // btnLavanderia
            // 
            this.btnLavanderia.Name = "btnLavanderia";
            this.btnLavanderia.Size = new System.Drawing.Size(202, 24);
            this.btnLavanderia.Text = "Lavanderia";
            this.btnLavanderia.Click += new System.EventHandler(this.lavanderiaToolStripMenuItem_Click);
            // 
            // btnValorLavagem
            // 
            this.btnValorLavagem.Name = "btnValorLavagem";
            this.btnValorLavagem.Size = new System.Drawing.Size(202, 24);
            this.btnValorLavagem.Text = "Valores de Lavagens";
            this.btnValorLavagem.Click += new System.EventHandler(this.btnValorLavagem_Click);
            // 
            // btnCidade
            // 
            this.btnCidade.Name = "btnCidade";
            this.btnCidade.Size = new System.Drawing.Size(202, 24);
            this.btnCidade.Text = "Cidade";
            this.btnCidade.Click += new System.EventHandler(this.btnCidade_Click);
            // 
            // btnTecido
            // 
            this.btnTecido.Name = "btnTecido";
            this.btnTecido.Size = new System.Drawing.Size(202, 24);
            this.btnTecido.Text = "Tecido";
            this.btnTecido.Click += new System.EventHandler(this.btnTecido_Click);
            // 
            // btnTipoRoupa
            // 
            this.btnTipoRoupa.Name = "btnTipoRoupa";
            this.btnTipoRoupa.Size = new System.Drawing.Size(202, 24);
            this.btnTipoRoupa.Text = "Tipo de Roupa";
            this.btnTipoRoupa.Click += new System.EventHandler(this.btnTipoRoupa_Click);
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.Name = "btnEmpresa";
            this.btnEmpresa.Size = new System.Drawing.Size(202, 24);
            this.btnEmpresa.Text = "Empresa";
            this.btnEmpresa.Click += new System.EventHandler(this.btnEmpresa_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::tccLavanderia.Properties.Resources.Lavanderia_Solidaria_S_L_slideshow_image;
            this.pictureBox1.Location = new System.Drawing.Point(0, 229);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1264, 432);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnRoupa;
        private System.Windows.Forms.ToolStripMenuItem btnLavagens;
        private System.Windows.Forms.ToolStripMenuItem btnLavanderia;
        private System.Windows.Forms.ToolStripMenuItem btnValorLavagem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton btnFicha;
        private System.Windows.Forms.ToolStripMenuItem btnCidade;
        private System.Windows.Forms.ToolStripMenuItem btnTecido;
        private System.Windows.Forms.ToolStripMenuItem btnTipoRoupa;
        private System.Windows.Forms.ToolStripMenuItem btnEmpresa;
    }
}

