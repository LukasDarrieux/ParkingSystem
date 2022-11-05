using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem.Shared;
using ParkingSystem.Views.Login;

namespace ParkingSystem.Views.Splash
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            lblVersao.Text = General.version;
            lblVersao.Refresh();
        }

        private void UpdateProgress(int value, string msg)
        {
            lblStatus.Text = msg;
            lblStatus.Refresh();

            progress.Value = value;
            progress.Refresh();

            this.Refresh();
        }

        private void frmSplash_Activated(object sender, EventArgs e)
        {
            this.Refresh();
            UpdateProgress(10, "Iniciando sistema...");
            Thread.Sleep(1000);

            UpdateProgress(30, "Carregando configurações da base de dados...");
            General.CarregarConfiguracoes();
            Thread.Sleep(1000);

            UpdateProgress(60, "Conectando com a base de dados...");
            Thread.Sleep(1000);
            if (General.CriarBanco())
            {
                UpdateProgress(90, "Carregando configurações...");
                Configuracoes.LoadConfiguracaoEstacionamento();
                Thread.Sleep(1000);

                UpdateProgress(100, "Iniciando...");
                Thread.Sleep(500);
                new frmLogin(true).Show();
                this.Visible = false;
            }
        }
    }
}
