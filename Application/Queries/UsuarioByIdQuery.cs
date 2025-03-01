using APIFinancia.Domain;
using MediatR;

namespace APIFinancia.Application.Queries
{
    public class UsuarioByIdQuery : IRequest<Usuario>
    {
        public Guid Id { get; set; }
    }

}
