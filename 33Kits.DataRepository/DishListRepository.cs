using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonContracts;
using _33kits.Contracts.Interfaces;
using _33kits.Contracts.Poco;

namespace _33Kits.DataRepository
{
    public class DishListRepository: IDishListRepository
    {
        private readonly ICommonDb _commonDb;

        public DishListRepository(ICommonDb commonDb)
        {
            _commonDb = commonDb;
        }

        public IEnumerable<DishList> Get()
        {
            return _commonDb.Query<DishList>("select * from MenuDish");
        }

        public IEnumerable<DishList> Get(Guid idMenu)
        {
            return _commonDb.Query<DishList>("select * from MenuDish where idMenu = @idMenu", new {idMenu});
        }

        public DishList Get(Guid idMenu, Guid idDish)
        {
            return _commonDb.Query<DishList>("select * from MenuDish where idMenu = @idMenu and idDish = @idDish",
                new {idMenu, idDish}).First();
        }

        public void Create(DishList dishList)
        {
            _commonDb.ExecuteNonQuery("insert into MenuDish(idMenu, idDish, dishCount) values(@idMenu, @idDish, @dishCount)", dishList);
        }

        public void Remove(Guid idMenu, Guid idDish)
        {
            _commonDb.ExecuteNonQuery("delete from MenuDish where idMenu = @idMenu and idDish = @idDish", new {idMenu, idDish});
        }

        public void CreateMany(DishList[] dishList)
        {
            foreach (var menuDishLink in dishList)
            {
                Create(menuDishLink);
            }
        }
    }
}
