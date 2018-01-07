using System;
using System.Collections.Generic;
using System.Linq;
using CommonContracts;
using _33kits.Contracts.Collections;
using _33kits.Contracts.Interfaces;
using _33kits.Contracts.Poco;

namespace _33Kits.DataRepository
{
    public class MenuOnDayRepository: IMenuOnDayRepository
    {
        private readonly ICommonDb _commonDb;

        public MenuOnDayRepository(ICommonDb commonDb)
        {
            _commonDb = commonDb;
        }

        public MenuOnDay Get(Guid id)
        {
            return _commonDb.Query<MenuOnDay>($"select * from MenuOnDay where id = @id", new { id }).First();
        }

        public IEnumerable<MenuOnDay> Get()
        {
            return _commonDb.Query<MenuOnDay>($"select * from MenuOnDay order by date desc");
        }

        public IEntityCollectionInfo<MenuOnDay> GetEntityCollectionInfo(int pageNumber, int pageSize)
        {
            var collectionInfo = new MenuOnDayCollectionInfo();
            collectionInfo.Entities = _commonDb.Query<MenuOnDay>($"select * from MenuOnDay order by date desc offset {pageNumber * pageSize - pageSize} rows fetch next {pageSize} rows only");
            _commonDb.GetPageCount(pageSize, "select count(1) from MenuOnDay", collectionInfo);

            return collectionInfo;
        }

        public Guid Create(MenuOnDay entity)
        {
            _commonDb.ExecuteNonQuery("insert into MenuOnDay(id, description, date) values(@id, @description, @date)",
                entity);

            return entity.Id;
        }

        public void Update(MenuOnDay entity)
        {
            _commonDb.ExecuteNonQuery("update MenuOnDay set description = @description, date = @date where id = @id",
                entity);
        }

        public void Remove(Guid id)
        {
            _commonDb.ExecuteNonQuery("delete from MenuOnDay where id = @id", new {id});
        }
    }
}