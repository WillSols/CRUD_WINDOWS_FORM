using CRUD_WINDOWS_FORM_TESTE.Models;
using CRUD_WINDOWS_FORM_TESTE.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_WINDOWS_FORM_TESTE.Forms
{
    public partial class Sales : Form
    {
        private readonly PostgresContext context;
        private readonly SaleService saleService;
        public Sales()
        {
            InitializeComponent();
            context = new PostgresContext();
            saleService = new SaleService(context);
        }

        //Read
        private async void saleList_Click(object sender, EventArgs e)
        {
            await LoadSales();
        }

        private async Task LoadSales()
        {
            try
            {
                var sales = await saleService.GetAllSales();
                dgSales.DataSource = sales;

                dgSales.Columns["Active"].Visible = false;
                dgSales.Columns["ClientId"].Visible = false;
                dgSales.Columns["ProductId"].Visible = false;
                dgSales.Columns["Client"].Visible = false;
                dgSales.Columns["Product"].Visible = false;

                dgSales.Columns["ClientName"].HeaderText = "Client";
                dgSales.Columns["ProductName"].HeaderText = "Product";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar as vendas: " + ex.Message);
            }
        }

        //Fim do read
        //Manutenção
        private void ClearSalesFields()
        {
            saleName.Clear();
            saleProductName.Clear();
            saleDate.Checked = false;
            saleQty.Clear();
        }

        private async void RefreshDataGrid()
        {
            await LoadSales();
        }
        private async void Sales_Load(object sender, EventArgs e)
        {
            await LoadSales();
        }
        private bool IsValidInput(string input, string fieldType)
        {
            if (string.IsNullOrEmpty(input))
            {
                Clientes.ShowError($"Por favor, insira o {fieldType}.");
                return false;
            }

            return true;
        }
        //Fim das funções de manutenção;

        //Create

        public async void saleCreate_Click(object sender, EventArgs e)
        {
      
            string clientName = saleName.Text.Trim();
            //Caso venha lista
            var productNameList = saleProductName.Text.Trim().Split(',').Select(p => p.Trim()).ToList();
            var quantityList = saleQty.Text.Trim().Split(',').Select(q => q.Trim()).ToList();

            //Verificações
            if (string.IsNullOrEmpty(clientName) || productNameList.Count == 0 || quantityList.Count == 0 || productNameList.Count != quantityList.Count)
            {
                MessageBox.Show("Preencha todos os campos corretamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var client = await context.Clients.FirstOrDefaultAsync(c => c.Name == clientName && c.Active);
            if (client == null)
            {
                MessageBox.Show("Cliente não encontrado ou não ativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //


            var productSales = new List<(int productId, string productName, int quantity, decimal unitPrice)>();

            for (int i = 0; i < productNameList.Count; i++)
            {
                var product = await context.Products.FirstOrDefaultAsync(p => p.Name == productNameList[i] && p.Active);
                if (product == null)
                {
                    MessageBox.Show($"Produto '{productNameList[i]}' não encontrado ou não ativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(quantityList[i], out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Quantidade inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                productSales.Add((product.ProductId, product.Name, quantity, product.Price));
            }

            try
            {
                var result = await saleService.CreateSale(client.Id, productSales, saleDate.Checked ? DateOnly.FromDateTime(saleDate.Value.Date) : (DateOnly?)null);

                if (result == "Venda criada com sucesso!")
                {
                    MessageBox.Show(result, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearSalesFields();
                    RefreshDataGrid();
                }
                else
                {
                    MessageBox.Show(result, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar vendas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Update
        private void saleUpdate_Click(object sender, EventArgs e)
        {
            if (dgSales.SelectedRows.Count > 0)
            {

                var saleId = dgSales.SelectedRows[0].Cells["SaleId"].Value;
                var clientName = dgSales.SelectedRows[0].Cells["ClientName"].Value;
                var productName = dgSales.SelectedRows[0].Cells["ProductName"].Value;
                var qty = dgSales.SelectedRows[0].Cells["Qty"].Value;
                var saleDatePicker = dgSales.SelectedRows[0].Cells["SaleDate"].Value;


                saleName.Text = clientName.ToString();
                saleProductName.Text = productName.ToString();
                saleQty.Text = qty.ToString();

                if (saleDate != null)
                {
                    saleDate.Value = DateTime.Parse(saleDatePicker.ToString());
                }

            }
            else
            {
                MessageBox.Show("Selecione uma venda para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void saleUpdateSave_Click(object sender, EventArgs e)
        {
            if (dgSales.SelectedRows.Count > 0)
            {
                var saleIdValue = dgSales.SelectedRows[0].Cells["SaleId"].Value?.ToString() ?? string.Empty;

                if (!int.TryParse(saleIdValue, out int saleId))
                {
                    MessageBox.Show("ID da venda inválido ou ausente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var clientName = saleName.Text.Trim();
                var productName = saleProductName.Text.Trim();
                int quantity = int.TryParse(saleQty.Text.Trim(), out int qtyResult) ? qtyResult : 0;
                DateOnly saleDatePicker = DateOnly.FromDateTime(saleDate.Value.Date);


                if (string.IsNullOrEmpty(clientName) || string.IsNullOrEmpty(productName) || quantity <= 0)
                {
                    MessageBox.Show("Preencha todos os campos corretamente para atualizar a venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {

                    await saleService.UpdateSale(saleId, clientName, productName, saleDatePicker, quantity);

                    MessageBox.Show("Venda atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDataGrid();
                    ClearSalesFields();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma venda para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete
        private async void saleDelete_Click(object sender, EventArgs e)
        {
            if (dgSales.SelectedRows.Count > 0)
            {
                var saleId = dgSales.SelectedRows[0].Cells["SaleId"].Value;
                var clientName = dgSales.SelectedRows[0].Cells["ClientName"].Value;
                var productName = dgSales.SelectedRows[0].Cells["ProductName"].Value;

                var result = MessageBox.Show($"Tem certeza que deseja excluir a venda do cliente {clientName} para o produto {productName}?",
                                             "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await saleService.DeleteSale((int)saleId);
                        MessageBox.Show("Venda excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshDataGrid();
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao excluir a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma venda para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
