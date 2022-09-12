using DOMAIN.Entities.Archivos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities.Persona
{
    public class Usuarios : IdentityUser
    {
        public Usuarios()
        {
        }

        public Usuarios(string name, string lastName, List<ImagenesPersona> imagenesPersona)
        {
            Name = name;
            LastName = lastName;
            ImagenesPersona = imagenesPersona;
        }

        public string Name { set; get; }
        public string LastName { set; get; }
        public List<ImagenesPersona> ImagenesPersona { get; set; }

    }
}
