using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Usuario;
using ParkingSystem.Shared;
using ParkingSystem.Views.Cliente;
using ParkingSystem.Views.Estacionamento;
using ParkingSystem.Views.Usuario;
using ParkingSystem.Views.Veiculo.Fabricante;
using ParkingSystem.Views.Veiculo.Modelo;
using ParkingSystem.Views.Veiculo.Veiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.Views
{
    public partial class frmPrincipal : Form
    {
        private Usuarios usuario;

        public int IdUsuario { get; private set; }

        public frmPrincipal(int idUsuario)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
            usuario = new UsuariosController().Get(IdUsuario);
            SessionLogin.SetUsuarioSession(usuario);

            lblUsuario.Text = $"Usuário: {usuario.Nome}"; 
            timer_Tick(null, null);
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHoraData.Text = $"Data: {DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss")}";
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
    }
}
