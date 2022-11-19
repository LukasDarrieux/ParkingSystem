namespace ParkingSystem.Views.Relatorios
{
    partial class frmRelatorioFaturamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelatorioFaturamento));
            this.gridFaturamento = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.ENTRADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SAIDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLIENTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VEICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEMPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR_TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridFaturamento)).BeginInit();
            this.SuspendLayout();
            // 
            // gridFaturamento
            // 
            this.gridFaturamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFaturamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFaturamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ENTRADA,
            this.SAIDA,
            this.CLIENTE,
            this.VEICULO,
            this.TEMPO,
            this.VALOR_TOTAL});
            this.gridFaturamento.Location = new System.Drawing.Point(12, 61);
            this.gridFaturamento.Name = "gridFaturamento";
            this.gridFaturamento.Size = new System.Drawing.Size(1215, 513);
            this.gridFaturamento.TabIndex = 5;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFechar.Location = new System.Drawing.Point(568, 619);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(104, 31);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(216, 16);
            this.txtDataFim.Mask = "00/00/0000";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(100, 25);
            this.txtDataFim.TabIndex = 3;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(183, 19);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(27, 17);
            this.lblAte.TabIndex = 2;
            this.lblAte.Text = "até";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Location = new System.Drawing.Point(77, 16);
            this.txtDataInicio.Mask = "00/00/0000";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(100, 25);
            this.txtDataInicio.TabIndex = 1;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(13, 19);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(58, 17);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Periodo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(1120, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 31);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(1040, 580);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(95, 17);
            this.lblValorTotal.TabIndex = 7;
            this.lblValorTotal.Text = "Sub Total: 0,00";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(12, 580);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(0, 17);
            this.lblQuantidade.TabIndex = 6;
            // 
            // ENTRADA
            // 
            this.ENTRADA.HeaderText = "DATA ENTRADA";
            this.ENTRADA.Name = "ENTRADA";
            this.ENTRADA.ReadOnly = true;
            this.ENTRADA.Width = 130;
            // 
            // SAIDA
            // 
            this.SAIDA.HeaderText = "DATA SAÍDA";
            this.SAIDA.Name = "SAIDA";
            this.SAIDA.ReadOnly = true;
            this.SAIDA.Width = 130;
            // 
            // CLIENTE
            // 
            this.CLIENTE.HeaderText = "CLIENTE";
            this.CLIENTE.Name = "CLIENTE";
            this.CLIENTE.ReadOnly = true;
            this.CLIENTE.Width = 380;
            // 
            // VEICULO
            // 
            this.VEICULO.HeaderText = "VEÍCULO";
            this.VEICULO.Name = "VEICULO";
            this.VEICULO.ReadOnly = true;
            this.VEICULO.Width = 330;
            // 
            // TEMPO
            // 
            this.TEMPO.HeaderText = "TEMPO";
            this.TEMPO.Name = "TEMPO";
            this.TEMPO.ReadOnly = true;
            this.TEMPO.Width = 80;
            // 
            // VALOR_TOTAL
            // 
            this.VALOR_TOTAL.HeaderText = "VALOR TOTAL";
            this.VALOR_TOTAL.Name = "VALOR_TOTAL";
            this.VALOR_TOTAL.ReadOnly = true;
            this.VALOR_TOTAL.Width = 120;
            // 
            // frmRelatorioFaturamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 662);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.txtDataFim);
            this.Controls.Add(this.lblAte);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.lblPeriodo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gridFaturamento);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRelatorioFaturamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faturamento";
            this.Load += new System.EventHandler(this.frmRelatorioFaturamento_Load);
            this.Resize += new System.EventHandler(this.frmRelatorioFaturamento_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridFaturamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridFaturamento;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.MaskedTextBox txtDataFim;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox txtDataInicio;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENTRADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SAIDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VEICULO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEMPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR_TOTAL;
    }
}