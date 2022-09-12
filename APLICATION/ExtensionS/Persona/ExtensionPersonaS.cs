using DOMAIN.Interfaces.IExtensionS.Persona;
using DOMAIN.Interfaces.IServices.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION.ExtensionS.Persona
{
    internal class ExtensionPersonaS : IExtensionPersonaS
    {
        public IServicioUsuarios UsuarioS { get; set ; }

        public ExtensionPersonaS(IServicioUsuarios usuarioS)
        {
            UsuarioS = usuarioS;
        }
    }
}
