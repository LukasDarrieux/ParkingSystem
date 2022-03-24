using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.Views.Usuario
{
    public partial class frmUsuariosCrud : Form
    {
        private int IdUsuario;
        private General.TypeAccess TipoAcesso;

        public frmUsuariosCrud(int id, int tipoAcesso)
        {
            IdUsuario = id;
            TipoAcesso = (General.TypeAccess)tipoAcesso;
            InitializeComponent();
        }

        private void ChangeTitleForm()
        {
            string title = String.Empty;
            switch (TipoAcesso)
            {
                case General.TypeAccess.CREATE:
                    title = "Criar Usuário";
                    break;
                case General.TypeAccess.READ:
                    title = "Exibir Usuário";
                    OnlyView();
                    break;
                case General.TypeAccess.UPDATE:
                    title = "Atualizar Usuário";
                    break;
                case General.TypeAccess.DELETE:
                    title = "Excluir Usuário";
                    btnSalvar.Text = "Excluir";
                    OnlyDelete();
                    break;
            }
            this.Text = title;
            this.Refresh();

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
                ChangeTitleForm();
                if (TipoAcesso != General.TypeAccess.CREATE)
                {
                    LoadUsuario();
                }
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmUsuarios frmUsuario = new frmUsuarios();
            frmUsuario.Show();
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
                using (Usuarios usuario = new Usuarios(0, txtNome.Text, txtEmail.Text, String.Empty))
                {
                    if (usuarioController.Insert(usuario))
                    {
                        this.Close();
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
                        this.Close();
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
                            this.Close();
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

                btnCancelar.Left = (this.Width / 2) - (btnCancelar.Width / 2);
                this.Refresh();
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

                this.Refresh();
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
