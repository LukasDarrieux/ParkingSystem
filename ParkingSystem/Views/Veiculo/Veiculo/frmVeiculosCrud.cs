using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Models.Veiculo;

namespace ParkingSystem.Views.Veiculo.Veiculo
{
    public partial class frmVeiculosCrud : Form
    {
        private readonly General.TypeAccess TipoAcesso;
        private readonly int IdVeiculo = 0;

        public frmVeiculosCrud(int idVeiculo, int tipoAcesso)
        {
            IdVeiculo = idVeiculo;
            TipoAcesso = (General.TypeAccess)tipoAcesso;
            InitializeComponent();
        }

        private void frmVeiculosCrud_Activated(object sender, EventArgs e)
        {
            //General.CarregarComboClientes(txtCliente);
            //General.CarregarComboFabricante(txtFabricante);
        }

        private void txtFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFabricante.SelectedIndex >= -1 && !String.IsNullOrEmpty(txtFabricante.Text))
            {
                General.CarregarComboModelos(((Fabricantes)txtFabricante.SelectedItem).Id, txtModelo);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVeiculosCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                new frmVeiculos().Show();
                return;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmVeiculosCrud_Load(object sender, EventArgs e)
        {
            try
            {
                General.ChangeTitleForm(this, "Veículo", TipoAcesso);
                General.CarregarComboClientes(txtCliente);
                General.CarregarComboFabricante(txtFabricante);
                General.CarregarComboModelos(0, txtModelo);

                if (TipoAcesso != General.TypeAccess.CREATE)
                {
                    LoadVeiculos();
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

                btnCancelar.Left = (Width / 2) - (btnCancelar.Width / 2);
                Refresh();
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
            txtFabricante.Enabled = false;
            txtModelo.Enabled = false;
            txtCliente.Enabled = false;
            txtPlaca.Enabled = false;
            if (IsView) btnSalvar.Visible = false;
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            txtPlaca.Text = txtPlaca.Text.ToUpper();
        }

        private void CreateVeiculos()
        {
            if (((Modelos)txtModelo.SelectedItem).Tipo == EnumVeiculos.tipo.Moto) CreateMoto();
            else CreateCarro();
        }

        private void CreateCarro()
        {
            using (VeiculosController veiculoController = new VeiculosController())
            {
                using (Veiculos veiculo = new Carros(0, txtPlaca.Text, new ModelosController().Get(((Modelos)txtModelo.SelectedItem).Id), new ClientesController().Get(((Clientes)txtCliente.SelectedItem).Id)))
                {
                    if (veiculoController.Insert(veiculo))
                    {
                        Close();
                    }
                }
            }
        }

        private void CreateMoto()
        {
            using (VeiculosController veiculoController = new VeiculosController())
            {
                using (Veiculos veiculo = new Motos(0, txtPlaca.Text, new ModelosController().Get(((Modelos)txtModelo.SelectedItem).Id), new ClientesController().Get(((Clientes)txtCliente.SelectedItem).Id)))
                {
                    if (veiculoController.Insert(veiculo))
                    {
                        Close();
                    }
                }
            }
        }


        private void UpdateVeiculos()
        {
            using (VeiculosController veiculoController = new VeiculosController())
            {
                using (Veiculos veiculo = new Veiculos(IdVeiculo, txtPlaca.Text, new ModelosController().Get(((Modelos)txtModelo.SelectedItem).Id), new ClientesController().Get(((Clientes)txtCliente.SelectedItem).Id), EnumVeiculos.tipo.Carro))
                {
                    if (veiculoController.Update(veiculo))
                    {
                        Close();
                    }
                }
            }
        }

        private void DeleteVeiculos()
        {
            using (VeiculosController veiculoController = new VeiculosController())
            {
                using (Veiculos veiculo = new Veiculos(IdVeiculo, txtPlaca.Text, new ModelosController().Get(((Modelos)txtModelo.SelectedItem).Id), new ClientesController().Get(((Clientes)txtCliente.SelectedItem).Id), EnumVeiculos.tipo.Carro)) if (General.MessageQuestion("Tem certeza que deseja excluir este modelo?"))
                {
                    if (General.MessageQuestion("Tem certeza que deseja excluir este veículo?"))
                    {
                        if (veiculoController.Delete(veiculo))
                        {
                            Close();
                        }
                    }
                }
            }
             
        }

        private void LoadVeiculos()
        {
            using (VeiculosController veiculoController = new VeiculosController())
            {
                using (Veiculos veiculo = veiculoController.Get(IdVeiculo))
                {
                    if (!(veiculo is null))
                    {
                        txtCliente.SelectedItem = veiculo.Cliente;
                        txtFabricante.SelectedItem = veiculo.Modelo.Fabricante;
                        txtModelo.SelectedItem = veiculo.Modelo;
                        txtPlaca.Text = veiculo.Placa.ToUpper();
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!General.ValidateField(txtCliente, lblCliente.Text)) return;
                if (!General.ValidateField(txtFabricante, lblFabricante.Text)) return;
                if (!General.ValidateField(txtModelo, lblModelo.Text)) return;
                if (!General.ValidateField(txtPlaca, lblModelo.Text)) return;
                
                switch (TipoAcesso)
                {
                    case General.TypeAccess.CREATE:
                        CreateVeiculos();
                        break;
                    case General.TypeAccess.UPDATE:
                        UpdateVeiculos();
                        break;
                    case General.TypeAccess.DELETE:
                        DeleteVeiculos();
                        break;
                }


            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }
    }
}
