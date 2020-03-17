namespace tccLavanderia.print
{
    partial class PrintFichaView
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TransacaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetRelatorio = new tccLavanderia.print.DataSetRelatorio();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TransacaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // TransacaoBindingSource
            // 
            this.TransacaoBindingSource.DataMember = "Transacao";
            this.TransacaoBindingSource.DataSource = this.DataSetRelatorio;
            // 
            // DataSetRelatorio
            // 
            this.DataSetRelatorio.DataSetName = "DataSetRelatorio";
            this.DataSetRelatorio.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetRelatorio";
            reportDataSource1.Value = this.TransacaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "tccLavanderia.print.Relatorio.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(744, 504);
            this.reportViewer1.TabIndex = 0;
            // 
            // PrintFichaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 504);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintFichaView";
            this.Text = "PrintFichaView";
            this.Load += new System.EventHandler(this.PrintFichaView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransacaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetRelatorio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TransacaoBindingSource;
        private DataSetRelatorio DataSetRelatorio;
    }
}