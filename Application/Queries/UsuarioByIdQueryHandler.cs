using APIFinancia.Domain;
using APIFinancia.Infra.Repository;
using MediatR;

namespace APIFinancia.Application.Queries
{
    public class UsuarioByIdQueryHandler : IRequestHandler<UsuarioByIdQuery, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioByIdQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Handle(UsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetByIdAsync(request.Id);
        }
    }

}
