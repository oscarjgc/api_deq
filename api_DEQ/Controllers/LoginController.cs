using api_DEQ.Models;
using api_DEQ.Utilerias;
using LC_DEQ.Models.BaseDeDatos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_DEQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BDContext_DEQ _Basededatos;
        public LoginController(BDContext_DEQ Basededatos) {
            _Basededatos = Basededatos;
        }
        [HttpGet("obtener")]
        public IActionResult Get()
        {
            //Usuario usuario = new Usuario()
            //{
            //    Status = true,
            //    UsuarioName = "cliente",
            //    Contrasenia = Utileria.Creahash("123")
            //};
            //_Basededatos.Usuario.Add(usuario);
            //_Basededatos.SaveChanges();
        //Usuario: admin(contrasenia: 123)
            return Ok("Hola");

        }

        [HttpPost("IniciarSesion")]
        public IActionResult IniciarSesion (UserInfo userInfo){ 

            IActionResult actionResult = null;

            try
            {
                Usuario usuario = _Basededatos.Usuario.Where(x=>x.UsuarioName==userInfo.Nombre && x.Status == true).FirstOrDefault()!;
                if (usuario == null)
                {
                    throw new ArgumentException("Usuario no existe.");
                }
                if (Utileria.Creahash(userInfo.Contrasenia) != usuario.Contrasenia)
                {
                    throw new ArgumentException("Contrasenia Incorrecta.");
                }

                actionResult = BuildToken(userInfo, usuario);

            }
            catch (Exception ex) 
            {
                actionResult = BadRequest(ex.Message);
            }

            return actionResult;
        }

        private IActionResult BuildToken(UserInfo userInfo, Usuario res) // token
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Nombre),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("***Osvaldo.141197***")); // esta configuracion se tiene que tener igual el Program
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(24);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "192.168.0.10",
               audience: "192.168.0.10",
               claims: claims,
               expires: expiration,
               signingCredentials: creds); // token
            int IdPerfil, IdCliente;
            if(res.UsuarioName == "admin")
            {
                IdPerfil = 1;
                IdCliente = 0;
            }
            else
            {
                IdPerfil = 2;
                IdCliente = 1;
            }
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration,
                Resultado = "éxito",
                Fecha = DateTime.Now,
                IdUsuario = res.IdUsuario,
                NombreUsuario = res.UsuarioName,
                IdPerfil = IdPerfil,
                IdCliente = IdCliente
            });
        }

    }

}
