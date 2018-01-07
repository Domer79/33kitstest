using System;
using System.Collections.Generic;
using System.Linq;
using CommonContracts;
using _33kits.Contracts.Collections;
using _33kits.Contracts.Interfaces;
using _33kits.Contracts.Poco;

namespace _33Kits.DataRepository
{
    public class DishRepository: IDishRepository
    {
        private readonly ICommonDb _commonDb;
        private readonly IImagesRepository _imageRepo;

        public DishRepository(ICommonDb commonDb, IImagesRepository imageRepo)
        {
            _commonDb = commonDb;
            _imageRepo = imageRepo;
        }

        public Dish Get(Guid id)
        {
            return _commonDb.Query<Dish>($"select * from Dish where id = @id", new {id}).First();
        }

        public IEnumerable<Dish> Get()
        {
            return _commonDb.Query<Dish>($"select * from Dish");
        }

        public IEnumerable<Dish> GetDishesExcept(Guid idMenu)
        {
            const string query = "select * from Dish where id in (select id from Dish where id not in (select idDish from MenuDish where idMenu = @idMenu))";
            return _commonDb.Query<Dish>(query, new {idMenu});
        }

        public IEntityCollectionInfo<Dish> GetEntityCollectionInfo(int pageNumber, int pageSize)
        {
            var collectionInfo = new DishCollectionInfo();
            collectionInfo.Entities = _commonDb.Query<Dish>(
                $"select * from Dish order by d.Id offset {pageNumber * pageSize - pageSize} rows fetch next {pageSize} rows.only");

            _commonDb.GetPageCount(pageSize, "select count(1) from Dish", collectionInfo);

            return collectionInfo;
        }

        public Guid Create(Dish entity)
        {
            _commonDb.ExecuteNonQuery(
                "insert into Dish(id, description, name) values(@id, @description, @name)", entity);
            return entity.Id;
        }

        public void Update(Dish entity)
        {
            _commonDb.ExecuteNonQuery(
                "update Dish set description = @description, name = @name where id = @id", entity);
        }

        public void Remove(Guid id)
        {
            _commonDb.ExecuteNonQuery("delete from Dish where id = @id", new {id});
        }

        public IEnumerable<FileInfo> GetDishImages(Guid idDish)
        {
            var ids = _commonDb.Query<Guid>("select idImage from DishImages where idDish = @idDish", new {idDish}).ToArray();
            if (ids.Length == 0)
                return new FileInfo[] { };

            return _imageRepo.GetImagesInfo(ids);
        }
    }
}