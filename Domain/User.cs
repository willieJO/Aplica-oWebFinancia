﻿namespace APIFinancia.Domain
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
