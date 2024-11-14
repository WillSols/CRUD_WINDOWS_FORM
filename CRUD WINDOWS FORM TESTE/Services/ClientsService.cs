using CRUD_WINDOWS_FORM_TESTE.Forms;
using CRUD_WINDOWS_FORM_TESTE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD_WINDOWS_FORM_TESTE.Services
{
    public class ClientsService
    {
        private readonly PostgresContext _context;

        public ClientsService(PostgresContext context)
        {
            _context = context;
        }

        //Create dos clientes
        public async Task<string> CreateClient(string name, string address, string ddd, string phone, string email)
        {
            var existingClient = await _context.Clients.Where(c => c.Name == name || c.Phone == phone || c.Email == email).FirstOrDefaultAsync(); // Quando sobrar um tempo ver se esse lambda é decente fiz as pressas.

            if (existingClient != null)
            {
                if (existingClient.Active)
                {
                    return "Já existe um cliente com o mesmo nome, telefone ou email e está ativo.";
                }
                else
                {
                    // Atualiza os dados do cliente e reativa ele
                    existingClient.Active = true;
                    existingClient.Address = address;
                    existingClient.DDD = ddd;
                    existingClient.Phone = phone;
                    existingClient.Email = email;

                    await _context.SaveChangesAsync();
                    return "Cliente reativado e atualizado com sucesso!";
                }
            }

            // Caso não exista cliente, cria um novo
            var newClient = new Clients
            {
                Name = name,
                Address = address,
                DDD = ddd,
                Phone = phone,
                Email = email,
                Active = true
            };

            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();
            return "Cliente adicionado com sucesso!";
        }


        //Read dos clientes
        public async Task<List<Clients>> GetAllClients()
        {
            return await _context.Clients.Where(client => client.Active).ToListAsync();
        }

        //Update dos clientes
        public async Task UpdateClient(int clientId, string name, string address, string ddd, string phone, string email)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client != null)
            {
                client.Name = name;
                client.Address = address;
                client.DDD = ddd;
                client.Phone = phone;
                client.Email = email;

                await _context.SaveChangesAsync();
            }
            else 
            {
                throw new ArgumentException("Cliente não encontrado.");
            }
            
        }

        //Delete por meio do ID
        public async Task DeleteClient(int? Id = null)
        {
            if (!Id.HasValue)
            {
                throw new ArgumentException("É necessário fornecer o Id do cliente.");
            }

            var client = await _context.Clients.FindAsync(Id.Value);

            if (client == null)
            {
                throw new ArgumentException("Cliente não encontrado na base de dados.");
            } 
            else if (!client.Active)
            {
                throw new ArgumentException("Cliente não está ativo na base de dados.");
            }

            client.Active = false;
            await _context.SaveChangesAsync();
        }

    }
}

