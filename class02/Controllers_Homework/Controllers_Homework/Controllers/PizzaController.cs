﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers_Homework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers_Homework.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            var pizzas = PizzaDb.Pizzas;
            return View(pizzas);
            
        }
    
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreatePizza(PizzaModel model)
        {
            PizzaModel pizza = new PizzaModel()
            {
                Name = model.Name,
                Size = model.Size,
                Id = PizzaDb.Pizzas.Count + 1
            };
            PizzaDb.Pizzas.Add(pizza);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            PizzaModel pizza = PizzaDb.Pizzas.SingleOrDefault(p => p.Id == id);
            return View(pizza);
        }

        //[HttpGet]     
        //public IActionResult DeletePizza(int id)
        //{
        //    PizzaModel models = PizzaDb.Pizzas.FirstOrDefault(p => p.Id == id);
        //    return View(models);
        //}


        //[HttpPost]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaDb.Pizzas.SingleOrDefault(x => x.Id == id);
            PizzaDb.Pizzas.Remove(pizza);
            return RedirectToAction("Index");
        }





   


    }
}
