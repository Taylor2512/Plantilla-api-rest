using DOMAIN.Dtos.Persona;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IServices.Persona
{
    public interface IServicioUsuarios
    {
        Task<RespuestaAutenticacion> ConstruirToken(LoginDto entidad);
        Task<List<UsuarioDo>> GetAllUsers();
        Task<SignInResult> Login(LoginDto entidad);
        Task<IdentityResult> Registrar(UsuarioDo entidad);
    }
}
