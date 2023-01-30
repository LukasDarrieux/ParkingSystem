using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Usuario;
using ParkingSystem.Shared;
using ParkingSystem.Views.Cliente;
using ParkingSystem.Views.Config;
using ParkingSystem.Views.Estacionamento;
using ParkingSystem.Views.Relatorios;
using ParkingSystem.Views.Usuario;
using ParkingSystem.Views.Veiculo.Fabricante;
using ParkingSystem.Views.Veiculo.Modelo;
using ParkingSystem.Views.Veiculo.Veiculo;
using System;
using System.Windows.Forms;

namespace ParkingSystem.Views
{
    public partial class frmPrincipal : Form
    {
        private readonly Usuarios usuario;

        public int IdUsuario { get; private set; }

        public frmPrincipal(int idUsuario)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
            usuario = new UsuariosController().Get(IdUsuario);
            SessionLogin.SetUsuarioSession(usuario);

            lblUsuario.Text = $"Usuário: {usuario.Nome}";
            lblDatabase.Text = $"Banco de Dados: {ConfiguracaoDatabase.SGBD}";
            timer.Enabled = true;
            Text = Configuracoes.GetConfiguracaoPersonalizacao().Titulo + " - DARRIEUX INFO";
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHoraData.Text = $"Data: {DateTime.Now:dd/MM/yyyy - HH:mm:ss}";
            lblHoraData.Refresh();
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            new frmUsuarios().Show();
        }

        private void mnuConfiguracoesBancoDados_Click(object sender, EventArgs e)
        {
            new frmConfigDatabase().Show();
        }

        private void mnuFabricantes_Click(object sender, EventArgs e)
        {
            new frmFabricantes().Show();
        }

        private void mnuModelos_Click(object sender, EventArgs e)
        {
            new frmModelos().Show();
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            new frmClientes().Show();
        }

        private void mnuVeiculos_Click(object sender, EventArgs e)
        {
            new frmVeiculos().Show();
        }

        private void mnuVaga_Click(object sender, EventArgs e)
        {
            new frmVagas().Show();
        }

        private void mnuConfiguracoes_Click(object sender, EventArgs e)
        {
            new frmConfig().Show();
        }

        private void mnuEstacionamento_Click(object sender, EventArgs e)
        {
            new frmEstacionamentos().Show();
        }

        private void mnuEntradaEstacionamento_Click(object sender, EventArgs e)
        {
            new frmEntrada().Show();
        }

        private void mnuRelatorioFaturamento_Click(object sender, EventArgs e)
        {
            new frmRelatorioFaturamento().Show();
        }

        private void mnuAlterarSenha_Click(object sender, EventArgs e)
        {
            if (usuario.IsAdmin())
            {
                General.MessageShowAttention("Não é possível alterar a senha do Administrador do Sistema!");
                return;
            }

            using (var frm = new frmSenha(usuario.Id, usuario.Senha))
            {
                frm.ShowDialog();
            }
        }
    }
}
