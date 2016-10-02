﻿using MVC_Voorbeeld3.Services;
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
    }
}