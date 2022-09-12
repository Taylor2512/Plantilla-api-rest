using DOMAIN.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Dtos.Archivos
{
    public class ImagenesProductoDto
    {
        public Guid Id { set; get; }
        public Guid? Id_procuto { set; get; }
        public string? name { get; set; }
        public string? Description { get; set; }
        public string? RouteFile { get; set; }
        public Producto? Producto { set; get; }
    }
}
