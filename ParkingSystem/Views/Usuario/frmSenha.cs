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
    public partial class frmSenha : Form
    {
        Usuarios Usuario;
        public bool CadastrouSenha { get; private set; }

        public frmSenha(int idUsuario, string senhaAtual)
        {
            InitializeComponent();
            Usuario = new UsuariosController().Get(idUsuario);
            Usuario.Senha = senhaAtual;
            Text = "Informe a sua nova senha";
        }

        private void frmSenha_Load(object sender, EventArgs e)
        {
            try
            {
                if (Usuario is null) Close();

                lblIDUsuario.Text = Usuario.Id.ToString();
                lblNomeUsuario.Text = Usuario.Nome;
                lblEmailUsuario.Text = Usuario.Email;

            }
            catch(Exception erro)
            {
                General.MessageShowError(erro.Message);
                Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!General.ValidateField(txtSenha, lblSenha.Text)) return;

                using (UsuariosController usuarioController = new UsuariosController())
                {
                    if (usuarioController.UpdatePassword(Usuario, Usuario.Senha, txtSenha.Text))
                    {
                        CadastrouSenha = true;
                        Close();
                    }
                }
            }
            catch (Exception erro)
            {
                General.MessageShowError(erro.Message);
            }

        }
    }
}
