using System.ComponentModel.DataAnnotations;

namespace MiniERP.Web.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public String? Nome { get; set; }
        public String? Email { get; set; }
        public String? Telefone { get; set; }
        public String? NomeEmpresa { get; set; }


    }
}
