using System;
using System.Collections.Generic;
using _33kits.Contracts.Poco;

namespace _33kits.Contracts.Interfaces
{
    public interface IDishListRepository
    {
        IEnumerable<DishList> Get();
        IEnumerable<DishList> Get(Guid idMenu);
        DishList Get(Guid idMenu, Guid idDish);
        void Create(DishList dishList);
        void Remove(Guid idMenu, Guid idDish);
        void CreateMany(DishList[] dishList);
    }
}