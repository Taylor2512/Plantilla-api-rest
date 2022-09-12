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
        Task<List<UsuarioDo>> GetAllUsers();
        Task<IdentityResult> Registrar(UsuarioDo entidad);
    }
}
