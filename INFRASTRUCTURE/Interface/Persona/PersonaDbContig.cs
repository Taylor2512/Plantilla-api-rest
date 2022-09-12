using DOMAIN.Entities.Persona;
using DOMAIN.Helper.Enums.DB;
using INFRASTRUCTURE.Config.Persona;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Interface.Persona
{
    internal class PersonaDbContig : IPersonaConfig
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable(TableDB.tbl_usuario.ToString());
            builder.HasMany(e => e.ImagenesPersona).WithOne(e => e.usuarios).HasForeignKey(e => e.IdUsuario);


        }
    }
}
