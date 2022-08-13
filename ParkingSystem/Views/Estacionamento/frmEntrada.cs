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
    public partial class frmEntrada : Form
    {
        public frmEntrada()
        {
            InitializeComponent();
        }

        private void frmEntrada_Load(object sender, EventArgs e)
        {
            General.CarregarComboVaga(txtVaga);
            General.CarregarComboClientes(txtCliente);
            txtCliente_SelectedIndexChanged(null, null);
            timer.Enabled = true;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!General.ValidateField(txtCliente, lblVaga.Text)) return;
            if (!General.ValidateField(txtVeiculo, lblVaga.Text)) return;
            if (!General.ValidateField(txtVaga, lblVaga.Text)) return;

            using (EstacionamentosController estacionamentoController = new EstacionamentosController())
            {
                using (VeiculosController veiculosController = new VeiculosController())
                {
                    Veiculos veiculos = veiculosController.Get(((Veiculos)txtVeiculo.SelectedItem).Id);
                    Estacionamentos estacionamento = new Estacionamentos(0, ((Vagas)txtVaga.SelectedItem), veiculos, DateTime.Now, null, 0);

                    if (estacionamentoController.Insert(estacionamento))
                    {
                        this.Close();
                    }
                }   
            }
        }

        private void frmEntrada_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Enabled = false;
            frmEstacionamentos frmEstacionamento = new frmEstacionamentos();
            frmEstacionamento.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
