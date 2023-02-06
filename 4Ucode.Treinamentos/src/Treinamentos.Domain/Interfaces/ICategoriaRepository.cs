using Business.Interfaces;
using Treinamentos.Domain.Model;

namespace Treinamentos.Domain.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> ObterCategoriasPorFomacao(Guid formacaoId);
        Task<IEnumerable<Categoria>> ObterCategoriasFormacoes();
        Task<Categoria> ObterCategoriaFormacao(Guid id);
    }
}
