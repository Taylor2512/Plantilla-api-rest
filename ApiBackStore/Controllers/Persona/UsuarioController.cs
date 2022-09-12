using APLICATION.AppConfig;
using DOMAIN.Dtos.Persona;
using DOMAIN.Interfaces.IExtensionS;
using DOMAIN.Interfaces.IExtensionS.Persona;
using DOMAIN.Interfaces.IServices.Persona;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackStore.Controllers.Persona
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IExtensionServices<IExtensionPersonaS> servicio;

        public UsuarioController(IExtensionServices<IExtensionPersonaS> servicio)
        {
            this.servicio = servicio;
        }



        /// <summary>
        /// Obtener usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<object>> GetUsarios()
        {
            List<UsuarioDo> encontrado = await servicio.Extension.UsuarioS.GetAllUsers();
            return Ok(encontrado);
        }
        [HttpPost]
        public async Task<ActionResult<object>> PostUsuario([FromForm][FromBody]  UsuarioDo entidad)
        {
            IdentityResult ecnontrado = await servicio.Extension.UsuarioS.Registrar(entidad);

            return Ok(ecnontrado);
        }
    }
}
