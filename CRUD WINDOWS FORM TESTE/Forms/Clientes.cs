using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_WINDOWS_FORM_TESTE.Models;
using CRUD_WINDOWS_FORM_TESTE.Services;

namespace CRUD_WINDOWS_FORM_TESTE.Forms
{
    public partial class Clientes : Form
    {
        private readonly ClientsService clientService;
        public Clientes()
        {
            InitializeComponent();
            var context = new PostgresContext();
            clientService = new ClientsService(context);
        }

        //Load da tabela de clientes
        private async void clientSearch_Click(object sender, EventArgs e)
        {
            await LoadClients();
        }

        private async void Clientes_Load(object sender, EventArgs e)
        {
            await LoadClients();
        }

        private async void RefreshDataGrid()
        {
            await LoadClients();
        }

        private async Task LoadClients()
        {
            try
            {
                var clientes = await clientService.GetAllClients();
                dgClients.DataSource = clientes;

                dgClients.Columns["Active"].Visible = false;
                dgClients.Columns["Sales"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os clientes: " + ex.Message);
            }
        }
        //Fim da área de load
        //Create associado ao botão adicionar Cliente
        private async void clientCreate_Click(object sender, EventArgs e)
        {

            string name = clientName.Text.Trim();
            string address = clientAddress.Text.Trim();
            string email = clientEmail.Text.Trim();
            string phone = clientPhone.Text.Trim();
            string DDD = clientDDD.Text.Trim();
            // Validação dos campos
            if (!IsValidInput(name, "name") || !IsValidInput(address, "address") || !IsValidInput(DDD, "DDD") || !IsValidInput(phone, "phone") || !IsValidInput(email, "email"))
            {
                return;
            }

            // Objeto cliente
            var cliente = new Clients
            {
                Name = name,
                Address = address,
                DDD = DDD,
                Phone = phone,
                Email = email
            };

            try
            {
                await clientService.CreateClient(cliente.Name, cliente.Address, cliente.DDD, cliente.Phone, cliente.Email);
                MessageBox.Show("Cliente criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                RefreshDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fim da área de create
        // Área dos métodos de checagem
        private bool IsValidInput(string input, string fieldType)
        {
            if (string.IsNullOrEmpty(input))
            {
                ShowError($"Por favor, insira o {fieldType}.");
                return false;
            }

            if (fieldType == "email" && (!input.Contains("@") || !input.Contains(".")))
            {
                ShowError("Por favor, insira um e-mail válido.");
                return false;
            }

            if (fieldType == "DDD" && (input.Length != 2 || !input.All(char.IsDigit)))
            {
                ShowError("Por favor, insira um DDD válido com 2 dígitos.");
                return false;
            }

            if (fieldType == "phone" && (input.Length < 8 || input.Length > 9 || !input.All(char.IsDigit)))
            {
                ShowError("Por favor, insira um telefone válido com 8 ou 9 dígitos.");
                return false;
            }

            return true;
        }


        //Fim da área dos métodos de checagem
        //Funções globais
        // Mensagem de erro
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Fim das funções globais
        // Limpar os campos
        private void ClearFields()
        {
            clientName.Clear();
            clientAddress.Clear();
            clientDDD.Clear();
            clientPhone.Clear();
            clientEmail.Clear();
        }

        //Delete ao selecionar na grid
        private async void clientDelete_Click(object sender, EventArgs e)
        {
            if (dgClients.SelectedRows.Count > 0)
            {
                var clientId = dgClients.SelectedRows[0].Cells["Id"].Value;
                var clientName = dgClients.SelectedRows[0].Cells["name"].Value;
                var result = MessageBox.Show($"Tem certeza que deseja excluir o cliente {clientName}?",
                                              "Confirmar Exclusão", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await clientService.DeleteClient(Id: (int)clientId);
                        MessageBox.Show("Cliente excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshDataGrid();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Area do Update
        //Função para sinalização do update
        private void clientUpdate_Click(object sender, EventArgs e)
        {
            if (dgClients.SelectedRows.Count > 0)
            {
                //Obtendo os dados da grid
                var Id = dgClients.SelectedRows[0].Cells["Id"].Value;
                var Name = dgClients.SelectedRows[0].Cells["nome"].Value;
                var Address = dgClients.SelectedRows[0].Cells["address"].Value;
                var DDD = dgClients.SelectedRows[0].Cells["ddd"].Value;
                var Phone = dgClients.SelectedRows[0].Cells["tel"].Value;
                var Email = dgClients.SelectedRows[0].Cells["email"].Value;

                //Preenchendo as textbox
                clientName.Text = Name.ToString();
                clientAddress.Text = Address.ToString();
                clientDDD.Text = DDD.ToString();
                clientPhone.Text = Phone.ToString();
                clientEmail.Text = Email.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void saveUpdate_Click(object sender, EventArgs e)
        {
            //Verifica se um cliente foi selecionado pela grid
            if (dgClients.SelectedRows.Count > 0)
            {
                //Verificação adicionada após erro onde o valor de ID não é válido.
                var clientIdValue = dgClients.SelectedRows[0].Cells["Id"].Value?.ToString() ?? string.Empty;

                if (!int.TryParse(clientIdValue, out int clientId))
                {
                    MessageBox.Show("ID do cliente inválido ou ausente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var Name = clientName.Text.ToString();
                var Address = clientAddress.Text.ToString();
                var DDD = clientDDD.Text.ToString();
                var Phone = clientPhone.Text.ToString();
                var Email = clientEmail.Text.ToString();

                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email))
                {
                    MessageBox.Show("Preencha todos os campos para atualizar o cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    await clientService.UpdateClient(clientId, Name, Address, DDD, Phone, Email);

                    MessageBox.Show("Cliente atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDataGrid();
                    ClearFields();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
