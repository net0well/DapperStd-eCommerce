using DapperStd_eCommerce.Models;

namespace DapperStd_eCommerce.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuario> Get();
        public Usuario Get(Guid id);
        public void Insert(Usuario usuario);
        public void Update(Usuario usuario);
        public void Delete(Guid id);
    }
}
