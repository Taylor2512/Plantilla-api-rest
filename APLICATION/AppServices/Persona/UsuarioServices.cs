using DOMAIN.Dtos.Persona;
using DOMAIN.Entities.Persona;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using APLICATION.AppConfig;
using DOMAIN.Helper.Tools;
using DOMAIN.Interfaces.IServicesExternals.Azure;
using DOMAIN.Interfaces.IServices.Persona;
using DOMAIN.Interfaces.IExtensionR;
using DOMAIN.Interfaces.IExtensionR.Persona;
using AutoMapper;

namespace APLICATION.AppServices.Persona
{
    public class UsuarioServices: IServicioUsuarios
    {
        private readonly UserManager<Usuarios> userManager;
        private readonly SignInManager<Usuarios> signInManager;
        private readonly IConfiguration configuration;
        private readonly IAzureStorageService azure;
        private IExtensionRepository<IExtensionPersonaR> repository;
        private IMapper mapper;

        public UsuarioServices(UserManager<Usuarios> userManager, SignInManager<Usuarios> signInManager, IConfiguration configuration, IAzureStorageService azure, IExtensionRepository<IExtensionPersonaR> repository, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.azure = azure;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> Registrar(UsuarioDo usuario)
        {
            Usuarios usuarioIdentity = new Usuarios
            {
                PhoneNumber = usuario.phone,
                UserName = usuario.Email,
                LastName = usuario.LastName,
                Name = usuario.Name,
                Email = usuario.Email,
               // ImagenesPersona = new List<DOMAIN.Entities.Archivos.ImagenesPersona>(),
            };
            if (usuario.Files!=null&& usuario.Files.Count > 0)
            {
                await usuario.Files.ForEachAsync(async e =>
                {

                    usuarioIdentity.ImagenesPersona.Add(new DOMAIN.Entities.Archivos.ImagenesPersona
                    {
                        name = await azure.UploadAsync(e, DOMAIN.Helper.Enums.AppsExternals.ContainerEnum.IMAGENES),

                    });

                    await Task.CompletedTask;
                });
            }
           
            
            var resultado = await userManager.CreateAsync(usuarioIdentity, usuario.Password);

            return resultado;
        }

        public async Task<SignInResult> Login(CredencialesUsuario credencialesUsuario)
        {
            var resultado = await signInManager.PasswordSignInAsync(credencialesUsuario.Email, credencialesUsuario.Password,
                isPersistent: false, lockoutOnFailure: false);
            return resultado;
        }
        public async Task<RespuestaAutenticacion> ConstruirToken(CredencialesUsuario credencialesUsuario)
        {
            var Claims = new List<Claim>()
            {
                new Claim("email",credencialesUsuario.Email)
            };
            var usuario = await userManager.FindByEmailAsync(credencialesUsuario.Email);
            var ClaimsDb = await userManager.GetClaimsAsync(usuario);
            Claims.AddRange(ClaimsDb);
            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["LlaveJwt"]));
            var cred = new SigningCredentials(llave, SecurityAlgorithms.Aes128CbcHmacSha256);
            var expiracion = DateTime.UtcNow.AddDays(2);
            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: Claims, expires: expiracion, signingCredentials: cred);
            return new RespuestaAutenticacion
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiracion,
            };
        }
        public async Task<Usuarios> obtenerUsuario(EmailDto user)
        {

            var usuario = await userManager.FindByEmailAsync(user.Email);
            return usuario;

        }

        public async Task<List<UsuarioDo>> GetAllUsers()
        {
           List<Usuarios> usuarios = new List<Usuarios>();
            usuarios = await repository.ExtensionR.usuarioR.GetAllUsers();
          return mapper.Map<List<UsuarioDo>>(usuarios); 

       }
    }
}