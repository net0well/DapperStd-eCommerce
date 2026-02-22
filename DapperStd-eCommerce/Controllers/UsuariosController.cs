using DapperStd_eCommerce.Data;
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
        private IUnitOfWork _unitOfWork;
        public UsuariosController(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork.BeginTransaction();
            try
            {
                _usuarioRepository.Update(usuario);
                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return StatusCode(500, "Erro ao atualizar o usuário");
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Usuario usuario)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                _usuarioRepository.Insert(usuario);
                _unitOfWork.Commit();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return StatusCode(500, "Erro ao inserir o usuário: " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var usr = _usuarioRepository.Get(id);
            if (usr == null) { return NotFound(); }

            _unitOfWork.BeginTransaction();
            try
            {
                _usuarioRepository.Delete(usr.Id);
                _unitOfWork.Commit();
                return NoContent();
            }
            catch
            {
                _unitOfWork.Rollback();
                return StatusCode(500, "Erro ao deletar o usuário");
            }
        }
    }
}
