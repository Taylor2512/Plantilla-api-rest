using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Dtos.Persona
{
    public class UsuarioDo
    {
        public string Email { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string Password { set; get; }
        public string phone { get; set; }
        public List<IFormFile> Files { set; get; } 
    }
}
