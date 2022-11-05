using System;
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
            if (rdMySQL.Checked)
            {
                chkUsarAutenticacaoWindows.Checked = false;
                chkUsarAutenticacaoWindows.Visible = false;
            }
            GroupConfigEnabled();
        }

        private void GroupConfigEnabled()
        {
            groupConfig.Enabled = DatabaseChecked();

            txtUsuario.Enabled = !chkUsarAutenticacaoWindows.Checked;
            txtSenha.Enabled = !chkUsarAutenticacaoWindows.Checked;

            ClearFields();
        }

        private void ClearFields()
        {
            if (chkUsarAutenticacaoWindows.Checked)
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
            if (rdSQLServer.Checked)
            {
                chkUsarAutenticacaoWindows.Checked = false;
                chkUsarAutenticacaoWindows.Visible = true;
            }
            GroupConfigEnabled();
        }

        private void frmConfigDatabase_Load(object sender, EventArgs e)
        {
            try
            {
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
                if (!chkUsarAutenticacaoWindows.Checked)
                {
                    if (!General.ValidateField(txtUsuario, lblUsuario.Text)) return;
                }

                bool resposta = General.MessageQuestion("Ao salvar as novas configurações de banco de dados, será necessário reiniciar o sistema.\n\nDeseja continuar?");

                if (resposta)
                {
                    LeitorConfiguracoes.WriteFileConfig(GetTipoDatabase(), txtServidor.Text, chkUsarAutenticacaoWindows.Checked, txtUsuario.Text, txtSenha.Text);
                    ConfiguracaoDatabase.SetConfig(GetTipoDatabase().ToString(), txtServidor.Text, chkUsarAutenticacaoWindows.Checked, txtUsuario.Text, txtSenha.Text);
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
                if (ConfiguracaoDatabase.SGBD == Database.Tipo.MySQL) rdMySQL.Checked = true;
                else
                {
                    rdSQLServer.Checked = true;
                    chkUsarAutenticacaoWindows.Checked = ConfiguracaoDatabase.AutenticationWindows;
                }

                if (ConfiguracaoDatabase.Server.Trim().Length > uint.MinValue) txtServidor.Text = ConfiguracaoDatabase.Server;
                if (ConfiguracaoDatabase.User.Trim().Length > uint.MinValue) txtUsuario.Text = ConfiguracaoDatabase.User;
                if (ConfiguracaoDatabase.Password.Trim().Length > uint.MinValue) txtSenha.Text = ConfiguracaoDatabase.Password;
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void chkUsarAutenticacaoWindows_CheckedChanged(object sender, EventArgs e)
        {
            GroupConfigEnabled();
        }
    }
}
