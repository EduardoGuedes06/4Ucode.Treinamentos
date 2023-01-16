using AutoMapper;
using Treinamentos.Api.ViewModel;
using Treinamentos.Domain.Model;

namespace Treinamentos.Api.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<AlunoViewModel, Aluno>().ReverseMap();
            CreateMap<DocumentoViewModel, Documento>().ReverseMap();

        }
    }
}
