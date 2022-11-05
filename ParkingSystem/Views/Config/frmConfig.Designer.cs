namespace ParkingSystem.Views.Config
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.grpValorEstacionamento = new System.Windows.Forms.GroupBox();
            this.txtPerNoite = new System.Windows.Forms.TextBox();
            this.lblPerNoite = new System.Windows.Forms.Label();
            this.txtMoto = new System.Windows.Forms.TextBox();
            this.txtCarro = new System.Windows.Forms.TextBox();
            this.lblMoto = new System.Windows.Forms.Label();
            this.lblCarro = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.grpConfigSistema = new System.Windows.Forms.GroupBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpValorEstacionamento.SuspendLayout();
            this.grpConfigSistema.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpValorEstacionamento
            // 
            this.grpValorEstacionamento.Controls.Add(this.txtPerNoite);
            this.grpValorEstacionamento.Controls.Add(this.lblPerNoite);
            this.grpValorEstacionamento.Controls.Add(this.txtMoto);
            this.grpValorEstacionamento.Controls.Add(this.txtCarro);
            this.grpValorEstacionamento.Controls.Add(this.lblMoto);
            this.grpValorEstacionamento.Controls.Add(this.lblCarro);
            this.grpValorEstacionamento.Location = new System.Drawing.Point(12, 81);
            this.grpValorEstacionamento.Name = "grpValorEstacionamento";
            this.grpValorEstacionamento.Size = new System.Drawing.Size(326, 133);
            this.grpValorEstacionamento.TabIndex = 3;
            this.grpValorEstacionamento.TabStop = false;
            this.grpValorEstacionamento.Text = "Valor Estacionamento";
            // 
            // txtPerNoite
            // 
            this.txtPerNoite.Location = new System.Drawing.Point(90, 101);
            this.txtPerNoite.Name = "txtPerNoite";
            this.txtPerNoite.Size = new System.Drawing.Size(212, 25);
            this.txtPerNoite.TabIndex = 9;
            this.txtPerNoite.Validated += new System.EventHandler(this.txtPerNoite_Validated);
            // 
            // lblPerNoite
            // 
            this.lblPerNoite.AutoSize = true;
            this.lblPerNoite.Location = new System.Drawing.Point(10, 104);
            this.lblPerNoite.Name = "lblPerNoite";
            this.lblPerNoite.Size = new System.Drawing.Size(68, 17);
            this.lblPerNoite.TabIndex = 8;
            this.lblPerNoite.Text = "Per Noite:";
            // 
            // txtMoto
            // 
            this.txtMoto.Location = new System.Drawing.Point(90, 70);
            this.txtMoto.Name = "txtMoto";
            this.txtMoto.Size = new System.Drawing.Size(212, 25);
            this.txtMoto.TabIndex = 7;
            this.txtMoto.Validated += new System.EventHandler(this.txtMoto_Validated);
            // 
            // txtCarro
            // 
            this.txtCarro.Location = new System.Drawing.Point(90, 39);
            this.txtCarro.Name = "txtCarro";
            this.txtCarro.Size = new System.Drawing.Size(212, 25);
            this.txtCarro.TabIndex = 5;
            this.txtCarro.Validated += new System.EventHandler(this.txtCarro_Validated);
            // 
            // lblMoto
            // 
            this.lblMoto.AutoSize = true;
            this.lblMoto.Location = new System.Drawing.Point(10, 73);
            this.lblMoto.Name = "lblMoto";
            this.lblMoto.Size = new System.Drawing.Size(44, 17);
            this.lblMoto.TabIndex = 6;
            this.lblMoto.Text = "Moto:";
            // 
            // lblCarro
            // 
            this.lblCarro.AutoSize = true;
            this.lblCarro.Location = new System.Drawing.Point(10, 42);
            this.lblCarro.Name = "lblCarro";
            this.lblCarro.Size = new System.Drawing.Size(44, 17);
            this.lblCarro.TabIndex = 4;
            this.lblCarro.Text = "Carro:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(239, 220);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(99, 35);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // grpConfigSistema
            // 
            this.grpConfigSistema.Controls.Add(this.txtTitulo);
            this.grpConfigSistema.Controls.Add(this.lblTitulo);
            this.grpConfigSistema.Location = new System.Drawing.Point(12, 12);
            this.grpConfigSistema.Name = "grpConfigSistema";
            this.grpConfigSistema.Size = new System.Drawing.Size(326, 63);
            this.grpConfigSistema.TabIndex = 0;
            this.grpConfigSistema.TabStop = false;
            this.grpConfigSistema.Text = "Personalização";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(90, 24);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(230, 25);
            this.txtTitulo.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(10, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(45, 17);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Titulo:";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 269);
            this.Controls.Add(this.grpConfigSistema);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grpValorEstacionamento);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.grpValorEstacionamento.ResumeLayout(false);
            this.grpValorEstacionamento.PerformLayout();
            this.grpConfigSistema.ResumeLayout(false);
            this.grpConfigSistema.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpValorEstacionamento;
        private System.Windows.Forms.TextBox txtPerNoite;
        private System.Windows.Forms.Label lblPerNoite;
        private System.Windows.Forms.TextBox txtMoto;
        private System.Windows.Forms.TextBox txtCarro;
        private System.Windows.Forms.Label lblMoto;
        private System.Windows.Forms.Label lblCarro;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox grpConfigSistema;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblTitulo;
    }
}