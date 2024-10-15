using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface IProdutoRepository
    {

        public IList<ProdutoModel> FindAll();

        public IList<ProdutoModel> FindByNome(string nome);

        public ProdutoModel FindById(int id);

        public int Insert(ProdutoModel produtoModel);

        public void Update(ProdutoModel produtoModel);

        public void Delete(ProdutoModel produtoModel);

        public void Delete(int id);

    }
}
