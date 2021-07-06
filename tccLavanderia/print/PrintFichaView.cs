using System;
using System.Windows.Forms;

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
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetRelatorio", dtList.Tables[0]));
            this.reportViewer1.RefreshReport();
            
        }
    }
}
