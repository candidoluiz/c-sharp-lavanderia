using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using tccLavanderia.dao;

namespace tccLavanderia.print
{
    public partial class PrintFichaView : Form
    {
        private DataSetRelatorio dtList;
        public PrintFichaView(DataSetRelatorio dtList)
        {
            InitializeComponent();
            this.dtList = dtList;
        
        }

        private void PrintFichaView_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetRelatorio", dtList.Tables[1]));
            this.reportViewer1.RefreshReport();
            
        }
    }
}
