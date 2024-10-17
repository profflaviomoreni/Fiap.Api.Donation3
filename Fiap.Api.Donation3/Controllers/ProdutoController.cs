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
        public ActionResult<dynamic> Get(
            [FromQuery] string dataReferencia,
            [FromQuery] int tamanho = 5)
        {

            var data = ( string.IsNullOrEmpty(dataReferencia) ) ? 
                            DateTime.UtcNow.AddYears(-200) :
                            DateTime.ParseExact(dataReferencia, "yyyy-MM-ddTHH:mm:ss.fffffff", null, System.Globalization.DateTimeStyles.RoundtripKind); ;

            var produtos = produtoRepository.FindAll(data, 5);

            if (produtos == null || produtos.Count() == 0)
            {
                return NoContent();
            }

            var ultimaData = produtos.LastOrDefault().DataCadastro.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
 
            var linkProxima = $"/api/produto?dataReferencia={ultimaData}&tamanho={tamanho}";

            var retorno = new
            {
                produtos,
                linkProxima
            };

            return Ok(retorno);

            
        }


        //[HttpGet]
        //public ActionResult<dynamic> Get( 
        //    [FromQuery] int pagina = 0, 
        //    [FromQuery] int tamanho = 5)
        //{

        //    var totalGeral = produtoRepository.Count();
        //    var totalPaginas = Convert.ToInt16( Math.Ceiling( (double) totalGeral / tamanho) );
        //    var linkProxima = (pagina < totalPaginas -1 ) ? $"/api/produto?pagina={pagina + 1}&tamanho={tamanho}" : "";
        //    var linkAnterior = (pagina > 0) ? $"/api/produto?pagina={pagina - 1}&tamanho={tamanho}" : "";


        //    if ( pagina > totalPaginas )
        //    {
        //        return NotFound();
        //    }

        //    var produtos = produtoRepository.FindAll(pagina, tamanho);
        //    if ( produtos ==  null || produtos.Count() == 0 ) { 
        //        return NoContent(); 
        //    }

        //    var retorno = new
        //    {
        //        produtos,
        //        totalPaginas,
        //        totalGeral,
        //        linkProxima,
        //        linkAnterior
        //    };

        //    return Ok(retorno);



        //    /*
        //    var produtos = produtoRepository.FindAll(1,3);
        //    if (produtos == null || produtos.Count == 0)
        //    {
        //        return NoContent();
        //    }



        //    return Ok(produtos);
        //    */
        //}

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
