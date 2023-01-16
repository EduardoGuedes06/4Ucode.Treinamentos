using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Api.ViewModel
{
    public class Aluno : Entity
    {
        public string Descricao { get; set; }
    }
}
