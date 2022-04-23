using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem.Shared;
using ParkingSystem.Utils.Implements;

namespace ParkingSystem.Views
{
    public partial class frmConfigDatabase : Form
    {
        public frmConfigDatabase()
        {
            InitializeComponent();
        }

        private void rdMySQL_CheckedChanged(object sender, EventArgs e)
        {
            GroupConfigEnabled();
        }

        private void GroupConfigEnabled()
        {
            groupConfig.Enabled = DatabaseChecked();

            txtUsuario.Enabled = rdMySQL.Checked;
            txtSenha.Enabled = rdMySQL.Checked;

            ClearFields();
        }

        private void ClearFields()
        {
            if (!rdMySQL.Checked)
            {
                txtUsuario.Clear();
                txtSenha.Clear();
            }
        }

        private bool DatabaseChecked()
        {
            return (rdMySQL.Checked || rdSQLServer.Checked);
        }

        private void rdSQLServer_CheckedChanged(object sender, EventArgs e)
        {
            GroupConfigEnabled();
        }

        private void frmConfigDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                GroupConfigEnabled();
                LoadConfig();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DatabaseChecked())
                {
                    General.MessageShowAttention("Selecione um banco de dados");
                    return;
                }

                if (!General.ValidateField(txtServidor, lblServidor.Text)) return;
                if (rdMySQL.Checked)
                {
                    if (!General.ValidateField(txtUsuario, lblUsuario.Text)) return;
                }
                

                bool resposta = General.MessageQuestion("Ao salvar as novas configurações de banco de dados, será necessário reiniciar o sistema.\n\nDeseja continuar?");

                if (resposta)
                {
                    LeitorConfiguracoes.WriteFileConfig(GetTipoDatabase(), txtServidor.Text, txtUsuario.Text, txtSenha.Text);
                    Configuracoes.SetConfig(GetTipoDatabase().ToString(), txtServidor.Text, txtUsuario.Text, txtSenha.Text);
                    Application.Exit();
                }
                else
                {
                    this.Close();
                }
                

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private Database.Tipo GetTipoDatabase()
        {
            if (rdMySQL.Checked) return Database.Tipo.MySQL;
            else return Database.Tipo.SQLServer;
        }

        private void LoadConfig()
        {
            try
            {
                if (Configuracoes.SGBD == Database.Tipo.MySQL) rdMySQL.Checked = true;
                else rdSQLServer.Checked = true;

                if (Configuracoes.Server.Trim().Length > uint.MinValue) txtServidor.Text = Configuracoes.Server;
                if (Configuracoes.User.Trim().Length > uint.MinValue) txtUsuario.Text = Configuracoes.User;
                if (Configuracoes.Password.Trim().Length > uint.MinValue) txtSenha.Text = Configuracoes.Password;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}
