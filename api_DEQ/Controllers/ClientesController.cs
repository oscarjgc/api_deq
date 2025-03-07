using api_DEQ.Models;
using LC_DEQ.Models.BaseDeDatos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_DEQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientesController : ControllerBase
    {
        private readonly BDContext_DEQ _Basededatos;

        public ClientesController(BDContext_DEQ basededatos)
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
                var consulta = _Basededatos.Clientes.Where(x => x.Status == true).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor = cons.IdCliente;
                    tipoExt.Descripcion = cons.Nombre;
                    lista.Add(tipoExt);
                }
                actionResult = Ok(lista);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message });
            }
            return actionResult;
        }

        [HttpGet("{idcliente}")]

        public IActionResult obtenerCliente(int idcliente)
        {
            IActionResult actionResult = null;
            List<Nombre> lista = new List<Nombre>();
            try
            {
                var consulta = _Basededatos.Clientes.Where(x => x.IdCliente == idcliente && x.Status == true).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    Nombre tipoExt = new Nombre();
                    tipoExt.idcliente = cons.IdCliente;
                    tipoExt.NombreCompleto = cons.Nombre;
                    tipoExt.status = cons.Status;
                    lista.Add(tipoExt);
                }
                actionResult = Ok(lista);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message });
            }
            return actionResult;
        }

        [HttpPost]

        public IActionResult guardar(Nombre cliente)
        {
            IActionResult actionResult = null;
            try
            {
                Cliente clienteExt = new Cliente();
                clienteExt.Nombre = cliente.NombreCompleto;
                clienteExt.Status = true;
                _Basededatos.Clientes.Add(clienteExt);
                _Basededatos.SaveChanges();
                actionResult = Ok(new { mensaje = "Cliente guardado" });
            }
            catch (Exception ex)
            {
                actionResult= BadRequest(new { resultado = ex.Message });
            }


            return actionResult;
        }

        [HttpPut]

        public IActionResult Modificar(Nombre cliente)
        {
            IActionResult actionResult = null;
            try
            {
                Cliente clienteExt = _Basededatos.Clientes.Where(x => x.IdCliente == cliente.idcliente.Value).FirstOrDefault()!;

                if (clienteExt == null)
                {
                    throw new ArgumentException("No Existe el Cliente.");
                }

                clienteExt.Nombre = cliente.NombreCompleto;
                clienteExt.Status = cliente.status;
                _Basededatos.Clientes.Update(clienteExt);
                _Basededatos.SaveChanges();
                actionResult = Ok(new { mensaje = "Cliente modificado" });
            }
            catch (Exception ex)
            { 
                actionResult = BadRequest(new { resultado = ex.Message });
            }

            return actionResult;
        }
        [HttpDelete("Borrar_Clientes/{idcliente}")]
        public IActionResult Eliminar(int idcliente)
        {
            IActionResult actionResult = null;
            try
            {
                Cliente clienteExt = _Basededatos.Clientes.Where(x => x.IdCliente == idcliente).FirstOrDefault()!;

                if (clienteExt == null)
                {
                    throw new ArgumentException("No Existe el Cliente.");
                }

                
                clienteExt.Status = false;
                _Basededatos.Clientes.Update(clienteExt);
                _Basededatos.SaveChanges();
                actionResult = Ok(new { mensaje = "Cliente eliminado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message });
            }

            return actionResult;
        }
    }
}
