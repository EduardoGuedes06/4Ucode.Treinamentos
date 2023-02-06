using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Domain.Model
{
    public class Comentario : Entity
    {
        public string Descricao { get; set; }
    }
}
