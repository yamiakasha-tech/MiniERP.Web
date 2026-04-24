using MiniERP.Web.Data;
using MiniERP.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniERP.Web.Services
{
    /// <summary>
    /// Serviço responsável pela gestão de empregados
    /// </summary>
    public class EmpregadoService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o DbContext
        /// </summary>
        public EmpregadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devolve todos os empregados
        /// </summary>
        public async Task<List<Empregado>> GetAllAsync()
        {
            return await _context.Empregados.ToListAsync();
        }

        /// <summary>
        /// Devolve um empregado por ID
        /// </summary>
        public async Task<Empregado?> GetByIdAsync(int id)
        {
            return await _context.Empregados.FindAsync(id);
        }

        /// <summary>
        /// Adiciona um novo empregado
        /// </summary>
        public async Task AddAsync(Empregado empregado)
        {
            _context.Empregados.Add(empregado);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um empregado existente
        /// </summary>
        public async Task UpdateAsync(Empregado empregado)
        {
            var existente = await _context.Empregados.FindAsync(empregado.Id);

            if (existente != null)
            {
                existente.Nome = empregado.Nome;
                existente.Email = empregado.Email;
                existente.Funcao = empregado.Funcao;

                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Remove um empregado
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var empregado = await _context.Empregados.FindAsync(id);

            if (empregado != null)
            {
                _context.Empregados.Remove(empregado);
                await _context.SaveChangesAsync();
            }
        }
    }
}