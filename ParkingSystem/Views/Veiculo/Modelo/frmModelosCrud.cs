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

namespace ParkingSystem.Views.Veiculo.Modelo
{
    public partial class frmModelosCrud : Form
    {
        private General.TypeAccess TipoAcesso;
        private int IdModelo;

        public frmModelosCrud(int idModelo, int tipoAcesso)
        {
            this.IdModelo = idModelo;
            TipoAcesso = (General.TypeAccess)tipoAcesso;
            InitializeComponent();
        }

        private void frmModelosCrud_Load(object sender, EventArgs e)
        {
            try
            {
                General.ChangeTitleForm(this, "Modelo", TipoAcesso);
                General.CarregarComboFabricante(txtFabricante);

                if (TipoAcesso != General.TypeAccess.CREATE)
                {
                    LoadModelos();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!General.ValidateField(txtFabricante, lblFabricante.Text)) return;
                if (!General.ValidateField(txtModelo, lblModelo.Text)) return;
                if (!General.ValidateField(txtMotor, lblModelo.Text)) return;
                if (!General.ValidateField(txtAno, lblAno.Text)) return;

                switch (this.TipoAcesso)
                {
                    case General.TypeAccess.CREATE:
                        CreateModelos();
                        break;
                    case General.TypeAccess.UPDATE:
                        UpdateModelos();
                        break;
                    case General.TypeAccess.DELETE:
                        DeleteModelos();
                        break;
                }


            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void CreateModelos()
        {
            using (FabricantesController fabricanteController = new FabricantesController())
            {
                using (Fabricantes fabricante = fabricanteController.Get(((Fabricantes)txtFabricante.SelectedItem).Id))
                {
                    using (ModelosController modeloController = new ModelosController())
                    {
                        using (Modelos modelo = new Modelos(0, txtModelo.Text, txtMotor.Text, int.Parse(txtAno.Text), fabricante))
                        {
                            if(modeloController.Insert(modelo))
                            {
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void UpdateModelos()
        {
            using (FabricantesController fabricanteController = new FabricantesController())
            {
                using (Fabricantes fabricante = fabricanteController.Get(((Fabricantes)txtFabricante.SelectedItem).Id))
                {
                    using (ModelosController modeloController = new ModelosController())
                    {
                        using (Modelos modelo = new Modelos(this.IdModelo, txtModelo.Text, txtMotor.Text, int.Parse(txtAno.Text), fabricante))
                        {
                            if (modeloController.Update(modelo))
                            {
                                this.Close();
                            }
                        }
                    }
                }
            }
        }

        private void DeleteModelos()
        {
            using (FabricantesController fabricanteController = new FabricantesController())
            {
                using (Fabricantes fabricante = fabricanteController.Get(((Fabricantes)txtFabricante.SelectedItem).Id))
                {
                    using (ModelosController modeloController = new ModelosController())
                    {
                        using (Modelos modelo = new Modelos(this.IdModelo, txtModelo.Text, txtMotor.Text, int.Parse(txtAno.Text), fabricante))
                        {
                            if (General.MessageQuestion("Tem certeza que deseja excluir este modelo?"))
                            { 
                                if (modeloController.Delete(modelo))
                                {
                                    this.Close();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LoadModelos()
        {
            using (ModelosController modeloController = new ModelosController())
            {
                using (Modelos modelo = modeloController.Get(IdModelo))
                {
                    if (!(modelo is null))
                    {
                        txtFabricante.SelectedItem = modelo.Fabricante;
                        txtModelo.Text = modelo.Nome;
                        txtMotor.Text = modelo.Motor;
                        txtAno.Text = modelo.Ano.ToString();
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
                this.Refresh();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void DisableControls(bool IsView = false)
        {
            txtFabricante.Enabled = false;
            txtModelo.Enabled = false;
            txtMotor.Enabled = false;
            txtAno.Enabled = false;
            if (IsView) btnSalvar.Visible = false;
        }

        private void frmModelosCrud_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmModelos frmModelo = new frmModelos();
                frmModelo.Show();
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }
    }
}
