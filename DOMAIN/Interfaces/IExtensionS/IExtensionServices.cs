using DOMAIN.Dtos.Inventario;
using DOMAIN.Interfaces.IServices.Inventario;
using DOMAIN.Interfaces.IServices.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IExtensionS
{
    public interface IExtensionServices<T>
    {
        public T Extension { set; get; }

        
    }
   
}
