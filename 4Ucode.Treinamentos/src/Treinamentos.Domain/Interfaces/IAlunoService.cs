using Treinamentos.Domain.Model;

namespace Treinamentos.Domain.Interfaces
{
    public interface IAlunoService
    {
        Task Adicionar(Aluno aluno);
        Task Atualizar(Aluno aluno);
        Task Remover(Guid id);
    }
}
