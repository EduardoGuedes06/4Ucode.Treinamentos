using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Api.ViewModel
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
