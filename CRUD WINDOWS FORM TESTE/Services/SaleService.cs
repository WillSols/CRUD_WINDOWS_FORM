using CRUD_WINDOWS_FORM_TESTE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_WINDOWS_FORM_TESTE.Services
{
    public class SaleService
    {
        private readonly PostgresContext _context;

        public SaleService(PostgresContext context)
        {
            _context = context;
        }

        //O create sale vai agregar e verificar as informações das tabelas
        public async Task<string> CreateSale(int? clientId, List<(int productId, string productName, int quantity, decimal unitPrice)> productSales, DateOnly? saleDate)
        {
            if (!clientId.HasValue || productSales == null || !productSales.Any())
                return "Cliente e ao menos um produto são obrigatórios.";

            var client = await _context.Clients.FindAsync(clientId.Value);
            if (client == null)
                return "Cliente não encontrado.";

            var saleDateValue = saleDate ?? DateOnly.FromDateTime(DateTime.Today);


            Guid? groupId = productSales.Count > 1 ? Guid.NewGuid() : (Guid?)null;
            string groupIdString = groupId.HasValue ? groupId.Value.ToString("N").Substring(0, 4) : null;  

            foreach (var productSale in productSales)
            {
                var product = await _context.Products.FindAsync(productSale.productId);
                if (product == null)
                    return $"Produto {productSale.productName} não encontrado.";

                if (productSale.quantity > product.Stock)
                    return $"Estoque insuficiente para o produto {productSale.productName}.";

                var saleItem = new Sale
                {
                    ClientId = clientId,
                    ProductId = productSale.productId,
                    ProductName = productSale.productName,
                    Qty = productSale.quantity,
                    UnitPrice = productSale.unitPrice,
                    SaleDate = saleDateValue,
                    Active = true,
                    Client = client,
                    Product = product,
                    GroupId = groupIdString 
                };

                _context.Sales.Add(saleItem);
                product.Stock -= productSale.quantity;
            }

            await _context.SaveChangesAsync();
            return "Venda criada com sucesso!";
        }




        //Read
        public async Task<List<Sale>> GetAllSales()
        {
            return await _context.Sales
                .Where(sale => sale.Active)
                .Select(sale => new Sale
                {
                    SaleId = sale.SaleId,
                    ClientId = sale.ClientId,
                    GroupId = sale.GroupId,
                    ProductId = sale.ProductId,
                    SaleDate = sale.SaleDate,
                    Qty = sale.Qty,
                    UnitPrice = sale.UnitPrice,
                    Active = sale.Active,
                    ClientName = _context.Clients.Where(c => c.Id == sale.ClientId).Select(c => c.Name).FirstOrDefault(),
                    ProductName = _context.Products.Where(p => p.ProductId == sale.ProductId).Select(p => p.Name).FirstOrDefault()
                })
                .ToListAsync();
        }

        //Update
        public async Task UpdateSale(int saleId, string clientName, string productName, DateOnly saleDate, int qty)
        {
            var sale = await _context.Sales.FindAsync(saleId);

            if (sale == null)
            {
                throw new ArgumentException("Venda não encontrada.");
            }

            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Name == clientName);
            if (client == null)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == productName);
            if (product == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            sale.ClientId = client.Id;
            sale.ProductId = product.ProductId;
            sale.SaleDate = saleDate != default ? saleDate : DateOnly.FromDateTime(DateTime.Today); ;
            sale.Qty = qty;
            sale.UnitPrice = product.Price;

            await _context.SaveChangesAsync();
        }


        // Delete por meio do ID, não achei necessário a possibilidade de reativar uma venda.
        public async Task DeleteSale(int? id = null)
        {
            if (!id.HasValue)
            {
                throw new ArgumentException("É necessário fornecer o Id da venda.");
            }

            var sale = await _context.Sales.FindAsync(id.Value);

            if (sale == null)
            {
                throw new ArgumentException("Venda não encontrada na base de dados.");
            }

            sale.Active = false;

            await _context.SaveChangesAsync();
        }

    }
}
