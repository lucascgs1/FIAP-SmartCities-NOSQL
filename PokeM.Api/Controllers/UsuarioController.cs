using Microsoft.AspNetCore.Mvc;
using PokeM.Api.Models.Documents;
using PokeM.Api.Services;
using System.Collections.Generic;

namespace PokeM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id:length(24)}", Name = "GetUsuario")]
        public ActionResult<Usuario> Get(string id)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpGet(Name = "GetUsuarios")]
        public ActionResult<IList<Usuario>> Get()
        {
            var usuarios = _usuarioService.Get();

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        [HttpPost]
        public ActionResult<Usuario> Create(Usuario usuario)
        {
            _usuarioService.Create(usuario);

            return CreatedAtRoute("GetUsuario", new { id = usuario.Id.ToString() }, usuario);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Usuario usuarioNovo)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioService.Update(id, usuarioNovo);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var usuario = _usuarioService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioService.Remove(usuario.Id);

            return NoContent();
        }
    }
}