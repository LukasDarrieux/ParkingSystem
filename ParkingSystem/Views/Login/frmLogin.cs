using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Usuario;
using ParkingSystem.Views.Usuario;
using System;
using System.Windows.Forms;

namespace ParkingSystem.Views.Login
{
    public partial class frmLogin : Form
    {
        private bool FinishSystem;

        public frmLogin(bool finishSystem)
        {
            InitializeComponent();
            FinishSystem = finishSystem;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FinishSystem) Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuariosController usuarioController = new UsuariosController();
            try
            {
                if (!General.ValidateField(txtEmail, lblEmail.Text)) return;
                if (!General.ValidateField(txtSenha, lblSenha.Text)) return;

                string email = txtEmail.Text.Trim();
                string senha = txtSenha.Text;
                bool CreatePassword = false;
                Usuarios usuario = usuarioController.Login(email, senha, out CreatePassword);

                if (usuario is null)
                {
                    General.MessageShowAttention("Usuário inválido!");
                    txtSenha.Text = string.Empty;
                    txtSenha.Focus();
                }
                else
                {
                    if (CreatePassword)
                    {
                        using (var frm = new frmSenha(usuario.Id, usuario.Senha))
                        {
                            frm.ShowDialog();
                            if (!frm.CadastrouSenha) Application.Exit();
                        }
                    }
                    using (var frm = new frmPrincipal(usuario.Id))
                    {
                        frm.Show();
                    }
                    FinishSystem = false;
                    Close();
                }
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
                Close();
                return;
            }
            finally
            {
                usuarioController.Dispose();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                #if DEBUG
                    txtEmail.Text = "adm@darrieuxinfo.com";
                    txtSenha.Text = "12345678";
                #else
                    txtEmail.Text = "";
                    txtSenha.Text = "";
                #endif
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
