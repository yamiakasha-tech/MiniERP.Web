using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    /// <summary>
    /// Representa um empregado
    /// </summary>
    public class Empregado
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do empregado
        /// </summary>
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Email do empregado
        /// </summary>
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Função do empregado
        /// </summary>
        public string? Funcao { get; set; }
    }
}