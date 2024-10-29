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
    public class TipoExtController : ControllerBase
    {
        private readonly BDContext_DEQ _Basededatos; //se declara variable para acceso a la base 

        public TipoExtController(BDContext_DEQ basededatos)
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
                var consulta = _Basededatos.TipoExtintor.Where(x=>x.Status==true).ToList(); //para devolver una lista
                foreach (var cons in consulta)
                {
                    AnonymousTipoExt tipoExt = new AnonymousTipoExt();
                    tipoExt.IdTipoExtintor=cons.IdTipoExtintor;
                    tipoExt.Descripcion = cons.Descripcion;
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
    }
}
