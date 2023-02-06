//using AutoMapper;
//using Domain.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Treinamentos.Domain.Interfaces;
//using Treinamentos.Api.Controllers;
//using Treinamentos.Api.ViewModel;
//using Treinamentos.Domain.Model;

//namespace Treinamentos.Api.V1.Controllers
//{
//    //[Authorize]
//    //[ApiVersion("1.0")]
//    [Route("api/alunos")]
//    public class AlunoController : MainController
//    {
//        private readonly IAlunoRepository _Alunorepository;
//        private readonly IAlunoService _Alunoservice;
//        private IMapper _mapper;

//        public AlunoController(IAlunoRepository alunoRepository, IAlunoService alunoService,
//            IMapper mapper, INotificador notificador, IUser user) : base(notificador, user)
//        {
//            _Alunorepository = alunoRepository;
//            _Alunoservice = alunoService;
//            _mapper = mapper;
//        }

//        // [Authorize]
//        [HttpGet]
//        public async Task<IEnumerable<AlunoViewModel>> ObterTodos()
//        {
//            return _mapper.Map<IEnumerable<AlunoViewModel>>(await _Alunorepository.ObterTodos());
//        }


//        [HttpGet("{id:guid}")]
//        //[Authorize]
//        public async Task<ActionResult<AlunoViewModel>> ObterPorId(Guid id)
//        {
//            var alunoViewModel = _mapper.Map<AlunoViewModel>(await _Alunorepository.ObterPorId(id));

//            if (alunoViewModel == null) return NotFound();


//            return alunoViewModel;
//        }


//        [HttpPost]
//        //[Authorize]
//        public async Task<ActionResult<AlunoViewModel>> Adicionar(AlunoViewModel alunoViewModel)
//        {
//            if (!ModelState.IsValid) return CostumResponse(ModelState);

//            await _Alunoservice.Adicionar(_mapper.Map<Aluno>(alunoViewModel));

//            return CostumResponse(alunoViewModel);
//        }


//        [HttpPut("{id:guid}")]
//        //[Authorize]
//        public async Task<ActionResult<AlunoViewModel>> Atualizar(Guid id, AlunoViewModel alunoViewModel)
//        {
//            if (id != alunoViewModel.Id)
//            {
//                NotificarErro("O id informado não é o mesmo que foi passado na query");
//                return CostumResponse(alunoViewModel);
//            }

//            if (!ModelState.IsValid) return CostumResponse(ModelState);

//            await _Alunoservice.Atualizar(_mapper.Map<Aluno>(alunoViewModel));

//            return CostumResponse(alunoViewModel);
//        }


//        [HttpDelete("{id:guid}")]
//        //[Authorize]
//        public async Task<ActionResult<AlunoViewModel>> Excluir(Guid id)
//        {
//            var alunoViewModel = await _Alunorepository.ObterPorId(id);

//            if (alunoViewModel == null) return NotFound();

//            await _Alunoservice.Remover(id);

//            return CostumResponse(alunoViewModel);
//        }





//    }
//}
