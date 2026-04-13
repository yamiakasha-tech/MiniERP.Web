using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    public class Empregado
    {
        [Key]
        public int Id { get; set; }

        public String? Nome { get; set; }

        public String? Email { get; set; }

        public String? Funcao { get; set; }
    }
}
