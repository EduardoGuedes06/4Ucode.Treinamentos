using Domain.Interfaces;
using Services;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Treinamentos.Service.Services
{
    public class DocumentoService : BaseService, IDocumentoService
    {
        private readonly IDocumentoRepository _documentoRepository;

        public DocumentoService(IDocumentoRepository documento, INotificador notificador) : base(notificador)
        {
            _documentoRepository = documento;
        }


        public async Task Adicionar(Documento documento)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _documentoRepository.Adicionar(documento);
        }

        public async Task Atualizar(Documento documento)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _documentoRepository.Atualizar(documento);
        }

        public async Task Remover(Guid id)
        {

            await _documentoRepository.Remover(id);
        }

        public void Dispose()
        {
            _documentoRepository?.Dispose();
        }


    }
}
