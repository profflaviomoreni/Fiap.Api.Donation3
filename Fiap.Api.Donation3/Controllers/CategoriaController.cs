using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public IList<CategoriaModel> Get()
        {
            var listaCategorias = _categoriaRepository.FindAll();
            return listaCategorias;
        }


        [HttpGet("{id:int}")]
        public CategoriaModel Get([FromRoute] int id)
        {
            var categoriaModel = _categoriaRepository.FindById(id);
            return categoriaModel;
        }


        [HttpDelete("{id:int}")]
        public bool Delete([FromRoute] int id)
        {
            _categoriaRepository.Delete(id);
            return true;
        }


        [HttpPost]
        public CategoriaModel Post([FromBody] CategoriaModel categoriaModel)
        {
            var id = _categoriaRepository.Insert(categoriaModel);
            categoriaModel.CategoriaId = id;

            return categoriaModel;
        }



        [HttpPut("{id:int}")]
        public bool Put([FromRoute]int id, [FromBody] CategoriaModel categoriaModel)
        {
            if (id == categoriaModel.CategoriaId)
            {
                _categoriaRepository.Update(categoriaModel);

                return true;
            } else
            {
                return false;
            }
        }


    }
}
