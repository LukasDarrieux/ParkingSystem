﻿using ParkingSystem.Controller.Implements;
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
                estacionamento = new Estacionamentos(0, null, veiculo, DateTime.MinValue, null, 0);

                using (EstacionamentosController estacionamentoController = new EstacionamentosController())
                {
                    listaEstacionamentos = estacionamentoController.GetAll(estacionamento);

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
                            gridEstacionamento[(int)ColsGrid.STATUS, row].Value = String.Empty; //parking.Saida.ToString();
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
                    listaEstacionamentos = null;
                }
            }
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
            finally
            {

            }
        }
    }
}
