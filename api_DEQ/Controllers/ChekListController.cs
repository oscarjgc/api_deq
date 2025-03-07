using api_DEQ.Models;
using LC_DEQ.Models.BaseDeDatos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_DEQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //este es para validar el token
    public class ChekListController : ControllerBase
    {
        private readonly BDContext_DEQ _Basededatos; //se declara variable para acceso a la base 

        public ChekListController(BDContext_DEQ basededatos)
        {
            _Basededatos = basededatos;

        }

        /// <summary>
        /// ////////////////////////////////////////////EXTINTORES////////////////////////////////////////
        /// </summary>
        /// <param name="chekExt"></param>
        /// <returns></returns>
        // este metodo es para guardar el cheklist de extintores
        [HttpPost("Guardar_chek_extintor")] // el verbo post es para indicar que es un guardado o extritura
        public IActionResult guardar_ChekExtintor(AnonymousChekExt chekExt) // Se recibe el nuevo Chek List (dar de alta)
        {
            IActionResult actionResult = null;
            try
            {
                CheckListExtintor checkListExtintor = new CheckListExtintor();
                checkListExtintor.IdExtintor = chekExt.IdExtintor; //Asignacion
                checkListExtintor.Letrero = chekExt.Letrero;
                checkListExtintor.NumeroExtintor = chekExt.NumeroExtintor;
                checkListExtintor.Funda = chekExt.Funda;
                checkListExtintor.Base = chekExt.Base;
                checkListExtintor.Seguro = chekExt.Seguro;
                checkListExtintor.Manometro = chekExt.Manometro;
                checkListExtintor.Observaciones = chekExt.Observaciones;
                //checkListExtintor.FechaHoraCaptura = chekExt.FechaHoraCaptura;
                checkListExtintor.FechaServicio = chekExt.FechaServicio;
                checkListExtintor.IdUsuario = chekExt.IdUsuario;
                checkListExtintor.Obstrucciones = chekExt.Obstrucciones;
                checkListExtintor.TipoDeRevision = chekExt.TipoDeRevision;
                _Basededatos.CLE.Add(checkListExtintor); // se agrega el Chek List a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok(new { mensaje = "Guardado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message });
            }
            return actionResult;

             
        }
        //ESTE METODO ES PARA OBTENER TODOS LOS CHEK LIST DE MANERA GENERAL, ES DECIR; OBTENER TODO.
        [HttpGet("obtener_cheklist_extintores")] // metodo get para llenar el combo// 
        public IActionResult obtener_cheklistExtintores() // 
        {
            IActionResult actionResult = null;
            List<AnonymousChekListGeneral> lista = new List<AnonymousChekListGeneral>();
            try
            {
                var consulta = _Basededatos.CLE.Include(x => x.Extintor.Cliente).ToList();
                foreach (var cons in consulta)
                {
                    AnonymousChekListGeneral tipoCLG = new AnonymousChekListGeneral(); // 
                    tipoCLG.Id = cons.IdChekList;
                    tipoCLG.Cliente = cons.Extintor.Cliente.Nombre;
                    tipoCLG.FechaChekList = cons.FechaHoraCaptura;

                    lista.Add(tipoCLG); // 
                }
                actionResult = Ok(lista.OrderByDescending(x=>x.Id));
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }

        [HttpGet("obtener_cheklist_extintores/{id_cliente}")] // metodo get para llenar el combo// 2do obtenemos por ID CLIENTE
        public IActionResult obtener_cheklistExtintoresporcliente(int id_cliente) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            List<AnonymousChekListGeneral> lista = new List<AnonymousChekListGeneral>();
            try
            {
                var consulta = _Basededatos.CLE.Include(x => x.Extintor.Cliente).Where(x=>x.Extintor.IdCliente==id_cliente).ToList();
                foreach (var cons in consulta)
                {
                    AnonymousChekListGeneral tipoCLG = new AnonymousChekListGeneral(); // SE HACE INSTANCIA DEL OBJETO CLG , PARA QUE SE DEVUELVA
                    tipoCLG.Id = cons.IdChekList;
                    tipoCLG.Cliente = cons.Extintor.Cliente.Nombre;
                    tipoCLG.FechaChekList = cons.FechaHoraCaptura;

                    lista.Add(tipoCLG); // 
                }
                actionResult = Ok(lista.OrderByDescending(x => x.Id));
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }
        // ESTE METODO ES PARA REGRESAR EL OBJETO DEL CHEK LIST QUE CAPTURARON
        [HttpGet("obtener_cheklist_extintor/{id_cheklist}")] // metodo get para llenar el combo// 2do obtenemos POR EL CHEK LIST QUE SE HIZO, O EL MISMO CHEK LIST
        public IActionResult obtener_cheklistExtintor(int id_cheklist) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            AnonymousChekExt chekExt = new AnonymousChekExt();
            try
            {// SE OBTIENE EL CHEK LIST QUE SE SOLICITO DE ACUERDO A SU ID Y SE ASIGNAN TODOS LOS PARAMETROS AL OBJETO A DEVOLVER
                var consulta = _Basededatos.CLE.Include(x => x.Extintor.Cliente).Where(x => x.IdChekList == id_cheklist).FirstOrDefault();
                chekExt.IdExtintor = consulta.IdExtintor; //AsignacioN
                chekExt.Letrero = consulta.Letrero;
                chekExt.NumeroExtintor = consulta.NumeroExtintor;
                chekExt.Funda = consulta.Funda;
                chekExt.IdChekList = consulta.IdChekList;
                chekExt.Base = consulta.Base;
                chekExt.Seguro = consulta.Seguro;
                chekExt.Manometro = consulta.Manometro;
                chekExt.Observaciones = consulta.Observaciones;
                chekExt.FechaHoraCaptura = consulta.FechaHoraCaptura;
                chekExt.FechaServicio = consulta.FechaServicio;
                chekExt.IdUsuario = consulta.IdUsuario;
                chekExt.Obstrucciones = consulta.Obstrucciones;
                chekExt.TipoDeRevision = consulta.TipoDeRevision;
                actionResult = Ok(chekExt);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////HIDRANTES//////////////////////////////////////////////////

        // este metodo es para guardar el cheklist de extintores
        [HttpPost("Guardar_chek_hidrante")] // el verbo post es para indicar que es un guardado o extritura
        public IActionResult guardar_ChekHidrante(AnonymousChekH chekH) // Se recibe el nuevo Chek List (dar de alta)
        {
            IActionResult actionResult = null;
            try
            {
                CheckListH checkListH = new CheckListH();
                checkListH.NumeroHidrante = chekH.NumeroHidrante; //Asignacion
                checkListH.Boquilla = chekH.Boquilla;
                checkListH.NumeroHidrante = chekH.NumeroHidrante;
                checkListH.Funda = chekH.Funda;
                checkListH.IdHidrante = chekH.IdHidrante;
                checkListH.Observaciones = chekH.Observaciones;
                //checkListH.FechaHoraCaptura = chekExt.FechaHoraCaptura;
                //checkListH.FechaServicio = chekExt.FechaServicio;
                checkListH.IdUsuario = chekH.IdUsuario;
                checkListH.Obstrucciones = chekH.Obstrucciones;
                //checkListH.TipoDeRevision = chekExt.TipoDeRevision;
                _Basededatos.CLH.Add(checkListH); // se agrega el Chek List a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok(new { mensaje = "Guardado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message });
            }
            return actionResult;


        }
        //ESTE METODO ES PARA OBTENER TODOS LOS CHEK LIST DE MANERA GENERAL, ES DECIR; OBTENER TODO.
        [HttpGet("obtener_cheklist_hidrantes")] // metodo get para llenar el combo// 
        public IActionResult obtener_cheklistHidrantes() // 
        {
            IActionResult actionResult = null;
            List<AnonymousChekListGeneral> lista = new List<AnonymousChekListGeneral>();
            try
            {
                var consulta = _Basededatos.CLH.Include(x => x.Hidrante.Cliente).ToList();
                foreach (var cons in consulta)
                {
                    AnonymousChekListGeneral tipoCLG = new AnonymousChekListGeneral(); // 
                    tipoCLG.Id = cons.IdChecklistH;
                    tipoCLG.Cliente = cons.Hidrante.Cliente.Nombre;
                    tipoCLG.FechaChekList = cons.FechaHoraCaptura;

                    lista.Add(tipoCLG); // 
                }
                actionResult = Ok(lista.OrderByDescending(x => x.Id));
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }

        [HttpGet("obtener_cheklist_hidrantes/{id_cliente}")] // metodo get para llenar el combo// 2do obtenemos por ID CLIENTE
        public IActionResult obtener_cheklistHidrantesporcliente(int id_cliente) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            List<AnonymousChekListGeneral> lista = new List<AnonymousChekListGeneral>();
            try
            {
                var consulta = _Basededatos.CLH.Include(x => x.Hidrante.Cliente).Where(x => x.Hidrante.IdCliente == id_cliente).ToList();
                foreach (var cons in consulta)
                {
                    AnonymousChekListGeneral tipoCLG = new AnonymousChekListGeneral(); // SE HACE INSTANCIA DEL OBJETO CLG , PARA QUE SE DEVUELVA
                    tipoCLG.Id = cons.IdChecklistH;
                    tipoCLG.Cliente = cons.Hidrante.Cliente.Nombre;
                    tipoCLG.FechaChekList = cons.FechaHoraCaptura;

                    lista.Add(tipoCLG); // 
                }
                actionResult = Ok(lista.OrderByDescending(x => x.Id));
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }
        // ESTE METODO ES PARA REGRESAR EL OBJETO DEL CHEK LIST QUE CAPTURARON
        [HttpGet("obtener_cheklist_hidrante/{id_cheklist}")] // metodo get para llenar el combo// 2do obtenemos POR EL CHEK LIST QUE SE HIZO, O EL MISMO CHEK LIST
        public IActionResult obtener_cheklistHidrante(int id_cheklist) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            AnonymousChekH checkH = new AnonymousChekH();
            try
            {// SE OBTIENE EL CHEK LIST QUE SE SOLICITO DE ACUERDO A SU ID Y SE ASIGNAN TODOS LOS PARAMETROS AL OBJETO A DEVOLVER
                var consulta = _Basededatos.CLH.Include(x => x.Hidrante.Cliente).Where(x => x.IdChecklistH == id_cheklist).FirstOrDefault();
                checkH.NumeroHidrante = consulta.NumeroHidrante; //Asignacion del objeto que vamos a devolver
                checkH.Boquilla = consulta.Boquilla;
                checkH.NumeroHidrante = consulta.NumeroHidrante;
                checkH.Funda = consulta.Funda;
                checkH.IdChecklistH = consulta.IdChecklistH;
                checkH.IdHidrante = consulta.IdHidrante;
                checkH.Observaciones = consulta.Observaciones;
                checkH.FechaHoraCaptura = consulta.FechaHoraCaptura;
                //checkH.FechaServicio = consulta.FechaServicio;
                checkH.IdUsuario = consulta.IdUsuario;
                checkH.Obstrucciones = consulta.Obstrucciones;
                //checkH.TipoDeRevision = consulta.TipoDeRevision;
                actionResult = Ok(checkH);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////EQUIPO AUTONOMO//////////////////////////////////////////////////

        // este metodo es para guardar el cheklist de extintores
        [HttpPost("Guardar_chek_autonomo")] // el verbo post es para indicar que es un guardado o extritura
        public IActionResult guardar_ChekEA(AnonymousChekEA chekea) // Se recibe el nuevo Chek List (dar de alta)
        {
            IActionResult actionResult = null;
            try
            {
                CheckListEA checkListEA = new CheckListEA();
                checkListEA.IdAutonomo = chekea.IdAutonomo; //Asignacion
                checkListEA.Presion = chekea.Presion;
                checkListEA.Observaciones = chekea.Observaciones;
                //checkListEA.FechaHoraCaptura = chekea.FechaHoraCaptura;
                //checkListEA.FechaServicio = chekea.FechaServicio;
                checkListEA.IdUsuario = chekea.IdUsuario;
                checkListEA.Obstrucciones = chekea.Obstrucciones;
                //checkListEA.TipoDeRevision = chekea.TipoDeRevision;
                _Basededatos.CLEA.Add(checkListEA); // se agrega el Chek List a la tabla
                _Basededatos.SaveChanges(); // se confirman los cambios

                actionResult = Ok(new { mensaje = "Guardado" });
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message });
            }
            return actionResult;


        }
        //ESTE METODO ES PARA OBTENER TODOS LOS CHEK LIST DE MANERA GENERAL, ES DECIR; OBTENER TODO.
        [HttpGet("obtener_cheklist_autonomos")] // metodo get para llenar el combo// 
        public IActionResult obtener_cheklistAutonomos() // 
        {
            IActionResult actionResult = null;
            List<AnonymousChekListGeneral> lista = new List<AnonymousChekListGeneral>();
            try
            {
                var consulta = _Basededatos.CLEA.Include(x => x.EquipoAutonomo.Cliente).ToList();
                foreach (var cons in consulta)
                {
                    AnonymousChekListGeneral tipoCLG = new AnonymousChekListGeneral(); // 
                    tipoCLG.Id = cons.IdChecklistEA;
                    tipoCLG.Cliente = cons.EquipoAutonomo.Cliente.Nombre;
                    tipoCLG.FechaChekList = cons.FechaHoraCaptura;

                    lista.Add(tipoCLG); // 
                }
                actionResult = Ok(lista.OrderByDescending(x => x.Id));
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }

        [HttpGet("obtener_cheklist_autonomos/{id_cliente}")] // metodo get para llenar el combo// 2do obtenemos por ID CLIENTE
        public IActionResult obtener_cheklistatonomosporcliente(int id_cliente) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            List<AnonymousChekListGeneral> lista = new List<AnonymousChekListGeneral>();
            try
            {
                var consulta = _Basededatos.CLEA.Include(x => x.EquipoAutonomo.Cliente).Where(x => x.EquipoAutonomo.IdCliente == id_cliente).ToList();
                foreach (var cons in consulta)
                {
                    AnonymousChekListGeneral tipoCLG = new AnonymousChekListGeneral(); // SE HACE INSTANCIA DEL OBJETO CLG , PARA QUE SE DEVUELVA
                    tipoCLG.Id = cons.IdChecklistEA;
                    tipoCLG.Cliente = cons.EquipoAutonomo.Cliente.Nombre;
                    tipoCLG.FechaChekList = cons.FechaHoraCaptura;

                    lista.Add(tipoCLG); // 
                }
                actionResult = Ok(lista.OrderByDescending(x => x.Id));
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }
        // ESTE METODO ES PARA REGRESAR EL OBJETO DEL CHEK LIST QUE CAPTURARON
        [HttpGet("obtener_cheklist_autonomo/{id_cheklist}")] // metodo get para llenar el combo// 2do obtenemos POR EL CHEK LIST QUE SE HIZO, O EL MISMO CHEK LIST
        public IActionResult obtener_cheklistAutonomo(int id_cheklist) // se espesifica que se quieren los extintores de un cliente espesifico
        {
            IActionResult actionResult = null;
            AnonymousChekEA checkEA = new AnonymousChekEA();
            try
            {// SE OBTIENE EL CHEK LIST QUE SE SOLICITO DE ACUERDO A SU ID Y SE ASIGNAN TODOS LOS PARAMETROS AL OBJETO A DEVOLVER
                var consulta = _Basededatos.CLEA.Include(x => x.EquipoAutonomo.Cliente).Where(x => x.IdChecklistEA == id_cheklist).FirstOrDefault();
                checkEA.IdAutonomo = consulta.IdAutonomo; //Asignacion
                checkEA.Presion = consulta.Presion;
                checkEA.Observaciones = consulta.Observaciones;
                checkEA.FechaHoraCaptura = consulta.FechaHoraCaptura;
                checkEA.IdChecklistEA = consulta.IdChecklistEA;
                // checkEA.FechaServicio = consulta.FechaServicio;
                checkEA.IdUsuario = consulta.IdUsuario;
                checkEA.Obstrucciones = consulta.Obstrucciones;
                //checkEA.TipoDeRevision = consulta.TipoDeRevision;
                actionResult = Ok(checkEA);
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(new { resultado = ex.Message }); //es para devolver codigo de error y mensaje de error
            }
            return actionResult;
        }

    }
}
