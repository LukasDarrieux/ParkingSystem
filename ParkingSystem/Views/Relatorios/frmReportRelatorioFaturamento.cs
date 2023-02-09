using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.Views.Relatorios
{
    public partial class frmReportRelatorioFaturamento : Form
    {

        private DataTable dtFaturamento;
        private string Periodo = String.Empty;
        private string ValorTotal = String.Empty;
        private string Quantidade = String.Empty;

        public frmReportRelatorioFaturamento(string periodo, string quantidade, string valorTotal, DataTable dataTableFaturamento)
        {
            InitializeComponent();
            dtFaturamento= dataTableFaturamento;
            Periodo = periodo.Trim();
            ValorTotal = valorTotal.Trim();
            Quantidade = quantidade.Trim();
        }

        private void frmReportRelatorioFaturamento_Load(object sender, EventArgs e)
        {   
            relatorioFaturamento.LocalReport.ReportEmbeddedResource = "ParkingSystem.Reports.RelatorioFaturamento.rdlc";
            relatorioFaturamento.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Periodo", Periodo));
            relatorioFaturamento.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Quantidade", Quantidade));
            relatorioFaturamento.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ValorTotal", ValorTotal));
            relatorioFaturamento.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Estacionamentos", dtFaturamento));
            relatorioFaturamento.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
         
            relatorioFaturamento.RefreshReport();
        }
    }
}
