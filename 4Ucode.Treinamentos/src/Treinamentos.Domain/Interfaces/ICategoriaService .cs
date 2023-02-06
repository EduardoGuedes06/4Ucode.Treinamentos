using Treinamentos.Domain.Model;

namespace Treinamentos.Domain.Interfaces
{
    public interface ICategoriaService
    {
        Task Adicionar(Categoria categoria);
        Task Atualizar(Categoria categoria);
        Task Remover(Guid id);
    }
}
