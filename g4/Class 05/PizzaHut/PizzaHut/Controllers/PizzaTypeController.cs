using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHut.Models.IRepositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaHut.Controllers
{
    public class PizzaTypeController : Controller
    {
        private IPizzaTypeRepository pizzaTypeRepository;
        public PizzaTypeController(IPizzaTypeRepository typeRepository)
        {
            pizzaTypeRepository = typeRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = pizzaTypeRepository.GetAll();
            return View(model);
        }
    }
}
