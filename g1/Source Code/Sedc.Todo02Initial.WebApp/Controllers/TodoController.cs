using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sedc.Todo02Initial.WebApp.Data;

namespace Sedc.Todo02Initial.WebApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly Storage _storage;

        public TodoController(Storage storage)
        {
            _storage = storage;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}