using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD_WINDOWS_FORM_TESTE.Models;
using CRUD_WINDOWS_FORM_TESTE.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CRUD_WINDOWS_FORM_TESTE.Forms
{
    public partial class Produtos : Form
    {
        private readonly ProductService productService;
        public Produtos()
        {
            InitializeComponent();
            var context = new PostgresContext();
            productService = new ProductService(context);
        }

        //Create
        private async void productCreate_Click(object sender, EventArgs e)
        {
            string name = productName.Text.Trim();
            string desc = productDescription.Text.Trim();
            decimal price = decimal.TryParse(productPrice.Text.Trim(), out decimal result) ? result : 0m;
            int stock = int.TryParse(productStock.Text.Trim(), out int phone) ? phone : 0;
            string sku = productSKU.Text.Trim();

            if (!IsValidInput(name, "name") || !IsValidInput(price.ToString(), "price") || !IsValidInput(stock.ToString(), "stock") || !IsValidInput(sku, "sku"))
            {
                return;
            }

            var product = new Products
            {
                Name = name,
                Description = desc,
                Price = price,
                Stock = stock,
                SKU = sku,
            };

            try
            {
                await productService.CreateProduct(product.Name, product.Description, product.Price, product.Stock, product.SKU);
                MessageBox.Show("Produto adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                RefreshDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar o produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpar os campos
        private void ClearFields()
        {
            productName.Clear();
            productDescription.Clear();
            productPrice.Clear();
            productStock.Clear();
            productSKU.Clear();
        }

        //Área dos métodos de checagem
        private bool IsValidInput(string input, string fieldType)
        {
            if (string.IsNullOrEmpty(input))
            {
                Clientes.ShowError($"Por favor, insira o {fieldType}.");
                return false;
            }

            if (fieldType == "price")
            {
                if (!decimal.TryParse(input, System.Globalization.NumberStyles.AllowDecimalPoint,
                                      System.Globalization.CultureInfo.CurrentCulture, out decimal price) ||
                    price <= 0 || input.Split(',')[1].Length != 2)
                {
                    Clientes.ShowError("Por favor, insira um preço válido no formato de exemplo: '11,99'.");
                    return false;
                }
            }

            return true;
        }

        //Load Específico para os produtos
        private async Task LoadProducts()
        {
            try
            {
                var clientes = await productService.GetAllProducts();
                dgProduct.DataSource = clientes;

                dgProduct.Columns["Active"].Visible = false;
                dgProduct.Columns["Sales"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os Produtos: " + ex.Message);
            }
        }

        //Botão de atualizar
        private async void productSearch_Click(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        //Função de refresh
        private async void RefreshDataGrid()
        {
            await LoadProducts();
        }

        private async void Produtos_Load(object sender, EventArgs e)
        {
            await LoadProducts();
        }
        //Area do Update
        //Função para sinalização do update
        private void productUpdate_Click(object sender, EventArgs e)
        {
            if (dgProduct.SelectedRows.Count > 0)
            {
                //Obtendo os dados da grid
                var productId = dgProduct.SelectedRows[0].Cells["ProductId"].Value;
                var name = dgProduct.SelectedRows[0].Cells["Name"].Value;
                var desc = dgProduct.SelectedRows[0].Cells["Description"].Value;
                var price = dgProduct.SelectedRows[0].Cells["Price"].Value;
                var sku = dgProduct.SelectedRows[0].Cells["SKU"].Value;
                var stock = dgProduct.SelectedRows[0].Cells["Stock"].Value;

                //Preenchendo as textbox
                productName.Text = name.ToString();
                productDescription.Text = desc.ToString();
                productPrice.Text = price.ToString();
                productSKU.Text = sku.ToString();
                productStock.Text = stock.ToString();

                //Mensagem indicadora da edição
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void productSaveUpdate_Click(object sender, EventArgs e)
        {
            if (dgProduct.SelectedRows.Count > 0)
            {
                var productIdValue = dgProduct.SelectedRows[0].Cells["ProductId"].Value?.ToString() ?? string.Empty;

                if (!int.TryParse(productIdValue, out int productId))
                {
                    MessageBox.Show("ID do produto inválido ou ausente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var Name = productName.Text.ToString();
                var Desc = productDescription.Text.ToString();
                decimal price = decimal.TryParse(productPrice.Text.Trim(), out decimal priceResult) ? priceResult : 0m;
                var SKU = productSKU.Text.ToString();
                int stock = int.TryParse(productStock.Text.Trim(), out int result) ? result : 0;

                if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(SKU))
                {
                    MessageBox.Show("Preencha todos os campos para atualizar o produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    await productService.UpdateProduct(productId, Name, Desc, price, SKU, stock);

                    MessageBox.Show("Produto atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Selecione um produto para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void productDelete_Click(object sender, EventArgs e)
        {
            if (dgProduct.SelectedRows.Count > 0)
            {
                var productId = dgProduct.SelectedRows[0].Cells["ProductId"].Value;
                var productName = dgProduct.SelectedRows[0].Cells["name"].Value;
                var result = MessageBox.Show($"Tem certeza que deseja excluir o produto {productName}?",
                                              "Confirmar Exclusão", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        await productService.DeleteProduct(Id: (int)productId);
                        MessageBox.Show("Produto excluído com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Selecione um produto para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
