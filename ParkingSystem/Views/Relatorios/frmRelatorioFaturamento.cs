using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Estacionamento;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParkingSystem.Views.Relatorios
{
    public partial class frmRelatorioFaturamento : Form
    {

        enum ColsGrid
        {
            ENTRADA,
            SAIDA,
            CLIENTE,
            VEICULO,
            TEMPO,
            VALORTOTAL
        }

        public frmRelatorioFaturamento()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Estacionamentos estacionamento = null;
            List<Estacionamentos> listaEstacionamentos = null;
            gridFaturamento.Rows.Clear();
            try
            {
                if (!General.ValidateDateField(txtDataInicio, "Data Inicial", false)) return;
                if (!General.ValidateDateField(txtDataFim, "Data Final", false)) return;

                DateTime dataInicial = Convert.ToDateTime(txtDataInicio.Text.Replace("/", "-"));
                DateTime dataFinal = Convert.ToDateTime(txtDataFim.Text.Replace("/", "-"));

                estacionamento = new Estacionamentos(0, null, null, dataInicial, dataFinal, 0);

                using (EstacionamentosController estacionamentoController = new EstacionamentosController())
                {
                    listaEstacionamentos = estacionamentoController.GetAll(estacionamento);
                                        
                    if (!(listaEstacionamentos is null) && listaEstacionamentos.Count > 0)
                    {
                        int row = 0;
                        double subTotal = 0;
                        foreach (Estacionamentos parking in listaEstacionamentos)
                        {
                            subTotal += parking.ValorTotal;
                            gridFaturamento.Rows.Add(); 
                            gridFaturamento[(int)ColsGrid.ENTRADA, row].Value = parking.Entrada.ToString();
                            gridFaturamento[(int)ColsGrid.SAIDA, row].Value = parking.Saida.ToString();
                            gridFaturamento[(int)ColsGrid.VEICULO, row].Value = parking.Veiculo.ToString();
                            gridFaturamento[(int)ColsGrid.CLIENTE, row].Value = parking.Veiculo.Cliente.ToString();
                            gridFaturamento[(int)ColsGrid.TEMPO, row].Value = parking.GetTotalHoras();
                            gridFaturamento[(int)ColsGrid.VALORTOTAL, row].Value = parking.ValorTotal.ToString("F2");
                            row++;
                        }

                        if (listaEstacionamentos.Count > 1) lblQuantidade.Text = $"{listaEstacionamentos.Count} registros encontrados.";
                        else lblQuantidade.Text = "1 registro encontrado";

                        lblValorTotal.Text = $"Sub Total: R${subTotal:F2}";
                    }
                    else
                    {
                        lblQuantidade.Text = "Nenhum registro encontrado.";
                        lblValorTotal.Text = "Sub Total: R$0,00";
                    }
                }

            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
            finally
            {
                btnBuscar.Enabled = true;
                Cursor = Cursors.Default;
                if (!(estacionamento is null)) estacionamento.Dispose();
                if (!(listaEstacionamentos is null))
                {
                    listaEstacionamentos.Clear();
                }
            }
        }

        private void frmRelatorioFaturamento_Load(object sender, EventArgs e)
        {
            txtDataInicio.Text = $"01/{DateTime.Now.Month}/{DateTime.Now.Year}";
            DateTime dataFinal = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1).AddDays(-1);
            txtDataFim.Text = dataFinal.ToString("dd/MM/yyyy");
            frmRelatorioFaturamento_Resize(null, null);
        }

        private void frmRelatorioFaturamento_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridFaturamento.Width - gridFaturamento.Columns[(int)ColsGrid.ENTRADA].Width - gridFaturamento.Columns[(int)ColsGrid.SAIDA].Width - gridFaturamento.Columns[(int)ColsGrid.TEMPO].Width - gridFaturamento.Columns[(int)ColsGrid.VALORTOTAL].Width - General.scroolWidth;
                gridFaturamento.Columns[(int)ColsGrid.CLIENTE].Width = widthTotal / 2;
                gridFaturamento.Columns[(int)ColsGrid.VEICULO].Width = widthTotal / 2;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }
    }
}
