using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface ITrocaRepository
    {

        public Task<Guid> Insert(Models.TrocaModel trocaModel);

        public Task<TrocaModel> FindById(Guid id);

    }
}
