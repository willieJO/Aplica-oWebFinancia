using APIFinancia.Application.Commands;
using APIFinancia.Application.Commands.Expense;
using APIFinancia.Application.Notification;
using APIFinancia.Domain;
using APIFinancia.Migrations;
using APIFinancia.Repository.Expense;
using MediatR;

namespace APIFinancia.Application.Handlers.Expense
{
    public class ExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, int>
    {
        private readonly IExpenseRepository _repository;
        private readonly IMediator _mediator;

        public ExpenseCommandHandler(IExpenseRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Domain.Expense
            {
                Valor = request.Valor,
                TipoGasto = request.TipoGasto,
                UsuarioId = request.UsuarioId,
            };

            await _repository.AddAsync(expense);
            await _mediator.Publish(new UserCriadaNotification { Id = expense.UsuarioId, Nome = expense.TipoGasto });
            return expense.Id;
        }
    }
}