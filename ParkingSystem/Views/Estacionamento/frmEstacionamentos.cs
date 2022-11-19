using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Models.Estacionamento;
using ParkingSystem.Models.Veiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.Views.Estacionamento
{
    public partial class frmEstacionamentos : Form
    {
        private int IdEstacionamento = 0;

        public frmEstacionamentos()
        {
            InitializeComponent();
        }

        enum ColsGrid
        {
            ID,
            VAGA,
            VEICULO,
            CLIENTE,
            ENTRADA,
            TEMPO
        }

        private void frmEstacionamentos_Activated(object sender, EventArgs e)
        {
            General.CarregarComboClientes(txtCliente);
            txtCliente_SelectedIndexChanged(null, null);
        }

        private void txtCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int IdCliente = 0;
                if (!(txtCliente.SelectedItem is null)) IdCliente = ((Clientes)txtCliente.SelectedItem).Id;
                General.CarregarComboVeiculos(IdCliente, txtVeiculo);
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCliente.Text.Trim().Length == 0)
                {
                    General.CarregarComboVeiculos(0, txtVeiculo);
                }
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmEstacionamentos_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridEstacionamento.Width - gridEstacionamento.Columns[(int)ColsGrid.ID].Width - gridEstacionamento.Columns[(int)ColsGrid.VAGA].Width - gridEstacionamento.Columns[(int)ColsGrid.ENTRADA].Width - gridEstacionamento.Columns[(int)ColsGrid.TEMPO].Width - General.scroolWidth;
                gridEstacionamento.Columns[(int)ColsGrid.CLIENTE].Width = widthTotal / 2;
                gridEstacionamento.Columns[(int)ColsGrid.VEICULO].Width = widthTotal / 2;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmEstacionamentos_Load(object sender, EventArgs e)
        {
            frmEstacionamentos_Resize(null, null);
            txtDataInicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDataFim.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnBuscar_Click(null, null);
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            this.Close();
            frmEntrada frmEntrada = new frmEntrada();
            frmEntrada.Show();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Estacionamentos estacionamento = null;
            Veiculos veiculo = null;
            List<Estacionamentos> listaEstacionamentos = null;
            gridEstacionamento.Rows.Clear();
            try
            {
                if (txtVeiculo.SelectedIndex > -1 && txtVeiculo.Text.Trim().Length > 0) veiculo = (Veiculos)txtVeiculo.SelectedItem;
                if (!General.ValidateDateField(txtDataInicio, "Data Inicial", false)) return;
                if (!General.ValidateDateField(txtDataFim, "Data Final", false)) return;

                DateTime dataInicial = Convert.ToDateTime(txtDataInicio.Text.Replace("/", "-"));
                DateTime dataFinal = Convert.ToDateTime(txtDataFim.Text.Replace("/", "-"));

                estacionamento = new Estacionamentos(0, null, veiculo, dataInicial, dataFinal, 0);

                using (EstacionamentosController estacionamentoController = new EstacionamentosController())
                {
                    listaEstacionamentos = estacionamentoController.GetAll(estacionamento, true);

                    if (!(listaEstacionamentos is null) && listaEstacionamentos.Count > 0)
                    {
                        int row = 0;

                        foreach (Estacionamentos parking in listaEstacionamentos)
                        {
                            gridEstacionamento.Rows.Add();
                            gridEstacionamento[(int)ColsGrid.ID, row].Value = parking.Id;
                            gridEstacionamento[(int)ColsGrid.VAGA, row].Value = parking.Vaga.ToString();
                            gridEstacionamento[(int)ColsGrid.VEICULO, row].Value = parking.Veiculo.ToString();
                            gridEstacionamento[(int)ColsGrid.CLIENTE, row].Value = parking.Veiculo.Cliente.ToString();
                            gridEstacionamento[(int)ColsGrid.ENTRADA, row].Value = parking.Entrada.ToString();
                            gridEstacionamento[(int)ColsGrid.TEMPO, row].Value = parking.GetTotalHoras();
                            row++;   
                        }
                    }
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
                if (!(estacionamento is null)) estacionamento.Dispose();
                if (!(veiculo is null)) veiculo.Dispose();
                if (!(listaEstacionamentos is null)) 
                { 
                    listaEstacionamentos.Clear();
                }
            }
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdEstacionamento == 0)
                {
                    General.MessageShowAttention("Selecione um estacionamento primeiro!");
                    return;
                }
                new frmSaida(IdEstacionamento).Show();
                this.Close();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
            finally
            {

            }
        }

        private void gridEstacionamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdEstacionamento = 0;

                if (e.RowIndex >= 0)
                {
                    if (!(gridEstacionamento[(int)ColsGrid.ID, e.RowIndex].Value is null))
                    {
                        if (gridEstacionamento[(int)ColsGrid.ID, e.RowIndex].Value.ToString().Trim().Length > 0)
                        {
                            IdEstacionamento = Int16.Parse(gridEstacionamento[(int)ColsGrid.ID, e.RowIndex].Value.ToString());
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
