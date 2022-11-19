namespace ParkingSystem.Views.Estacionamento
{
    partial class frmSaida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaida));
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblVaga = new System.Windows.Forms.Label();
            this.lblVeiculo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.txtVaga = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtTempoTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHora
            // 
            this.txtHora.Enabled = false;
            this.txtHora.Location = new System.Drawing.Point(102, 105);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(243, 25);
            this.txtHora.TabIndex = 40;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(12, 108);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(74, 17);
            this.lblHora.TabIndex = 39;
            this.lblHora.Text = "Data/Hora:";
            // 
            // lblVaga
            // 
            this.lblVaga.AutoSize = true;
            this.lblVaga.Location = new System.Drawing.Point(11, 77);
            this.lblVaga.Name = "lblVaga";
            this.lblVaga.Size = new System.Drawing.Size(40, 17);
            this.lblVaga.TabIndex = 37;
            this.lblVaga.Text = "Vaga:";
            // 
            // lblVeiculo
            // 
            this.lblVeiculo.AutoSize = true;
            this.lblVeiculo.Location = new System.Drawing.Point(11, 46);
            this.lblVeiculo.Name = "lblVeiculo";
            this.lblVeiculo.Size = new System.Drawing.Size(53, 17);
            this.lblVeiculo.TabIndex = 35;
            this.lblVeiculo.Text = "Veiculo:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(11, 15);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 17);
            this.lblCliente.TabIndex = 33;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(102, 12);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(541, 25);
            this.txtCliente.TabIndex = 41;
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.Enabled = false;
            this.txtVeiculo.Location = new System.Drawing.Point(102, 43);
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(541, 25);
            this.txtVeiculo.TabIndex = 42;
            // 
            // txtVaga
            // 
            this.txtVaga.Enabled = false;
            this.txtVaga.Location = new System.Drawing.Point(102, 74);
            this.txtVaga.Name = "txtVaga";
            this.txtVaga.Size = new System.Drawing.Size(243, 25);
            this.txtVaga.TabIndex = 43;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Location = new System.Drawing.Point(472, 105);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(171, 25);
            this.txtSubTotal.TabIndex = 45;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Location = new System.Drawing.Point(381, 108);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(63, 17);
            this.lblSubTotal.TabIndex = 44;
            this.lblSubTotal.Text = "SubTotal:";
            // 
            // txtTempoTotal
            // 
            this.txtTempoTotal.Enabled = false;
            this.txtTempoTotal.Location = new System.Drawing.Point(472, 74);
            this.txtTempoTotal.Name = "txtTempoTotal";
            this.txtTempoTotal.Size = new System.Drawing.Size(171, 25);
            this.txtTempoTotal.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 48;
            this.label2.Text = "Tempo Total:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(245, 146);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(84, 35);
            this.btnSalvar.TabIndex = 49;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(335, 147);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 35);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 194);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTempoTotal);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.txtVaga);
            this.Controls.Add(this.txtVeiculo);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblVaga);
            this.Controls.Add(this.lblVeiculo);
            this.Controls.Add(this.lblCliente);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmSaida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saída";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSaida_FormClosed);
            this.Load += new System.EventHandler(this.frmSaida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblVaga;
        private System.Windows.Forms.Label lblVeiculo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtVeiculo;
        private System.Windows.Forms.TextBox txtVaga;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtTempoTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}