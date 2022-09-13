using APLICATION.ExtensionS;
using DOMAIN.Dtos.Persona;
using DOMAIN.Interfaces.IExtensionS;
using DOMAIN.Interfaces.IExtensionS.Persona;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackStore.Controllers.Persona
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private IExtensionServices<IExtensionPersonaS> servicio;

        public LoginController(IExtensionServices<IExtensionPersonaS> servicio)
        {
            this.servicio = servicio;
        }

        [HttpPost]
        public async Task<ActionResult<RespuestaAutenticacion>> Login(LoginDto entidad)
        {
            var login = await servicio.Extension.UsuarioS.Login(entidad);
            if (login.Succeeded)
            {
                RespuestaAutenticacion respuesta = await servicio.Extension.UsuarioS.ConstruirToken(entidad);
                return respuesta;
            }
            else
            {
                return BadRequest("Usuario incorrecto");
            }
            return Ok(login);
        }
    }
}
