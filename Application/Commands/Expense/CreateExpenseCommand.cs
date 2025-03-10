using APIFinancia.Domain;
using MediatR;

namespace APIFinancia.Application.Commands.Expense
{
    public class CreateExpenseCommand : IRequest<int>
    {
        public Guid UsuarioId { get; set; }
        public decimal Valor { get; set; }
        public string TipoGasto { get; set; }

    }

}
