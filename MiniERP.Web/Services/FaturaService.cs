using MiniERP.Web.Data;
using MiniERP.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniERP.Web.Services
{
    /// <summary>
    /// Serviço de gestão de faturação
    /// </summary>
    public class FaturaService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor
        /// </summary>
        public FaturaService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todas as faturas com projeto
        /// </summary>
        public async Task<List<Fatura>> GetAllAsync()
        {
            return await _context.Faturas
                .Include(f => f.Projeto)
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona nova fatura
        /// </summary>
        public async Task AddAsync(Fatura fatura)
        {
            _context.Faturas.Add(fatura);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza fatura
        /// </summary>
        public async Task UpdateAsync(Fatura fatura)
        {
            var existente = await _context.Faturas.FindAsync(fatura.Id);

            if (existente != null)
            {
                existente.ProjetoId = fatura.ProjetoId;
                existente.Data = fatura.Data;
                existente.Total = fatura.Total;

                await _context.SaveChangesAsync();

            }

        }

        /// <summary>
        /// Remove fatura
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var fatura = await _context.Faturas.FindAsync(id);

            if (fatura != null)
            {
                _context.Faturas.Remove(fatura);
                await _context.SaveChangesAsync();
            }
        }
    }
}