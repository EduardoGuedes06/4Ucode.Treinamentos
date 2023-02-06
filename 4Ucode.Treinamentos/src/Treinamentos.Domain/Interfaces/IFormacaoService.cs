using Treinamentos.Domain.Model;

namespace Treinamentos.Domain.Interfaces
{
    public interface IFormacaoService
    {
        Task Adicionar(Formacao formacao);
        Task Atualizar(Formacao formacao);
        Task Remover(Guid id);
    }
}
