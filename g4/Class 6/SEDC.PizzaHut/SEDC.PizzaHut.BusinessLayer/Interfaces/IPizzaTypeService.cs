using SEDC.PizzaHut.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaHut.BusinessLayer.Interfaces
{
    public interface IPizzaTypeService
    {
        List<PizzaType> GetAll();
    }
}
