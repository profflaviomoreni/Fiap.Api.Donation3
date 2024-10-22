using AutoMapper;
using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Fiap.Api.Donation3.ViewModel;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Fiap.Api.Donation3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        // Métodos Get - Acesso permitido para admin, operador e revisor
        [Authorize(Roles = "admin, operador, revisor")]
        [HttpGet]
        public async Task<ActionResult<dynamic>> Get([FromQuery] int produtoIdRef = 0, [FromQuery] int tamanho = 5)
        {
            var produtos = await _produtoRepository.FindAllByIdRefAsync(produtoIdRef, tamanho);
            if (produtos == null || produtos.Count == 0)
            {
                return NoContent();
            }

            var produtosResponse = _mapper.Map<IList<ProdutoResponseViewModel>>(produtos);
            var ultimoId = produtosResponse[^1].ProdutoId;

            var linkProxima = $"/api/produto?produtoIdRef={ultimoId}&tamanho={tamanho}";

            var retorno = new
            {
                produtos = produtosResponse,
                linkProxima
            };

            return Ok(retorno);
        }

        [Authorize(Roles = "admin, operador, revisor")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoResponseViewModel>> GetById(int id)
        {
            var produto = await _produtoRepository.FindByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            var produtoResponse = _mapper.Map<ProdutoResponseViewModel>(produto);
            return Ok(produtoResponse);
        }

        // Métodos Post e Patch - Acesso permitido para admin e operador
        [Authorize(Roles = "admin, operador")]
        [HttpPost]
        public async Task<ActionResult<ProdutoResponseViewModel>> Post([FromBody] ProdutoRequestViewModel produtoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoModel = _mapper.Map<ProdutoModel>(produtoRequest);
            var produtoId = await _produtoRepository.InsertAsync(produtoModel);
            var produtoResponse = _mapper.Map<ProdutoResponseViewModel>(produtoModel);

            return CreatedAtAction(nameof(GetById), new { id = produtoId }, produtoResponse);
        }

        [Authorize(Roles = "admin, operador")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ProdutoPatchViewModel> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("Invalid patch document.");
            }

            var produtoExistente = await _produtoRepository.FindByIdAsync(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }

            var produtoPatchVM = _mapper.Map<ProdutoPatchViewModel>(produtoExistente);
            patchDoc.ApplyTo(produtoPatchVM, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(produtoPatchVM, produtoExistente);
            await _produtoRepository.UpdateAsync(produtoExistente);

            return NoContent();
        }

        // Métodos Put e Delete - Acesso permitido apenas para admin
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutoRequestViewModel produtoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produtoRequest.ProdutoId)
            {
                return BadRequest();
            }

            var produtoExistente = await _produtoRepository.FindByIdAsync(id);
            if (produtoExistente == null)
            {
                return NotFound();
            }

            var produto = _mapper.Map<ProdutoModel>(produtoRequest);
            await _produtoRepository.UpdateAsync(produto);

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _produtoRepository.FindByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            await _produtoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
