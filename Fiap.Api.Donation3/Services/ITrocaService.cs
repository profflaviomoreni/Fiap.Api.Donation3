using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Services
{
    public interface ITrocaService
    {

        public Task<Guid> Trocar(TrocaModel trocaModel);

    }
}
