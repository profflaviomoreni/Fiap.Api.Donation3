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
        public ActionResult<IList<CategoriaModel>> Get()
        {
            var listaCategorias = _categoriaRepository.FindAll();

            if ( listaCategorias != null && listaCategorias.Count > 0 )
            {
                return Ok(listaCategorias);
            } else
            {
                return NoContent();
            }
            
        }


        [HttpGet("{id:int}")]
        public ActionResult<CategoriaModel> Get([FromRoute] int id)
        {
            var categoriaModel = _categoriaRepository.FindById(id);

            if ( categoriaModel != null )
            {
                return Ok(categoriaModel);
            } else
            {
                return NotFound();
            }
            
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            if ( id == 0 )
            {
                return BadRequest();
            }

            var categoria = _categoriaRepository.FindById(id);
            if ( categoria == null )
            {
                return NotFound();
            }


            _categoriaRepository.Delete(id);
            return NoContent();
        }


        [HttpPost]
        public ActionResult<CategoriaModel> Post([FromBody] CategoriaModel categoriaModel)
        {
            if ( ModelState.IsValid )
            {
                var categoriaId = _categoriaRepository.Insert(categoriaModel);
                categoriaModel.CategoriaId = categoriaId;

                return CreatedAtAction( nameof(Get), new { id = categoriaId } , categoriaModel );
            } else
            {
                return BadRequest();
            }

        }



        [HttpPut("{id:int}")]
        public ActionResult Put([FromRoute]int id, [FromBody] CategoriaModel categoriaModel)
        {
            if ( ModelState.IsValid == false ) {
                var errors = ModelState.Values
                                .SelectMany(m => m.Errors)
                                .Select(m => m.ErrorMessage);

                return BadRequest(errors);
            }
             
            if ( id != categoriaModel.CategoriaId)
            {
                return BadRequest( new { erro = "Ids divergentes, operação não efetuada" } );
            }

            var categoria = _categoriaRepository.FindById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _categoriaRepository.Update(categoriaModel);
            return NoContent();

        }


    }
}
