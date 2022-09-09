﻿using DOMAIN.Dtos.Persona;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackStore.Controllers.Persona
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Obtener usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<object>> GetUsarios()
        {

            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<object>> PostUsuarios(UsuarioDo entidad)
        {

            return Ok();
        }
    }
}