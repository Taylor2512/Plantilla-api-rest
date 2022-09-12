using DOMAIN.Interfaces.IRespositorio.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IExtensionR.Persona
{
    public interface IExtensionPersonaR
    {
        public IUsuarioR usuarioR { set; get; }
    }
}
