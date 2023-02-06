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
    [Route("api/categoria")]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private IMapper _mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, ICategoriaService categoriaService,
            IMapper mapper, INotificador notificador, IUser user) : base(notificador, user)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        // [Authorize]
        [HttpGet]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
        }

        // [Authorize]
        [HttpGet("formacoes{id:guid}")]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodosPorFormacao(Guid id)
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterCategoriasPorFomacao(id));
        }

        [HttpGet("{id:guid}")]
        //[Authorize]
        public async Task<ActionResult<CategoriaViewModel>> ObterPorId(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaId(id);

            if (categoriaViewModel == null) return NotFound();


            return categoriaViewModel;
        }



        
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return CostumResponse(ModelState);

            await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            return CostumResponse(categoriaViewModel);
        }


        [HttpPut("{id:guid}")]
        //[Authorize]
        public async Task<ActionResult<CategoriaViewModel>> Atualizar(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CostumResponse(categoriaViewModel);
            }

            if (!ModelState.IsValid) return CostumResponse(ModelState);

            await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

            return CostumResponse(categoriaViewModel);
        }


        [HttpDelete("{id:guid}")]
        //[Authorize]
        public async Task<ActionResult<CategoriaViewModel>> Excluir(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaId(id);

            if (categoriaViewModel == null) return NotFound();

            await _categoriaService.Remover(id);

            return CostumResponse(categoriaViewModel);
        }

        private async Task<CategoriaViewModel> ObterCategoriaId(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterCategoriaFormacao(id));
        }



    }
}
