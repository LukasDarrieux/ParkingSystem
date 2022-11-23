using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Models.Pessoa;
using ParkingSystem.Services.ViaCEP;
using System;
using System.Windows.Forms;

namespace ParkingSystem.Views.Cliente
{
    public partial class frmClientesCrud : Form
    {
        private General.TypeAccess TipoAcesso;
        private int IdCliente = 0;

        public frmClientesCrud(int idCliente, int tipoAcesso)
        {
            IdCliente = idCliente;
            TipoAcesso = (General.TypeAccess)tipoAcesso;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmClientesCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                new frmClientes().Show();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmClientesCrud_Load(object sender, EventArgs e)
        {
            try
            {
                General.ChangeTitleForm(this, "Cliente", TipoAcesso);

                if (TipoAcesso != General.TypeAccess.CREATE)
                {
                    LoadCliente();
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
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
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
            catch (Exception error)
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
            DisableTabPessoais();
            DisableTabEndereco();
            if (IsView) btnSalvar.Visible = false;
        }

        private void DisableTabPessoais()
        {
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtCPF.Enabled = false;
        }

        private void DisableTabEndereco()
        {
            txtCEP.Enabled = false;
            btnBuscar.Enabled = false;

            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
        }

        private void LoadCliente()
        {
            using (ClientesController clienteController = new ClientesController())
            {
                using (Clientes cliente = clienteController.Get(IdCliente))
                {
                    if (!(cliente is null))
                    {
                        LoadTabPessoais(cliente);
                        LoadTabEndereco(cliente);
                    }
                }
            }
        }

        private void LoadTabPessoais(Clientes cliente)
        {
            if (cliente is null) return;

            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtCPF.Text = cliente.Cpf;
        }

        private void LoadTabEndereco(Clientes cliente)
        {
            if (cliente is null) return;
            if (cliente.Endereco is null) return;

            txtCEP.Text = cliente.Endereco.CEP;
            txtLogradouro.Text = cliente.Endereco.Logradouro;
            txtNumero.Text = cliente.Endereco.Numero;
            txtBairro.Text = cliente.Endereco.Bairro;
            txtCidade.Text = cliente.Endereco.Cidade;
            txtUF.Text = cliente.Endereco.UF;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateTabPessoais()) return;
                if (!ValidateTabEndereco()) return;

                switch (TipoAcesso)
                {
                    case General.TypeAccess.CREATE:
                        CreateCliente();
                        break;
                    case General.TypeAccess.UPDATE:
                        UpdateCliente();
                        break;
                    case General.TypeAccess.DELETE:
                        DeleteCliente();
                        break;
                }

            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private bool ValidateTabPessoais()
        {
            if (!General.ValidateField(txtNome, lblNome.Text)) return false;
            if (!General.ValidateField(txtEmail, lblEmail.Text)) return false;
            if (!General.ValidateField(txtCPF, lblCPF.Text)) return false;

            //Validando se o CPF informado é válido
            if (!General.ValidateCpf(txtCPF.Text.Trim().Replace(".", "").Replace("-", "").Replace(",", "")))
            {
                General.MessageShowAttention("CPF informado é inválido!");
                txtCPF.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateTabEndereco()
        {
            if (!General.ValidateField(txtLogradouro, lblLogradouro.Text)) return false;
            if (!General.ValidateField(txtNumero, lblNumero.Text)) return false;
            if (!General.ValidateField(txtBairro, lblBairro.Text)) return false;
            if (!General.ValidateField(txtCidade, lblCidade.Text)) return false;
            if (!General.ValidateField(txtUF, lblUF.Text)) return false;
            return true;
        }


        private void CreateCliente()
        {
            using (ClientesController clienteController = new ClientesController())
            {
                using (Clientes cliente = new Clientes(0, txtNome.Text, txtEmail.Text, txtCPF.Text, GetEndereco()))
                {
                    if (clienteController.Insert(cliente))
                    {
                        Close();
                    }
                }
            }
        }

        private void UpdateCliente()
        {
            using (ClientesController clienteController = new ClientesController())
            {
                using (Clientes cliente = new Clientes(IdCliente, txtNome.Text, txtEmail.Text, txtCPF.Text, GetEndereco()))
                {
                    if (clienteController.Update(cliente))
                    {
                        Close();
                    }
                }
            }
        }

        private void DeleteCliente()
        {
            using (ClientesController clienteController = new ClientesController())
            {
                using (Clientes cliente = new Clientes(IdCliente, txtNome.Text, txtEmail.Text, txtCPF.Text, GetEndereco()))
                {
                    if (General.MessageQuestion("Tem certeza que deseja excluir este cliente?"))
                    {
                        if (clienteController.Delete(cliente))
                        {
                            Close();
                        }
                    }

                }
            }
        }

        private Enderecos GetEndereco()
        {
            return new Enderecos(txtCEP.Text, txtLogradouro.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, txtUF.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cepInformado = txtCEP.Text.Trim().Replace("-", "");
            if (cepInformado.Trim().Length > 0)
            {
                CEP cep = ViaCEP.BuscarCEP(cepInformado);
                if (!(cep is null))
                {
                    txtLogradouro.Text = cep.Logradouro;
                    txtBairro.Text = cep.Bairro;
                    txtCidade.Text = cep.Localidade;
                    txtUF.Text = cep.Uf;
                }
            }
            else
            {
                General.MessageShowAttention("Informe um CEP!");
            }
            
        }
    }
}
