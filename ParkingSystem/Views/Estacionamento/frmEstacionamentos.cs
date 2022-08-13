using ParkingSystem.Models.Cliente;
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
            STATUS
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
                int widthTotal = gridEstacionamento.Width - gridEstacionamento.Columns[(int)ColsGrid.ID].Width - gridEstacionamento.Columns[(int)ColsGrid.VAGA].Width - gridEstacionamento.Columns[(int)ColsGrid.ENTRADA].Width - gridEstacionamento.Columns[(int)ColsGrid.STATUS].Width - General.scroolWidth;
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
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            frmEntrada frmEntrada = new frmEntrada();
            frmEntrada.Show();
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
