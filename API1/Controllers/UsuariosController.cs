using API1.Interfaces;
using API1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _IUsuarioReporitory;

        public UsuariosController(IUsuarioRepository iUsuarioReporitory)
        {
            _IUsuarioReporitory = iUsuarioReporitory;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_IUsuarioReporitory.Listar())
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Usuario usuarioEncontrado = _IUsuarioReporitory.BuscarPorId(id);

                if (usuarioEncontrado == null)
                    return NotFound();

                return Ok(usuarioEncontrado);
           
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _IUsuarioReporitory.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("{id}")]
        public IActionResult Alterar(int id, Usuario usuario)
        {
            try
            {
                _IUsuarioReporitory.Atualizar(id, usuario);

                return Ok("Usuário alterado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                _IUsuarioReporitory.Deletar(id);

                return Ok("Usuário deletado com sucesso");
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
