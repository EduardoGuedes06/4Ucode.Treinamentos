//using AutoMapper;
//using Data.repository;
//using Domain.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Treinamentos.Api.Controllers;
//using Treinamentos.Api.ViewModel;
//using Treinamentos.Domain.Interfaces;
//using Treinamentos.Domain.Model;
//using Treinamentos.Service.Services;

//namespace Treinamentos.Api.V1.Controllers
//{
//    //[Authorize]
//    //[ApiVersion("1.0")]
//    [Route("api/documento")]
//    public class DocumentoController : MainController
//    {
//        private readonly IDocumentoRepository _Documentorepository;
//        private readonly IDocumentoService _Documentoservice;
//        private IMapper _mapper;

//        public DocumentoController(IDocumentoRepository documentoRepository, IDocumentoService documentoService,
//            IMapper mapper, INotificador notificador, IUser user) : base(notificador, user)
//        {
//            _Documentorepository = documentoRepository;
//            _Documentoservice = documentoService;
//            _mapper = mapper;
//        }

//        // [Authorize]
//        [HttpGet]
//        public async Task<IEnumerable<DocumentoViewModel>> ObterTodos()
//        {
//            return _mapper.Map<IEnumerable<DocumentoViewModel>>(await _Documentorepository.ObterTodos());
//        }


//        [HttpGet("{id:guid}")]
//        //[Authorize]
//        public async Task<ActionResult<DocumentoViewModel>> ObterPorId(Guid id)
//        {
//            var documentoViewModel = _mapper.Map<DocumentoViewModel>(await _Documentorepository.ObterPorId(id));

//            if (documentoViewModel == null) return NotFound();


//            return documentoViewModel;
//        }


//        [HttpPost]
//        //[Authorize]
//        public async Task<ActionResult<DocumentoViewModel>> Adicionar(DocumentoViewModel documentoViewModel)
//        {
//            if (!ModelState.IsValid) return CostumResponse(ModelState);

//            await _Documentoservice.Adicionar(_mapper.Map<Documento>(documentoViewModel));

//            return CostumResponse(documentoViewModel);
//        }


//        [HttpPut("{id:guid}")]
//        //[Authorize]
//        public async Task<ActionResult<DocumentoViewModel>> Atualizar(Guid id, DocumentoViewModel documentoViewModel)
//        {
//            if (id != documentoViewModel.Id)
//            {
//                NotificarErro("O id informado não é o mesmo que foi passado na query");
//                return CostumResponse(documentoViewModel);
//            }

//            if (!ModelState.IsValid) return CostumResponse(ModelState);

//            await _Documentoservice.Atualizar(_mapper.Map<Documento>(documentoViewModel));

//            return CostumResponse(documentoViewModel);
//        }


//        [HttpDelete("{id:guid}")]
//        //[Authorize]
//        public async Task<ActionResult<AlunoViewModel>> Excluir(Guid id)
//        {
//            var documentoViewModel = await _Documentorepository.ObterPorId(id);

//            if (documentoViewModel == null) return NotFound();

//            await _Documentoservice.Remover(id);

//            return CostumResponse(documentoViewModel);
//        }





//    }
//}
