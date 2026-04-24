using MiniERP.Web.Data;
using MiniERP.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniERP.Web.Services
{
    /// <summary>
    ///  Serviço responsável pela lógica de negócio dos clientes
    /// </summary>
    public class ClienteService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o DbContext
        /// </summary>

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devolve todos os clientes
        /// </summary>
        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        /// <summary>
        /// Devolve um cliente pelo ID
        /// </summary>
        public async Task<Cliente> GetByIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
            }
            return cliente;
        }

        /// <summary>
        /// Adiciona um novo cliente
        /// </summary>
        public async Task AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Atualiza um novo cliente
        /// </summary>
        public async Task UpdateAsync(Cliente cliente)
        {
            var existente = await _context.Clientes.FindAsync(cliente.Id);

            if (existente != null)
            {
                existente.Nome = cliente.Nome;
                existente.Email = cliente.Email;
                existente.Telefone = cliente.Telefone;
                existente.NomeEmpresa = cliente.NomeEmpresa;

                await _context.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Remove um novo cliente
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }



    }
}
