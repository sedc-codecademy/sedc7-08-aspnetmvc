﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IPizzaIngredientRepository
    {
        void RemoveAllPizzaIngredients(int pizzaId);
    }
}
