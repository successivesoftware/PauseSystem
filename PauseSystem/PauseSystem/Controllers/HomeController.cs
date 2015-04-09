﻿using PauseSystem.Models;
using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PauseSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        Repository<Levering> leveringRepository;

        public HomeController()
        {
            this.leveringRepository = unitOfWork.Repository<Levering>();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult GetLeverings()
        {
            var items = leveringRepository.Table.Take(10).ToList();
            return PartialView("_UCLiverings", items);




        }

        [Authorize(Roles=UserRoleTypes.Customer)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}