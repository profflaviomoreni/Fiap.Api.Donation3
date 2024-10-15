using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository _produtoRepository)
        {
            produtoRepository = _produtoRepository;
        }


        [HttpGet]
        public ActionResult<IList<ProdutoModel>> Get()
        {
            var produtos = produtoRepository.FindAll();
            if (produtos == null || produtos.Count == 0)
            {
                return NoContent();
            }

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoModel> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                var prod = produtoRepository.FindById(id);

                if (prod == null)
                {
                    return NotFound(id);
                }
                else
                {
                    return Ok(prod);
                }
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProdutoModel produtoModel)
        {
            if (id != produtoModel.ProdutoId)
            {
                return BadRequest();
            }
            else
            {
                var produtoConsulta = produtoRepository.FindById(id);

                if (produtoConsulta == null)
                {
                    return NotFound();
                }
                else
                {
                    produtoRepository.Update(produtoModel);
                    return NoContent();
                }
            }
        }

        [HttpPost]
        public ActionResult<ProdutoModel> Post(ProdutoModel produtoModel)
        {

            try
            {
                produtoRepository.Insert(produtoModel);
                return CreatedAtAction(nameof(Get), new { id = produtoModel.ProdutoId }, produtoModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var produto = produtoRepository.FindById(id);

            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                produtoRepository.Delete(id);
                return NoContent();
            }
        }


    }
}
