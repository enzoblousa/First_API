using ApiFicticia.Models;
using ApiFicticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiFicticia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DadosService _dadosService;

        public UsuariosController(DadosService dadosService)
        {
            _dadosService = dadosService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _dadosService.ObterTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _dadosService.ObterUsuarioPorId(id);
            if (usuario == null)
                return NotFound();
            
            return Ok(usuario);
        }

        [HttpGet("ativos")]
        public IActionResult GetAtivos()
        {
            var usuarios = _dadosService.ObterTodosUsuarios()
                .Where(u => u.Ativo)
                .ToList();
            
            return Ok(usuarios);
        }
    }
}