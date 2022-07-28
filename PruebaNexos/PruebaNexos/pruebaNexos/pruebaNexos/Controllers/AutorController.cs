using BLL.Comunes;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using pruebaNexos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaNexos.Controllers
{
    public class AutorController : Controller
    {

        private readonly IBusinessLogic<AutorDTO> _autorBLL;

        public AutorController(IBusinessLogic<AutorDTO> autorBLLbroBLL)
        {

            _autorBLL = autorBLLbroBLL;
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include: "idAutor,NombreAutor,FechaNacimiento,CiudadProcedencia,Correo")] AutorDTO autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string Mensaje = _autorBLL.Crear(autor);
                    if (!Mensaje.Contains("Error"))
                    {
                        Mensaje = "Se ha registrado un nuevo autor";
                        TempData["UserMessage"] = MensajeUsuario.GetMessage(enums.Accion.Adicionar, enums.TipoDeMensaje.Exito, "Registro creado: " + Mensaje);
                        return RedirectToAction("Index", "Libro");
                    }
                    else
                    {
                        TempData["UserMessage"] = MensajeUsuario.GetMessage(enums.Accion.Adicionar, enums.TipoDeMensaje.Advertencia, Mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                string Mensaje = "Ocurrio un error en la creación del autor. Revise el log de errores.";
                TempData["UserMessage"] = MensajeUsuario.GetMessage(enums.Accion.Adicionar, enums.TipoDeMensaje.Error, Mensaje, ex);
            }

            return View();
        }

    }
}
