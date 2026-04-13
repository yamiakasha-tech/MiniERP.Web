using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    public class Fatura
    {
        [Key]
        public int Id { get; set; }
        // Foreign key 
        public int ProjetoId { get; set; }

        public DateOnly Data { get; set; }

        public decimal Total { get; set; }

    }
}

