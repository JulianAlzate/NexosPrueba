using BLL.Comunes;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pruebaNexos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaNexos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorAPIController : ControllerBase
    {
        private readonly IBusinessLogic<AutorDTO> _autorBLL;

        public AutorAPIController(IBusinessLogic<AutorDTO> autorBLLbroBLL)
        {
            _autorBLL = autorBLLbroBLL;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Crear(AutorDTO autor)
        {
            try
            {
                string Mensaje = _autorBLL.Crear(autor);
                if (!Mensaje.Contains("Error"))
                {
                    return JsonConvert.SerializeObject(new { success = true, responseText = "Autor creado" });
                }
                else
                {
                    MensajeUsuario.GetMessage(enums.Accion.Adicionar, enums.TipoDeMensaje.Advertencia, Mensaje);
                    return JsonConvert.SerializeObject(new { success = false, responseText = Mensaje });
                }
            }
            catch (Exception ex)
            {
                string Mensaje = "Ocurrio un error al crear el autor " + autor.NombreAutor + ". Revise el log de errores.";
                MensajeUsuario.GetMessage(enums.Accion.Adicionar, enums.TipoDeMensaje.Error, Mensaje, ex);
                return JsonConvert.SerializeObject(new { success = false, responseText = Mensaje });
            }
        }
    }
}
