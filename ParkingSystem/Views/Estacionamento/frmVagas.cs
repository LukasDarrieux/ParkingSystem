using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Estacionamento;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParkingSystem.Views.Estacionamento
{
    public partial class frmVagas : Form
    {
        private int IdVagaSelecionada = 0;

        public frmVagas()
        {
            InitializeComponent();
        }

        enum ColsGrid
        {
            ID,
            VAGA
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            Cursor = Cursors.WaitCursor;
            gridVagas.Rows.Clear();
            VagasController vagaController = new VagasController();
            Vagas vaga = null;
            List<Vagas> listaVagas = null;
            try
            {
                string nomeVaga = string.Empty;

                if (txtVaga.Text.Trim().Length > 0) nomeVaga = txtVaga.Text;

                vaga = new Vagas(0, nomeVaga);
                listaVagas = vagaController.GetAll(vaga);
                if (!(listaVagas is null))
                {
                    if (listaVagas.Count > 0)
                    {
                        gridVagas.Rows.Add(listaVagas.Count);

                        int row = 0;
                        IdVagaSelecionada = listaVagas[0].Id;
                        foreach (Vagas spaceParking in listaVagas)
                        {
                            gridVagas[(int)ColsGrid.ID, row].Value = spaceParking.Id.ToString();
                            gridVagas[(int)ColsGrid.VAGA, row].Value = spaceParking.Vaga;

                            row++;
                        }
                    }
                    if (listaVagas.Count == 1) lblQuantidade.Text = "1 vaga encontrada";
                    else lblQuantidade.Text = $"{listaVagas.Count} vagas encontradas";
                }
                else
                {
                    lblQuantidade.Text = "Nenhuma vaga encontrada";
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

                vagaController.Dispose();
                if (!(vaga is null)) vaga.Dispose();
                if (!(listaVagas is null))
                {
                    listaVagas.Clear();
                }
            }
        }

        private void frmVaga_Load(object sender, EventArgs e)
        {
            try
            {
                lblQuantidade.Text = String.Empty;
                OnResize(null);
                btnBuscar.PerformClick();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmVaga_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridVagas.Width - gridVagas.Columns[(int)ColsGrid.ID].Width - General.scroolWidth;
                gridVagas.Columns[(int)ColsGrid.VAGA].Width = widthTotal;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void ViewCrud(int typeAccess)
        {
            if (typeAccess != (int)General.TypeAccess.CREATE)
            {
                if (IdVagaSelecionada == 0)
                {
                    General.MessageShowAttention("Selecione uma vaga primeiro!");
                    return;
                }
            }
            using (var frm = new frmVagasCrud(IdVagaSelecionada, typeAccess))
            {
                frm.Show();
            }
            Close();
        }

        private void gridVagas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdVagaSelecionada = 0;

                if (e.RowIndex >= 0)
                {
                    if (!(gridVagas[(int)ColsGrid.ID, e.RowIndex].Value is null))
                    {
                        if (gridVagas[(int)ColsGrid.ID, e.RowIndex].Value.ToString().Trim().Length > 0)
                        {
                            IdVagaSelecionada = int.Parse(gridVagas[(int)ColsGrid.ID, e.RowIndex].Value.ToString());
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
