using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace DapperStd_eCommerce.Models
{
    public class Contato
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        [JsonIgnore] 
        [ValidateNever]
        public Usuario Usuario { get; set; }
    }
}
