using api_DEQ.Models;
using api_DEQ.Utilerias;
using LC_DEQ.Models.BaseDeDatos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_DEQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //este es para validar el token
    public class UsuariosController : Controller
    {
        private readonly BDContext_DEQ _Basededatos;

        public UsuariosController(BDContext_DEQ basededatos)
        {
            _Basededatos = basededatos;
        }
        [HttpGet]

        public IActionResult obtener()
        {
            IActionResult actionResult = null;
            List<AnonymousTipoExt> lista = new List<AnonymousTipoExt>();
            try
            {
                var consulta = _Basededatos.Usuario.Where(x => x.Status == true).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor = cons.IdUsuario;
                    tipoExt.Descripcion = cons.UsuarioName;
                    lista.Add(tipoExt);
                }
                actionResult = Ok(lista);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }


        [HttpPost]

        public IActionResult guardar(Usuario usuario)
        {
            IActionResult actionResult = null;
            try
            {
                Usuario clienteExt = new Usuario();
                clienteExt.UsuarioName = usuario.UsuarioName;
                clienteExt.Status = true;
                clienteExt.Contrasenia = Utileria.Creahash(usuario.Contrasenia);
                clienteExt.IdPerfil = usuario.IdPerfil;
                clienteExt.IdCliente = usuario.IdCliente;
                _Basededatos.Usuario.Add(clienteExt);
                _Basededatos.SaveChanges();
                actionResult = Ok(new { mensaje = "Usuario guardado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }


            return actionResult;
        }

        [HttpPut]

        public IActionResult Modificar(Usuario usuario)
        {
            IActionResult actionResult = null;
            try
            {
                Usuario clienteExt = _Basededatos.Usuario.Where(x => x.IdUsuario == usuario.IdUsuario).FirstOrDefault()!;

                if (clienteExt == null)
                {
                    throw new ArgumentException("No Existe el Usuario.");
                }

                clienteExt.Contrasenia = Utileria.Creahash(usuario.Contrasenia);
  
                _Basededatos.Usuario.Update(clienteExt);
                _Basededatos.SaveChanges();
                actionResult = Ok(new { mensaje = "Usuario modificado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }

            return actionResult;
        }
        [HttpDelete("Borrar_Usuario/{idusuario}")]
        public IActionResult Eliminar(int idusuario)
        {
            IActionResult actionResult = null;
            try
            {
                Usuario clienteExt = _Basededatos.Usuario.Where(x => x.IdUsuario == idusuario).FirstOrDefault()!;

                if (clienteExt == null)
                {
                    throw new ArgumentException("No Existe el Usuario.");
                }


                clienteExt.Status = false;
                _Basededatos.Usuario.Update(clienteExt);
                _Basededatos.SaveChanges();
                actionResult = Ok(new { mensaje = "Usuario eliminado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }

            return actionResult;
        }
    }
}
