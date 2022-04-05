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
    public partial class frmModelo : Form
    {
        public frmModelo()
        {
            InitializeComponent();
        }

        private void frmModelo_Activated(object sender, EventArgs e)
        {
            CarregarComboFabricante(txtFabricante);
        }

        private void CarregarComboFabricante(ComboBox combo)
        {
            List<Fabricantes> listaFabricantes = null;
            try
            {
                combo.Items.Clear();
                using (FabricantesController fabricanteController = new FabricantesController())
                {
                    listaFabricantes = fabricanteController.GetAll();
                    if (!(listaFabricantes is null))
                    {
                        if (listaFabricantes.Count > 0)
                        {
                            foreach (Fabricantes fabricante in listaFabricantes)
                            {
                                combo.Items.Add(fabricante);
                            }
                        }
                    }
                }
            }
            catch(Exception error)
            {
                throw error;
            }
            finally
            {
                if (!(listaFabricantes is null))
                {
                    listaFabricantes = null;
                }
            }
        }
    }
}
