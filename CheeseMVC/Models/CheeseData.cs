﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        public static List<Cheese> cheeses = new List<Cheese>();

        // GetAll
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }
        // Add
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        // Remove
        public static void Remove(int id)
        {
            Cheese cheeseToRemove = GetById(id);
            cheeses.Remove(cheeseToRemove);
        }

        // GetById
        public static Cheese GetById(int id)
        {
            Cheese cheeseToEdit = cheeses.SingleOrDefault(chs => chs.CheeseId == id);
            return cheeseToEdit;
            //cheeses.Single(x => x.CheeseId == id);
        }

    }
}
