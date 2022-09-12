using DOMAIN.Interfaces.IRespositorio.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IExtensionR.Inventario
{
    public interface IExtensionInventarioR
    {
        public IProductoR productoR { set; get; }
        
    }
}
