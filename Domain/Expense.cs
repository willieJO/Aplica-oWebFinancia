﻿namespace APIFinancia.Domain
{
    public class Expense
    {
        public int Id { get; set; } 
        public Guid UsuarioId { get; set; } 
        public decimal Valor { get; set; } 
        public string TipoGasto { get; set; }

        public User Usuario { get; set; }
    }
}
