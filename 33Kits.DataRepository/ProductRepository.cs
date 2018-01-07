using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonContracts;
using _33kits.Contracts.Collections;
using _33kits.Contracts.Interfaces;
using _33kits.Contracts.Poco;
using _33kits.Contracts.ViewModels;

namespace _33Kits.DataRepository
{
    public class ProductRepository: IProductRepository
    {
        private readonly ICommonDb _commonDb;
        private readonly IImagesRepository _imageRepo;

        public ProductRepository(ICommonDb commonDb, IImagesRepository imageRepo)
        {
            _commonDb = commonDb;
            _imageRepo = imageRepo;
        }

        public Product Get(Guid id)
        {
            return _commonDb.Query<Product>("select * from products where id = @id", new {id}).First();
        }

        public IEnumerable<Product> Get()
        {
            return _commonDb.Query<Product>("select * from products");
        }

        public IEntityCollectionInfo<Product> GetEntityCollectionInfo(int pageNumber, int pageSize)
        {
            var collectionInfo = new ProductCollectionInfo();
            collectionInfo.Entities = _commonDb.Query<Product>($"select * from products order by id offset {pageNumber * pageSize - pageSize} rows fetch next {pageSize} rows only");
            _commonDb.GetPageCount(pageSize, "select count(1) from products", collectionInfo);

            return collectionInfo;
        }

        public Guid Create(Product entity)
        {
            _commonDb.ExecuteNonQuery("insert into products(id, description, name, price) values(@id, @description, @name, @price)", entity);
            return entity.Id;
        }

        public void Update(Product entity)
        {
            _commonDb.ExecuteNonQuery("update products set description = @description, name = @name, price = @price where id = @id", entity);
        }

        public void Remove(Guid id)
        {
            _commonDb.ExecuteNonQuery("drop from products where id = @id", new {id});
        }

        public IEnumerable<ProductNeedViewModel> GetNeedProducts(DateTime? beginDate, DateTime? endDate, Guid? idDish)
        {
            var baseQuery = @"select
	dp.idProduct id,
	dp.productName name,
	sum(dp.productNeedCount) needCount,
	Format(sum(dp.price), 'C', 'ru-RU') needSum
from 
	MenuWithDish md inner join DishWithProducts dp 
on 
	md.idDish = dp.idDish
{0}
group by
	dp.idProduct,
	dp.productName";

            if (beginDate.HasValue)
            {
                if (!endDate.HasValue)
                    endDate = new DateTime(beginDate.Value.Add(TimeSpan.FromHours(24)).Ticks);
            }
            else
            {
                if (endDate.HasValue)
                    beginDate = new DateTime(endDate.Value.Subtract(TimeSpan.FromHours(24)).Ticks); ;
            }

            if (!beginDate.HasValue && !idDish.HasValue)
                throw new ArgumentException($"{nameof(beginDate)} and {nameof(endDate)} and {nameof(idDish)}");

            var dateFilter = beginDate.HasValue
                ? $"where md.menuDate between '{beginDate:yyyy-MM-dd}' and '{endDate.Value:yyyy-MM-dd}'" : "";
            var dishFilter = beginDate.HasValue ? $"and md.idDish = '{idDish.Value}'" : $"where md.idDish = '{idDish.Value}'";

            var commonFilter = dateFilter + " " + dishFilter;

            baseQuery = string.Format(baseQuery, commonFilter);
            return _commonDb.Query<ProductNeedViewModel>(baseQuery);
        }

        public IEnumerable<FileInfo> GetProductImages(Guid idProduct)
        {
            var ids = _commonDb.Query<Guid>("select idImage from ProductImages where idProduct = @idProduct", new { idProduct }).ToArray();
            if (ids.Length == 0)
                return new FileInfo[] { };

            return _imageRepo.GetImagesInfo(ids);

        }
    }
}
