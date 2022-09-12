using DOMAIN.Interfaces.IExtensionR.Financiero;
using DOMAIN.Interfaces.IExtensionR.Inventario;
using DOMAIN.Interfaces.IRespositorio.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUERY.Extensions.Inventario
{
    public class ExtensionInventarioR : IExtensionInventarioR
    {
        public IProductoR productoR { set; get; }

        public ExtensionInventarioR(IProductoR productoR)
        {
            this.productoR = productoR;
        }
    }
}
