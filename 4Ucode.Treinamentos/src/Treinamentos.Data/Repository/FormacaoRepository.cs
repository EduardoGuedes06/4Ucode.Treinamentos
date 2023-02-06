using Microsoft.EntityFrameworkCore;
using Data.context;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Data.repository
{
    public class FormacaoRepository : Repository<Formacao>, IFormacaoRepository
    {
        public FormacaoRepository(MeuDbContext context) : base(context) { }

        public async Task<Formacao> ObterFormacaoCategoria(Guid id)
        {
            return await Db.Formacoes.AsNoTracking()
                .Include(c => c.Categorias)
                .FirstOrDefaultAsync(c => c.Id == id);
        }


    }
}
