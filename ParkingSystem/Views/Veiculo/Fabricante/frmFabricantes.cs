using ParkingSystem.Controller.Implements;
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

namespace ParkingSystem.Views.Veiculo.Fabricante
{
    public partial class frmFabricantes : Form
    {
        private int IdFabricanteSelecionado = 0;

        public frmFabricantes()
        {
            InitializeComponent();
        }

        enum ColsGrid
        {
            ID,
            FABRICANTE
        }

        private void frmFabricantes_Load(object sender, EventArgs e)
        {
            try
            {
                lblQuantidade.Text = String.Empty;
                this.OnResize(null);
                btnBuscar.PerformClick();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmFabricantes_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridFabricantes.Width - gridFabricantes.Columns[(int)ColsGrid.ID].Width - General.scroolWidth;
                gridFabricantes.Columns[(int)ColsGrid.FABRICANTE].Width = widthTotal;
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
                if (IdFabricanteSelecionado == 0)
                {
                    General.MessageShowAttention("Selecione um fabricante primeiro!");
                    return;
                }
            }
            frmFabricantesCrud fabricanteCrud = new frmFabricantesCrud(IdFabricanteSelecionado, typeAccess);
            fabricanteCrud.Show();
            this.Close();
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
            btnBuscar.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            gridFabricantes.Rows.Clear();
            FabricantesController fabricanteController = new FabricantesController();
            Fabricantes fabricante = null;
            List<Fabricantes> listaFabricantes = null;
            try
            {
                string nomeFabricante = String.Empty;

                if (txtFabricante.Text.Trim().Length > 0) nomeFabricante = txtFabricante.Text;
                

                fabricante = new Fabricantes(0, nomeFabricante);
                listaFabricantes = fabricanteController.GetAll(fabricante);
                if (!(listaFabricantes is null))
                {
                    if (listaFabricantes.Count > 0)
                    {
                        gridFabricantes.Rows.Add(listaFabricantes.Count);

                        int row = 0;
                        IdFabricanteSelecionado = listaFabricantes[0].Id;
                        foreach (Fabricantes maker in listaFabricantes)
                        {
                            gridFabricantes[(int)ColsGrid.ID, row].Value = maker.Id.ToString();
                            gridFabricantes[(int)ColsGrid.FABRICANTE, row].Value = maker.Nome;
                            
                            row++;
                        }
                    }
                    if (listaFabricantes.Count == 1) lblQuantidade.Text = "1 fabricante encontrado";
                    else lblQuantidade.Text = $"{listaFabricantes.Count.ToString()} fabricantes encontrados";
                }
                else
                {
                    lblQuantidade.Text = "Nenhum fabricante encontrado";
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
                this.Cursor = Cursors.Default;

                fabricanteController.Dispose();
                if (!(fabricante is null)) fabricante.Dispose();
                if (!(listaFabricantes is null))
                {
                    listaFabricantes.Clear();
                    listaFabricantes = null;
                }
            }
        }

        private void gridFabricantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdFabricanteSelecionado = 0;

                if (e.RowIndex >= 0)
                {
                    if (!(gridFabricantes[(int)ColsGrid.ID, e.RowIndex].Value is null))
                    {
                        if (gridFabricantes[(int)ColsGrid.ID, e.RowIndex].Value.ToString().Trim().Length > 0)
                        {
                            IdFabricanteSelecionado = Int16.Parse(gridFabricantes[(int)ColsGrid.ID, e.RowIndex].Value.ToString());
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
