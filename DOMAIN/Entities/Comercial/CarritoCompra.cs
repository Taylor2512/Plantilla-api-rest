using DOMAIN.Helper.Generador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities.Comercial
{
    public class CarritoCompra:Entity<Guid>
    {
        public string nameCarrito { get; set; }
        public Guid Id_usuario { get; set; }
       
        
    }
}
