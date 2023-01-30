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
            using (var frm = new frmUsuarios())
            {
                frm.Show();
            }
        }

        private void mnuConfiguracoesBancoDados_Click(object sender, EventArgs e)
        {
            using (var frm = new frmConfigDatabase())
            { 
                frm.Show();
            }
        }

        private void mnuFabricantes_Click(object sender, EventArgs e)
        {
            using (var frm = new frmFabricantes())
            {
                frm.Show();
            }
        }

        private void mnuModelos_Click(object sender, EventArgs e)
        {
            using (var frm = new frmModelos())
            {
                frm.Show();
            }
        }

        private void mnuClientes_Click(object sender, EventArgs e)
        {
            using (var frm = new frmClientes())
            {
                frm.Show();
            }
        }

        private void mnuVeiculos_Click(object sender, EventArgs e)
        {
            using (var frm = new frmVeiculos())
            {
                frm.Show();
            }
        }

        private void mnuVaga_Click(object sender, EventArgs e)
        {
            using (var frm = new frmVagas())
            {
                frm.Show();
            }
        }

        private void mnuConfiguracoes_Click(object sender, EventArgs e)
        {
            using (var frm = new frmConfig())
            {
                frm.Show();
            }
        }

        private void mnuEstacionamento_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEstacionamentos())
            {
                frm.Show();
            }
        }

        private void mnuEntradaEstacionamento_Click(object sender, EventArgs e)
        {
            using (var frm = new frmEntrada())
            {
                frm.Show();
            }
        }

        private void mnuRelatorioFaturamento_Click(object sender, EventArgs e)
        {
            using (var frm = new frmRelatorioFaturamento())
            {
                frm.Show();
            }
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
