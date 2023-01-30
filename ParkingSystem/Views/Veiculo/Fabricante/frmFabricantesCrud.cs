using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Veiculo;
using System;
using System.Windows.Forms;

namespace ParkingSystem.Views.Veiculo.Fabricante
{
    public partial class frmFabricantesCrud : Form
    {
        private readonly General.TypeAccess TipoAcesso;
        private readonly int IdFabricante;

        public frmFabricantesCrud(int idFabricante, int tipoAcesso)
        {
            IdFabricante = idFabricante;
            TipoAcesso = (General.TypeAccess)tipoAcesso;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFabricanteCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                new frmFabricantes().Show();
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmFabricanteCrud_Load(object sender, EventArgs e)
        {
            try
            {
                General.ChangeTitleForm(this, "Fabricante", TipoAcesso);

                if (TipoAcesso != General.TypeAccess.CREATE)
                {
                    LoadFabricante();
                }

                switch (TipoAcesso)
                {
                    case General.TypeAccess.DELETE:
                        OnlyDelete();
                        break;

                    case General.TypeAccess.READ:
                        OnlyView();
                        break;

                }
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!General.ValidateField(txtFabricante, lblFabricante.Text)) return;

                switch (TipoAcesso)
                {
                    case General.TypeAccess.CREATE:
                        CreateFabricante();
                        break;
                    case General.TypeAccess.UPDATE:
                        UpdateFabricante();
                        break;
                    case General.TypeAccess.DELETE:
                        DeleteFabricante();
                        break;
                }

            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void LoadFabricante()
        {
            using (FabricantesController fabricanteController = new FabricantesController())
            {
                using (Fabricantes fabricante = fabricanteController.Get(IdFabricante))
                {
                    if (!(fabricante is null))
                    {
                        txtFabricante.Text = fabricante.Nome;
                    }
                }
            }
        }

        private void CreateFabricante()
        {
            using (FabricantesController fabricanteController = new FabricantesController())
            {
                using (Fabricantes fabricante = new Fabricantes(0, txtFabricante.Text))
                {
                    if (fabricanteController.Insert(fabricante))
                    {
                        Close();
                    }
                }
            }
        }

        private void UpdateFabricante()
        {
            using (FabricantesController fabricanteController = new FabricantesController())
            {
                using (Fabricantes fabricante = new Fabricantes(IdFabricante, txtFabricante.Text))
                {
                    if (fabricanteController.Update(fabricante))
                    {
                        Close();
                    }
                }
            }
        }

        private void DeleteFabricante()
        {
            using (FabricantesController fabricanteController = new FabricantesController())
            {
                using (Fabricantes fabricante = new Fabricantes(IdFabricante, txtFabricante.Text))
                {
                    if (General.MessageQuestion("Tem certeza que deseja excluir este fabricante?"))
                    {
                        if (fabricanteController.Delete(fabricante))
                        {
                            Close();
                        }
                    }

                }
            }
        }

        private void OnlyView()
        {
            try
            {
                DisableControls(true);

                btnCancelar.Left = (this.Width / 2) - (btnCancelar.Width / 2);
                this.Refresh();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void OnlyDelete()
        {
            try
            {
                DisableControls();
                btnSalvar.Text = "Excluir";
                Refresh();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void DisableControls(bool IsView = false)
        {
            txtFabricante.Enabled = false;
            if (IsView) btnSalvar.Visible = false;
        }
    }
}
