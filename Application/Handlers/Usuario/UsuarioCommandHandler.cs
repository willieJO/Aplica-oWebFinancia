﻿using APIFinancia.Application.Commands;
using APIFinancia.Application.Notification;
using APIFinancia.Domain;
using APIFinancia.Infra.Repository;
using MediatR;

namespace APIFinancia.Application.Handlers
{
    public class UsuarioCommandHandler : IRequestHandler<UsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediator _mediator;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository, IMediator mediator)
        {
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(UsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new User
            {
                Name = request.Nome,
                Email = request.Email,
                Senha = request.Senha
            };

            await _usuarioRepository.AddAsync(usuario);
            await _mediator.Publish(new UsuarioCriadaNotification { Id = usuario.Id, Nome = usuario.Name });
            return usuario.Id;
        }
    }
}
