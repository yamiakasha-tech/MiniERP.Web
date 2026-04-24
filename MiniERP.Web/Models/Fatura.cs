using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.Web.Models
{
    /// <summary>
    /// Representa uma fatura
    /// </summary>
    public class Fatura
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Projeto associado
        /// </summary>
        [Required]
        public int ProjetoId { get; set; }

        [ForeignKey("ProjetoId")]
        public Projeto? Projeto { get; set; }

        /// <summary>
        /// Data da fatura
        /// </summary>
        [Required]
        public DateTime Data { get; set; } = DateTime.Now;

        /// <summary>
        /// Valor total
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Total { get; set; }
    }
}

