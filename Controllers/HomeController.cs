using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using crudelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace crudelicious.Controllers
{
    public class HomeController : Controller
    {
        private CrudeliciousContext db;

        public HomeController(CrudeliciousContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            
            List<Dish> allDishes = db.Dishes.OrderByDescending(dish => dish.CreatedAt).ToList();

            return View("Index", allDishes);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                db.Dishes.Add(newDish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View("New");
            }
        }

        [HttpGet("{dishId}")]
        public IActionResult Details(int dishId)
        {
            Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            if (selectedDish == null)
            {
                return RedirectToAction("Index");
            }

            return View("DishDetails", selectedDish);
        }

        [HttpPost("{dishId}/delete")]
        public IActionResult Delete(int dishId)
        {
            Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            if (selectedDish != null)
            {
                db.Dishes.Remove(selectedDish);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult Edit(int dishId)
        {
            Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

            return View("EditDish", selectedDish);
        }

        [HttpPost("update/{dishId}")]
        public IActionResult Update(Dish editedDish, int dishId)
        {
            if (ModelState.IsValid)
            {
                Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

                selectedDish.Name = editedDish.Name;
                selectedDish.Chef = editedDish.Chef;
                selectedDish.Tastiness = editedDish.Tastiness;
                selectedDish.Calories = editedDish.Calories;
                selectedDish.Description = editedDish.Description;
                selectedDish.UpdatedAt = DateTime.Now;
                
                db.Dishes.Update(selectedDish);
                db.SaveChanges();

                return RedirectToAction("Details", new { dishId = dishId });
            }

            return View("Edit", editedDish);
        }
    }
}
