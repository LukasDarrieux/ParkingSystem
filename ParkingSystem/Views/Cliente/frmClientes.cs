using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.Views.Cliente
{
    public partial class frmClientes : Form
    {

        private enum ColsGrid
        {
            ID = 0,
            NOME,
            EMAIL
        }

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Resize(object sender, EventArgs e)
        {
            try
            {
                int widthTotal = gridClientes.Width - gridClientes.Columns[(int)ColsGrid.ID].Width - General.scroolWidth;

                gridClientes.Columns[(int)ColsGrid.NOME].Width = widthTotal / 2;
                gridClientes.Columns[(int)ColsGrid.EMAIL].Width = widthTotal / 2;
            }
            catch (Exception error)
            {
                General.MessageShowError(error.Message);
            }
        }
    }
}
