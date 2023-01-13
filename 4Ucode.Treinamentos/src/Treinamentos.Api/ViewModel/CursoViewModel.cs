using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Api.ViewModel
{
    public class CursoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
