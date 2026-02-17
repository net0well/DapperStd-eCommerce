namespace DapperStd_eCommerce.Models
{
    public class Departamento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }

        ICollection<Usuario> Usuarios { get; set; } = []; 
    }
}
