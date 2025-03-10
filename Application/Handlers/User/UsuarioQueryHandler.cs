﻿using APIFinancia.Application.Queries;
using MediatR;
using APIFinancia.Domain;
using APIFinancia.Repository;
namespace APIFinancia.Application.Handlers.Usuario
{
    public class UsuarioQueryHandler : IRequestHandler<UsuarioQuery, List<User>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<User>> Handle(UsuarioQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetAll();
        }
    }
}
