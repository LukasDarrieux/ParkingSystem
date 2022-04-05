using ParkingSystem.Shared;
using ParkingSystem.Utils.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem
{
    class General
    {
        public enum TypeAccess
        {
            CREATE = 0,
            READ,
            UPDATE,
            DELETE
        }

        public const string DIRETORIO = "C:\\ParkingSystem\\";
        public const string ARQUIVOCONFIG = "config.json";
        public static string version = "1.0.0";
        public const int scroolWidth = 60;

        public static void MessageShowAttention(string msg, string title = "Atenção")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void MessageShowError(string msg, string title = "Error")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MessageShow(string msg, string title = "")
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool MessageQuestion(string msg, string title = "")
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static bool ValidateField(TextBox textBox, string nameField)
        {
            if (textBox.Text.Trim().Length > 0) return true;
            else
            {
                MessageShowAttention($"Informe {nameField}");
                textBox.Focus();
                return false;
            }
        }

        public static bool CriarBanco()
        {
            DatabaseCreator DbCreator = DatabaseCreator.GetDatabase(Configuracoes.SGBD, Configuracoes.Server, Configuracoes.User, Configuracoes.Password);
            try
            {
                DbCreator.CreateDatabase();
                DbCreator.UpdateDatabase();
                return true;
            }
            catch (Exception error)
            {
                General.MessageShowError($"Error:\n\n{error.Message}", "Error");
                Application.Exit();
                return false;
            }
            finally
            {
                DbCreator.Dispose();
            }
        }

        public static void CarregarConfiguracoes()
        {
            LeitorConfiguracoes.LoadConfig();
        }

        public static void ChangeTitleForm(Form frm, string nameForm,TypeAccess TipoAcesso)
        {
            string title = String.Empty;
            switch (TipoAcesso)
            {
                case TypeAccess.CREATE:
                    title = $"Criar {nameForm}";
                    break;
                case General.TypeAccess.READ:
                    title = $"Exibir {nameForm}";
                    break;
                case General.TypeAccess.UPDATE:
                    title = $"Atualizar {nameForm}";
                    break;
                case General.TypeAccess.DELETE:
                    title = $"Excluir {nameForm}";
                    break;
            }
            frm.Text = title;
            frm.Refresh();

        }
    }
}
