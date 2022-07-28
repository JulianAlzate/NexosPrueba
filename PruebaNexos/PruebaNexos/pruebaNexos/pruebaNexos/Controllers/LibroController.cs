using BLL.Comunes;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using pruebaNexos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaNexos.Controllers
{
    public class LibroController : Controller
    {
        private readonly IBusinessLogic<LibroDTO> _libroBLL;
        private readonly IBusinessLogic<AutorDTO> _autorBLL;

        public LibroController(IBusinessLogic<LibroDTO> libroBLL, IBusinessLogic<AutorDTO> autorBLLbroBLL)
        {
            _libroBLL = libroBLL;
            _autorBLL = autorBLLbroBLL;
        }
        public IActionResult Index()
        {
            try
            {
                IList<LibroDTO> libro = _libroBLL.ListAll();
                return View(libro);
            }
            catch (Exception ex)
            {
                string Mensaje = "Ocurrio un error listando el libro. Revise el log de errores.";
                TempData["UserMessage"] = MensajeUsuario.GetMessage(enums.Accion.Consultar, enums.TipoDeMensaje.Error, Mensaje, ex);
                return View(new List<LibroDTO>());
            }
        }
        public IActionResult Create()
        {

            ViewBag.Autor = new SelectList(_autorBLL.ListAll(), "IdAutor", "NombreAutor");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(include: "idLibro,Titulo,Genero,NumeroPaginas,Anio,IdAutor")] LibroDTO libro)
        {
            try
            {
                ViewBag.Autor = new SelectList(_autorBLL.ListAll(), "IdAutor", "NombreAutor", libro.IdAutor);

                if (ModelState.IsValid)
                {
                    string Mensaje = _libroBLL.Crear(libro);
                    if (string.IsNullOrEmpty(Mensaje))
                    {
                        Mensaje = "Se ha registrado un nuevo libro";
                        TempData["UserMessage"] = MensajeUsuario.GetMessage(enums.Accion.Adicionar, enums.TipoDeMensaje.Exito, "Registro creado: " + Mensaje);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["UserMessage"] = MensajeUsuario.GetMessage(enums.Accion.Adicionar, enums.TipoDeMensaje.Advertencia, Mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                string Mensaje = "Ocurrio un error en la creación del libro. Revise el log de errores.";
                TempData["UserMessage"] = MensajeUsuario.GetMessage(enums.Accion.Adicionar, enums.TipoDeMensaje.Error, Mensaje, ex);
            }

            return View();
        }

    }
}
