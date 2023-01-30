namespace ParkingSystem.Views.Usuario
{
    partial class frmSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSenha));
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.lblIDUsuario = new System.Windows.Forms.Label();
            this.lblNomeUsuario = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblEmailUsuario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(65, 88);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '•';
            this.txtSenha.Size = new System.Drawing.Size(234, 25);
            this.txtSenha.TabIndex = 5;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(9, 91);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(48, 17);
            this.lblSenha.TabIndex = 4;
            this.lblSenha.Text = "Senha:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(190, 119);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(111, 33);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 17);
            this.lblID.TabIndex = 7;
            this.lblID.Text = "ID:";
            // 
            // lblIDUsuario
            // 
            this.lblIDUsuario.AutoSize = true;
            this.lblIDUsuario.Location = new System.Drawing.Point(65, 9);
            this.lblIDUsuario.Name = "lblIDUsuario";
            this.lblIDUsuario.Size = new System.Drawing.Size(0, 17);
            this.lblIDUsuario.TabIndex = 8;
            // 
            // lblNomeUsuario
            // 
            this.lblNomeUsuario.AutoSize = true;
            this.lblNomeUsuario.Location = new System.Drawing.Point(65, 35);
            this.lblNomeUsuario.Name = "lblNomeUsuario";
            this.lblNomeUsuario.Size = new System.Drawing.Size(0, 17);
            this.lblNomeUsuario.TabIndex = 10;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 35);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(48, 17);
            this.lblNome.TabIndex = 9;
            this.lblNome.Text = "Nome:";
            // 
            // lblEmailUsuario
            // 
            this.lblEmailUsuario.AutoSize = true;
            this.lblEmailUsuario.Location = new System.Drawing.Point(65, 61);
            this.lblEmailUsuario.Name = "lblEmailUsuario";
            this.lblEmailUsuario.Size = new System.Drawing.Size(0, 17);
            this.lblEmailUsuario.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "E-mail:";
            // 
            // frmSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 163);
            this.Controls.Add(this.lblEmailUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNomeUsuario);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblIDUsuario);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Senha";
            this.Load += new System.EventHandler(this.frmSenha_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblIDUsuario;
        private System.Windows.Forms.Label lblNomeUsuario;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblEmailUsuario;
        private System.Windows.Forms.Label label2;
    }
}