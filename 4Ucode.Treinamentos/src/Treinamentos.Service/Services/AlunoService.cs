using Domain.Interfaces;
using Services;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Treinamentos.Service.Services
{
    public class AlunoService : BaseService, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository aluno, INotificador notificador) : base(notificador)
        {
            _alunoRepository = aluno;
        }


        public async Task Adicionar(Aluno aluno)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _alunoRepository.Adicionar(aluno);
        }

        public async Task Atualizar(Aluno aluno)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _alunoRepository.Atualizar(aluno);
        }

        public async Task Remover(Guid id)
        {

            await _alunoRepository.Remover(id);
        }

        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }


    }
}
