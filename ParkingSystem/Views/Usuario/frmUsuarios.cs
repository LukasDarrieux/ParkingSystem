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
    public partial class frmUsuarios : Form
    {
        private int IdUsuarioSelecionado = 0;

        private enum ColsGrid
        {
            ID = 0,
            NOME,
            EMAIL
        }

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            gridUsuario.Rows.Clear();
            UsuariosController usuariosController = new UsuariosController();
            Usuarios usuario = null;
            List<Usuarios> listaUsuarios = null;
            try
            {
                string nome = String.Empty;
                string email = String.Empty;
                
                if (txtNome.Text.Trim().Length > 0) nome = txtNome.Text;
                if (txtEmail.Text.Trim().Length > 0) email = txtEmail.Text;
                
                usuario = new Usuarios(0, nome, email, String.Empty);
                listaUsuarios = usuariosController.GetAll(usuario);
                if (!(listaUsuarios is null))
                {
                    if (listaUsuarios.Count > 0)
                    {
                        gridUsuario.Rows.Add(listaUsuarios.Count);
                        
                        int row = 0;
                        foreach (Usuarios user in listaUsuarios)
                        {
                            gridUsuario[(int)ColsGrid.ID, row].Value = user.Id.ToString();
                            gridUsuario[(int)ColsGrid.NOME, row].Value = user.Nome;
                            gridUsuario[(int)ColsGrid.EMAIL, row].Value = user.Email;
                            row++;
                        }
                    }
                    if (listaUsuarios.Count == 1) lblQuantidade.Text = "1 usuário encontrado";
                    else lblQuantidade.Text = $"{listaUsuarios.Count.ToString()} usuários encontrados";
                }
                else
                {
                    lblQuantidade.Text = "Nenhum usuário encontrado";
                }
                
                lblQuantidade.Refresh();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
            finally
            {
                btnBuscar.Enabled = true;
                this.Cursor = Cursors.Default;

                usuariosController.Dispose();
                if (!(usuario is null)) usuario.Dispose();
                if (!(listaUsuarios is null))
                {
                    listaUsuarios.Clear();
                    listaUsuarios = null;
                }
            }
        }

        private void frmUsuarios_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridUsuario.Width - gridUsuario.Columns[(int)ColsGrid.ID].Width - General.scroolWidth;

                gridUsuario.Columns[(int)ColsGrid.NOME].Width = widthTotal / 2;
                gridUsuario.Columns[(int)ColsGrid.EMAIL].Width = widthTotal / 2;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void ViewCrud(int typeAccess)
        {
            if (typeAccess != (int)General.TypeAccess.CREATE)
            {
                if (IdUsuarioSelecionado == 0)
                {
                    General.MessageShowAttention("Selecione um usuário primeiro!");
                    return;
                }
            }
            frmUsuariosCrud usuarioCrud = new frmUsuariosCrud(IdUsuarioSelecionado, typeAccess);
            usuarioCrud.Show();
            this.Close();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            ViewCrud((int)General.TypeAccess.CREATE);
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            ViewCrud((int)General.TypeAccess.READ);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ViewCrud((int)General.TypeAccess.UPDATE);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ViewCrud((int)General.TypeAccess.DELETE);
        }

        private void gridUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdUsuarioSelecionado = 0;
                
                if (e.RowIndex >= 0)
                {
                    if (!(gridUsuario[(int)ColsGrid.ID, e.RowIndex].Value is null))
                    {
                        if (gridUsuario[(int)ColsGrid.ID, e.RowIndex].Value.ToString().Trim().Length > 0)
                        {
                            IdUsuarioSelecionado = Int16.Parse(gridUsuario[(int)ColsGrid.ID, e.RowIndex].Value.ToString());
                            ValidateUserIsAdmin(gridUsuario[(int)ColsGrid.NOME, e.RowIndex].Value.ToString());
                            return;
                        }
                    }
                }
                ValidateUserIsAdmin(String.Empty);
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                lblQuantidade.Text = String.Empty;
                this.OnResize(null);
                btnBuscar.PerformClick();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }

        }

        private void ValidateUserIsAdmin(string nome)
        {
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;

            using (UsuariosController usuariosController = new UsuariosController())
            {
                Usuarios usuario = usuariosController.Get(IdUsuarioSelecionado);
                if (usuario is null) return;

                using (usuario)
                {
                    btnAlterar.Enabled = !(usuario.IsAdmin());
                    btnExcluir.Enabled = !(usuario.IsAdmin());
                }
            }
        }
    }
}
