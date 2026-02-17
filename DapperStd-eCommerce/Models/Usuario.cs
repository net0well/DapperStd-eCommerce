namespace DapperStd_eCommerce.Models
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string NomeMae { get; set; }
        public string SituacaoCadastro { get; set; }
        public DateTimeOffset DataCadastro { get; set; } = DateTime.UtcNow;

        public Contato Contato { get; set; }
        public ICollection<EnderecoEntrega> EnderecosEntrega { get; set; } = [];
        public ICollection<Departamento> Departamentos { get; set;} = [];
    }
}
