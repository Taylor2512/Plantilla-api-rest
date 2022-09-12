using DOMAIN.Interfaces.IServices.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IExtensionS.Persona
{
    public interface IExtensionPersonaS
    {
        public IServicioUsuarios UsuarioS { set; get; }
    }
}
