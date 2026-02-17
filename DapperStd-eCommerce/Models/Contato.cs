namespace DapperStd_eCommerce.Models
{
    public class Contato
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public Usuario Usuario { get; set; }
    }
}
