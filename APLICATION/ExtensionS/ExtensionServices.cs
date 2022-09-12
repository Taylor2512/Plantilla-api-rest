using DOMAIN.Interfaces.IExtensionS;
using DOMAIN.Interfaces.IServices.Inventario;
using DOMAIN.Interfaces.IServices.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION.ExtensionS
{
    public class ExtensionServices<T> : IExtensionServices<T>
    {
        public T Extension { get; set; }

        public ExtensionServices(T extension)
        {
            Extension = extension;
        }
    }
   
}
