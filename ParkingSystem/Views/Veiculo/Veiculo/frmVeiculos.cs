using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.Views.Veiculo.Veiculo
{
    public partial class frmVeiculos : Form
    {
        public frmVeiculos()
        {
            InitializeComponent();
        }

        enum ColsGrid
        {
            ID,
            CLIENTE,
            FABRICANTE,
            MODELO,
            PLACA
        }

        private void frmVeiculos_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridVeiculos.Width - gridVeiculos.Columns[(int)ColsGrid.ID].Width - gridVeiculos.Columns[(int)ColsGrid.PLACA].Width - General.scroolWidth;
                gridVeiculos.Columns[(int)ColsGrid.CLIENTE].Width = widthTotal / 3;
                gridVeiculos.Columns[(int)ColsGrid.FABRICANTE].Width = widthTotal / 3;
                gridVeiculos.Columns[(int)ColsGrid.MODELO].Width = widthTotal / 3;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }

        private void frmVeiculos_Load(object sender, EventArgs e)
        {
            this.OnResize(null);
        }
    }
}
