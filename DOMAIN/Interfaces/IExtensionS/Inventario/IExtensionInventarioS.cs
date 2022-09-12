using DOMAIN.Interfaces.IServices.Inventario;
using DOMAIN.Interfaces.IServices.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IExtensionS.Inventario
{
    public interface IExtensionInventarioS
    {
        
        public IProductoServices ProductoS { set; get; }
    }
}
