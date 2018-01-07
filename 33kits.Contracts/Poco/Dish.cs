using System;
using System.Collections.Generic;
using CommonContracts;

namespace _33kits.Contracts.Poco
{
    /// <summary>
    /// Блюдо
    /// </summary>
    public class Dish: Entity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}