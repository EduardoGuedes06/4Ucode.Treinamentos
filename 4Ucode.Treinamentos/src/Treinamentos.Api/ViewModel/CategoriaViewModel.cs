using System.ComponentModel.DataAnnotations;
using Treinamentos.Domain.Model;

namespace Treinamentos.Api.ViewModel
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(90, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Descricao { get; set; }
        public Guid FormacaoId { get; set; }     
    }
}
