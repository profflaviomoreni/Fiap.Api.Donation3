using Fiap.Api.Donation3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        [HttpGet]
        public List<CategoriaModel> Get()
        {

            return new List<CategoriaModel>()
            {
                new CategoriaModel()
                {
                    CategoriaId = 1,
                    NomeCategoria = "Celular"
                },
                new CategoriaModel() {
                    CategoriaId = 2,
                    NomeCategoria = "Televisor"
                }
            };
        }

        [HttpGet("{id:int}")]
        public CategoriaModel Get([FromRoute] int id)
        {
            return new CategoriaModel()
            {
                CategoriaId = 2,
                NomeCategoria = "Televisor"
            };
        }


        [HttpDelete("{id:int}")]
        public bool Delete([FromRoute] int id)
        {
            return true;
        }


        [HttpPost]
        public CategoriaModel Post([FromBody] CategoriaModel categoriaModel)
        {
            return categoriaModel;
        }



        [HttpPut("{id:int}")]
        public bool Put([FromRoute]int id, [FromBody] CategoriaModel categoriaModel)
        {
            if (id == categoriaModel.CategoriaId)
            {
                return true;
            } else
            {
                return false;
            }
        }


    }
}
