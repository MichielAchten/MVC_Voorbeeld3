using MVC_Voorbeeld3.Models;
using MVC_Voorbeeld3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Voorbeeld3.Controllers
{
    public class PersoonController : Controller
    {
        // GET: Persoon
        private PersoonService persoonService = new PersoonService();

        public ActionResult Index()
        {
            return View(persoonService.FindAll());
        }

        [HttpGet]
        public ActionResult VerwijderForm(int id)
        {
            return View(persoonService.FindById(id));
        }

        [HttpPost]
        public ActionResult Verwijderen(int id)
        {
            persoonService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Opslag()
        {
            OpslagForm opslagForm = new OpslagForm();
            opslagForm.Percentage = 10;
            return View(opslagForm);
        }

        [HttpPost]
        public ActionResult Opslag(OpslagForm opslagForm)
        {
            if (this.ModelState.IsValid)
            {
                persoonService.Opslag(opslagForm.VanWedde.Value,
                    opslagForm.TotWedde.Value,
                    opslagForm.Percentage);
                return RedirectToAction("Index");
            }
            else
            {
                return View(opslagForm);
            }

            //persoonService.Opslag(opslagForm.VanWedde.Value, opslagForm.TotWedde.Value, opslagForm.Percentage);
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult VanTotWedde()
        {
            var form = new VanTotWeddeForm();
            return View(form);
        }

        [HttpGet]
        public ActionResult VanTotWeddeResultaat(VanTotWeddeForm form)
        {
            if (this.ModelState.IsValid)
            {
                //form.Personen = persoonService.VanTotWedde(form.VanWedde.Value, form.TotWedde.Value);
                var lijst = persoonService.VanTotWedde(form.VanWedde.Value, form.TotWedde.Value);
                if (lijst.Count <= 3)
                {
                    form.Personen = lijst;
                }
                else
                {
                    this.ModelState.AddModelError("", "Te veel resultaten");
                }
            }
            return View("VanTotWedde", form);
        }

        [HttpGet]
        public ActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Geslacht = Geslacht.Vrouw;
            return View(persoon);
        }
    }
}