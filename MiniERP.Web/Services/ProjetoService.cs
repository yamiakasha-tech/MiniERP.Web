using MiniERP.Web.Data;
using MiniERP.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniERP.Web.Services
{
    /// <summary>
    /// Serviço de gestão de projetos
    /// </summary>
    public class ProjetoService
    {
        private readonly ApplicationDbContext _context;

        public ProjetoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todos os projetos com cliente
        /// </summary>
        public async Task<List<Projeto>> GetAllAsync()
        {
            return await _context.Projetos
                .Include(p => p.Cliente)
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona projeto
        /// </summary>
        public async Task AddAsync(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza projeto
        /// </summary>
        public async Task UpdateAsync(Projeto projeto)
        {
            var existente = await _context.Projetos.FindAsync(projeto.Id);

            if (existente != null)
            {
                existente.Nome = projeto.Nome;
                existente.ClienteId = projeto.ClienteId;
                existente.DataInicio = projeto.DataInicio;
                existente.DataFim = projeto.DataFim;
                existente.Orcamento = projeto.Orcamento;
                existente.Estado = projeto.Estado;

                await _context.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Remove projeto
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var projeto = await _context.Projetos.FindAsync(id);

            if (projeto != null)
            {
                _context.Projetos.Remove(projeto);
                await _context.SaveChangesAsync();
            }
        }
    }
}