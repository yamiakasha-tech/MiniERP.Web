using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    /// <summary>
    /// Representa um cliente do sistema
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Identificador único do cliente
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente (obrigatório)
        /// </summary>
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Email do cliente (obrigatório)
        /// </summary>
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Telefone do cliente (opcional)
        /// </summary>
        [Phone(ErrorMessage = "Número de telefone inválido")]
        public string? Telefone { get; set; }

        /// <summary>
        /// Nome da empresa (opcional)
        /// </summary>
        [StringLength(150, ErrorMessage = "Máximo 150 caracteres")]
        public string? NomeEmpresa { get; set; }

    }
}
