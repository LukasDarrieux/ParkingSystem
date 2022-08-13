using ParkingSystem.Controller.Implements;
using ParkingSystem.Models.Veiculo;
using ParkingSystem.Models.Cliente;
using ParkingSystem.Shared;
using ParkingSystem.Utils.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParkingSystem.Models.Estacionamento;

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

        public static bool ValidateField(ComboBox comboBox, string nameField)
        {
            if (comboBox.SelectedIndex > -1 && comboBox.Text.Trim().Length > 0) return true;
            else
            {
                MessageShowAttention($"Informe {nameField}");
                comboBox.Focus();
                return false;
            }
        }

        public static bool ValidateField(MaskedTextBox maskedBox, string nameField)
        {
            if (maskedBox.Text.Trim().Length > 0 && maskedBox.MaskCompleted) return true;
            else
            {
                MessageShowAttention($"Informe {nameField}");
                maskedBox.Focus();
                return false;
            }
        }

        public static bool CriarBanco()
        {
            DatabaseCreator DbCreator = DatabaseCreator.GetDatabase(Configuracoes.SGBD, Configuracoes.Server, Configuracoes.AutenticationWindows, Configuracoes.User, Configuracoes.Password);
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

        public static void CarregarComboFabricante(ComboBox combo)
        {
            List<Fabricantes> listaFabricantes = null;
            try
            {
                object itemSelected = combo.SelectedItem;
                combo.Items.Clear();
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

        public static bool ValidateCpf(string CPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string auxCPF, digito;
            int soma = 0, resto = 0;
            int qtdCaracter = Convert.ToInt16(CPF.Length);

            CPF = CPF.Trim().Replace(".", "").Replace("-", "").Replace(",", "");

            if (CPF.Length < 11) return false;

            auxCPF = CPF.Substring(0, 9);
            
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(auxCPF[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            digito = resto.ToString();

            auxCPF = auxCPF + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(auxCPF[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;

            auxCPF = auxCPF + resto;

            if (CPF != auxCPF) return false;
            return true;
        }
    }
}
