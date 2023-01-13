using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Api.ViewModel
{
    public class ComentarioViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
