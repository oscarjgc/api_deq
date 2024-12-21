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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //este es para validar el token
    public class EAController : ControllerBase
    {
        private readonly BDContext_DEQ _Basededatos; //se declara variable para acceso a la base 
        public EAController(BDContext_DEQ basededatos)
        {
            _Basededatos = basededatos;
        }
        [HttpGet] // metodo get para llenar el combo // 1ro obtenemos todo
        public IActionResult obtener()
        {
            IActionResult actionResult = null;
            List<AnonymousTipoExt> lista = new List<AnonymousTipoExt>();
            try
            {
                var consulta = _Basededatos.EquipoAutonomo.Where(x => x.Status == true).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor = cons.IdAutonomo;
                    tipoExt.Descripcion = cons.NumeroAutonomo;
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

        [HttpGet("{idcliente}")] // metodo get para llenar el combo// 2do obtenemos por ID
        public IActionResult obtener_por_idcliente(int idcliente) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            List<AnonymousTipoExt> lista = new List<AnonymousTipoExt>();
            try
            {
                var consulta = _Basededatos.EquipoAutonomo.Where(x => x.Status == true && x.IdCliente == idcliente).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor = cons.IdAutonomo;
                    tipoExt.Descripcion = cons.NumeroAutonomo;
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

        [HttpGet("obtener/{id_autonomo}")] // metodo get para llenar el combo// 2do obtenemos por ID
        public IActionResult obtener_por_id_autonomo(int id_autonomo) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            List<AnonymousEA> lista = new List<AnonymousEA>(); 
            try
            {
                var consulta = _Basededatos.EquipoAutonomo.Where(x => x.Status == true && x.IdAutonomo == id_autonomo).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousEA tipoEA = new AnonymousEA(); // se crea el objeto de Equipo autonomo
                    tipoEA.IdAutonomo = cons.IdAutonomo;
                    tipoEA.NumeroAutonomo = cons.NumeroAutonomo;
                    tipoEA.Status = cons.Status;
                    tipoEA.IdCliente = cons.IdCliente;
                    
                    lista.Add(tipoEA); // se carga Equipo autonomo a la lista 
                }
                actionResult = Ok(lista);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }

        [HttpPost] // el verbo post es para indicar que es un guardado o extritura
        public IActionResult guardar_EA(AnonymousEA EA) // Se recibe el nuevo Equipo Autonomo (dar de alta)
        {
            IActionResult actionResult = null;
            try
            {
                EquipoAutonomo nuevo_EA = new EquipoAutonomo(); // creamos el objeto que vamos a guardar y hacemos asignacion/  el new equipo autonomo ¿que es? es el contructor que se manda a llamar
                nuevo_EA.NumeroAutonomo = EA.NumeroAutonomo;
                nuevo_EA.IdCliente = EA.IdCliente;
                nuevo_EA.Status = true;
                _Basededatos.EquipoAutonomo.Add(nuevo_EA); // se agrega el Equipo Autonomo a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok(new { mensaje = "Equipo Autonomo guardado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        [HttpPut] // el verbo put es para indicar que es una modificacion (http es el hiper de navegacion, en otras palabras son protocolos de navegacion)
        public IActionResult modificar_EA(AnonymousEA EA) // Se modifica el Equipo Autonomo
        {
            IActionResult actionResult = null;
            try
            {
                EquipoAutonomo nuevo_EA = _Basededatos.EquipoAutonomo.Where(x => x.IdAutonomo == EA.IdAutonomo).FirstOrDefault(); // obtenemos el extintor guardado que vamos a modificar
                nuevo_EA.NumeroAutonomo = EA.NumeroAutonomo;
                nuevo_EA.IdCliente = EA.IdCliente;
                nuevo_EA.Status = EA.Status;
                _Basededatos.EquipoAutonomo.Update(nuevo_EA); // se modifica el Equipon Autonomo a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok(new { mensaje = "Equipo Autonomo modificado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        [HttpDelete("Borrar_EA/{idEA}")] // 
        public IActionResult Borrar_EA(int id_EA) // se espesifica que se quiere borrar el extintor por ID
        {
            IActionResult actionResult = null;

            try
            {
                var consulta = _Basededatos.EquipoAutonomo.Where(x => x.IdAutonomo == id_EA).FirstOrDefault(); // para obtener el extintor a borrar
                EquipoAutonomo EA = consulta; //se asigna el equipo autonomo encontrado
                EA.Status = false; // se deshabilita el equipo autonomo
                _Basededatos.EquipoAutonomo.Update(EA); // se inserta en tabla
                _Basededatos.SaveChanges(); // se guardan
                actionResult = Ok(new { mensaje = "Equipo Autonomo eliminado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }
    }
}
