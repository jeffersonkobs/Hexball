using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimeiraAPP_MVC4.Models;
using System.IO.Ports;

namespace PrimeiraAPP_MVC4.Controllers
{
    public class ExerciciosItemController : Controller
    {
        private static ExerciciosItem _exerciciosItem = new ExerciciosItem();
        // GET: ExerciciosItem
        public ActionResult ExerciciosItemIndex(ExerciciosModels _exercicios)
        {
            return View(_exerciciosItem.listaExerciciosItem);
        }

        /*public ActionResult Execute()
        {

        }*/
    }
}