using DOMAIN.Entities.Persona;
using DOMAIN.Helper.Generador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities.Archivos
{
    public class ImagenesPersona:Entity<Guid>
    {
        public string name { set; get; }
        public string? RouteFile { set; get; }
        public string IdUsuario { set; get; }
        public Usuarios usuarios { set; get; }
    }
}
