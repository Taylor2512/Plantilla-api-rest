using DOMAIN.Entities.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IRespositorio.Persona
{
    public interface IUsuarioR
    {
        Task<List<Usuarios>> GetAllUsers();
    }
}
