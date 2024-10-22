using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface IProdutoRepository
    {
        Task<IList<ProdutoModel>> FindAllAsync();
        Task<IList<ProdutoModel>> FindAllAsync(int pagina, int tamanho);
        Task<IList<ProdutoModel>> FindAllAsync(DateTime? dataRef, int tamanho);
        Task<IList<ProdutoModel>> FindAllByIdRefAsync(int produtoIdRef, int tamanho);
        Task<int> CountAsync();
        Task<IList<ProdutoModel>> FindByNomeAsync(string nome);
        Task<ProdutoModel> FindByIdAsync(int id);
        Task<int> InsertAsync(ProdutoModel produtoModel);
        Task UpdateAsync(ProdutoModel produtoModel);
        Task DeleteAsync(ProdutoModel produtoModel);
        Task DeleteAsync(int id);
    }
}
