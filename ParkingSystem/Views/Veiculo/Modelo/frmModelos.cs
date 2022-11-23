using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Veiculo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParkingSystem.Views.Veiculo.Modelo
{
    public partial class frmModelos : Form
    {

        private int IdModeloSelecionado = 0;

        public frmModelos()
        {
            InitializeComponent();
        }

        enum ColsGrid
        {
            ID,
            FABRICANTE,
            MODELO,
            MOTOR,
            ANO
        }

        private void frmModelo_Activated(object sender, EventArgs e)
        {
            General.CarregarComboFabricante(txtFabricante);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnBuscar.Enabled = false;
            gridModelos.Rows.Clear();
            ModelosController modeloController = new ModelosController();
            FabricantesController fabricanteController = new FabricantesController();
            Modelos modelo = null;
            List<Modelos> listaModelos = null;
            try
            {
                string nomeModelo = String.Empty;
                Fabricantes fabricante = null;
                string motor = String.Empty;
                int ano = 0;

                if (txtFabricante.SelectedIndex > -1 && txtFabricante.Text.Trim().Length > 0) fabricante = fabricanteController.Get(((Fabricantes)txtFabricante.SelectedItem).Id);
                if (txtModelo.Text.Trim().Length > 0) nomeModelo = txtModelo.Text;
                if (txtMotor.Text.Trim().Length > 0) motor = txtMotor.Text.Trim();
                if (txtAno.Text.Trim().Length > 0) ano = int.Parse(txtAno.Text.Trim());


                modelo = new Modelos(0, nomeModelo, motor, ano, fabricante);
                listaModelos = modeloController.GetAll(modelo);
                if (!(listaModelos is null))
                {
                    if (listaModelos.Count > 0)
                    {
                        gridModelos.Rows.Add(listaModelos.Count);

                        int row = 0;
                        IdModeloSelecionado = listaModelos[0].Id;
                        foreach (Modelos model in listaModelos)
                        {
                            gridModelos[(int)ColsGrid.ID, row].Value = model.Id.ToString();
                            gridModelos[(int)ColsGrid.FABRICANTE, row].Value = model.Fabricante.Nome;
                            gridModelos[(int)ColsGrid.MODELO, row].Value = model.Nome;
                            gridModelos[(int)ColsGrid.MOTOR, row].Value = model.Motor.ToString();
                            gridModelos[(int)ColsGrid.ANO, row].Value = model.Ano.ToString();

                            row++;
                        }
                    }
                    if (listaModelos.Count == 1) lblQuantidade.Text = "1 modelo encontrado";
                    else lblQuantidade.Text = $"{listaModelos.Count} modelos encontrados";
                }
                else
                {
                    lblQuantidade.Text = "Nenhum modelo encontrado";
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

                modeloController.Dispose();
                fabricanteController.Dispose();
                if (!(modelo is null)) modelo.Dispose();
                if (!(listaModelos is null))
                {
                    listaModelos.Clear();
                }
            }
        }

        private void frmModelo_Load(object sender, EventArgs e)
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

        private void frmModelo_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridModelos.Width - gridModelos.Columns[(int)ColsGrid.ID].Width - gridModelos.Columns[(int)ColsGrid.ANO].Width - gridModelos.Columns[(int)ColsGrid.MOTOR].Width -  General.scroolWidth;
                gridModelos.Columns[(int)ColsGrid.FABRICANTE].Width = widthTotal / 2;
                gridModelos.Columns[(int)ColsGrid.MODELO].Width = widthTotal / 2;
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
                if (IdModeloSelecionado == 0)
                {
                    General.MessageShowAttention("Selecione um modelo primeiro!");
                    return;
                }
            }
            frmModelosCrud modeloCrud = new frmModelosCrud(IdModeloSelecionado, typeAccess);
            modeloCrud.Show();
            Close();
        }

        private void gridModelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdModeloSelecionado = 0;

                if (e.RowIndex >= 0)
                {
                    if (!(gridModelos[(int)ColsGrid.ID, e.RowIndex].Value is null))
                    {
                        if (gridModelos[(int)ColsGrid.ID, e.RowIndex].Value.ToString().Trim().Length > 0)
                        {
                            IdModeloSelecionado = Int16.Parse(gridModelos[(int)ColsGrid.ID, e.RowIndex].Value.ToString());
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
