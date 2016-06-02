using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeiraAPP_MVC4.Models;

namespace PrimeiraAPP_MVC4.Controllers
{
    public class TreinamentosController : Controller
    {
        private static Treinamentos _treinamentos = new Treinamentos();
        // GET: Treinamentos
        public ActionResult Index()
        {
            return View(_treinamentos.listaTreinamentos);
        }
        public ActionResult DetalhesTreinamentos(int id)
        {
            View(_treinamentos.GetTreinamentos(id));
            return View();
        }
    }
}