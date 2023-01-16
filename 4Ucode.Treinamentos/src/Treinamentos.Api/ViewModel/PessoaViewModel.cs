using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Api.ViewModel
{
    public class PessoaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
