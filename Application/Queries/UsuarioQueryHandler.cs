using APIFinancia.Application.Commands;
using APIFinancia.Domain;
using APIFinancia.Infra.Repository;
using MediatR;

namespace APIFinancia.Application.Queries
{
    public class UsuarioQueryHandler : IRequestHandler<UsuarioQuery, List<Usuario>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> Handle(UsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetAll();
        }
    }
}
