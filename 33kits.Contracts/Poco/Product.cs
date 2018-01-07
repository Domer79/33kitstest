using System;
using CommonContracts;

namespace _33kits.Contracts.Poco
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
