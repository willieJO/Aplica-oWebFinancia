using APIFinancia.Application.Commands;
using APIFinancia.Application.Commands.Expense;
using APIFinancia.Application.Handlers;
using APIFinancia.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APIFinancia.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase

    {
        private readonly IMediator _mediator;
        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuarioId = await _mediator.Send(command);

            return Ok(new { Id = usuarioId });
        }
       
    }
}
