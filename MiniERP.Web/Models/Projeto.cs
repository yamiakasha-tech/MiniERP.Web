using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }

        public String? Nome { get; set; }

        // Foreign key

        public int ClienteId { get; set; }

        public DateOnly DataInicio { get; set; }

        public DateOnly DataFim { get; set; }

        public decimal Orcamento { get; set; }

        public String? Estado { get; set; }



    }
}
