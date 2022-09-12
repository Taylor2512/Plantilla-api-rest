using DOMAIN.Dtos.Archivos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Dtos.Inventario
{
    public class ProductoDto
    {
       // public Guid? Id { get; set; }    
        public string NameProduct { set; get; }
        public string Description { set; get; }
        public double Precio { set; get; }
        public int cantidad { set; get; }
        public List<IFormFile> Files { set; get; }

    }
    public class ProductoGetDto
    {
         public Guid? Id { get; set; }    
        public string NameProduct { set; get; }
        public string Description { set; get; }
        public double Precio { set; get; }
        public int cantidad { set; get; }
        public List<ImagenesProductoDto> imagenes { set; get; }= new List<ImagenesProductoDto>();

    }
}
