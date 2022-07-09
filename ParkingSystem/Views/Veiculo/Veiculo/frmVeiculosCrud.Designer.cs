namespace ParkingSystem.Views.Veiculo.Veiculo
{
    partial class frmVeiculosCrud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVeiculosCrud));
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.ComboBox();
            this.txtPlaca = new System.Windows.Forms.MaskedTextBox();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.ComboBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.txtFabricante = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(5, 15);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 17);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.FormattingEnabled = true;
            this.txtCliente.Location = new System.Drawing.Point(85, 12);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(474, 25);
            this.txtCliente.TabIndex = 3;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(85, 105);
            this.txtPlaca.Mask = "LLL-0&00";
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(100, 25);
            this.txtPlaca.TabIndex = 13;
            this.txtPlaca.Leave += new System.EventHandler(this.txtPlaca_Leave);
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Location = new System.Drawing.Point(5, 108);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(42, 17);
            this.lblPlaca.TabIndex = 12;
            this.lblPlaca.Text = "Placa:";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(5, 77);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(57, 17);
            this.lblModelo.TabIndex = 10;
            this.lblModelo.Text = "Modelo:";
            // 
            // txtModelo
            // 
            this.txtModelo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModelo.FormattingEnabled = true;
            this.txtModelo.Location = new System.Drawing.Point(85, 74);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(474, 25);
            this.txtModelo.TabIndex = 11;
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(5, 46);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(74, 17);
            this.lblFabricante.TabIndex = 8;
            this.lblFabricante.Text = "Fabricante:";
            // 
            // txtFabricante
            // 
            this.txtFabricante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFabricante.FormattingEnabled = true;
            this.txtFabricante.Location = new System.Drawing.Point(85, 43);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(474, 25);
            this.txtFabricante.TabIndex = 9;
            this.txtFabricante.SelectedIndexChanged += new System.EventHandler(this.txtFabricante_SelectedIndexChanged);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(213, 161);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(84, 35);
            this.btnSalvar.TabIndex = 18;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(303, 162);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 35);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmVeiculosCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 209);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.lblPlaca);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblFabricante);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.txtCliente);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmVeiculosCrud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Veiculos";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmVeiculosCrud_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVeiculosCrud_FormClosed);
            this.Load += new System.EventHandler(this.frmVeiculosCrud_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox txtCliente;
        private System.Windows.Forms.MaskedTextBox txtPlaca;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.ComboBox txtModelo;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.ComboBox txtFabricante;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}