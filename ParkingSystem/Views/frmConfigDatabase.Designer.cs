namespace ParkingSystem.Views
{
    partial class frmConfigDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigDatabase));
            this.groupDatabase = new System.Windows.Forms.GroupBox();
            this.rdSQLServer = new System.Windows.Forms.RadioButton();
            this.rdMySQL = new System.Windows.Forms.RadioButton();
            this.groupConfig = new System.Windows.Forms.GroupBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblServidor = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupDatabase.SuspendLayout();
            this.groupConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDatabase
            // 
            this.groupDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDatabase.Controls.Add(this.rdSQLServer);
            this.groupDatabase.Controls.Add(this.rdMySQL);
            this.groupDatabase.Location = new System.Drawing.Point(13, 12);
            this.groupDatabase.Name = "groupDatabase";
            this.groupDatabase.Size = new System.Drawing.Size(356, 57);
            this.groupDatabase.TabIndex = 0;
            this.groupDatabase.TabStop = false;
            this.groupDatabase.Text = "Banco de Dados";
            // 
            // rdSQLServer
            // 
            this.rdSQLServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rdSQLServer.AutoSize = true;
            this.rdSQLServer.Location = new System.Drawing.Point(150, 24);
            this.rdSQLServer.Name = "rdSQLServer";
            this.rdSQLServer.Size = new System.Drawing.Size(153, 21);
            this.rdSQLServer.TabIndex = 1;
            this.rdSQLServer.TabStop = true;
            this.rdSQLServer.Text = "Microsoft SQL Server";
            this.rdSQLServer.UseVisualStyleBackColor = true;
            this.rdSQLServer.CheckedChanged += new System.EventHandler(this.rdSQLServer_CheckedChanged);
            // 
            // rdMySQL
            // 
            this.rdMySQL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rdMySQL.AutoSize = true;
            this.rdMySQL.Location = new System.Drawing.Point(76, 24);
            this.rdMySQL.Name = "rdMySQL";
            this.rdMySQL.Size = new System.Drawing.Size(68, 21);
            this.rdMySQL.TabIndex = 0;
            this.rdMySQL.TabStop = true;
            this.rdMySQL.Text = "MySQL";
            this.rdMySQL.UseVisualStyleBackColor = true;
            this.rdMySQL.CheckedChanged += new System.EventHandler(this.rdMySQL_CheckedChanged);
            // 
            // groupConfig
            // 
            this.groupConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupConfig.Controls.Add(this.txtSenha);
            this.groupConfig.Controls.Add(this.txtUsuario);
            this.groupConfig.Controls.Add(this.txtServidor);
            this.groupConfig.Controls.Add(this.label2);
            this.groupConfig.Controls.Add(this.lblUsuario);
            this.groupConfig.Controls.Add(this.lblServidor);
            this.groupConfig.Location = new System.Drawing.Point(13, 75);
            this.groupConfig.Name = "groupConfig";
            this.groupConfig.Size = new System.Drawing.Size(356, 136);
            this.groupConfig.TabIndex = 1;
            this.groupConfig.TabStop = false;
            this.groupConfig.Text = "Configurações";
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSenha.Location = new System.Drawing.Point(75, 90);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '•';
            this.txtSenha.Size = new System.Drawing.Size(275, 25);
            this.txtSenha.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Location = new System.Drawing.Point(75, 59);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(275, 25);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtServidor
            // 
            this.txtServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServidor.Location = new System.Drawing.Point(75, 28);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(275, 25);
            this.txtServidor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(6, 62);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(57, 17);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuário:";
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.Location = new System.Drawing.Point(6, 31);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(63, 17);
            this.lblServidor.TabIndex = 0;
            this.lblServidor.Text = "Servidor:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(270, 221);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(99, 35);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // frmConfigDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 268);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupConfig);
            this.Controls.Add(this.groupDatabase);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmConfigDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração do Banco de Dados";
            this.Load += new System.EventHandler(this.frmConfigDatabase_Load);
            this.groupDatabase.ResumeLayout(false);
            this.groupDatabase.PerformLayout();
            this.groupConfig.ResumeLayout(false);
            this.groupConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDatabase;
        private System.Windows.Forms.RadioButton rdSQLServer;
        private System.Windows.Forms.RadioButton rdMySQL;
        private System.Windows.Forms.GroupBox groupConfig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtServidor;
    }
}