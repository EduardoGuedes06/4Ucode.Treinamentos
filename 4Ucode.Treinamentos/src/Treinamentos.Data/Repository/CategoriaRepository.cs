using Microsoft.EntityFrameworkCore;
using Data.context;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Data.repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MeuDbContext context) : base(context) { }

        public async Task<Categoria> ObterCategoriaFormacao(Guid id)
        {
            return await Db.Categorias.AsNoTracking().Include(f => f.Formacao)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Categoria>> ObterCategoriasFormacoes()
        {
            return await Db.Categorias.AsNoTracking().Include(f => f.Formacao)
                .OrderBy(p => p.Descricao).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterCategoriasPorFomacao(Guid formacaoId)
        {
            return await Buscar(p => p.FormacaoId == formacaoId);
        }
    }
}
