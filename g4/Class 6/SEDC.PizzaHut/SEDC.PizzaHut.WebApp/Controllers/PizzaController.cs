using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaHut.BusinessLayer.Interfaces;
using SEDC.PizzaHut.BusinessLayer.ViewModels;
using SEDC.PizzaHut.WebApp.Models;

namespace SEDC.PizzaHut.WebApp.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            var pizzas = _pizzaService.GetAll();
            return View(pizzas);
        }

        public IActionResult Details(int id)
        {
            var result = _pizzaService.GetById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePizzaViewModel model)
        {
            if (ModelState.IsValid)
            {
                int count = _pizzaService.AddPizza(model);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _pizzaService.GetById(id);
            if (result == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel
                {
                    RequestId = id.ToString()
                };
                return View("Error", errorViewModel);
            }

            EditPizzaViewModel editPizzaViewModel = new EditPizzaViewModel
            {
                Id = result.Id,
                Name = result.Name,
                PizzaTypeId = result.PizzaType.Id,
                Price = result.Price,
                Size = result.Size
            };
            return View(editPizzaViewModel);

        }

        [HttpPost]
        public IActionResult Edit(EditPizzaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modified = _pizzaService.EditPizza(model);
                if(modified != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _pizzaService.GetById(id);
            EditPizzaViewModel editPizzaViewModel = new EditPizzaViewModel
            {
                Id = model.Id,
                Name = model.Name,
                PizzaTypeId = model.PizzaType.Id,
                Price = model.Price,
                Size = model.Size
            };
            return View(editPizzaViewModel);
        }

        [HttpPost]
        public IActionResult Delete(PizzaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _pizzaService.RemovePizza(model.Id);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}