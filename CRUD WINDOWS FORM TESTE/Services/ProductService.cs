using CRUD_WINDOWS_FORM_TESTE.Forms;
using CRUD_WINDOWS_FORM_TESTE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_WINDOWS_FORM_TESTE.Services
{
    public class ProductService
    {
        private readonly PostgresContext _context;

        public ProductService(PostgresContext context)
        {
            _context = context;
        }

        //Create dos produtos
        public async Task<string> CreateProduct(string name, string description, decimal price, int stock, string sku)
        {
            var existingProduct = await _context.Products.Where(p => p.Name == name || p.SKU == sku).FirstOrDefaultAsync();

            if (existingProduct != null)
            {
                if (existingProduct.Active)
                {
                    return "Já existe um produto com o mesmo nome ou SKU e está ativo.";
                }
                else
                {
                    existingProduct.Active = true;
                    existingProduct.Description = description;
                    existingProduct.Price = price;
                    existingProduct.Stock = stock;
                    existingProduct.SKU = sku;

                    await _context.SaveChangesAsync();
                    return "Produto reativado e atualizado com sucesso!";
                }
            }

            var newProduct = new Products
            {
                Name = name,
                Description = description,
                Price = price,
                Stock = stock,
                SKU = sku,
                Active = true
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return "Produto adicionado com sucesso!";
        }


        //Read dos Produtos
        public async Task<List<Products>> GetAllProducts()
        {
            return await _context.Products.Where(product => product.Active).ToListAsync();
        }

        //Update dos clientes
        public async Task UpdateProduct(int productId, string name, string description, decimal price, string sku, int stock)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.ProductId = productId;
                product.Name = name;
                product.Description = description;
                product.Price = price;
                product.SKU = sku;
                product.Stock = stock;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Cliente não encontrado.");
            }

        }

        //Delete dos Produtos

        public async Task DeleteProduct(int? Id = null)
        {
            if (!Id.HasValue)
            {
                throw new ArgumentException("É necessário fornecer o selecionar um produto válido.");
            }

            var product = await _context.Products.FindAsync(Id.Value);

            if (product == null || !product.Active)
            {
                throw new ArgumentException("Produto não encontrado na base de dados.");
            }
            else if (!product.Active)
            {
                throw new ArgumentException("Produto não está ativo na base de dados.");
            }

            product.Active = false;
            await _context.SaveChangesAsync();
        }
    }
}
