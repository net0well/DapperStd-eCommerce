using DapperStd_eCommerce.Models;

namespace DapperStd_eCommerce.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private List<Usuario> _db = new List<Usuario>()
        {
            new Usuario(){ Id = 1, Nome = "Testinho", Email = "testinho@gmail.com" },
            new Usuario(){ Id = 2, Nome = "Testinho2", Email = "testinho2@gmail.com" },
            new Usuario(){ Id = 3, Nome = "Testinho3", Email = "testinho3@gmail.com" },
            new Usuario(){ Id = 4, Nome = "Testinho4", Email = "testinho4@gmail.com" },
        };

        public void Delete(int id)
        {
           Usuario usr = _db.FirstOrDefault(x => x.Id == id);
           _db.Remove(usr);
        }

        public List<Usuario> Get()
        {
            return _db.ToList();
        }

        public Usuario Get(int id)
        {
            return _db.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(Usuario usuario)
        {
            Usuario lastUser = _db.LastOrDefault();

            if (lastUser == null)
            {
                usuario.Id = 1;
            }else
            {
                usuario.Id = lastUser.Id;
                usuario.Id++;
            }
            _db.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            _db.Remove(usuario);
            _db.Add(usuario);
        }
    }
}
