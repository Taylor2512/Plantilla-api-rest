using DOMAIN.Dtos.Persona;
using DOMAIN.Entities.Persona;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using APLICATION.AppConfig;

namespace APLICATION.AppServices.Persona
{
    public class UsuarioServices: IServicioUsuarios
    {
        private readonly UserManager<Usuarios> userManager;
        private readonly SignInManager<Usuarios> signInManager;
        private readonly IConfiguration configuration;

        public async Task<IdentityResult> Registrar(CredencialesUsuario usuario)
        {
            Usuarios usuarioIdentity = new Usuarios
            {
                UserName = usuario.Email,
                Email = usuario.Email,
            };
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


    }
}