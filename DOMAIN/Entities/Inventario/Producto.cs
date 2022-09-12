using DOMAIN.Entities.Archivos;
using DOMAIN.Helper.Generador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities.Inventario
{
    public class Producto : Entity<Guid>
    {
        public string? NameProduct { set; get; }
        public string? Description { set; get; }
        public double Precio { set; get; }
        public int cantidad { set; get; }
        public List<ImagenesProducto> imagenes { set; get; }= new List<ImagenesProducto>();
        public Guid? IdUsuario { set; get; }

    }
}
