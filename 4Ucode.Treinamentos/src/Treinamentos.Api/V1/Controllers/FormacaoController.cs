using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Treinamentos.Api.Controllers;
using Treinamentos.Api.ViewModel;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Treinamentos.Api.V1.Controllers
{
    //[Authorize]
    //[ApiVersion("1.0")]
    [Route("api/formacao")]
    public class FormacaoController : MainController
    {
        private readonly IFormacaoRepository _formacaoRepository;
        private readonly IFormacaoService _formacaoService;
        private IMapper _mapper;

        public FormacaoController(IFormacaoRepository formacaoRepository, IFormacaoService formacaoService,
            IMapper mapper, INotificador notificador, IUser user) : base(notificador, user)
        {
            _formacaoRepository = formacaoRepository;
            _formacaoService = formacaoService;
            _mapper = mapper;
        }

        // [Authorize]
        [HttpGet]
        public async Task<IEnumerable<FormacaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<FormacaoViewModel>>(await _formacaoRepository.ObterTodos());
        }


        [HttpGet("{id:guid}")]
        //[Authorize]
        public async Task<ActionResult<FormacaoViewModel>> ObterPorId(Guid id)
        {
            var formacaoViewModel = await ObterFormacao(id);

            if (formacaoViewModel == null) return NotFound();


            return formacaoViewModel;
        }


        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<FormacaoViewModel>> Adicionar(FormacaoViewModel formacaoViewModel)
        {
            if (!ModelState.IsValid) return CostumResponse(ModelState);

            await _formacaoService.Adicionar(_mapper.Map<Formacao>(formacaoViewModel));

            return CostumResponse(formacaoViewModel);
        }


        [HttpPut("{id:guid}")]
        //[Authorize]
        public async Task<ActionResult<FormacaoViewModel>> Atualizar(Guid id, FormacaoViewModel formacaoViewModel)
        {
            if (id != formacaoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CostumResponse(formacaoViewModel);
            }

            if (!ModelState.IsValid) return CostumResponse(ModelState);

            await _formacaoService.Atualizar(_mapper.Map<Formacao>(formacaoViewModel));

            return CostumResponse(formacaoViewModel);
        }


        [HttpDelete("{id:guid}")]
        //[Authorize]
        public async Task<ActionResult<FormacaoViewModel>> Excluir(Guid id)
        {
            var formacaoViewModel = await ObterFormacao(id);

            if (formacaoViewModel == null) return NotFound();

            await _formacaoService.Remover(id);

            return CostumResponse(formacaoViewModel);
        }
        private async Task<FormacaoViewModel> ObterFormacao(Guid id)
        {
            return _mapper.Map<FormacaoViewModel>(await _formacaoRepository.ObterFormacaoCategoria(id));
        }




    }
}
