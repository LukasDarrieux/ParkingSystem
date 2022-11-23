using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Estacionamento;
using System;
using System.Windows.Forms;

namespace ParkingSystem.Views.Estacionamento
{
    public partial class frmVagasCrud : Form
    {
        private General.TypeAccess TipoAcesso;
        private int IdVaga;

        public frmVagasCrud(int idVaga, int tipoAcesso)
        {
            IdVaga = idVaga;
            TipoAcesso = (General.TypeAccess)tipoAcesso;
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadVaga()
        {
            using (VagasController vagaController = new VagasController())
            {
                using (Vagas vaga = vagaController.Get(IdVaga))
                {
                    if (!(vaga is null))
                    {
                        txtVaga.Text = vaga.Vaga;
                    }
                }
            }
        }

        private void CreateVaga()
        {
            using (VagasController vagaController = new VagasController())
            {
                using (Vagas vaga = new Vagas(0, txtVaga.Text))
                {
                    if (vagaController.Insert(vaga))
                    {
                        Close();
                    }
                }
            }
        }

        private void UpdateVaga()
        {
            using (VagasController vagaController = new VagasController())
            {
                using (Vagas vaga = new Vagas(IdVaga, txtVaga.Text))
                {
                    if (vagaController.Update(vaga))
                    {
                        Close();
                    }
                }
            }
        }

        private void DeleteVaga()
        {
            using (VagasController vagaController = new VagasController())
            {
                using (Vagas vaga = new Vagas(IdVaga, txtVaga.Text))
                {
                    if (General.MessageQuestion("Tem certeza que deseja excluir esta vaga?"))
                    {
                        if (vagaController.Delete(vaga))
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
                Refresh();
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
            txtVaga.Enabled = false;
            if (IsView) btnSalvar.Visible = false;
        }

        private void frmVagasCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmVagas frmVaga = new frmVagas();
                frmVaga.Show();
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!General.ValidateField(txtVaga, lblVaga.Text)) return;

                switch (TipoAcesso)
                {
                    case General.TypeAccess.CREATE:
                        CreateVaga();
                        break;
                    case General.TypeAccess.UPDATE:
                        UpdateVaga();
                        break;
                    case General.TypeAccess.DELETE:
                        DeleteVaga();
                        break;
                }

            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmVagasCrud_Load(object sender, EventArgs e)
        {
            try
            {
                General.ChangeTitleForm(this, "Vaga", TipoAcesso);

                if (TipoAcesso != General.TypeAccess.CREATE)
                {
                    LoadVaga();
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
    }
}
