using Microsoft.EntityFrameworkCore;
using Data.context;
using Treinamentos.Domain.Interfaces;
using Treinamentos.Domain.Model;

namespace Data.repository
{
    public class DocumentoRepository : Repository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(MeuDbContext context) : base(context) { }


    }
}
