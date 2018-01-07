using System;
using System.Collections.Generic;
using CommonContracts;

namespace _33kits.Contracts.Poco
{
    public class MenuOnDay: Entity
    {
        public DateTime Date { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}