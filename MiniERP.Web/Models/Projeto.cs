using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniERP.Web.Models
{
    /// <summary>
    /// Representa um projeto
    /// </summary>
    public class Projeto
    {
        /// <summary>
        /// Id do projeto
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do projeto (obrigatório)
        /// </summary>
        [Required(ErrorMessage = "O nome do projeto é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Cliente associado
        /// </summary>
        [Required]
        public int ClienteId { get; set; }

        /// <summary>
        /// Navegação para cliente
        /// </summary>
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        /// <summary>
        /// Data de início
        /// </summary>
        [Required]
        public DateTime DataInicio { get; set; } = DateTime.Now;

        /// <summary>
        /// Data de fim
        /// </summary>
        public DateTime? DataFim { get; set; }

        /// <summary>
        /// Orçamento do projeto
        /// </summary>
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Valor inválido")]
        public decimal Orcamento { get; set; }

        /// <summary>
        /// Estado do projeto
        /// </summary>
        [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; set; } = "Ativo";
    }
}