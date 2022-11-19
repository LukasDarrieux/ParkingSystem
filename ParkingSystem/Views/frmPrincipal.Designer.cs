namespace ParkingSystem.Views
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.lblHoraData = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.MenuStrip();
            this.mnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfiguracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfiguracoesBancoDados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnusVeiculos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFabricantes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModelos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVeiculos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnusEstacionamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVaga = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstaciomentos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEstacionamento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEntradaEstacionamento = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.mnuRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelatorioFaturamento = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHoraData
            // 
            this.lblHoraData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHoraData.AutoSize = true;
            this.lblHoraData.Location = new System.Drawing.Point(602, 535);
            this.lblHoraData.Name = "lblHoraData";
            this.lblHoraData.Size = new System.Drawing.Size(170, 17);
            this.lblHoraData.TabIndex = 0;
            this.lblHoraData.Text = "Data: 00/00/0000 - 00:00:00";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 535);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 17);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuário";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSistema,
            this.mnuCadastros,
            this.mnuEstaciomentos,
            this.mnuRelatorios});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(784, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // mnuSistema
            // 
            this.mnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsuarios,
            this.mnuConfiguracoes,
            this.mnuConfiguracoesBancoDados});
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(61, 20);
            this.mnuSistema.Text = "Sistema";
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(246, 22);
            this.mnuUsuarios.Text = "Usuários";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);
            // 
            // mnuConfiguracoes
            // 
            this.mnuConfiguracoes.Name = "mnuConfiguracoes";
            this.mnuConfiguracoes.Size = new System.Drawing.Size(246, 22);
            this.mnuConfiguracoes.Text = "Configurações";
            this.mnuConfiguracoes.Click += new System.EventHandler(this.mnuConfiguracoes_Click);
            // 
            // mnuConfiguracoesBancoDados
            // 
            this.mnuConfiguracoesBancoDados.Name = "mnuConfiguracoesBancoDados";
            this.mnuConfiguracoesBancoDados.Size = new System.Drawing.Size(246, 22);
            this.mnuConfiguracoesBancoDados.Text = "Configurações da Base de Dados";
            this.mnuConfiguracoesBancoDados.Click += new System.EventHandler(this.mnuConfiguracoesBancoDados_Click);
            // 
            // mnuCadastros
            // 
            this.mnuCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClientes,
            this.mnusVeiculos,
            this.mnusEstacionamento});
            this.mnuCadastros.Name = "mnuCadastros";
            this.mnuCadastros.Size = new System.Drawing.Size(70, 20);
            this.mnuCadastros.Text = "Cadastros";
            // 
            // mnuClientes
            // 
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.Size = new System.Drawing.Size(159, 22);
            this.mnuClientes.Text = "Clientes";
            this.mnuClientes.Click += new System.EventHandler(this.mnuClientes_Click);
            // 
            // mnusVeiculos
            // 
            this.mnusVeiculos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFabricantes,
            this.mnuModelos,
            this.mnuVeiculos});
            this.mnusVeiculos.Name = "mnusVeiculos";
            this.mnusVeiculos.Size = new System.Drawing.Size(159, 22);
            this.mnusVeiculos.Text = "Veículos";
            // 
            // mnuFabricantes
            // 
            this.mnuFabricantes.Name = "mnuFabricantes";
            this.mnuFabricantes.Size = new System.Drawing.Size(134, 22);
            this.mnuFabricantes.Text = "Fabricantes";
            this.mnuFabricantes.Click += new System.EventHandler(this.mnuFabricantes_Click);
            // 
            // mnuModelos
            // 
            this.mnuModelos.Name = "mnuModelos";
            this.mnuModelos.Size = new System.Drawing.Size(134, 22);
            this.mnuModelos.Text = "Modelos";
            this.mnuModelos.Click += new System.EventHandler(this.mnuModelos_Click);
            // 
            // mnuVeiculos
            // 
            this.mnuVeiculos.Name = "mnuVeiculos";
            this.mnuVeiculos.Size = new System.Drawing.Size(134, 22);
            this.mnuVeiculos.Text = "Veículos";
            this.mnuVeiculos.Click += new System.EventHandler(this.mnuVeiculos_Click);
            // 
            // mnusEstacionamento
            // 
            this.mnusEstacionamento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVaga});
            this.mnusEstacionamento.Name = "mnusEstacionamento";
            this.mnusEstacionamento.Size = new System.Drawing.Size(159, 22);
            this.mnusEstacionamento.Text = "Estacionamento";
            // 
            // mnuVaga
            // 
            this.mnuVaga.Name = "mnuVaga";
            this.mnuVaga.Size = new System.Drawing.Size(105, 22);
            this.mnuVaga.Text = "Vagas";
            this.mnuVaga.Click += new System.EventHandler(this.mnuVaga_Click);
            // 
            // mnuEstaciomentos
            // 
            this.mnuEstaciomentos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEstacionamento,
            this.mnuEntradaEstacionamento});
            this.mnuEstaciomentos.Name = "mnuEstaciomentos";
            this.mnuEstaciomentos.Size = new System.Drawing.Size(109, 20);
            this.mnuEstaciomentos.Text = "Estacionamentos";
            // 
            // mnuEstacionamento
            // 
            this.mnuEstacionamento.Name = "mnuEstacionamento";
            this.mnuEstacionamento.Size = new System.Drawing.Size(219, 22);
            this.mnuEstacionamento.Text = "Estacionamento";
            this.mnuEstacionamento.Click += new System.EventHandler(this.mnuEstacionamento_Click);
            // 
            // mnuEntradaEstacionamento
            // 
            this.mnuEntradaEstacionamento.Name = "mnuEntradaEstacionamento";
            this.mnuEntradaEstacionamento.Size = new System.Drawing.Size(219, 22);
            this.mnuEntradaEstacionamento.Text = "Entrada no Estacionamento";
            this.mnuEntradaEstacionamento.Click += new System.EventHandler(this.mnuEntradaEstacionamento_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(418, 535);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(154, 17);
            this.lblDatabase.TabIndex = 3;
            this.lblDatabase.Text = "Banco de dados: MySQL";
            // 
            // mnuRelatorios
            // 
            this.mnuRelatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRelatorioFaturamento});
            this.mnuRelatorios.Name = "mnuRelatorios";
            this.mnuRelatorios.Size = new System.Drawing.Size(71, 20);
            this.mnuRelatorios.Text = "Relatórios";
            // 
            // mnuRelatorioFaturamento
            // 
            this.mnuRelatorioFaturamento.Name = "mnuRelatorioFaturamento";
            this.mnuRelatorioFaturamento.Size = new System.Drawing.Size(208, 22);
            this.mnuRelatorioFaturamento.Text = "Relatório de Faturamento";
            this.mnuRelatorioFaturamento.Click += new System.EventHandler(this.mnuRelatorioFaturamento_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblHoraData);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHoraData;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mnuSistema;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguracoes;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguracoesBancoDados;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastros;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnusVeiculos;
        private System.Windows.Forms.ToolStripMenuItem mnuFabricantes;
        private System.Windows.Forms.ToolStripMenuItem mnuModelos;
        private System.Windows.Forms.ToolStripMenuItem mnuVeiculos;
        private System.Windows.Forms.ToolStripMenuItem mnusEstacionamento;
        private System.Windows.Forms.ToolStripMenuItem mnuVaga;
        private System.Windows.Forms.ToolStripMenuItem mnuEstaciomentos;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ToolStripMenuItem mnuEstacionamento;
        private System.Windows.Forms.ToolStripMenuItem mnuEntradaEstacionamento;
        private System.Windows.Forms.ToolStripMenuItem mnuRelatorios;
        private System.Windows.Forms.ToolStripMenuItem mnuRelatorioFaturamento;
    }
}