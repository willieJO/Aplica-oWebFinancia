namespace APIFinancia.Domain
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
