using System;
using System.Collections.Generic;

namespace CheeseMVC.ViewModels
{
    public class DeletCheeseViewModel
    {
        public List<Cheese> Cheeses { get; set; }

        public List<int> SelectedCheeses { get; set;  }
    }
}
