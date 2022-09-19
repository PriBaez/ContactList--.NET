using Microsoft.AspNetCore.Mvc;
using MVC_Project.Data;
using MVC_Project.Models;

namespace MVC_Project.Controllers
{
    public class MantenedorController : Controller
        {
        ContactosDatos _ContactoDatos = new ContactosDatos();
        public IActionResult Listar()
        {
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Contactos oContacto)
        {

            if(!ModelState.IsValid){
                return View();
            }

            var respuesta = _ContactoDatos.Guardar(oContacto);

            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Editar(Contactos oContacto)
        {
            if(!ModelState.IsValid){
                return View();
            }

            var respuesta = _ContactoDatos.Editar(oContacto);

            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto)
        {
            var oContacto = _ContactoDatos.Obtener(IdContacto);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(Contactos oContacto)
        {
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    
    }
}

