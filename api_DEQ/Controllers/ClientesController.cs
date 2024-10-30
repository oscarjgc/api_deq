﻿using api_DEQ.Models;
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
                actionResult = BadRequest(ex.Message);
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
                actionResult = Ok("Guardar");
            }
            catch (Exception ex)
            {
                actionResult= BadRequest(ex.Message);
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
                actionResult = Ok("Modificado");
            }
            catch (Exception ex)
            { 
                actionResult = BadRequest(ex.Message);
            }

            return actionResult;
        }
        [HttpDelete("{idcliente}")]
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
                actionResult = Ok("Eliminado");
            }
            catch (Exception ex)
            {
                actionResult = BadRequest(ex.Message);
            }

            return actionResult;
        }
    }
}