using ApiFicticia.Models;
using ApiFicticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiFicticia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly DadosService _dadosService;

        public ProdutosController(DadosService dadosService)
        {
            _dadosService = dadosService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _dadosService.ObterTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _dadosService.ObterProdutoPorId(id);
            if (produto == null)
                return NotFound();
            
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            var novoProduto = _dadosService.AdicionarProduto(produto);
            return CreatedAtAction(nameof(GetById), new { id = novoProduto.Id }, novoProduto);
        }

        [HttpGet("categoria/{categoria}")]
        public IActionResult GetByCategoria(string categoria)
        {
            var produtos = _dadosService.ObterTodosProdutos()
                .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
            return Ok(produtos);
        }
    }
}