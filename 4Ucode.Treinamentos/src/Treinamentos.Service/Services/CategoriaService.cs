using Domain.Interfaces;
using Services;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Treinamentos.Service.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IFormacaoRepository _formacaoRepository;

        public CategoriaService(ICategoriaRepository categoria,
                IFormacaoRepository formacaoRepository,
                INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoria;
            _formacaoRepository = formacaoRepository;
        }


        public async Task Adicionar(Categoria categoria)
        {
            if (_categoriaRepository.Buscar(f => f.Id == categoria.Id).Result.Any())
            {
                Notificar("Já existe uma categoria com este id infomado.");
                return;
            }

            var formacao = await _formacaoRepository.ObterPorId(categoria.FormacaoId);

            if (formacao == null)
            {
                Notificar("Nenhuma formacao com esse id cadastrada!");
                return;
            }

            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task Atualizar(Categoria categoria)
        {
            var formacao = await _formacaoRepository.ObterPorId(categoria.FormacaoId);

            if (formacao == null)
            {
                Notificar("Nenhuma formacao com esse id cadastrada!");
                return;
            }
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task Remover(Guid id)
        {

            await _categoriaRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }


    }
}
