namespace DapperStd_eCommerce.Models
{
    public class EnderecoEntrega
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public string NomeEndereco { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Usuario Usuario { get; set; }
    }
}
