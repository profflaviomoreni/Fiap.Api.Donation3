using Fiap.Api.Donation3.Data;
using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation3.Repository
{
    public class TrocaRepository : ITrocaRepository
    {

        private readonly DataContext dataContext;

        public TrocaRepository(DataContext context)
        {
            dataContext = context;
        }

        public async Task<Guid> Insert(Models.TrocaModel trocaModel)
        {
            await dataContext.Trocas.AddAsync(trocaModel);
            await dataContext.SaveChangesAsync();

            return trocaModel.TrocaId;
        }


        public async Task<TrocaModel> FindById(Guid id)
        {
            var troca = await dataContext.Trocas.AsNoTracking()
                    .Include(t => t.ProdutoMeu)
                    .Include(t => t.ProdutoEscolhido)
                .FirstOrDefaultAsync(t => t.TrocaId == id);

            return troca;
        }

    }
}
