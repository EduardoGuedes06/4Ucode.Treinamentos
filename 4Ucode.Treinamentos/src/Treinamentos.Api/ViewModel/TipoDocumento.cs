using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Api.ViewModel
{
    public class TipoDocumentoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
