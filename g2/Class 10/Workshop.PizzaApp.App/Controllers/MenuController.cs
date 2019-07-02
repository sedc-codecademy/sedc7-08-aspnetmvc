using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Workshop.PizzaApp.Model;
using Workshop.PizzaApp.Service.Interfaces;

namespace Workshop.PizzaApp.App.Controllers
{
    public class MenuController : Controller
    {
        private IPizzaManagementService _pizzaManagementService;
        private ISizeManagementService _sizeManagementService;
        private IPizzaSizeManagementService _pizzaSizeManagementService;
        public MenuController(IPizzaManagementService pizzaManagementService, ISizeManagementService sizeManagementService, IPizzaSizeManagementService pizzaSizeManagementService)
        {
            _pizzaManagementService = pizzaManagementService;
            _sizeManagementService = sizeManagementService;
            _pizzaSizeManagementService = pizzaSizeManagementService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Pizza Management

        public IActionResult PizzaList()
        {
            var pizzas = _pizzaManagementService.GetAllPizzas();

            return View(pizzas);
        }

        public IActionResult AddPizza()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPizza(PizzaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _pizzaManagementService.AddPizza(model);
            return Redirect("/Menu/PizzaList");
        }

        public IActionResult EditPizza(int id)
        {
            return View(_pizzaManagementService.GetPizzaById(id));
        }

        [HttpPost]
        public IActionResult EditPizza(PizzaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _pizzaManagementService.UpdatePizza(model);

            return Redirect("/Menu/PizzaList");
        }

        public IActionResult DeletePizza(int id)
        {
            _pizzaManagementService.DeletePizza(id);
            return Redirect("/Menu/PizzaList");
        }
        #endregion Pizza Management

        #region Size Management

        public IActionResult SizeList()
        {
            var sizes = _sizeManagementService.GetAllSizes();

            return View(sizes);
        }

        public IActionResult AddSize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSize(SizeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _sizeManagementService.AddSize(model);
            return Redirect("/Menu/SizeList");
        }

        public IActionResult EditSize(int id)
        {
            return View(_sizeManagementService.GetSizeById(id));
        }

        [HttpPost]
        public IActionResult EditSize(SizeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _sizeManagementService.UpdateSize(model);

            return Redirect("/Menu/SizeList");
        }

        public IActionResult DeleteSize(int id)
        {
            _sizeManagementService.DeleteSize(id);
            return Redirect("/Menu/SizeList");
        }
        #endregion Size Management

        #region Pizza Price Management
        public IActionResult PriceList()
        {
            var priceList = _pizzaSizeManagementService.GetAllPizzaSizes();
            return View(priceList);
        }

        public IActionResult AddPizzaPrice()
        {
            var pizzas = _pizzaManagementService.GetAllPizzas();

            var pizzaItems = pizzas.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.PizzaId.ToString()
            });

            var sizes = _sizeManagementService.GetAllSizes();
            var sizeItems = sizes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.SizeId.ToString()
            });

            var model = new AddPriceViewModel
            {
                Pizzas = new SelectList(pizzaItems, "Value", "Text"),
                Sizes = new SelectList(sizeItems, "Value", "Text")
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddPizzaPrice(AddPriceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _pizzaSizeManagementService.AddPizzaSize(model.PizzaSize);
            return Redirect("/Menu/PriceList");
        }

        public IActionResult EditPizzaPrice(int id)
        {
            var item = _pizzaSizeManagementService.GetPizzaSizeById(id);

            var pizzas = _pizzaManagementService.GetAllPizzas();
            var pizzaItems = pizzas.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.PizzaId.ToString()
            });

            var sizes = _sizeManagementService.GetAllSizes();
            var sizeItems = sizes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.SizeId.ToString()
            });

            var model = new AddPriceViewModel
            {
                PizzaSize = item,
                Pizzas = new SelectList(pizzaItems, "Value", "Text"),
                Sizes = new SelectList(sizeItems, "Value", "Text")
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditPizzaPrice(AddPriceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var item = _pizzaSizeManagementService.GetPizzaSizeById(model.PizzaSize.PizzaSizeId ?? 0);

                var pizzas = _pizzaManagementService.GetAllPizzas();
                var pizzaItems = pizzas.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.PizzaId.ToString()
                });

                var sizes = _sizeManagementService.GetAllSizes();
                var sizeItems = sizes.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.SizeId.ToString()
                });

                var modelToResend = new AddPriceViewModel
                {
                    PizzaSize = item,
                    Pizzas = new SelectList(pizzaItems, "Value", "Text"),
                    Sizes = new SelectList(sizeItems, "Value", "Text")
                };
                return View(modelToResend);
            }

            _pizzaSizeManagementService.UpdatePizzaSizePrice(model.PizzaSize);

            return Redirect("/Menu/PriceList");
        }

        #endregion Pizza Price Management
    }
}