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
        public async Task<Cliente?> GetClienteAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        /// <summary>
        /// Devolve um cliente pelo ID
        /// </summary>
        public async Task<Cliente> GetByIdAsync (int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
            }
            return cliente;
        }



        

    }
}
