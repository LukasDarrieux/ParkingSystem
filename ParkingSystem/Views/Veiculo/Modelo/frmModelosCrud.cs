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
        private int IdModelo;

        public frmModelosCrud(int idModelo, int tipoAcesso)
        {
            InitializeComponent();
            this.IdModelo = idModelo;
        }

        private void frmModelosCrud_Load(object sender, EventArgs e)
        {

        }
    }
}
