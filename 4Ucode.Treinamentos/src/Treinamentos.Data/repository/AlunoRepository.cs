
using Data.context;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Data.repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(MeuDbContext context) : base(context) { }

    }
}
