using System.ComponentModel.DataAnnotations;


namespace MiniERP.Web.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        public String? Nome { get; set; }

        // Foreign key
        public int ProjetoId { get; set; }
        public int EmpregadoId { get; set; }
        public String? Estado { get; set; }
        public String? Prioridade { get; set; }


    }
}
