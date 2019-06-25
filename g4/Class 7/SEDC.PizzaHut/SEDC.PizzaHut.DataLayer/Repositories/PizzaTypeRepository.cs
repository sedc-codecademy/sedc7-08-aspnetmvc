using SEDC.PizzaHut.DataLayer.Interfaces;
using SEDC.PizzaHut.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaHut.DataLayer.Repositories
{
    public class PizzaTypeRepository : BaseRepository<PizzaType>, IPizzaTypeRepository
    {
        public PizzaTypeRepository(PizzaHutContext context)
            : base(context)
        {
        }
    }
}
