using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeiraAPP_MVC4.Models;

namespace PrimeiraAPP_MVC4.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        private static Usuario _usuarios = new Usuario();

        public ActionResult Index()
        {
            return View(_usuarios.listaUsuarios);
        }

        public ActionResult AdicionaUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaUsuario(UsuarioModel _usuarioModel)
        {
            _usuarios.CriaUsuario(_usuarioModel);
            return View();
        }

        public ActionResult AlteraUsuario(int id)
        {
            View(_usuarios.GetUsuario(id));
            return View();
        }

        [HttpPost]
        public ActionResult AlteraUsuario(UsuarioModel _usuarioModel)
        {
            _usuarios.AlteraUsuario(_usuarioModel);
            return Index();
        }

        public ViewResult ExcluiUsuario(int id)
        {
            return View(_usuarios.GetUsuario(id));

        }

        [HttpPost]
        public ActionResult ExcluiUsuario(UsuarioModel _usuarioModel)
        {
            _usuarios.DeletarUsuario(_usuarioModel);
            return RedirectToAction("Index");
        }
    }
}