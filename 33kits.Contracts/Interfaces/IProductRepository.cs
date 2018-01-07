using System;
using System.Collections.Generic;
using CommonContracts;
using _33kits.Contracts.Poco;
using _33kits.Contracts.ViewModels;

namespace _33kits.Contracts.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        IEnumerable<ProductNeedViewModel> GetNeedProducts(DateTime? beginDate, DateTime? endDate, Guid? idDish);
        IEnumerable<FileInfo> GetProductImages(Guid idProduct);
    }
}