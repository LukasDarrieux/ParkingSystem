using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Veiculo;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Shared;
using ParkingSystem.Utils.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ParkingSystem.Models.Estacionamento;
using ParkingSystem.Views;

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
        public const short scroolWidth = 60;
        public const short COMBO_VAZIA = -1;
        public const string SENHA_PADRAO = "1234567890";

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
            int length = 0;
            if (textBox.PasswordChar.ToString() != String.Empty) length = 7;
            
            if (textBox.Text.Trim().Length > length) return true;
            else
            {
                MessageShowAttention($"Informe {nameField.Replace(":", "")}");
                textBox.Focus();
                return false;
            }
        }

        public static bool ValidateDecimalField(TextBox textBox, string nameField)
        {
            if (!ValidateField(textBox, nameField)) return false;

            if (ValidateDecimal(textBox.Text.Trim())) return true;
            else
            {
                MessageShowAttention($"Informe um valor válido para {nameField.Replace(":", "")}");
                textBox.Focus();
                return false;
            }
        }

        public static bool ValidateDateField(MaskedTextBox txtDateTime, string nameField, bool canEmpty)
        {
            if (txtDateTime.Text.Trim().Replace("/", "").Length < 1)
            {
                if (canEmpty) return true;
                
                MessageShowAttention($"Informe {nameField.Replace(":", "")}");
                txtDateTime.Focus();
                return false;
            }
            else
            {
                if (!IsDate(txtDateTime.Text))
                {
                    MessageShowAttention($"Informe uma data válida para {nameField.Replace(":", "")}");
                    txtDateTime.Focus();
                    return false;
                }

                return true;
            }
        }

        public static bool ValidateField(ComboBox comboBox, string nameField)
        {
            if (comboBox.SelectedIndex > -1 && comboBox.Text.Trim().Length > 0) return true;
            else
            {
                MessageShowAttention($"Informe {nameField.Replace(":", "")}");
                comboBox.Focus();
                return false;
            }
        }

        public static bool ValidateField(MaskedTextBox maskedBox, string nameField)
        {
            if (maskedBox.Text.Trim().Length > 0 && maskedBox.MaskCompleted) return true;
            else
            {
                MessageShowAttention($"Informe {nameField.Replace(":", "")}");
                maskedBox.Focus();
                return false;
            }
        }

        public static bool CriarBanco()
        {
            DatabaseCreator DbCreator = DatabaseCreator.GetDatabase(ConfiguracaoDatabase.SGBD, ConfiguracaoDatabase.Server, ConfiguracaoDatabase.AutenticationWindows, ConfiguracaoDatabase.User, ConfiguracaoDatabase.Password);
            bool createDatabase = false;
            try
            {
                DbCreator.CreateDatabase();
                createDatabase = true;
                DbCreator.UpdateDatabase();
                return true;
            }
            catch (Exception error)
            {
                MessageShowError($"Error:\n\n{error.Message}", "Error");
                if (!createDatabase) new frmConfigDatabase().ShowDialog();
                else Application.Exit();
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
                case TypeAccess.READ:
                    title = $"Exibir {nameForm}";
                    break;
                case TypeAccess.UPDATE:
                    title = $"Atualizar {nameForm}";
                    break;
                case TypeAccess.DELETE:
                    title = $"Excluir {nameForm}";
                    break;
            }
            frm.Text = title;
            frm.Refresh();

        }

        public static void CarregarComboFabricante(ComboBox combo)
        {
            List<Fabricantes> listaFabricantes = null;
            try
            {
                object itemSelected = combo.SelectedItem;
                combo.Items.Clear();
                combo.SelectedIndex = COMBO_VAZIA;
                using (FabricantesController fabricanteController = new FabricantesController())
                {
                    listaFabricantes = fabricanteController.GetAll();
                    if (!(listaFabricantes is null))
                    {
                        if (listaFabricantes.Count > 0)
                        {
                            listaFabricantes = listaFabricantes.OrderBy(fabricante => fabricante.Nome).ToList();
                            foreach (Fabricantes fabricante in listaFabricantes)
                            {
                                combo.Items.Add(fabricante);
                            }
                        }
                    }
                }
                combo.SelectedItem = itemSelected;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (!(listaFabricantes is null)) listaFabricantes = null;
            }
        }

        public static void CarregarComboModelos(int IdFabricante, ComboBox combo)
        {
            if (IdFabricante == 0) return;

            Modelos modelo = new Modelos();
            List<Modelos> listaModelos = null;
            try
            {
                object itemSelected = combo.SelectedItem;
                combo.Items.Clear();
                combo.SelectedIndex = COMBO_VAZIA;
                using (FabricantesController fabricanteController = new FabricantesController())
                {
                    modelo.Fabricante = fabricanteController.Get(IdFabricante);

                    using (ModelosController modeloController = new ModelosController())
                    {
                        listaModelos = modeloController.GetAll(modelo);
                        if (!(listaModelos is null))
                        {
                            if (listaModelos.Count > 0)
                            {
                                listaModelos = listaModelos.OrderBy(modelos => modelos.Nome).ToList();
                                foreach (Modelos modelos in listaModelos)
                                {
                                    combo.Items.Add(modelos);
                                }
                            }
                        }
                    }
                }
                combo.SelectedItem = itemSelected;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (!(listaModelos is null)) listaModelos = null;
                modelo.Dispose();
            }
        }

        public static void CarregarComboClientes(ComboBox combo)
        {
            List<Clientes> listaClientes = null;
            try
            {
                object itemSelected = combo.SelectedItem;
                combo.Items.Clear();
                combo.SelectedIndex = COMBO_VAZIA;
                using (ClientesController clienteController = new ClientesController())
                {
                    listaClientes = clienteController.GetAll();
                    if (!(listaClientes is null))
                    {
                        if (listaClientes.Count > 0)
                        {
                            listaClientes = listaClientes.OrderBy(cliente => cliente.Nome).ToList();
                            foreach (Clientes cliente in listaClientes)
                            {
                                combo.Items.Add(cliente);
                            }
                        }
                    }
                }
                combo.SelectedItem = itemSelected;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (!(listaClientes is null)) listaClientes = null;
            }
        }

        public static void CarregarComboVaga(ComboBox combo)
        {
            List<Vagas> listaVagas = null;
            try
            {
                object itemSelected = combo.SelectedItem;
                combo.Items.Clear();
                combo.SelectedIndex = COMBO_VAZIA;
                using (VagasController vagaController = new VagasController())
                {
                    listaVagas = vagaController.GetAll();
                    if (!(listaVagas is null))
                    {
                        if (listaVagas.Count > 0)
                        {
                            listaVagas = listaVagas.OrderBy(vaga => vaga.Vaga).ToList();
                            foreach (Vagas vaga in listaVagas)
                            {
                                combo.Items.Add(vaga);
                            }
                        }
                    }
                }
                combo.SelectedItem = itemSelected;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (!(listaVagas is null)) listaVagas = null;
            }
        }

        public static void CarregarComboVeiculos(int IdCliente, ComboBox combo)
        {
            List<Veiculos> listaVeiculos = null;
            Clientes cliente = null;
            Veiculos veiculos = new Veiculos(0, String.Empty, null, null, EnumVeiculos.tipo.Carro);
            try
            {
                object itemSelected = combo.SelectedItem;
                combo.Items.Clear();
                combo.SelectedIndex = COMBO_VAZIA;
                using (ClientesController clienteController = new ClientesController())
                {
                    cliente = clienteController.Get(IdCliente);
                    veiculos.Cliente = cliente;
                    using (VeiculosController veiculoController = new VeiculosController())
                    {
                        listaVeiculos = veiculoController.GetAll(veiculos);
                        if (!(listaVeiculos is null))
                        {
                            if (listaVeiculos.Count > 0)
                            {
                                listaVeiculos = listaVeiculos.OrderBy(veiculo => veiculo.Modelo.ToString()).ToList();
                                foreach (Veiculos vehicle in listaVeiculos)
                                {
                                    combo.Items.Add(vehicle);
                                }
                            }
                        }
                    }
                }
                combo.SelectedItem = itemSelected;
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                if (!(listaVeiculos is null)) listaVeiculos = null;
            }
        }

        public static void CarregaComboTipoModelo(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Items.Add(EnumVeiculos.tipo.Carro);
            combo.Items.Add(EnumVeiculos.tipo.Moto);

            combo.SelectedItem = EnumVeiculos.tipo.Carro;
        }

        public static bool ValidateCpf(string CPF)
        {
            short[] multiplicador1 = new short[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            short[] multiplicador2 = new short[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string auxCPF, digito;
            int soma = 0; 
            
            CPF = CPF.Trim().Replace(".", "").Replace("-", "").Replace(",", "");

            if (CPF.Length < 11) return false;

            auxCPF = CPF.Substring(0, 9);
            
            for (int i = 0; i < 9; i++)
            {
                soma += short.Parse(auxCPF[i].ToString()) * multiplicador1[i];
            }
            
            int resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();

            auxCPF = auxCPF + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += short.Parse(auxCPF[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            auxCPF = auxCPF + resto;

            if (CPF != auxCPF) return false;
            return true;
        }

        public static bool ValidateDecimal(string value)
        {
            try
            {
                bool hasPointFloat = false;
                for (int contador = 0; contador < value.Length; contador++)
                {
                    if (hasPointFloat && value.Substring(contador, 1) == ",") return false;
                    if (!hasPointFloat && value.Substring(contador, 1) == ",") hasPointFloat = true;
                    if (value.Substring(contador, 1) != "0" &&
                        value.Substring(contador, 1) != "1" &&
                        value.Substring(contador, 1) != "2" &&
                        value.Substring(contador, 1) != "3" &&
                        value.Substring(contador, 1) != "4" &&
                        value.Substring(contador, 1) != "5" &&
                        value.Substring(contador, 1) != "6" &&
                        value.Substring(contador, 1) != "7" &&
                        value.Substring(contador, 1) != "8" &&
                        value.Substring(contador, 1) != "9" &&
                        value.Substring(contador, 1) != ",") return false;
                }
                return true;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public static bool IsNumeric(string value)
        {
            try
            {
                for (int contador = 0; contador < value.Length; contador++)
                {
                    if (value.Substring(contador, 1) != "0" &&
                        value.Substring(contador, 1) != "1" &&
                        value.Substring(contador, 1) != "2" &&
                        value.Substring(contador, 1) != "3" &&
                        value.Substring(contador, 1) != "4" &&
                        value.Substring(contador, 1) != "5" &&
                        value.Substring(contador, 1) != "6" &&
                        value.Substring(contador, 1) != "7" &&
                        value.Substring(contador, 1) != "8" &&
                        value.Substring(contador, 1) != "9") return false;
                }
                return true;
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public static bool IsDate(string date)
        {
            if (date.Trim().Length < 10) return false;
            if (!IsNumeric(date.Trim().Replace("/", "").Replace("-", "").Replace(".", ""))) return false;
            short dia, mes, ano, maiorDiaMes = 0;
            dia = Convert.ToInt16(date.Substring(0, 2));
            mes = Convert.ToInt16(date.Substring(3, 2));
            ano = Convert.ToInt16(date.Substring(6, 4));
            if (dia < 1 || dia > 31) return false; //Validando dia
            if (mes < 1 || mes > 12) return false; //Validando mes
            switch (mes)
            {
                case 2: maiorDiaMes = 28; if (ano % 4 == 0) { maiorDiaMes = 29; } break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: maiorDiaMes = 31; break;
                default: maiorDiaMes = 30; break;
            }
            if (dia > maiorDiaMes) return false;
            return true;
        }

        public static string FormatValue(double value)
        {
            return value.ToString("F2").Replace(",", ".").Trim();
        }

        public static DateTime GetLastDayMonth(int year = 0, int month = 0)
        {
            if (year == uint.MinValue) year = DateTime.Now.Year;
            if (month == uint.MinValue) month = DateTime.Now.Month;

            return new DateTime(year, month, DateTime.DaysInMonth(year, month));
        }

        public static DateTime GetFirstDayMonth(int year = 0, int month = 0)
        {
            if (year == uint.MinValue) year = DateTime.Now.Year;
            if (month == uint.MinValue) month = DateTime.Now.Month;

            return new DateTime(year, month, 1);
        }
    }
}
