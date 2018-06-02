﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult Add(Cheese newCheese)
        {
            CheeseData.Add(newCheese);

            return Redirect("/Cheese");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult Remove(int[] cheeseIds)
        {
            ViewBag.cheeses = CheeseData.GetAll();

            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/");
        }

        public IActionResult Edit(int cheeseId)
        {
            ViewBag.CheeseToEdit = CheeseData.GetById(cheeseId);
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Edit")]
        public IActionResult Edit(int cheeseId, string name, string description)
        {
            CheeseData.GetById(cheeseId).Name = name;
            CheeseData.GetById(cheeseId).Description = description;

            return Redirect("/");
        }
    }                                   

}
