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
    public class HidranteController : ControllerBase
    {
        private readonly BDContext_DEQ _Basededatos; //se declara variable para acceso a la base 

        public HidranteController(BDContext_DEQ basededatos)
        {
            _Basededatos= basededatos;
        }

        [HttpGet] // metodo get para llenar el combo // 1ro obtenemos todo
        public IActionResult obtener()
        {
            IActionResult actionResult = null;
            List<AnonymousTipoExt> lista = new List<AnonymousTipoExt>();
            try
            {
                var consulta = _Basededatos.Hidrante.Where(x => x.Status == true).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor = cons.IdHidrante;
                    tipoExt.Descripcion = cons.NumeroHidrante;
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
                var consulta = _Basededatos.Hidrante.Where(x => x.Status == true && x.IdCliente == idcliente).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor = cons.IdHidrante;
                    tipoExt.Descripcion = cons.NumeroHidrante;
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

        [HttpGet("obtener/{id_hidrante}")] // metodo get para llenar el combo// 2do obtenemos por ID
        public IActionResult obtener_por_id_hidrante(int id_hidrante) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            List<AnonymousEA> lista = new List<AnonymousEA>();
            try
            {
                var consulta = _Basededatos.Hidrante.Where(x => x.Status == true && x.IdHidrante == id_hidrante).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousEA tipoEA = new AnonymousEA(); // se crea el objeto de Hidrante
                    tipoEA.IdAutonomo = cons.IdHidrante;
                    tipoEA.NumeroAutonomo = cons.NumeroHidrante;
                    tipoEA.Status = cons.Status;
                    tipoEA.IdCliente = cons.IdCliente;

                    lista.Add(tipoEA); // se carga Hidrante a la lista 
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
        public IActionResult guardar_hidrante(AnonymousEA Hidrante) // Se recibe el nuevo Hidrante (dar de alta)
        {
            IActionResult actionResult = null;
            try
            {
                Hidrante nuevo_Hidrante = new Hidrante(); // creamos el objeto que vamos a guardar y hacemos asignacion/  el new Hidrante ¿que es? es el contructor que se manda a llamar
                nuevo_Hidrante.NumeroHidrante = Hidrante.NumeroAutonomo;
                nuevo_Hidrante.IdCliente = Hidrante.IdCliente;
                nuevo_Hidrante.Status = true;
                _Basededatos.Hidrante.Add(nuevo_Hidrante); // se agrega el Hidrante a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok("Hidrante guardado");
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        [HttpPut] // el verbo put es para indicar que es una modificacion (http es el hiper de navegacion, en otras palabras son protocolos de navegacion)
        public IActionResult modificar_Hidrante(AnonymousEA Hidrante) // Se modifica el Equipo Autonomo
        {
            IActionResult actionResult = null;
            try
            {
                Hidrante nuevo_Hidrante = _Basededatos.Hidrante.Where(x => x.IdHidrante == Hidrante.IdAutonomo).FirstOrDefault(); // obtenemos el Hidrante guardado que vamos a modificar
                nuevo_Hidrante.NumeroHidrante = Hidrante.NumeroAutonomo;
                nuevo_Hidrante.IdCliente = Hidrante.IdCliente;
                nuevo_Hidrante.Status = Hidrante.Status;
                _Basededatos.Hidrante.Update(nuevo_Hidrante); // se modifica el Hidrante a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok("Hidrante modificado");
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        [HttpDelete] // 
        public IActionResult Borrar_Hidrante(int id_Hidrante) // se espesifica que se quiere borrar el Hidrante por ID
        {
            IActionResult actionResult = null;

            try
            {
                var consulta = _Basededatos.Hidrante.Where(x => x.IdHidrante == id_Hidrante).FirstOrDefault(); // para obtener el Hidrante a borrar
                Hidrante hidrante = consulta; //se asigna el Hidrante encontrado
                hidrante.Status = false; // se deshabilita el Hidrante
                _Basededatos.Hidrante.Update(hidrante); // se inserta en tabla
                _Basededatos.SaveChanges(); // se guardan
                actionResult = Ok("Hidrante eliminado");
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }
    }
}
