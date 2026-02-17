using DapperStd_eCommerce.Models;
using DapperStd_eCommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperStd_eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Usuario> users = _usuarioRepository.Get();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            Usuario usr = _usuarioRepository.Get(id);
            if(usr == null) { return NotFound(); }
            return Ok(usr);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario) 
        {
            _usuarioRepository.Update(usuario);

            return Ok();
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Usuario usuario)
        {
            _usuarioRepository.Insert(usuario);
            return Ok(usuario);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Usuario usr = _usuarioRepository.Get(id);
            if(usr == null) { return NotFound(); }
            _usuarioRepository.Delete(usr.Id);
            return NoContent();
        }
    }
}
