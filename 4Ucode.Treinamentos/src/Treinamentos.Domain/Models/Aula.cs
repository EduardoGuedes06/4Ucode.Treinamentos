using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Domain.Model
{
    public class Aula : Entity
    {
        public string Descricao { get; set; }
    }
}
