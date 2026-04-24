using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.Web.Models
{
    /// <summary>
    /// Representa uma tarefa de um projeto
    /// </summary>
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da tarefa (obrigatório)
        /// </summary>
        [Required(ErrorMessage = "Nome da tarefa é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Projeto associado
        /// </summary>
        [Required]
        public int ProjetoId { get; set; }

        [ForeignKey("ProjetoId")]
        public Projeto? Projeto { get; set; }

        /// <summary>
        /// Empregado responsável
        /// </summary>
        [Required]
        public int EmpregadoId { get; set; }

        [ForeignKey("EmpregadoId")]
        public Empregado? Empregado { get; set; }

        /// <summary>
        /// Estado da tarefa
        /// </summary>
        [Required]
        public string Estado { get; set; } = "Pendente";

        /// <summary>
        /// Prioridade da tarefa
        /// </summary>
        [Required]
        public string Prioridade { get; set; } = "Normal";
    }
}