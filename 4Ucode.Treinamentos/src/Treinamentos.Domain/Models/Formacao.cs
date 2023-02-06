using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Treinamentos.Domain.Model
{
    public class Formacao : Entity
    {
        public string Descricao { get; set; }
        public string Bios { get; set; }

        public int DuracaoMinutos { get; set; }

        public string Foto { get; set; }

        /* EF Relations */

        public IEnumerable<Categoria>? Categorias { get; set; }


    }
}
