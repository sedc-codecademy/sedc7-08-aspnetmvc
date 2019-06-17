using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sedc.G2.PizzApp.Models;

namespace Sedc.G2.PizzApp.Controllers
{
    public class MenuController : Controller
    {
        #region Old code before domain model was created
        //static list that is used to simulate database, with predefined data
        private static List<PizzaModel> pizzaList = new List<PizzaModel>
        {
            new PizzaModel
            {
                Id = 1,
                Name = "Capricioza",
                Description = "Some description",
                Size = "small",
                Price = 140
            },
            new PizzaModel
            {
                Id = 2,
                Name = "Capricioza",
                Description = "Some description",
                Size = "medium",
                Price = 200
            },
            new PizzaModel
            {
                Id = 3,
                Name = "Capricioza",
                Description = "Some description",
                Size = "large",
                Price = 240
            },
            new PizzaModel
            {
                Id = 4,
                Name = "Capricioza",
                Description = "Some description",
                Size = "family",
                Price = 350
            }
        };

        //public IActionResult Index()
        //{
        //    //sending the pizza list to the Index view
        //    return View(pizzaList);
        //}

        public IActionResult PizzaDetails(int id)
        {
            //get the requested pizza from the pizza list using linq
            var pizza = pizzaList.FirstOrDefault(x => x.Id == id);
            //send the found pizza to PizzaDetails view
            return View(pizza);
        }

        public IActionResult Edit(int id)
        {
            //get the requested pizza from the pizza list using linq
            var pizza = pizzaList.FirstOrDefault(x => x.Id == id);
            //send the found pizza to Edit view
            return View(pizza);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PizzaModel model)
        {
            //on save check if the model that is sent for saving is valid
            //if not then return to Add view and display the validation messages
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Add the model to pizzaList
            pizzaList.Add(model);

            //redirect to Menu Index view and pass the updated pizzaList
            //this should display all pizzas including the new added one
            return View("Index", pizzaList);
        }

        [HttpPost]
        //Added custom routing on save on pizza edit view
        //Also added aditional routing in Startup.cs
        [Route("UpdatePizza")]
        public IActionResult SaveChanges(PizzaModel model)
        {
            //on save check if the model that is sent for saving is valid
            //if not then return to Edit view and display the validation messages
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            //find the index of the view that shoud be updated
            var index = pizzaList.FindIndex(x => x.Id == model.Id);
            //update the found pizza model with the new updated model
            pizzaList[index] = model;
            //redirect to Menu Index view and pass the updated pizzaList
            //this should display all pizzas
            return View("Index", pizzaList);
        }

        public IActionResult Delete(int id)
        {
            var pizza = pizzaList.FirstOrDefault(x => x.Id == id);
            pizzaList.Remove(pizza);
            return View("Index", pizzaList);
        }
        #endregion

        public static List<Model.PizzaModel> pizzas = new List<Model.PizzaModel> {
            new Model.PizzaModel
            {
                Id = 1,
                Name = "Capriciosa",
                Description = "Ham, Cheese, Mushrooms"
            }
        };
        public static List<Model.SizeModel> sizes = new List<Model.SizeModel> {
            new Model.SizeModel
            {
                Id = 1,
                Name = "Small",
                Dimension = 20
            }
        };
        public static List<Model.PizzaSizeModel> pizzaPrices = new List<Model.PizzaSizeModel>();
        
        #region Pizza 
        public IActionResult PizzaList()
        {
            return View(pizzas);
        }

        public IActionResult EditPizza(int id)
        {
            var pizza = pizzas.FirstOrDefault(x => x.Id == id);
            return View(pizza);
        }

        [HttpPost]
        public IActionResult EditPizza(Model.PizzaModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var index = pizzas.FindIndex(x => x.Id == model.Id);
            pizzas[index] = model;
            pizzas.Add(model);
            return View("PizzaList", pizzas);
        }

        public IActionResult AddPizza()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPizza(Model.PizzaModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            pizzas.Add(model);
            return Redirect("/Menu/PizzaList");
        }

        public IActionResult DeletePizza(int id)
        {
            var pizza = pizzas.FirstOrDefault(x => x.Id == id);
            pizzas.Remove(pizza);
            return Redirect("/Menu/PizzaList");
        }
        #endregion

        #region Size 
        public IActionResult SizeList()
        {
            return View(sizes);
        }

        public IActionResult EditSize(int id)
        {
            var size = sizes.FirstOrDefault(x => x.Id == id);
            return View(size);
        }

        [HttpPost]
        public IActionResult EditSize(Model.SizeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var index = sizes.FindIndex(x => x.Id == model.Id);
            sizes[index] = model;
            sizes.Add(model);
            return View("SizeLIst", sizes);
        }

        public IActionResult AddSize()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSize(Model.SizeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            sizes.Add(model);
            return Redirect("/Menu/SizeList");
        }

        public IActionResult DeleteSize(int id)
        {
            var size = sizes.FirstOrDefault(x => x.Id == id);
            sizes.Remove(size);
            return Redirect("/Menu/SizeList");
        }
        #endregion

        #region Pizza Price
        public IActionResult Index()
        {
            var menuList = new PizzaPriceListViewModel
            {
                PizzaPrices = pizzaPrices,
                Pizzas = pizzas,
                Sizes = sizes
            };

            return View(menuList);
        }

        public IActionResult EditPizzaPrice(int id)
        {
            var price = pizzaPrices.FirstOrDefault(x => x.Id == id);
            
            var pizzaItems = pizzas.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var sizeItems = sizes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var pizzaPriceView = new PizzaPriceViewModel
            {
                Id = price.Id,
                PizzaId = price.PizzaId,
                SizeId = price.SizeId,
                Price = price.Price,
                Pizzas = new SelectList(pizzaItems, "Value", "Text"),
                Sizes = new SelectList(sizeItems, "Value", "Text")
            };

            return View(pizzaPriceView);
        }

        [HttpPost]
        public IActionResult EditPizzaPrice(PizzaPriceViewModel model)
        {
            var price = pizzaPrices.FirstOrDefault(x => x.Id == model.Id);
            if (price != null)
            {
                price.Price = model.Price;
            }

            var index = pizzaPrices.FindIndex(x => x.Id == model.Id);
            pizzaPrices[index] = price;
            return Redirect("/Menu/Index");
        }

        public IActionResult AddPizzaPrice()
        {
            var pizzaItems = pizzas.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var sizeItems = sizes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var addModel = new PizzaPriceViewModel
            {
                Pizzas = new SelectList(pizzaItems, "Value", "Text"),
                Sizes = new SelectList(sizeItems, "Value", "Text")
            };
            return View(addModel);
        }

        [HttpPost]
        public IActionResult AddPizzaPrice(PizzaPriceViewModel model)
        {
            pizzaPrices.Add(new Model.PizzaSizeModel
            {
                Id = model.Id,
                PizzaId = model.PizzaId,
                SizeId = model.SizeId,
                Price = model.Price
            });
            return Redirect("/Menu/Index");
        }
        #endregion
    }
}