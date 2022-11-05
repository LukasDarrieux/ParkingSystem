using ParkingSystem.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem.Views.Config
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            try
            {
                txtTitulo.Text = Configuracoes.GetConfiguracaoPersonalizacao().Titulo;
                txtCarro.Text = Configuracoes.GetConfiguracaoEstacionamento().Carro.ToString("F2");
                txtMoto.Text = Configuracoes.GetConfiguracaoEstacionamento().Moto.ToString("F2");
                txtPerNoite.Text = Configuracoes.GetConfiguracaoEstacionamento().PerNoite.ToString("F2");
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
                return;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!General.ValidateDecimalField(txtCarro, lblCarro.Text)) return;
                if (!General.ValidateDecimalField(txtMoto, lblMoto.Text)) return;
                if (!General.ValidateDecimalField(txtPerNoite, lblPerNoite.Text)) return;

                double valorCarro = Convert.ToDouble(txtCarro.Text);
                double valorMoto = Convert.ToDouble(txtMoto.Text);
                double valorPerNoite = Convert.ToDouble(txtPerNoite.Text);

                Configuracoes.AtualizarConfiguracaoPersonalizacao(txtTitulo.Text);
                Configuracoes.AtualizaConfiguracaoEstacionamento(valorCarro, valorMoto, valorPerNoite);


                return;
            }
            catch(Exception error)
            {
                General.MessageShowError(error.Message);
                return;
            }
        }

        private void txtCarro_Validated(object sender, EventArgs e)
        {
            if (General.ValidateDecimal(txtCarro.Text))
            {
                txtCarro.Text =  Convert.ToDouble(txtCarro.Text).ToString("F2");
            }
        }

        private void txtMoto_Validated(object sender, EventArgs e)
        {
            if (General.ValidateDecimal(txtMoto.Text))
            {
                txtMoto.Text = Convert.ToDouble(txtMoto.Text).ToString("F2");
            }
        }

        private void txtPerNoite_Validated(object sender, EventArgs e)
        {
            if (General.ValidateDecimal(txtPerNoite.Text))
            {
                txtPerNoite.Text = Convert.ToDouble(txtPerNoite.Text).ToString("F2");
            }
        }
    }
}
