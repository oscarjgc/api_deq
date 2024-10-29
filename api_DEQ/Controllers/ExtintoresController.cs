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
    public class ExtintoresController : ControllerBase
    {
        private readonly BDContext_DEQ _Basededatos; //se declara variable para acceso a la base 
        public ExtintoresController(BDContext_DEQ basededatos) { //contructor en donde inicializamos la variable de la conexion a la base de datos
            _Basededatos = basededatos;
        }

        [HttpGet] // metodo get para llenar el combo // 1ro obtenemos todo
        public IActionResult obtener()
        {
            IActionResult actionResult = null;
            List<AnonymousTipoExt> lista = new List<AnonymousTipoExt>();
            try
            {
                var consulta = _Basededatos.Extintor.Where(x => x.Status == true).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor = cons.IdExtintor;
                    tipoExt.Descripcion = cons.NumeroDeExtintor;
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
                var consulta = _Basededatos.Extintor.Where(x => x.Status == true && x.IdCliente == idcliente).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor = cons.IdExtintor;
                    tipoExt.Descripcion = cons.NumeroDeExtintor;
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

        [HttpGet("obtener/{idextintor}")] // metodo get para llenar el combo// 2do obtenemos por ID
        public IActionResult obtener_por_idextintor(int idextintor) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            List<AnonymousExtintor> lista = new List<AnonymousExtintor>();
            try
            {
                var consulta = _Basededatos.Extintor.Where(x => x.Status == true && x.IdExtintor == idextintor).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousExtintor tipoExt = new AnonymousExtintor(); // se crea el objeto de extinrores
                    tipoExt.IdExtintor = cons.IdExtintor;
                    tipoExt.NumeroDeExtintor = cons.NumeroDeExtintor;
                    tipoExt.IdTipoExtintor = cons.IdTipoExtintor;
                    tipoExt.Status = cons.Status;
                    tipoExt.IdCliente = cons.IdCliente;
                    tipoExt.FechaFabricacion = cons.FechaFabricacion;
                    lista.Add(tipoExt); // se carga extintor a la lista 
                }
                actionResult = Ok(lista);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        [HttpPost] // el verbo post es para indicar que es un guardado o extritura
        public IActionResult guardar_extintor (AnonymousExtintor extintor) // Se recibe el nuevo extintor (dar de alta)
        {
            IActionResult actionResult = null;
            try
            {
                Extintor nuevo_extintor = new Extintor(); // creamos el objeto que vamos a guardar y hacemos asignacion
                nuevo_extintor.NumeroDeExtintor = extintor.NumeroDeExtintor;
                nuevo_extintor.IdCliente = extintor.IdCliente;
                nuevo_extintor.Status = true;
                nuevo_extintor.IdTipoExtintor = extintor.IdTipoExtintor;
                nuevo_extintor.FechaFabricacion = extintor.FechaFabricacion.Value;
                _Basededatos.Extintor.Add(nuevo_extintor); // se agrega el extintor a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok("Extintor guardado");
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        [HttpPut] // el verbo put es para indicar que es una modificacion (http es el hiper de navegacion, en otras palabras son protocolos de navegacion)
        public IActionResult modificar_extintor(AnonymousExtintor extintor) // Se modifica el extintor
        {
            IActionResult actionResult = null;
            try
            {
                Extintor nuevo_extintor = _Basededatos.Extintor.Where(x=>x.IdExtintor==extintor.IdExtintor).FirstOrDefault(); // obtenemos el extintor guardado que vamos a modificar
                nuevo_extintor.NumeroDeExtintor = extintor.NumeroDeExtintor;
                nuevo_extintor.IdCliente = extintor.IdCliente;
                nuevo_extintor.Status = extintor.Status;
                nuevo_extintor.IdTipoExtintor = extintor.IdTipoExtintor;
                nuevo_extintor.FechaFabricacion = extintor.FechaFabricacion.Value;
                _Basededatos.Extintor.Update(nuevo_extintor); // se modifica el extintor a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok("Extintor modificado");
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }

        [HttpDelete] // 
        public IActionResult Borrar_Extintores(int idextintor) // se espesifica que se quiere borrar el extintor por ID
        {
            IActionResult actionResult = null;

            try
            {
                var consulta = _Basededatos.Extintor.Where(x => x.IdExtintor == idextintor).FirstOrDefault(); // para obtener el extintor a borrar
                Extintor extintor = consulta; //se asigna el extintor encontrado
                extintor.Status = false; // se deshabilita el extintor
                _Basededatos.Extintor.Update(extintor); // se inserta en tabla
                _Basededatos.SaveChanges(); // se guardan
                actionResult = Ok("Extintor eliminado");
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }
            return actionResult;
        }
    }
}
