using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Usuario;
using System;
using System.Windows.Forms;

namespace ParkingSystem.Views.Usuario
{
    public partial class frmUsuariosCrud : Form
    {
        private readonly int IdUsuario;
        private readonly General.TypeAccess TipoAcesso;

        public frmUsuariosCrud(int idUsuario, int tipoAcesso)
        {
            IdUsuario = idUsuario;
            TipoAcesso = (General.TypeAccess)tipoAcesso;
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!General.ValidateField(txtNome, lblNome.Text)) return;
                if (!General.ValidateField(txtEmail, lblEmail.Text)) return;

                switch (TipoAcesso)
                {
                    case General.TypeAccess.CREATE:
                        CreateUsuario();
                        break;
                    case General.TypeAccess.UPDATE:
                        UpdateUsuario();
                        break;
                    case General.TypeAccess.DELETE:
                        DeleteUsuario();
                        break;
                }

            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmUsuariosCrud_Load(object sender, EventArgs e)
        {
            try
            {
                General.ChangeTitleForm(this, "Usuário", TipoAcesso);
                
                if (TipoAcesso != General.TypeAccess.CREATE)
                {
                    LoadUsuario();
                }

                switch (TipoAcesso)
                {
                    case General.TypeAccess.DELETE:
                        OnlyDelete();
                        break;

                    case General.TypeAccess.READ:
                        OnlyView();
                        break;

                }

            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUsuariosCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (var frm = new frmUsuarios())
            {
                frm.Show();
            }
                
        }

        private void LoadUsuario()
        {
            using (UsuariosController usuarioController = new UsuariosController())
            {
                using (Usuarios usuario = usuarioController.Get(IdUsuario))
                {
                    if (!(usuario is null))
                    {
                        txtNome.Text = usuario.Nome;
                        txtEmail.Text = usuario.Email;
                    }
                }
            }
        }

        private void CreateUsuario()
        {
            using (UsuariosController usuarioController = new UsuariosController())
            {
                using (Usuarios usuario = new Usuarios(0, txtNome.Text, txtEmail.Text, General.SENHA_PADRAO))
                {
                    if (usuarioController.Insert(usuario))
                    {
                        Close();
                    }
                }
            }
        }

        private void UpdateUsuario()
        {
            using (UsuariosController usuarioController = new UsuariosController())
            {
                using (Usuarios usuario = new Usuarios(IdUsuario, txtNome.Text, txtEmail.Text, String.Empty))
                {
                    if(usuarioController.Update(usuario))
                    {
                        Close();
                    }
                }
            }
        }

        private void DeleteUsuario()
        {
            using (UsuariosController usuarioController = new UsuariosController())
            {
                using (Usuarios usuario = new Usuarios(IdUsuario, txtNome.Text, txtEmail.Text, String.Empty))
                {
                    if (General.MessageQuestion("Tem certeza que deseja excluir este usuário?"))
                    {
                        if(usuarioController.Delete(usuario))
                        {
                            Close();
                        }
                    }
                    
                }
            }
        }

        private void OnlyView()
        {
            try
            {
                DisableControls(true);

                btnCancelar.Left = (Width / 2) - (btnCancelar.Width / 2);
                Refresh();
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void OnlyDelete()
        {
            try
            {
                DisableControls();
                btnSalvar.Text = "Excluir";
                Refresh();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void DisableControls(bool IsView = false)
        {
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            if (IsView) btnSalvar.Visible = false;
        }

    }
}
