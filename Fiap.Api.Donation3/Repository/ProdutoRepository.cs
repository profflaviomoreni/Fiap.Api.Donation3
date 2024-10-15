using Fiap.Api.Donation3.Data;
using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation3.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        public IList<ProdutoModel> FindAll()
        {
            var produtos = dataContext.Produtos.AsNoTracking().ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }


        public IList<ProdutoModel> FindByNome(string nome)
        {
            var produtos = dataContext
                                .Produtos // SELECT * FROM Produtos
                                .AsNoTracking()
                                .Include(p => p.Categoria) // INNER JOIN
                                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                                    .ToList();

            return produtos == null ? new List<ProdutoModel>() : produtos;
        }

        public ProdutoModel FindById(int id)
        {
            var produto = dataContext
                                .Produtos
                                .AsNoTracking()
                                .FirstOrDefault(p => p.ProdutoId == id);

            return produto;
        }

        // Inserir
        public int Insert(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();

            return produtoModel.ProdutoId;
        }

        public void Update(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Update(produtoModel);
            dataContext.SaveChanges();
        }

        public void Delete(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Remove(produtoModel);
            dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var produtoModel = new ProdutoModel()
            {
                ProdutoId = id,
            };

            Delete(produtoModel);
        }


    }
}
