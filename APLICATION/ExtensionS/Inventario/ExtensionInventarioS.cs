using DOMAIN.Interfaces.IExtensionS.Inventario;
using DOMAIN.Interfaces.IServices.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION.ExtensionS.Inventario
{
    public class ExtensionInventarioS: IExtensionInventarioS
    {
        public IProductoServices ProductoS { set; get; }

        public ExtensionInventarioS(IProductoServices productoS)
        {
            ProductoS = productoS;
        }
    }
}
