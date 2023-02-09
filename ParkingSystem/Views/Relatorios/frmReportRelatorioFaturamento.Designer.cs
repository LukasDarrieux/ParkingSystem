namespace ParkingSystem.Views.Relatorios
{
    partial class frmReportRelatorioFaturamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportRelatorioFaturamento));
            this.relatorioFaturamento = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // relatorioFaturamento
            // 
            this.relatorioFaturamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.relatorioFaturamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relatorioFaturamento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.relatorioFaturamento.Location = new System.Drawing.Point(0, 0);
            this.relatorioFaturamento.Margin = new System.Windows.Forms.Padding(0);
            this.relatorioFaturamento.Name = "relatorioFaturamento";
            this.relatorioFaturamento.ServerReport.BearerToken = null;
            this.relatorioFaturamento.Size = new System.Drawing.Size(592, 528);
            this.relatorioFaturamento.TabIndex = 0;
            this.relatorioFaturamento.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.relatorioFaturamento.ZoomPercent = 200;
            // 
            // frmReportRelatorioFaturamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 528);
            this.Controls.Add(this.relatorioFaturamento);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportRelatorioFaturamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportRelatorioFaturamento_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer relatorioFaturamento;
    }
}