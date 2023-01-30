using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParkingSystem.Views.Cliente
{
    public partial class frmClientes : Form
    {
        private int IdClienteSelecionado = 0;

        private enum ColsGrid
        {
            ID = 0,
            NOME,
            EMAIL
        }

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridClientes.Width - gridClientes.Columns[(int)ColsGrid.ID].Width - General.scroolWidth;

                gridClientes.Columns[(int)ColsGrid.NOME].Width = widthTotal / 2;
                gridClientes.Columns[(int)ColsGrid.EMAIL].Width = widthTotal / 2;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Clientes cliente = null;
            ClientesController clienteController = new ClientesController();
            List<Clientes> ListaClientes = null;
            gridClientes.Rows.Clear();
            try
            {
                string nome = String.Empty;
                string email = String.Empty;
                string cpf = String.Empty;

                if (txtNome.Text.Trim().Length > 0) nome = txtNome.Text.Trim();
                if (txtEmail.Text.Trim().Length > 0) email = txtEmail.Text.Trim();
                if (txtCPF.Text.Trim().Length > 0 && txtCPF.MaskCompleted) cpf = txtCPF.Text.Trim();

                cliente = new Clientes(0, nome, email, cpf, null);
                ListaClientes = clienteController.GetAll(cliente);

                if (!(ListaClientes is null))
                {
                    if (ListaClientes.Count > 0)
                    {
                        int row = 0;
                        IdClienteSelecionado = ListaClientes[0].Id;
                        foreach(Clientes client in ListaClientes)
                        {
                            gridClientes.Rows.Add();
                            gridClientes[(int)ColsGrid.ID, row].Value = client.Id.ToString();
                            gridClientes[(int)ColsGrid.NOME, row].Value = client.Nome;
                            gridClientes[(int)ColsGrid.EMAIL, row].Value = client.Email;
                            row++;
                        }
                    }
                    if (ListaClientes.Count == 1) lblQuantidade.Text = "1 cliente encontrado";
                    else lblQuantidade.Text = $"{ListaClientes.Count.ToString()} clientes encontrados";
                }
                else
                {
                    lblQuantidade.Text = "Nenhum cliente encontrado";
                }

            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
            }
            finally
            {
                btnBuscar.Enabled = true;
                Cursor = Cursors.Default;

                clienteController.Dispose();
                if (!(cliente is null)) cliente.Dispose();
                if (!(ListaClientes is null))
                {
                    ListaClientes.Clear();
                }
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                lblQuantidade.Text = String.Empty;
                OnResize(null);
                btnBuscar.PerformClick();
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void ViewCrud(int typeAccess)
        {
            if (typeAccess != (int)General.TypeAccess.CREATE)
            {
                if (IdClienteSelecionado == 0)
                {
                    General.MessageShowAttention("Selecione um usuário primeiro!");
                    return;
                }
            }

            using (var frm = new frmClientesCrud(IdClienteSelecionado, typeAccess))
            {
                frm.Show();
            }

            Close();
        }

        private void gridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdClienteSelecionado = 0;

                if (e.RowIndex >= 0)
                {
                    if (!(gridClientes[(int)ColsGrid.ID, e.RowIndex].Value is null))
                    {
                        if (gridClientes[(int)ColsGrid.ID, e.RowIndex].Value.ToString().Trim().Length > 0)
                        {
                            IdClienteSelecionado = int.Parse(gridClientes[(int)ColsGrid.ID, e.RowIndex].Value.ToString());
                            return;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
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
    }
}
