using PizzaHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHouse.Services
{
    public interface IPizzaService
    {
        Menu GetMenu();
    }
}
