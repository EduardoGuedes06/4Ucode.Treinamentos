using Business.Interfaces;
using Treinamentos.Domain.Model;

namespace Treinamentos.Domain.Interfaces
{
    public interface IFormacaoRepository : IRepository<Formacao>
    {
        Task<Formacao> ObterFormacaoCategoria(Guid id);
    }
}
