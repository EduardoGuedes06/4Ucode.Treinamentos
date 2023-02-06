using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Domain.Model
{
    public class Categoria : Entity
    {
        public string Descricao { get; set; }

        public Guid FormacaoId { get; set; }

        /* EF Relations */

        public Formacao Formacao { get; set; }
    }
}
