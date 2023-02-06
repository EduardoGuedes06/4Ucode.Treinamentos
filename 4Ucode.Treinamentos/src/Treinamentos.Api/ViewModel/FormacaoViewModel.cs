using System.ComponentModel.DataAnnotations;
using Treinamentos.Domain.Model;

namespace Treinamentos.Api.ViewModel
{
    public class FormacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(355, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 15)]
        public string Bios { get; set; }

        public int DuracaoMinutos { get; set; }

        //public IFormFile ImagemUpload { get; set; }
        public string Foto { get; set; }
        public IEnumerable<CategoriaViewModel>? Categoria { get; set; }
    }
}
