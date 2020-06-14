using System;
using System.Collections;
using System.Collections.Generic;

namespace BudgeIt.Skateboard.Models
{
    public class Categories
    {
        public List<string> CategoryList { get; private set; }
        public Categories()
        {
            CategoryList = new List<string>
            {
                "Groceries",
                "Gas",
                "Restaurants",
                "Discretionary"
            };
        }
    }
}

