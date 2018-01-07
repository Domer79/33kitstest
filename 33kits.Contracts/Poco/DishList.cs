using System;
using CommonContracts;

namespace _33kits.Contracts.Poco
{
    public class DishList
    {
        public Guid IdMenu { get; set; }
        public Guid IdDish { get; set; }
        public int DishCount { get; set; }
    }
}