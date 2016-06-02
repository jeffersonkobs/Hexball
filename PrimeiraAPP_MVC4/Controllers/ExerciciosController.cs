using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeiraAPP_MVC4.Models;

namespace PrimeiraAPP_MVC4.Controllers
{
    public class ExerciciosController : Controller
    {
        private static Exercicios _exercicios = new Exercicios();

        // GET: Exercicios
        public ActionResult ExerciciosIndex(TreinamentosModels _treinamentos)
        {
            return View(_exercicios.listaExercicios);
        }
    }
}