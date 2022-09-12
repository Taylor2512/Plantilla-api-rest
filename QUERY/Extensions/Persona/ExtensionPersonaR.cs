using DOMAIN.Interfaces.IExtensionR.Financiero;
using DOMAIN.Interfaces.IExtensionR.Persona;
using DOMAIN.Interfaces.IRespositorio.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUERY.Extensions.Persona
{
    public class ExtensionPersonaR: IExtensionPersonaR
    {
        public IUsuarioR usuarioR { get ; set ; }

        public ExtensionPersonaR(IUsuarioR usuarioR)
        {
            this.usuarioR = usuarioR;
        }
    }
}
