using MiniERP.Web.Data;
using MiniERP.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

namespace MiniERP.Web.Services
{
    /// <summary>
    /// Serviço responsável pela gestão de tarefas
    /// </summary>
    public class TarefaService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Construtor que recebe o DbContext
        /// </summary>
        public TarefaService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Devolve todas as tarefas com Projeto e Empregado
        /// </summary>
        public async Task<List<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas
                .Include(t => t.Projeto)   // inclui dados do projeto
                .Include(t => t.Empregado) // inclui dados do empregado
                .ToListAsync();
        }

        /// <summary>
        /// Devolve uma tarefa por ID
        /// </summary>
        public async Task<Tarefa?> GetByIdAsync(int id)
        {
            return await _context.Tarefas
                .Include(t => t.Projeto)
                .Include(t => t.Empregado)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// Adiciona nova tarefa
        /// </summary>
        public async Task AddAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza tarefa existente
        /// </summary>
        public async Task UpdateAsync(Tarefa tarefa)
        {
            var existente = await _context.Tarefas.FindAsync(tarefa.Id);

            if (existente != null)
            {
                existente.Nome = tarefa.Nome;
                existente.ProjetoId = tarefa.ProjetoId;
                existente.EmpregadoId = tarefa.EmpregadoId;
                existente.Estado = tarefa.Estado;
                existente.Prioridade = tarefa.Prioridade;

                await _context.SaveChangesAsync();

            }


        }

        /// <summary>
        /// Remove tarefa
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}