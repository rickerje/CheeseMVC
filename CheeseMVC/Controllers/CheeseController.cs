using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();
            return View(cheeses);
        }


        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if(ModelState.IsValid) 
            {
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                                                    
                };

                CheeseData.Add(newCheese);

                return Redirect("/Cheese");
            }
            return View(addCheeseViewModel);

        }

        public IActionResult Remove()
        {
            DeleteCheesesViewModel model = new DeleteCheesesViewModel();

            return View(model);
        }

        [HttpPost]
        [Route("/Cheese/Remove")]
        public IActionResult Remove(DeleteCheesesViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.Delete();

            return Redirect("Index");
        }

/*        public IActionResult Edit(int cheeseId)
        {
            
            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel();

            addEditCheeseViewModel.CheeseId = cheeseId;
            addEditCheeseViewModel.Name = CheeseData.GetById(addEditCheeseViewModel.CheeseId).Name;
            addEditCheeseViewModel.Description = CheeseData.GetById(addEditCheeseViewModel.CheeseId).Description;
            addEditCheeseViewModel.Type = CheeseData.GetById(addEditCheeseViewModel.CheeseId).Type;

            return View(addEditCheeseViewModel);
        }

        [HttpPost]
        [Route("/Cheese/Edit")]
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            //if(ModelState.IsValid)
            //{
                CheeseData.GetById(addEditCheeseViewModel.CheeseId).Name = addEditCheeseViewModel.Name;
                CheeseData.GetById(addEditCheeseViewModel.CheeseId).Description = addEditCheeseViewModel.Description;
                CheeseData.GetById(addEditCheeseViewModel.CheeseId).Type = addEditCheeseViewModel.Type;

                return Redirect("/");
            //}
            //return View(addEditCheeseViewModel);
        }
        */
    }                                   

}
