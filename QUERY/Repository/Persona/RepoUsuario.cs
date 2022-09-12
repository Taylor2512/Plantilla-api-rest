using DOMAIN.Entities.Persona;
using DOMAIN.Interfaces.IRespositorio.Persona;
using INFRASTRUCTURE.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUERY.Repository.Persona
{
    public class RepoUsuario:IUsuarioR
    {
        private readonly ApplicationDbContext _LContext;
        private  ApplicationDbContext _Context;

        public RepoUsuario(ApplicationDbContext lContext, ApplicationDbContext context)
        {
            _LContext = lContext;
            _Context = context;
        }

        public async Task<List<Usuarios>> GetAllUsers()
        {
            return await _LContext.tbl_usuario.ToListAsync();
        }
    }
}
