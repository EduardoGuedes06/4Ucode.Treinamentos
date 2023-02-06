using Domain.Interfaces;
using Services;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Treinamentos.Service.Services
{
    public class FormacaoService : BaseService, IFormacaoService
    {
        private readonly IFormacaoRepository _formacaoRepository;
        private readonly ICategoriaService _categoriaService;

        public FormacaoService(IFormacaoRepository formacao, 
                                ICategoriaService categoriaService
                                ,INotificador notificador) : base(notificador)
        {
            _formacaoRepository = formacao;
            _categoriaService = categoriaService;
        }


        public async Task Adicionar(Formacao formacao)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
            if (_formacaoRepository.Buscar(f => f.Id == formacao.Id).Result.Any())
            {
                Notificar("Já existe uma formacao com este id infomado.");
                return;
            }


            await _formacaoRepository.Adicionar(formacao);
        }

        public async Task Atualizar(Formacao formacao)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _formacaoRepository.Atualizar(formacao);
        }

        public async Task Remover(Guid id)
        {

            await _formacaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _formacaoRepository?.Dispose();
        }


    }
}
