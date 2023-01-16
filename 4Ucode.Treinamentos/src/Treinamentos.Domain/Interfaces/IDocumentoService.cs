using Treinamentos.Domain.Model;

namespace Treinamentos.Domain.Interfaces
{
    public interface IDocumentoService
    {
        Task Adicionar(Documento documento);
        Task Atualizar(Documento documento);
        Task Remover(Guid id);
    }
}
