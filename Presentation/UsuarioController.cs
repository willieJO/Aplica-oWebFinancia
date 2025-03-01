using APIFinancia.Application.Commands;
using APIFinancia.Application.Handlers;
using APIFinancia.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APIFinancia.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase

    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuarioId = await _mediator.Send(command);

            return Ok(new { Id = usuarioId });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(Guid id, [FromBody] UpdateUsuarioCommand command)
        {
     
            try
            {
                var usuarioId = await _mediator.Send(command);
                return Ok(new { Id = usuarioId });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _mediator.Send(new UsuarioQuery());
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(Guid id)
        {
            var usuario = await _mediator.Send(new UsuarioByIdQuery { Id = id });

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
    }
}
