using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Domain.Model
{
    public class Pessoa : Entity
    {
        public string Descricao { get; set; }
    }
}
