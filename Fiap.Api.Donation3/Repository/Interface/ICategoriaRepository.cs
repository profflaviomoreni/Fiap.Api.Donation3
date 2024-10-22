using Fiap.Api.Donation3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface ICategoriaRepository
    {
        Task DeleteAsync(int id);
        Task<IList<CategoriaModel>> FindAllAsync();
        Task<CategoriaModel> FindByIdAsync(int id);
        Task<int> InsertAsync(CategoriaModel categoriaModel);
        Task UpdateAsync(CategoriaModel categoriaModel);
    }
}
