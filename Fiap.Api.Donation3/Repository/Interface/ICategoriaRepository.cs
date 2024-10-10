using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface ICategoriaRepository
    {
        public IList<CategoriaModel> FindAll();

        public CategoriaModel FindById(int id);

        public int Insert(CategoriaModel categoriaModel);

        public void Update(CategoriaModel categoriaModel);

        public void Delete(int id);


    }
}
