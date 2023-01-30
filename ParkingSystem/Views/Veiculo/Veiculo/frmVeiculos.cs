using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Models.Veiculo;

namespace ParkingSystem.Views.Veiculo.Veiculo
{
    public partial class frmVeiculos : Form
    {
        private int IdVeiculoSelecionado = 0;

        public frmVeiculos()
        {
            InitializeComponent();
        }

        enum ColsGrid
        {
            ID,
            CLIENTE,
            FABRICANTE,
            MODELO,
            PLACA
        }

        private void frmVeiculos_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridVeiculos.Width - gridVeiculos.Columns[(int)ColsGrid.ID].Width - gridVeiculos.Columns[(int)ColsGrid.PLACA].Width - General.scroolWidth;
                gridVeiculos.Columns[(int)ColsGrid.CLIENTE].Width = widthTotal / 3;
                gridVeiculos.Columns[(int)ColsGrid.FABRICANTE].Width = widthTotal / 3;
                gridVeiculos.Columns[(int)ColsGrid.MODELO].Width = widthTotal / 3;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmVeiculos_Load(object sender, EventArgs e)
        {
            lblQuantidade.Text = String.Empty;
            OnResize(null);
            btnBuscar.PerformClick();
        }

        private void frmVeiculos_Activated(object sender, EventArgs e)
        {
            try
            {
                General.CarregarComboClientes(txtCliente);
                General.CarregarComboFabricante(txtFabricante);
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
                Close();
            }
            
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            txtPlaca.Text = txtPlaca.Text.ToUpper();
        }

        private void txtFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFabricante.SelectedIndex >= -1 && !String.IsNullOrEmpty(txtFabricante.Text))
            {
                General.CarregarComboModelos(((Fabricantes)txtFabricante.SelectedItem).Id, txtModelo);
            }
        }

        private void ViewCrud(int typeAccess)
        {
            if (typeAccess != (int)General.TypeAccess.CREATE)
            {
                if (IdVeiculoSelecionado == 0)
                {
                    General.MessageShowAttention("Selecione um veículo primeiro!");
                    return;
                }
            }
            new frmVeiculosCrud(IdVeiculoSelecionado, typeAccess).Show();
            Close();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnBuscar.Enabled = false;
            gridVeiculos.Rows.Clear();
            ClientesController clientesController = new ClientesController();
            FabricantesController fabricantesController = new FabricantesController();
            ModelosController modelosController = new ModelosController();
            VeiculosController veiculosController = new VeiculosController();

            Veiculos veiculo = null;
            List<Veiculos> listaVeiculos = null;
            try
            {
                Fabricantes fabricante = null;
                Clientes cliente = null;
                Modelos modelo = new Modelos();
                string placa = String.Empty;

                if (txtFabricante.SelectedIndex > -1 && txtFabricante.Text.Trim().Length > 0)
                {
                    fabricante = fabricantesController.Get(((Fabricantes)txtFabricante.SelectedItem).Id);
                    modelo.Fabricante = fabricante;
                }
                if (txtModelo.SelectedIndex > -1 && txtModelo.Text.Trim().Length > 0) modelo = modelosController.Get(((Modelos)txtModelo.SelectedItem).Id);
                if (txtCliente.SelectedIndex > -1 && txtCliente.Text.Trim().Length > 0) cliente = clientesController.Get(((Clientes)txtCliente.SelectedItem).Id);
                if (txtPlaca.MaskCompleted) placa = txtPlaca.Text.Trim();

                veiculo = new Veiculos(0, placa, modelo, cliente, EnumVeiculos.tipo.Carro);
                listaVeiculos = veiculosController.GetAll(veiculo);
                if (!(listaVeiculos is null))
                {
                    if (listaVeiculos.Count > 0)
                    {
                        gridVeiculos.Rows.Add(listaVeiculos.Count);

                        int row = 0;
                        IdVeiculoSelecionado = listaVeiculos[0].Id;
                        foreach (Veiculos vehicle in listaVeiculos)
                        {
                            gridVeiculos[(int)ColsGrid.ID, row].Value = vehicle.Id.ToString();
                            gridVeiculos[(int)ColsGrid.CLIENTE, row].Value = vehicle.Cliente.Nome.ToString();
                            gridVeiculos[(int)ColsGrid.FABRICANTE, row].Value = vehicle.Modelo.Fabricante.Nome;
                            gridVeiculos[(int)ColsGrid.MODELO, row].Value = vehicle.Modelo.ToString();
                            gridVeiculos[(int)ColsGrid.PLACA, row].Value = vehicle.Placa;

                            row++;
                        }
                    }
                    if (listaVeiculos.Count == 1) lblQuantidade.Text = "1 veiculo encontrado";
                    else lblQuantidade.Text = $"{listaVeiculos.Count} veiculos encontrados";
                }
                else
                {
                    lblQuantidade.Text = "Nenhum veiculo encontrado";
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
                Cursor = Cursors.Default;

                modelosController.Dispose();
                fabricantesController.Dispose();
                if (!(listaVeiculos is null))
                {
                    listaVeiculos.Clear();
                }
            }
        }

        private void gridVeiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdVeiculoSelecionado = 0;

                if (e.RowIndex >= 0)
                {
                    if (!(gridVeiculos[(int)ColsGrid.ID, e.RowIndex].Value is null))
                    {
                        if (gridVeiculos[(int)ColsGrid.ID, e.RowIndex].Value.ToString().Trim().Length > 0)
                        {
                            IdVeiculoSelecionado = int.Parse(gridVeiculos[(int)ColsGrid.ID, e.RowIndex].Value.ToString());
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
    }
}
