using DOMAIN.Entities.Persona;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Config.Persona
{
    internal interface IPersonaConfig: IEntityTypeConfiguration<Usuarios>
    {
    }
}
