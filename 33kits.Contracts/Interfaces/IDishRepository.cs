using System;
using System.Collections.Generic;
using CommonContracts;
using _33kits.Contracts.Poco;

namespace _33kits.Contracts.Interfaces
{
    public interface IDishRepository : IRepository<Dish>
    {
        IEnumerable<FileInfo> GetDishImages(Guid idDish);
        IEnumerable<Dish> GetDishesExcept(Guid idMenu);
    }
}