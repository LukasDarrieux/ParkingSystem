using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Estacionamento;
using System;
using System.Windows.Forms;

namespace ParkingSystem.Views.Estacionamento
{
    public partial class frmSaida : Form
    {
        private int IdEstacionamento;
        private Estacionamentos Estacionamento;

        public frmSaida(int idEstacionamento)
        {
            IdEstacionamento = idEstacionamento;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                using (EstacionamentosController estacionamentoController = new EstacionamentosController())
                {
                    if (estacionamentoController.Update(Estacionamento))
                    {
                        Close();
                    }
                }
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmSaida_Load(object sender, EventArgs e)
        {
            try
            {
                using (EstacionamentosController estacionamentoController = new EstacionamentosController())
                {
                    Estacionamento = estacionamentoController.Get(IdEstacionamento);
                    
                    if (!(Estacionamento is null))
                    {
                        Estacionamento.Saida = DateTime.Now;
                        Estacionamento.ValorTotal = Estacionamento.Veiculo.GetSubTotal(Estacionamento.Entrada);

                        txtCliente.Text = Estacionamento.Veiculo.Cliente.Nome;
                        txtVeiculo.Text = Estacionamento.Veiculo.ToString();
                        txtVaga.Text = Estacionamento.Vaga.ToString();
                        txtHora.Text = Estacionamento.Entrada.ToString();
                        txtTempoTotal.Text = Estacionamento.GetTotalHoras();
                        txtSubTotal.Text = Estacionamento.ValorTotal.ToString("F2");
                    }
                    
                }
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmSaida_FormClosed(object sender, FormClosedEventArgs e)
        {
            new frmEstacionamentos().Show();
            if (!(Estacionamento is null)) Estacionamento.Dispose();
        }
    }
}
